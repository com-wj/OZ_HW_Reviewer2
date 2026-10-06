using UnityEngine;

public class GM_014 : MonoBehaviour
{
	string[] inventory = new string[5];
	string[] fieldItems = { "물약", "녹슨 검", "금화", "독사과", "방패" };
	int fieldIndex = 0;

	void Start()
	{
		for (int i = 0; i < inventory.Length; i++)
		{
			inventory[i] = "비어있음";
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			Debug.Log("=== 인벤토리 상태 ===");
			for (int i = 0; i < inventory.Length; i++)
			{
				Debug.Log($"[{i+1}번 슬롯] : {inventory[i]}");
			}
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (fieldIndex >= fieldItems.Length)
			{
				Debug.Log("필드에 더 이상 아이템이 없습니다.");
				return;
			}

			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i] == "비어있음")
				{
					inventory[i] = fieldItems[fieldIndex++];
					return;
				}
			}
			Debug.Log("가방이 가득 찼습니다!");
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			if (inventory[0] != "비어있음")
			{
				Debug.Log($"{inventory[0]}(을)를 사용했습니다!");
				inventory[0] = "비어있음";
			}
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i] == "독사과")
				{
					inventory[i] = "비어있음";
					Debug.Log($"[{i+1}번 슬롯]에서 [독사과]를 버립니다.");
				}
			}
		}
	}
}