using UnityEngine;

public class GM_018 : MonoBehaviour
{
	struct NormalWeapon
	{
		public string name;
		public int power;
	}

	class LegendaryWeapon
	{
		public string Name { get; set; }
		public int Power { get; set; }
	}

	LegendaryWeapon original = new LegendaryWeapon();
	LegendaryWeapon linked;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			NormalWeapon original;
			original.name = "waepon1";
			original.power = 10;
			NormalWeapon copy = original;
			copy.power = 50;

			Debug.Log($"원본 공격력 : {original.power}, 복사본 공격력 : {copy.power}");
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			original.Power = 50;
			linked = original;
			linked.Power = 999;

			Debug.Log($"원본 공격력 : {original.Power}, 복사본 공격력 : {linked.Power}");
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			linked = null;
			Debug.Log($"원본 공격력 : {original.Power}");
		}
	}
}