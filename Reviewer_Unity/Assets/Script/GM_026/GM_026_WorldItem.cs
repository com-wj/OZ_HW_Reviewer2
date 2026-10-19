using UnityEngine;

[System.Serializable]
public struct ItemData
{
	int id;
	string name;
}

public class GM_026_WorldItem : MonoBehaviour
{
	[SerializeField] private ItemData _itemData;

	public ItemData GetItemData()
	{
		return _itemData;
	}

	public void PickedUp()
	{
		gameObject.SetActive(false);
	}
}