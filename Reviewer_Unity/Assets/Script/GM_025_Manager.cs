using UnityEngine;

// 스테이지 관리, 몹 팩토리
public class GM_025_Manager : MonoBehaviour
{
	private const int MAX_SPAWN_POINT_COUNT = 3;

	[System.Serializable]
	private class CSpawnData
	{
		public string Name;
		public Transform[] SpawnPoint = new Transform[MAX_SPAWN_POINT_COUNT];
	}

	[SerializeField] private GM_025_Monster _mobPrefab;
	[SerializeField] private GM_025_MobData[] _mobDatas = new GM_025_MobData[3];
	[SerializeField] private CSpawnData[] _cSpawnData = new CSpawnData[3];
	[SerializeField] private int _currentRound = 0;
	[SerializeField] private Transform _playerTr;

	[SerializeField] private GameObject[] _portals = new GameObject[2];

	private int _mobCount = 0;
	private bool _isSpawned = false;

	private void Awake()
	{
		if (_playerTr == null)
		{
			gameObject.SetActive(false);
		}
	}

	void Start()
	{
		RoundStart(_currentRound);
	}

	// 클리어 체크, 다음 라운드 실행
	void Update()
	{
		if (_isSpawned || _mobCount > 0) return;

		if (_currentRound < _portals.Length)
		{
			_portals[_currentRound].SetActive(true);
		}
		_currentRound++;
		RoundStart(_currentRound);
	}

	void RoundStart(int currentRound)
	{
		if (currentRound >= MAX_SPAWN_POINT_COUNT)
		{
			Debug.Log("모든 라운드 클리어");
			gameObject.SetActive(false);
		}

		_isSpawned = true;

		for (int i = 0; i <= currentRound; i++)
		{
			if (currentRound >= MAX_SPAWN_POINT_COUNT)
				break;

			Vector3 pos = _cSpawnData[currentRound].SpawnPoint[i].position;
			Spawn(_mobPrefab, pos, Quaternion.identity, _mobDatas[currentRound]);
		}

		_isSpawned = false;
	}

	void Spawn(GM_025_Monster prefab, Vector3 pos, Quaternion rot, GM_025_MobData data)
	{
		GM_025_Monster mob = Instantiate(_mobPrefab, pos, rot);
		mob.Init(data, _playerTr, this);
		_mobCount++;
	}

	public void OnMobDead()
	{
		_mobCount--;
	}
}