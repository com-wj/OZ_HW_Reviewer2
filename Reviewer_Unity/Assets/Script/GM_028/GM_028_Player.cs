using UnityEngine;

[RequireComponent (typeof(GM_028_PlayerShooter))]
public class GM_028_Player : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 10f;
	[SerializeField] private GM_028_PlayerShooter _playerShooter;

	private void Awake()
	{
		if (_playerShooter == null)
		{
			_playerShooter = GetComponent<GM_028_PlayerShooter>();
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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}

	void PlayerMove(Vector3 dir)
	{
		transform.Translate(dir * _moveSpeed * Time.deltaTime, Space.Self);
	}

	void Fire()
	{
		if (_playerShooter == null) return;

		_playerShooter.Fire();
	}
}
