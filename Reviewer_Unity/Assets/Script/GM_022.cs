using UnityEngine;

public class GM_022 : MonoBehaviour
{
	enum EState
	{
		Normal,
		Overload,
		Cool,
	}

	[SerializeField] private Renderer _playerRenderer;
	[SerializeField] private float _rotateSharpness = 360f;
	[SerializeField] private float _scaleSharpness = 0.001f;
	private EState _state = EState.Normal;
	private float _guage = 0f;
	private float _guageSpeed = 15f;
	private float _overloadCooldown = 2f;
	private float _dir = 1f;

	private void Awake()
	{
		if (_playerRenderer == null)
		{
			_playerRenderer = gameObject.GetComponent<Renderer>();
		}
	}

	void Update()
	{
		switch (_state)
		{
			case EState.Normal:
				StateNormal();
				break;
			case EState.Overload:
				StateOverload();
				break;
			case EState.Cool:
				StateCool();
				break;
		}

		_guage = Mathf.Clamp(_guage, 0f, 100f);
		ChangeColor(_playerRenderer, _guage);
	}

	void StateNormal()
	{
		Transform tr = _playerRenderer.transform;
		float dt = Time.deltaTime * _guageSpeed;

		if (Input.GetKey(KeyCode.Space)) // 상승
		{
			_guage += dt;

			// 좌우 흔들림
			if (Time.frameCount % 50 == 0)
			{
				tr.Rotate(Vector3.up, Time.deltaTime * _rotateSharpness * _dir);
				_dir *= -1;
			}
			ChangeScale(1, _scaleSharpness);

			if (_guage >= 80f)
			{
				_overloadCooldown = 2f;
				_state = EState.Overload;
			}
		}
		else if (_guage > 0f) // 하락
		{
			_guage -= dt;
			ChangeScale(-1, _scaleSharpness);
		}
	}

	void StateOverload()
	{
		_overloadCooldown -= Time.deltaTime;
		if (_overloadCooldown <= 0f)
		{
			_state = EState.Cool;
		}
	}

	void StateCool()
	{
		float dt = Time.deltaTime * _guageSpeed;
		_guage -= dt;
		ChangeScale(-1, _scaleSharpness);
		if (_guage <= 20f)
		{
			_state = EState.Normal;
		}
	}

	// 색 시각화
	void ChangeColor(Renderer renderer, float guage)
	{
		if (guage < 40f && renderer.material.color != Color.blue)
		{
			renderer.material.color = Color.blue;
		}
		else if (40f < guage && guage < 80f && renderer.material.color != Color.yellow)
		{
			renderer.material.color = Color.yellow;
		}
		else if (80f < guage && renderer.material.color != Color.red)
		{
			renderer.material.color = Color.red;
		}
	}

	void ChangeScale(float dir, float sharpness)
	{
		float nSize = Mathf.Clamp(_playerRenderer.transform.localScale.x + dir * sharpness, 1f, 5f);
		_playerRenderer.transform.localScale = new Vector3(nSize, nSize, nSize);
	}
}