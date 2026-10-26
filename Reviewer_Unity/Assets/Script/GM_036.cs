using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GM_036 : MonoBehaviour
{
	public enum EGameState
	{
		INIT,
		STAGE_INTRO,
		WAVE_READY,
		WAVE_PROGRESS,
		WAVE_INTERVAL,
		STAGE_CLEAR,
		STAGE_FAILED,
		PAUSE
	}

	[SerializeField] private EGameState _gameState = EGameState.INIT;
	[SerializeField] private Button _startButton;
	[SerializeField] private Button _failButton;
	[SerializeField] private Button _pauseButton;
	[SerializeField] private Button _resumeButton;

	private Coroutine _routine;
	private EGameState _tempState;

	private void OnEnable()
	{
		_startButton.onClick.AddListener(OnClickStartButton);
		_failButton.onClick.AddListener(OnClickFailButton);
		_pauseButton.onClick.AddListener(OnClickPauseButton);
		_resumeButton.onClick.AddListener(OnClickResumeButton);
	}

	private void OnDisable()
	{
		_startButton.onClick.RemoveListener(OnClickStartButton);
		_failButton.onClick.RemoveListener(OnClickFailButton);
		_pauseButton.onClick.RemoveListener(OnClickPauseButton);
		_resumeButton.onClick.RemoveListener(OnClickResumeButton);

		StopRoutine();
	}

	void Start()
	{
		ChangeStateAfterTime(EGameState.STAGE_INTRO, 2f);
	}

	private void ChangeStateAfterTime(EGameState targetState, float time, bool isCountDown = false)
	{
		StopRoutine();

		_routine =
			StartCoroutine(Co_ChangeStateAfterTime(targetState, time, isCountDown));
	}

	private IEnumerator Co_ChangeStateAfterTime(EGameState targetState, float time, bool isCountdown = false)
	{
		yield return StartCoroutine(Co_WaitTime(time, isCountdown));

		_gameState = targetState;
		_routine = null;
	}

	private IEnumerator Co_WaitTime(float time, bool isCountdown = false)
	{
		if (isCountdown)
		{
			WaitForSeconds sec = new WaitForSeconds(1f);

			for (int i = (int)Mathf.Floor(time); i > 0; i--)
			{
				Debug.Log($"{i}초");
				yield return sec;
			}
		}
		else
		{
			yield return new WaitForSeconds(time);
		}
	}

	private IEnumerator Co_WaveStart()
	{
		yield return StartCoroutine(Co_WaitTime(3f, true));
		_gameState = EGameState.WAVE_PROGRESS;

		yield return StartCoroutine(Co_WaitTime(5f));
		_gameState = EGameState.WAVE_INTERVAL;

		yield return StartCoroutine(Co_WaitTime(1f));
		_gameState = EGameState.WAVE_READY;

		_gameState = EGameState.STAGE_CLEAR;
		_routine = null;
	}

	private void StopRoutine()
	{
		if (_routine != null)
		{
			StopCoroutine(_routine);
			_routine = null;
		}
	}

	private void OnClickStartButton()
	{
		if (_gameState != EGameState.STAGE_INTRO) return;
		_gameState = EGameState.WAVE_READY;
		
		StopRoutine();
		_routine = StartCoroutine(Co_WaveStart());
	}

	private void OnClickFailButton()
	{
		if (_gameState != EGameState.WAVE_PROGRESS) return;

		StopRoutine();
		_gameState = EGameState.STAGE_FAILED;
	}

	private void OnClickPauseButton()
	{
		if(_gameState == EGameState.PAUSE) return;

		_tempState = _gameState;
		_gameState = EGameState.PAUSE;
		Time.timeScale = 0f;
	}

	private void OnClickResumeButton()
	{
		if (_gameState != EGameState.PAUSE) return;

		_gameState = _tempState;
		Time.timeScale = 1f;
	}
}