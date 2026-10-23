using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GM_035_UI : MonoBehaviour
{
	[SerializeField] private TMP_Text _stage;
	[SerializeField] private TMP_Text _enemyCount;
	[SerializeField] private TMP_Text _startGold;
	[SerializeField] private Button _startButton;

	public void SetUI(int stage, int enemyCount, int requireGold)
	{
		_stage.text = $"Stage : {stage.ToString()}";
		_enemyCount.text = $"Enemy Count : {enemyCount.ToString()}";
		_startGold.text = $"Start Gold : {requireGold.ToString()}";
	}

	private void OnEnable()
	{
		_startButton.onClick.AddListener(OnClickStartButton);
	}

	private void OnDisable()
	{
		_startButton.onClick.RemoveListener(OnClickStartButton);
	}

	public void OnClickStartButton()
	{
		Debug.Log("버튼 클릭 감지");
		gameObject.SetActive(false);
	}
}