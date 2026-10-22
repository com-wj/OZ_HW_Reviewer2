using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 인벤토리 정보 저장
public class GM_031 : MonoBehaviour
{
	[System.Serializable]
	public class InventorySlot
	{
		[SerializeField] private string _name;
		[SerializeField] private int _count;

		public InventorySlot(string name, int count)
		{
			_name = name;
			_count = count;
		}

		public string Name => _name;
		public int Count => _count;
	}

	[SerializeField] private Image _inventoryUI;
	[SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

	public IReadOnlyList<InventorySlot> InventorySlots => _inventorySlots;

	void Start()
	{
		_inventorySlots.Add(new InventorySlot("potion", 3));
		_inventorySlots.Add(new InventorySlot("gold", 1000));
		_inventorySlots.Add(new InventorySlot("key_red", 1));
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			if (_inventoryUI == null) return;

			bool targetActive = !_inventoryUI.gameObject.activeSelf;
			Debug.Log($"인벤토리 활성화 : {targetActive}");
			_inventoryUI.gameObject.SetActive(targetActive);
		}
	}
}