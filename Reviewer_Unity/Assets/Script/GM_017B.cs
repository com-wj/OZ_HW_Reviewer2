using System.Collections.Generic;
using UnityEngine;

public class GM_017B : MonoBehaviour
{
	string[] itemNames = { "쓰레기", "일반 검", "희귀 방패", "전설의 보석" };
	int[] weights = { 700, 200, 90, 10 };
	int totalWeight = 0;

	Stack<string> lootHistory = new Stack<string>();
	int undoLeft = 3;

	void Start()
	{
		for (int i = 0; i < weights.Length; i++)
		{
			totalWeight += weights[i];
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			Draw();
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			Undo();
		}
	}

	void Draw()
	{
		int r = Random.Range(0, totalWeight);

		int sum = 0;
		for (int i = 0; i < weights.Length; i++)
		{
			sum += weights[i];
			if (sum >= r)
			{
				lootHistory.Push(itemNames[i]);
				Debug.Log($"획득 : {itemNames[i]} (r = {r})");
				break;
			}
		}
	}

	void Undo()
	{
		if (lootHistory.Count <= 0)
		{
			Debug.Log("남은 뽑기 내역이 없습니다.");
			return;
		}

		if (undoLeft <= 0)
		{
			Debug.Log("Undo 횟수를 모두 소모했습니다.");
			return;
		}

		string undoItemName = lootHistory.Pop();
		undoLeft--;
		Debug.Log($"취소 : {undoItemName} / 남은 Undo : {undoLeft}");
		Draw();
	}
}