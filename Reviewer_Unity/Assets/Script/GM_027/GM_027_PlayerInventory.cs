using System.Collections.Generic;
using UnityEngine;

public class GM_027_PlayerInventory : MonoBehaviour
{
	[SerializeField] private List<GM_027_EnergyCoil> _energyCoils = new List<GM_027_EnergyCoil>();

	public IReadOnlyList<GM_027_EnergyCoil> EnergyCoils => _energyCoils;

	public void AddItem(GM_027_EnergyCoil item)
	{
		_energyCoils.Add(item);
	}

	public int UseItem()
	{
		if (_energyCoils.Count <= 0)
		{
			Debug.Log($"보유한 아이템이 없습니다.");
			return 0;
		}

		int power = _energyCoils[0].PowerValue;
		// swap & pop
		int last = _energyCoils.Count - 1;
		var temp = _energyCoils[last];
		_energyCoils[last] = _energyCoils[0];
		_energyCoils[0] = temp;
		_energyCoils.RemoveAt(last);

		return power;
	}
}