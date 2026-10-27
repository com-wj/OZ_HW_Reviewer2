using System;
using System.Collections;
using UnityEngine;

public class GM_040 : MonoBehaviour
{
	[SerializeField] private Renderer _playerRenderer;
	[SerializeField] private float _cooldown = 5f;
	[SerializeField] private float _remainCooldown;

	private bool _isCooldown = false;
	private Coroutine _routine;
	public event Action OnSkillUsed; // 스킬 사용
	public event Action OnSkillCooldownEnded; // 스킬 쿨타임 종료

	public float CooldownProgressRatio => Mathf.Clamp01(_remainCooldown / _cooldown);
	public bool IsCooldown => _isCooldown;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TryUseSkill(_cooldown);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (!_isCooldown) return;

			StopRoutine();
			ResetCooldown();
		}
	}

	private bool TryUseSkill(float time)
	{
		if (_isCooldown) return false;

		_isCooldown = true;
		StopRoutine();
		_routine = StartCoroutine(Co_Cooldown(time));
		OnSkillUsed?.Invoke();
		if (_playerRenderer != null)
		{
			_playerRenderer.material.color = Color.red;
		}

		return true;
	}

	private IEnumerator Co_Cooldown(float time)
	{
		_remainCooldown = time;
		int lastSecond = -1;
		while (_remainCooldown > 0)
		{
			_remainCooldown -= Time.deltaTime;

			int currentSecond = Mathf.CeilToInt(_remainCooldown);
			if (lastSecond != currentSecond && currentSecond > 0)
			{
				Debug.Log($"{currentSecond}초 남음.");
				lastSecond = currentSecond;
			}
			yield return null;
		}

		ResetCooldown();
		_routine = null;
	}

	private void ResetCooldown()
	{
		_remainCooldown = 0f;
		_isCooldown = false;
		OnSkillCooldownEnded?.Invoke();

		if (_playerRenderer != null)
		{
			_playerRenderer.material.color = Color.white;
		}

		Debug.Log($"쿨타임 종료.");
	}

	private void StopRoutine()
	{
		if (_routine != null)
		{
			StopCoroutine(_routine);
			_routine = null;
		}
	}
}