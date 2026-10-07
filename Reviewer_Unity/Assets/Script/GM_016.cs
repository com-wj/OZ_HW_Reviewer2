using System.Collections.Generic;
using UnityEngine;

public class GM_016 : MonoBehaviour
{
	[SerializeField] private string[] masterCards = { "용사", "마법사", "궁수", "도둑", "기사", "힐러", "드래곤", "슬라임", "골렘", "암살자" };
	[SerializeField] private List<string> playerDeck = new List<string>();

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (playerDeck.Count > 0)
			{
				Debug.Log(playerDeck[0]);
				playerDeck.RemoveAt(0);
			}
			Debug.Log($"보유 카드 수 : {playerDeck.Count}");
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			for (int i = playerDeck.Count - 1; i >= 0; i--)
			{
				if (playerDeck[i] == "슬라임")
				{
					int last = playerDeck.Count - 1;
					playerDeck[i] = playerDeck[last];
					playerDeck.RemoveAt(last);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			playerDeck.Insert(0, "EmergencyHeal");
			Debug.Log($"보유 카드 수 : {playerDeck.Count}");
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (playerDeck.Count > 0)
			{
				Debug.Log("보유 카드가 남아있습니다.");
				return;
			}

			RefillDeck();
			ShuffleDeck();
			PrintDeck();
		}
	}

	void RefillDeck()
	{
		playerDeck.Clear();
		int i = 0;
		while (playerDeck.Count < 10)
		{
			playerDeck.Add(masterCards[i]);
			i = (i > 9) ? 0 : i + 1;
		}

		if (playerDeck.Count == 10)
		{
			Debug.Log("리필 완료");
		}
	}

	void Swap(List<string> list, int a, int b)
	{
		if (0 > a && list.Count < a)
			return;
		if (0 > b && list.Count < b)
			return;

		if (a == b)
			return;

		string temp = list[a];
		list[a] = list[b];
		list[b] = temp;
	}

	void ShuffleDeck()
	{
		if (playerDeck == null || playerDeck.Count <= 0)
			return;

		for (int i = playerDeck.Count - 1; i > 0; i--)
		{
			int j = Random.Range(0, i + 1);
			Swap(playerDeck, i, j);
		}

		if (playerDeck.Count == 10)
		{
			Debug.Log("카드 수 정상");
		}
	}

	void PrintDeck()
	{
		int i = 0;
		foreach (string str in playerDeck)
		{
			Debug.Log($"{i+1}. {str}");
			i++;
		}
	}
}