using TMPro;
using UnityEngine;

public class GM_039_Timer : MonoBehaviour
{
	[SerializeField] private TMP_Text _timerUI;

	private float _timer = 0f;

	void Update()
	{
		_timer += Time.deltaTime;
		UpdateTimerUI();
	}

	private void UpdateTimerUI()
	{
		int h = (int)_timer / 3600;
		int m = (int)_timer / 60;
		float s = _timer % 60;

		_timerUI.text = $"{h:0}:{m:00}:{s:00.000}";
	}
}