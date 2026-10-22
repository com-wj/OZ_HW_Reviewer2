using System.Collections.Generic;
using UnityEngine;

public class GM_030_PlayerInventory : MonoBehaviour
{
	[SerializeField] private readonly Dictionary<string, int> _inventory = new Dictionary<string, int>();

	public void AddItem(string itemId, int count = 1)
	{
		if (_inventory.ContainsKey(itemId))
		{
			_inventory[itemId] += count;
		}
		else
		{
			_inventory[itemId] = count;
		}
	}

	public int GetItemCount(string itemId)
	{
		if (string.IsNullOrEmpty(itemId)) return 0;

		return (_inventory.ContainsKey(itemId) == true) ?
			_inventory[itemId] : 0;
	}

	public bool TryUseItem(string itemId, int count)
	{
		if(string.IsNullOrEmpty(itemId)) return false;
		if (!_inventory.ContainsKey(itemId)) return false;
		if (_inventory[itemId] < count) return false;

		_inventory[itemId] -= count;
		return true;
	}
}