using UnityEngine;

public class GM_023 : MonoBehaviour
{
	enum EState
	{
		None,
		Memorize,
		Input,
		GameOver,
	}

	[SerializeField] private Renderer _cube;

	private EState _state = EState.None;
	private const int MAX_ROUND = 3;
	private const int PATTERN_SIZE = 4;
	private int[] _pattern = new int[PATTERN_SIZE];
	private int _patternIndex = 0;

	private float[] COOLDOWN_ROUND = { 1.5f, 1.0f, 0.5f };
	private int _round = -1;
	private float _time = 0f;

	private void Awake()
	{
		if (_cube == null)
		{
			_cube = GetComponent<Renderer>();
		}
		if (_cube == null)
		{
			gameObject.SetActive(false);
		}
	}

	private void Start()
	{
		for (int i = 0; i < PATTERN_SIZE; i++)
		{
			_pattern[i] = i;
		}

		GameStart();
	}

	void Update()
	{
		switch (_state)
		{
			case EState.Memorize:
				UpdateMemorize();
				break;
			case EState.Input:
				UpdateInput();
				break;
			case EState.GameOver:
				UpdateGameOver();
				break;
		}
	}

	void UpdateMemorize()
	{
		_time -= Time.deltaTime;
		if (_time > 0f) return;

		if (_patternIndex >= PATTERN_SIZE)
		{
			_state = EState.Input;
			_patternIndex = 0;
			ChangeColor(_cube, 4); // 4 : 흰색
			return;
		}

		_time = COOLDOWN_ROUND[_round];
		ChangeColor(_cube, _pattern[_patternIndex]);
		_patternIndex++;
	}

	void UpdateInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SelectNumber(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SelectNumber(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SelectNumber(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SelectNumber(3);
		}
	}

	void UpdateGameOver()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameStart();
		}
	}

	void GameStart()
	{
		ChangeColor(_cube, 4);
		_round = 0;
		RoundStart();
	}

	void RoundStart()
	{
		shuffle();
		_time = COOLDOWN_ROUND[_round];
		_patternIndex = 0;
		_state = EState.Memorize;
	}

	// 순서 섞기
	void shuffle()
	{
		for (int i = PATTERN_SIZE - 1; i > 0; i--)
		{
			int j = Random.Range(0, PATTERN_SIZE);

			int tmp = _pattern[j];
			_pattern[j] = _pattern[i];
			_pattern[i] = tmp;
		}
	}

	/// <summary>
	/// value = 0 → 빨강
	/// </summary>
	void ChangeColor(Renderer r, int value = 0)
	{
		if (r == null) return;

		switch (value)
		{
			case 0:
				r.material.color = Color.red;
				break;
			case 1:
				r.material.color = Color.green;
				break;
			case 2:
				r.material.color = Color.blue;
				break;
			case 3:
				r.material.color = Color.yellow;
				break;
			case 4:
				r.material.color = Color.white;
				break;
		}
	}

	void SelectNumber(int num)
	{
		if (num == _pattern[_patternIndex])
		{
			ChangeColor(_cube, num);
			_patternIndex++;

			if (_patternIndex >= PATTERN_SIZE)
			{
				ChangeColor(_cube, 1);

				_round++;
				if (_round >= MAX_ROUND)
				{
					Debug.Log($"[클리어] 모든 라운드 클리어.");
					_state = EState.GameOver;
					return;
				}
				RoundStart();
			}
		}
		else
		{
			Debug.Log($"[오답] {num + 1}은 정답이 아닙니다. 정답 : {_pattern[_patternIndex] + 1}");
			ChangeColor(_cube);
			_patternIndex = 0;
			_state = EState.GameOver;
		}
	}

	private void OnGUI()
	{
		switch (_state)
		{
			case EState.Input:
				GUI.Label(new Rect(10, 10, 600, 20), "1 : 빨강, 2 : 초록, 3 : 파랑, 4 : 노랑");
				break;
			case EState.GameOver:
				GUI.Label(new Rect(10, 10, 600, 20), "Space : 재시작");
				break;
		}
	}
}