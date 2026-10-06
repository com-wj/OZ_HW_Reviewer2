using UnityEngine;

public class GM_013 : MonoBehaviour
{
	float playerHP = 100;
	float playerAtk = 50;
	int gold = 0;
	int trainingCount = 0;
	bool isBossDefeated = false;
	int explorationProgress;

	void Update()
	{
		// 2단계
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (trainingCount >= 3)
				return;

			for (int i = 0; i < 10; i++)
			{
				Debug.Log($"칼을 휘두릅니다! ({i+1}회)");
			}
			playerAtk += 5;
			trainingCount++;
			Debug.Log($"현재 공격력 : {playerAtk}");
		}

		// 3단계
		if (Input.GetKeyDown(KeyCode.H))
		{
			while (explorationProgress < 100)
			{
				Debug.Log($"탐험 진행도 : {explorationProgress}%");
				explorationProgress += 20;
				if (Random.Range(0f, 1f) <= 0.2f)
				{
					playerHP -= 10f;
					if (playerHP <= 0)
					{
						Debug.Log("탐험 실패!");
						return;
					}
				}
			}
			gold += 50;
			explorationProgress = 0;
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			if (isBossDefeated)
				return;

			bool isBossShield = true;
			float bossHP = 100f;
			do
			{
				Debug.Log("플레이어가 공격합니다!");
				if (isBossShield)
				{
					isBossShield = false;
					Debug.Log($"공격이 쉴드에 막혔습니다.");
				}
				else
				{
					bossHP -= playerAtk;
					Debug.Log($"보스 체력 : {bossHP}");
				}
				Debug.Log("보스가 반격합니다!");
				playerHP -= 20f;
				Debug.Log($"플레이어 체력 : {playerHP}");
			} while (bossHP > 0 && playerHP > 0);

			if (bossHP <= 0)
			{
				Debug.Log($"보스 처치 성공");
				isBossDefeated = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			Debug.Log($"[현재 상태] HP : {playerHP} | ATK : {playerAtk} | GOLD : {gold}");
			if (playerHP <= 20f)
			{
				Debug.LogWarning("휴식이 절실합니다...");
			}
		}
	}
}