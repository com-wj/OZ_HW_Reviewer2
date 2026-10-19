using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GM_026_Player : MonoBehaviour
{
	// 플레이어 조작(이동, 상호작용)
	[SerializeField] private float _moveSpeed = 75f;
	[SerializeField] private Rigidbody2D _rb;

	private Vector3 _targetPos;
	private bool _isMoving = false;

	private void Awake()
	{
		if (_rb == null)
		{
			_rb = GetComponent<Rigidbody2D>();
		}
	}


	void Update()
	{
		if (_isMoving)
		{
			MovePlayer();
		}
		else
		{
			PlayerInput();
		}
	}

	void MovePlayer()
	{
		Vector3 nextPos = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
		_rb.MovePosition(nextPos);

		if (Vector3.Distance(transform.position, _targetPos) < 0.0001f)
		{
			_rb.MovePosition(_targetPos);
			_isMoving = false;
		}
	}

	void PlayerInput()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h != 0 || v != 0) // 키가 입력되면
		{
			Vector3 dest = transform.position + new Vector3(h, v, 0);
			if (CanMoveTo(dest))
			{
				_targetPos = dest;
				Debug.Log($"[TargetPos] x : {_targetPos.x}, y : {_targetPos.y}");
				_isMoving = true;
			}
		}
	}

	bool CanMoveTo(Vector3 dest) // targetPos에 collision이 있는지 판단.
	{
		Collider2D hit = Physics2D.OverlapPoint(dest);
		return (hit == null);
	}
}