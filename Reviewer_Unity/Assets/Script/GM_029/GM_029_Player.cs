using UnityEngine;

[RequireComponent (typeof(GM_029_PlayerShooter))]
public class GM_029_Player : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 10f;
	[SerializeField] private GM_029_PlayerShooter _playerShooter;

	private void Awake()
	{
		if (_playerShooter == null)
		{
			_playerShooter = GetComponent<GM_029_PlayerShooter>();
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
		if (Input.GetKey(KeyCode.Space))
		{
			Fire();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (_playerShooter == null) return;
			_playerShooter.FireReset();
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
