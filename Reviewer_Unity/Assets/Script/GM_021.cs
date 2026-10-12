using System.Collections.Generic;
using UnityEngine;

public class GM_021 : MonoBehaviour
{
	enum EState
	{
		Prepare, // 회색
		Select, // 빨, 초
	}

	[SerializeField] private List<Renderer> _cubes;

	private EState state = EState.Prepare;

	private int _randomNumber = -1;
	private float _cooldown = 0f;
	private const float COOLDOWN = 0.5f;
	private int _round;
	private int _correct = 0;
	private const int MAX_ROUND = 10;

	private bool _isReady = true;

	private void Start()
	{
		_randomNumber = Random.Range(0, _cubes.Count);
		_round = 1;
	}

	void Update()
	{
		if (_cooldown > 0f)
		{
			_cooldown -= Time.deltaTime;
			return;
		}
		ChangeState();

		if (_round > MAX_ROUND) return;

		if (state == EState.Prepare)
		{
			if (Input.GetKeyDown(KeyCode.C))
			{
				Debug.Log($"[치트] 정답은 {_randomNumber + 1}입니다.");
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				TrySelectCube(_cubes, 0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				TrySelectCube(_cubes, 1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				TrySelectCube(_cubes, 2);
			}
		}
	}

	void ChangeState()
	{
		switch (state)
		{
			case EState.Prepare:
				if (_isReady) return;
				_randomNumber = Random.Range(0, _cubes.Count);
				ChangeALLColor(_cubes, Color.gray);
				_isReady = true;
				break;
			case EState.Select:
				_isReady = false;
				state = EState.Prepare;
				if (_round > MAX_ROUND)
				{
					Debug.Log($"정답률 : {(float)_correct / (float)MAX_ROUND * 100}%");
				}
				break;
		}
	}

	// 큐브 선택 → 정답 판정
	void TrySelectCube(List<Renderer> cubes, int number)
	{
		if (cubes == null || cubes.Count <= 0) return;

		Color color;
		if (_randomNumber == number)
		{
			color = Color.green;
			_correct++;
		}
		else
		{
			color = Color.red;
		}
		ChangeColor(cubes[number], color);

		Vector3 pos = cubes[number].transform.position;
		Debug.DrawLine(pos, pos + new Vector3(0, 2, 0), Color.yellow, COOLDOWN);

		_cooldown = COOLDOWN;
		state = EState.Select;
		_round++;
	}

	void ChangeColor(Renderer cube, Color color)
	{
		if (cube == null) return;

		cube.material.color = color;
	}

	void ChangeALLColor(List<Renderer> cubes, Color color)
	{
		if (cubes == null || cubes.Count <= 0) return;

		for (int i = 0; i < cubes.Count; i++)
		{
			cubes[i].material.color = color;
		}
	}
}