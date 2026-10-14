using UnityEngine;

public class GM_024 : MonoBehaviour
{
	[SerializeField] private Renderer _hintCube;
	[SerializeField] private Renderer[] _cubeRenderers = new Renderer[3];

	private int[] _cubes = new int[3]; // 로직용
	private int _score = 0; // 누적 점수
	private int _currentColor = 0; // 답

	private void Awake()
	{
		if (_hintCube == null)
		{
			_hintCube = GetComponent<Renderer>();
		}
		if (_hintCube == null || _cubes == null ||
			_cubes.Length == 0)
		{
			gameObject.SetActive(false);
		}
	}

	private void Start()
	{
		for (int i = 0; i < _cubes.Length; i++)
		{
			_cubes[i] = i;
		}

		OnRoundStart();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SelectCube(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SelectCube(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SelectCube(2);
		}
	}

	void OnRoundStart()
	{
		ChangeColor(_hintCube, _currentColor);

		int answerIndex = Random.Range(0, _cubes.Length);
		_cubes[answerIndex] = _currentColor;
		ChangeColor(_cubeRenderers[answerIndex], _currentColor);

		for (int i = 0; i < _cubes.Length; i++)
		{
			if (i == answerIndex)
				continue;

			int rgb = Random.Range(0, 3); // 0 ~ 2
			ChangeColor(_cubeRenderers[i], rgb);
		}
	}

	void SelectCube(int value)
	{
		if (value >= _cubes.Length) return;
		if (_cubes == null) return;
		if (_cubeRenderers == null || _cubeRenderers[value] == null) return;
		
		Debug.Log($"{value+1}번 : {_cubes[value]} 선택. 정답 : {_currentColor}");
		if (_currentColor == _cubes[value])
		{
			_currentColor++;
			if (_currentColor >= _cubes.Length)
			{
				_score++;
				Debug.Log($"[점수 획득] 현재 점수 : {_score}");
				_currentColor = 0;
			}
			OnRoundStart();
		}
		else
		{
			_currentColor = 0;
			OnRoundStart();
		}
	}

	void ChangeColor(Renderer r, int value)
	{
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
		}
	}
}