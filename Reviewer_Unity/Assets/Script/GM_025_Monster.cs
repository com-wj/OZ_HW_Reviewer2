using UnityEngine;
using UnityEngine.AI;

interface IDamageable
{
	void TakeDamage(float damage);
}

public class GM_025_Monster : MonoBehaviour, IDamageable
{
	// 몬스터 클래스
	// 몬스터 스탯(이동속도, 공격력), 사망 함수 > 몹 프리팹

	[SerializeField] private float _hp = 10f;
	[SerializeField] private float _moveSpeed = 10f;
	[SerializeField] private float _attackDamage = 1f;

	[SerializeField] private bool _printLog = false;

	[Header("NavMesh")]
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Transform _targetTr;
	[SerializeField] private float _updateInterval = 0.1f;

	private float _time = 0f;
	private GM_025_Manager _spawnManager;

	private void Awake()
	{
		if (_agent == null)
		{
			_agent = GetComponent<NavMeshAgent>();
		}
	}

	public void Init(GM_025_MobData data, Transform target = null, GM_025_Manager spawnManager = null)
	{
		_hp = data.Hp;
		_agent.speed = _moveSpeed = data.Speed;
		_attackDamage = data.AttackDamage;
		transform.localScale = Vector3.one * data.Size;
		_targetTr = target;
		_spawnManager = spawnManager;
	}

	void Update()
	{
		if (_targetTr == null) return;

		if (_time >= 0f)
		{
			_time -= Time.deltaTime;
			return;
		}
		_time = _updateInterval;

		_agent.SetDestination(_targetTr.position);
	}

	public void TakeDamage(float damage)
	{
		float decrease = damage > _hp ? _hp : damage;

		if (_printLog)
		{
			Debug.Log($"[{name}] {decrease} 피해 입음.");
		}
		_hp -= decrease;
		if (_hp <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		gameObject.SetActive(false);
		if (_spawnManager == null) return;
		_spawnManager.OnMobDead();
	}
}
