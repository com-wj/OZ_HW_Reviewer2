using UnityEngine;

interface IInteractable
{
	void Interact(GameObject interactor);
}

enum ECoilEnergyValue
{
	low = 10,
	mid = 15,
	high = 20,
	veryHigh = 30,
}

public class GM_027_EnergyCoil : MonoBehaviour, IInteractable
{
	[SerializeField] private ECoilEnergyValue _powerValue;

	public int PowerValue => (int)_powerValue;

	public void LootCoil()
	{
		gameObject.SetActive(false);
	}

	public void Interact(GameObject interactor)
	{
		if (interactor.TryGetComponent<GM_027_PlayerInventory>(out GM_027_PlayerInventory inventory))
		{
			inventory.AddItem(this);
			LootCoil();
		}
	}
}