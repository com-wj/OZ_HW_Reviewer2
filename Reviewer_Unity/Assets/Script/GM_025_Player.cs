using UnityEngine;

public class GM_025_Player : MonoBehaviour
{
	// 플레이어 클래스
	// 플레이어 스탯, 조작 함수(이동, 공격)
	[SerializeField] private Transform _playerTr;
	[SerializeField] private float _moveSpeed = 10f;

	[SerializeField] private float _attackDamage = 1f;
	[SerializeField] private float _attackRange = 1f;
	[SerializeField] private LayerMask _monsterMask;
	
	private Collider[] _hitCollider = new Collider[3];

	private void Awake()
	{
		if (_playerTr == null)
		{
			_playerTr = transform;
		}
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			PlayerMove(Vector3.forward);
		}
		if (Input.GetKey(KeyCode.A))
		{
			PlayerMove(Vector3.left);
		}
		if (Input.GetKey(KeyCode.S))
		{
			PlayerMove(Vector3.back);
		}
		if (Input.GetKey(KeyCode.D))
		{
			PlayerMove(Vector3.right);
		}
		if (Input.GetKeyDown(KeyCode.Space)) // 공격
		{
			Attack();
		}
	}

	void PlayerMove(Vector3 dir)
	{
		_playerTr.Translate(dir * _moveSpeed * Time.deltaTime, Space.Self);
	}

	void Attack()
	{
		int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _attackRange, _hitCollider, _monsterMask);

		for (int i = 0; i < hitCount; i++)
		{
			if (_hitCollider[i].TryGetComponent<IDamageable>(out IDamageable enemy))
			{
				enemy.TakeDamage(_attackDamage);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, _attackRange);
	}
}
