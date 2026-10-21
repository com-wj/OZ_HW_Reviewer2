using UnityEngine;

public class GM_029_PlayerShooter : MonoBehaviour
{
	enum EFireType
	{
		Type1,
		Type2,
		Type3,
	}

	[SerializeField] private GameObject _bulletPrefab;

	private const float FIRE_COOLDOWN = 0.5f;
	private float _cooldown;

	private const int MAX_CELLS = 5;
	[SerializeField] private int _remainCells = 5;
	[SerializeField] private float _reChargeCooldown;
	private const float _baseCharge = 2f;

	[SerializeField] private float[] _cellTemperatures = new float[MAX_CELLS];
	private float _cooldownSpeed = 20f;
	// ---
	[SerializeField] private int _projectileCount = 5;
	[SerializeField] private float _spreadAngle = 20f;
	[SerializeField] private EFireType _fireType = EFireType.Type1;

	private Quaternion _lastFireDegree = Quaternion.identity;
	private float _lastAttackTime;
	private const float INTERVAL_SPREAD_BULLET = 0.1f;

	private void Update()
	{
		if (_cooldown >= 0f)
		{
			_cooldown -= Time.deltaTime;
		}
		/*
		if (_remainCells < MAX_CELLS)
		{
			_reChargeCooldown -= Time.deltaTime;
			if (_reChargeCooldown <= 0f)
			{
				_remainCells++;
				_reChargeCooldown = GetReChargeCooldown();
			}
		}

		for (int i = 0; i < _cellTemperatures.Length; i++)
		{
			if (_cellTemperatures[i] > 0f)
			{
				_cellTemperatures[i] -= _cooldownSpeed * Time.deltaTime;
				_cellTemperatures[i] = Mathf.Max(0f, _cellTemperatures[i]);
			}
		}
		*/

		if (_lastAttackTime > 0f)
		{
			_lastAttackTime -= Time.deltaTime;
		}
	}

	public void Fire()
	{
		if (_bulletPrefab == null) return;

		/*
		if (_remainCells <= 0) return;
		if (_cooldown >= 0f) return;
		if (!CanFire(out int index)) return;

		_cooldown = FIRE_COOLDOWN;
		_remainCells--;
		_reChargeCooldown = GetReChargeCooldown();
		_cellTemperatures[index] = 100f;
		*/

		switch (_fireType)
		{
			case EFireType.Type1:
				FireType1();
				break;
			case EFireType.Type2:
				FireType2();
				break;
			case EFireType.Type3:
				FireType3();
				break;
		}

		//_cooldownSpeed = CheckOverHeating() ? 10f : 20f;
	}

	public void FireReset()
	{
		if (_fireType != EFireType.Type3) return;
		_lastFireDegree = Quaternion.identity;
	}

	private void FireType1()
	{
		if (_cooldown > 0f) return;
		_cooldown = 0.2f;

		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		float step = _spreadAngle / _projectileCount;

		for (int i = 0; i < _projectileCount; i++)
		{
			Vector3 angle = new Vector3(0, step * Mathf.Ceil(i / 2f), 0);
			if (i % 2 == 0)
			{
				angle *= -1;
			}
			Quaternion nrot = rot * Quaternion.Euler(angle);
			Instantiate(_bulletPrefab, pos, nrot);
			Debug.Log($"방향 : {nrot.eulerAngles}");
		}
	}

	private void FireType2()
	{
		if (_cooldown > 0f) return;
		_cooldown = 0.2f;

		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		float step = 360f / _projectileCount;

		for (int i = 0; i < _projectileCount; i++)
		{
			Vector3 angle = new Vector3(0, step, 0);
			rot *= Quaternion.Euler(angle);
			Instantiate(_bulletPrefab, pos, rot);
			Debug.Log($"방향 : {rot.eulerAngles}");
		}
	}

	private void FireType3()
	{
		if (_lastAttackTime > 0f) return;
		_lastAttackTime = INTERVAL_SPREAD_BULLET;

		Vector3 pos = transform.position;
		Quaternion rot = (_lastFireDegree == Quaternion.identity) ? transform.rotation : _lastFireDegree;
		float step = 360f / _projectileCount;

		Vector3 angle = new Vector3(0, step, 0);
		Debug.Log($"step : {step} / angle : {angle}");
		rot *= Quaternion.Euler(angle);
		Instantiate(_bulletPrefab, pos, rot);
		Debug.Log($"방향 : {rot.eulerAngles}");
		_lastFireDegree = rot;
	}

	private float GetReChargeCooldown()
	{
		return _baseCharge + (MAX_CELLS - _remainCells) * 0.5f; // ← 0.5f ?
	}

	private bool CanFire(out int index)
	{
		index = -1;

		for (int i = 0; i < _cellTemperatures.Length; i++)
		{
			if (_cellTemperatures[i] <= 0)
			{
				index = i;
				return true;
			}
		}
		return false;
	}

	private bool CheckOverHeating()
	{
		for (int i = 0; i < _cellTemperatures.Length; i++)
		{
			if (_cellTemperatures[i] < 50f)
				return false;
		}
		return true;
	}
}