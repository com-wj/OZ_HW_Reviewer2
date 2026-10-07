using UnityEngine;

public class GM_015 : MonoBehaviour
{
	public int[] monsterDeck = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log("카드 위치를 교체합니다. (0번 ↔ 마지막");

			SwapAt(0, monsterDeck.Length - 1);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.Log("덱을 섞습니다! (Fisher-Yates)");
			ShuffleFisherYates();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			int bossPower = Random.Range(1, 11);
			Debug.Log($"보스 공격력 : {bossPower}");

			if (monsterDeck[0] > bossPower)
			{
				Debug.Log("승리!");
			}
			else if (monsterDeck[0] == bossPower)
			{
				Debug.Log("무승부!");
			}
			else
			{
				Debug.Log("패배!");
			}
			Debug.Log("다음 판은 S로 셔플하세요");
		}
	}

	void SwapAt(int i, int j)
	{
		if (i == null || j == null)
			return;

		if (0 > i && monsterDeck.Length < i)
			return;
		if (0 > j && monsterDeck.Length < j)
			return;

		if (i == j)
			return;

		int temp = monsterDeck[i];
		monsterDeck[i] = monsterDeck[j];
		monsterDeck[j] = temp;
	}

	void ShuffleFisherYates()
	{
		if (monsterDeck == null || monsterDeck.Length <= 0)
			return;

		for (int i = monsterDeck.Length - 1; i > 0 ; i--)
		{
			int randomIndex = Random.Range(0, i + 1);

			SwapAt(i, randomIndex);
		}
	}
}