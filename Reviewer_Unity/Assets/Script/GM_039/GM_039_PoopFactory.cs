using UnityEngine;

public class GM_039_PoopFactory : MonoBehaviour
{
	[Header("스폰 정보")]
	[SerializeField] private GameObject _prefab;
	[SerializeField] private float _spawnHeight = 10f;
	[SerializeField] private float _spawnInterval = 1f;

	private float _spawnTimer;

	void Update()
	{
		if (_prefab == null) return;

		if (_spawnTimer < _spawnInterval)
		{
			_spawnTimer += Time.deltaTime;
			return;
		}
		_spawnTimer = 0f;

		Vector2 viewportR = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 viewportL = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
		float min = viewportL.x;
		float max = viewportR.y;
		float x = Random.Range(min, max);
		Vector3 pos = new Vector3(x, _spawnHeight, -10);

		Instantiate(_prefab, pos, Quaternion.identity);
	}
}