using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GM_031_UI : MonoBehaviour
{
	[SerializeField] private GM_031 _playerData;
	[SerializeField] private List<TMP_Text> _textItemCounts = new List<TMP_Text>();
	[SerializeField] private List<TMP_Text> _textItemNames = new List<TMP_Text>();

	private void Awake()
	{
		if (_playerData == null)
		{
			Debug.LogWarning("인스펙터 확인");
			gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		if (_playerData.InventorySlots.Count != _textItemNames.Count)
		{
			Debug.LogWarning("인벤토리 데이터와 UI 데이터 불일치");
			gameObject.SetActive(false);
			return;
		}

		for (int i = 0; i < _textItemCounts.Count; i++)
		{
			_textItemCounts[i].text = _playerData.InventorySlots[i].Count.ToString();
			_textItemNames[i].text = _playerData.InventorySlots[i].Name.ToString();
		}
	}
}