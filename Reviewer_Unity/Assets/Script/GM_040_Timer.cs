using UnityEngine;
using UnityEngine.UI;

public class GM_040_Timer : MonoBehaviour
{
	[SerializeField] private GM_040 gm;
	[SerializeField] private Image _cooldownGuage;

	private bool _isUpdateGuage = false;

	private void Awake()
	{
		if (gm == null)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		gm.OnSkillUsed += AppearGauge;
		gm.OnSkillCooldownEnded += DisAppearGauge;
	}
	private void OnDisable()
	{
		gm.OnSkillUsed -= AppearGauge;
		gm.OnSkillCooldownEnded -= DisAppearGauge;
	}

	void Update()
	{
		if (!_isUpdateGuage) return;

		_cooldownGuage.fillAmount = gm.CooldownProgressRatio;
	}

	private void AppearGauge()
	{
		_cooldownGuage.gameObject.SetActive(true);
		_isUpdateGuage = true;
	}

	private void DisAppearGauge()
	{
		_cooldownGuage.gameObject.SetActive(false);
		_isUpdateGuage = false;
	}
}