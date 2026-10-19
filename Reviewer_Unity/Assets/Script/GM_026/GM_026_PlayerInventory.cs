using System.Collections.Generic;
using UnityEngine;

public class GM_026_PlayerInventory : MonoBehaviour
{
	private readonly Dictionary<GM_026_WorldItem, ItemData> _inventory = new Dictionary<GM_026_WorldItem, ItemData>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Item")) return;
		
		if (collision.TryGetComponent<GM_026_WorldItem>(out GM_026_WorldItem item))
		{
			_inventory.Add(item, item.GetItemData());
			item.PickedUp();
		}
	}
}