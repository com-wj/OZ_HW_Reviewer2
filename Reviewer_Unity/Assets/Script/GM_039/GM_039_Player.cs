using UnityEngine;

// 이동 조작
public class GM_039_Player : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private float _moveSpeed = 5f;

	void Update()
	{
		Move();
	}

	private void Move()
	{
		if (_player == null) return;

		// 이동 연산
		float h = Input.GetAxis("Horizontal");
		float moveDelta = h * _moveSpeed * Time.deltaTime;

		_player.Translate(Vector2.right * moveDelta, Space.World);

		// 화면 밖 이동 방지
		Vector2 viewportPos = Camera.main.WorldToViewportPoint(_player.position);
		viewportPos.x = Mathf.Clamp01(viewportPos.x);
		viewportPos.y = Mathf.Clamp01(viewportPos.y);
		_player.position = Camera.main.ViewportToWorldPoint(viewportPos);
	}
}