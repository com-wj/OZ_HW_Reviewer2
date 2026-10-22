using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GM_030_PlayerInventory))]
public class GM_030 : MonoBehaviour
{
	[SerializeField] private GM_030_PlayerInventory _inventory;

	private readonly Dictionary<string, int> _itemPrices = new Dictionary<string, int>();
	private readonly Dictionary<string, int> _requireRecipe = new Dictionary<string, int>();

	private void Awake()
	{
		if (_inventory == null)
		{
			_inventory = GetComponent<GM_030_PlayerInventory>();
		}
	}

	void Start()
	{
		AddItem("potion", 50);
		AddItem("sword", 300);

		Debug.Log($"sword의 가격 : {GetPrice("sword")}");

		foreach (KeyValuePair<string, int> p in _itemPrices)
		{
			Debug.Log($"[가격] {p.Key} : {p.Value}Gold");
		}

		_requireRecipe.Add("나무", 5);
		_requireRecipe.Add("일회용 톱", 1);
		_requireRecipe.Add("허름한 장갑", 1);
		
		_inventory.AddItem("나무", 10);
		_inventory.AddItem("일회용 톱", 1);
		_inventory.AddItem("허름한 장갑", 3);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			CraftItem("목재", _requireRecipe, _inventory);
		}
	}

	void AddItem(string itemId, int price)
	{
		if (_itemPrices.ContainsKey(itemId)) return;
		_itemPrices[itemId] = price;
	}

	public int GetPrice(string itemId)
	{
		if (_itemPrices.TryGetValue(itemId, out int price))
		{
			return price;
		}

		return 0;
	}

	public bool CraftItem(string recipeId, Dictionary<string, int> requireMaterials, GM_030_PlayerInventory inventory)
	{
		foreach (KeyValuePair<string, int> p in requireMaterials)
		{
			if (inventory.GetItemCount(p.Key) < p.Value)
			{
				Debug.Log($"보유한 아이템 수량이 부족합니다. ({p.Key})");
				return false;
			}
		}

		foreach (KeyValuePair<string, int> p in requireMaterials)
		{
			inventory.TryUseItem(p.Key, p.Value);
		}
		inventory.AddItem(recipeId);
		Debug.Log($"{recipeId} 획득");
		return true;
	}
}