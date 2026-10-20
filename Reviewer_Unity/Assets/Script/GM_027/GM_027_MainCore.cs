using UnityEngine;

public class GM_027_MainCore : MonoBehaviour
{
	private static GM_027_MainCore _instance;
	public static GM_027_MainCore Instance => _instance;

	[SerializeField] private float _totalPower = 0f;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	public void AddPower(float value)
	{
		_totalPower += value;
		Debug.Log($"[{name}] 누적 Power : {_totalPower}");
		CheckPower();
	}

	private void CheckPower()
	{
		if (_totalPower > 100f)
		{
			Debug.Log("발전기 과부화. 실패했습니다.");
		}
		else if (_totalPower == 100f)
		{
			Debug.Log("발전기 안정화 성공.");
		}
	}
}