using UnityEngine;

public class GM_035 : MonoBehaviour
{
	[SerializeField] private GM_035_UI _stagePopupUI;
	[SerializeField] private int _stage = 1;
	[SerializeField] private int _enemyCount = 10;
	[SerializeField] private int _requireGold = 10;

	void Start()
	{
		if (_stagePopupUI == null) return;

		_stagePopupUI.SetUI(_stage, _enemyCount, _requireGold);
		_stagePopupUI.gameObject.SetActive(true);
	}
}