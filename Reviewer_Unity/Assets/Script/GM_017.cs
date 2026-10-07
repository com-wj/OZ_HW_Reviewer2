using System.Collections.Generic;
using UnityEngine;

public class GM_017 : MonoBehaviour
{
	string[] monsterPool = { "주황버섯", "슬라임", "돼지" };
	string[] roomPool = { "헤네시스", "엘리니아", "리스항구" };
	Queue<string> monsterQueue = new Queue<string>();
	Stack<string> travelHistory = new Stack<string>();

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			int moster = Random.Range(0, monsterPool.Length);
			monsterQueue.Enqueue(monsterPool[moster]);

			Debug.Log($"[조우 예고] 저 멀리서 {monsterPool[moster]}이(가) 나타났습니다!");
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (monsterQueue.Count <= 0)
				return;

			string monster = monsterQueue.Dequeue();
			Debug.Log($"[전투] {monster}을(를) 처치했습니다! 남은 적 : {monsterQueue.Count}마리");
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			int room = Random.Range(0, roomPool.Length);
			travelHistory.Push(roomPool[room]);

			Debug.Log($"[이동] {roomPool[room]}에 진입했습니다. (총 이동 거리 : {travelHistory.Count})");
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			if (travelHistory.Count <= 0)
			{
				Debug.Log("던전 입구까지 돌아왔습니다. 더 이상 퇴각할 수 없습니다.");
				return;
			}

			travelHistory.Pop();
			if (travelHistory.Count > 0)
			{
				string beforeRoom = travelHistory.Peek();
				Debug.Log($"[퇴각] {beforeRoom}(으)로 돌아왔습니다.");
			}
			else
			{
				Debug.Log("던전 입구까지 돌아왔습니다. 더 이상 퇴각할 수 없습니다.");
			}
		}
	}
}