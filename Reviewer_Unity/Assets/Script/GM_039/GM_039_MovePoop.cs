using UnityEngine;

public class GM_039_MovePoop : MonoBehaviour
{
	[SerializeField] private float _disableHeight = -1f;
	[SerializeField] private float _moveSpeed = 2f;
	[SerializeField] private Transform _poopTr;

	void Update()
	{
		MoveDown();
	}

	private void MoveDown()
	{
		if (_poopTr == null) return;

		_poopTr.Translate(Vector2.down * _moveSpeed * Time.deltaTime);

		if (_poopTr.position.y <= _disableHeight)
		{
			Destroy(gameObject);
			//gameObject.SetActive(false);
			//ReturnToPool();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("플레이어 접촉");
			if (GM_039_GameManager.Instance == null) return;
			GM_039_GameManager.Instance.GameOver();
		}
	}
}