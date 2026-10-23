using UnityEngine;
using UnityEngine.UI;

public class GM_035_OtherButton : MonoBehaviour
{
	[SerializeField] private Button _otherButton;

	private void OnEnable()
	{
		_otherButton.onClick.AddListener(OnClickOtherButton);
	}

	private void OnDisable()
	{
		_otherButton.onClick.RemoveListener(OnClickOtherButton);
	}

	public void OnClickOtherButton()
	{
		Debug.Log("other 버튼 클릭 감지");
	}
}