using UnityEngine;

public class GM_028_PlayerShooter : MonoBehaviour
{
	[SerializeField] private GameObject _bulletPrefab;

	private const float FIRE_COOLDOWN = 0.5f;
	private float _cooldown;

	private const int MAX_CELLS = 5;
	[SerializeField] private int _remainCells = 5;
	[SerializeField] private float _reChargeCooldown;
	private const float _baseCharge = 2f;

	[SerializeField] private float[] _cellTemperatures = new float[MAX_CELLS];
	private float _cooldownSpeed = 20f;

	private void Update()
	{
		if (_cooldown >= 0f)
		{
			_cooldown -= Time.deltaTime;
		}
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
	}

	public void Fire()
	{
		if (_bulletPrefab == null) return;

		if (_remainCells <= 0) return;
		if (_cooldown >= 0f) return;
		if (!CanFire(out int index)) return;

		_cooldown = FIRE_COOLDOWN;
		_remainCells--;
		_reChargeCooldown = GetReChargeCooldown();
		_cellTemperatures[index] = 100f;

		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;

		Instantiate(_bulletPrefab, pos, rot);
		Debug.Log($"생성 위치 : {pos} / 방향 : {rot.eulerAngles}");

		_cooldownSpeed = CheckOverHeating() ? 10f : 20f;
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