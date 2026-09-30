namespace Reviewer_CSharp
{
	internal class GM_005
	{
		static void HW1()
		{
			Print.HWNumber(1);
			int n = 3;
			while (0 < n--)
			{
				Console.Write("값을 입력하세요(1~12) : ");
				int input;
				int.TryParse(Console.ReadLine(), out input);

				if (input < 1 || 12 < input)
				{
					Console.WriteLine("잘못된 값을 입력했습니다.");
					return;
				}

				int day = 0;
				switch (input)
				{
					case 2:
						day = 28;
						break;
					case 4:
					case 6:
					case 9:
					case 11:
						day = 30;
						break;
					default:
						day = 31;
						break;
				}

				Console.WriteLine($"{input}월은 {day}일입니다.");
			}
			Print.Line();
		}

		// 치트 기능에 대한 설명 추가 : 특정 값을 입력받으면 컴퓨터가 뭘 낼지 알려줌.
		// 배팅 기능에 대한 설명 추가 : 매 가위바위보 시도마다 배팅액을 입력받아야 하고, 
		// 입력값 예외에 대한 처리 추가 : 잘못된 값 입력 시 재입력 시도 혹은 프로세스 종료
		// 종료 조건 수정 : 가진 돈을 전부 잃으면 X → 최소 배팅액(1000원)을 사용할 수 없으면 게임 종료.
		// 느낀점 : 시스템 플로우(입력 → 체크 → 결과 → 종료)에 맞게 문제를 설명해 주시면 이해하기 더 수월할 것 같습니다.
		static void HW2()
		{
			Print.HWNumber(2);

			int n = 5;
			int gold = 10000;
			while (0 < n-- && gold >= 1000) // 반복 종료 조건
			{
				Random random = new Random();
				int computer = random.Next(1, 4); // 1 ~ 3
				int player = 0;
				int bet = 0;

				Console.WriteLine($"현재 소지금 : {gold}");

				do
				{
					Console.Write("가위(1), 바위(2), 보(3)를 선택하세요 : ");
					int.TryParse(Console.ReadLine(), out player);
					if (player == 4)
					{
						Cheat(computer);
					}
				} while (player < 1 || 3 < player);

				do
				{
					Console.Write("배팅액을 입력하세요(1000 이상) : ");
					int.TryParse(Console.ReadLine(), out bet);
				} while (bet < 1000 || gold < bet);

				int reward = 0;
				switch (computer - player)
				{
					case -2:
					case 1:
						reward = -bet * 7;
						Console.Write("졌다. ");
						break;
					case 2:
					case -1:
						reward = bet * 3;
						Console.Write("이겼다. ");
						break;
					case 0:
						reward = bet * 5;
						Console.Write("비겼다. ");
						break;
				}
				Console.WriteLine($"{reward}골드 획득.");
				gold += reward;
			}

			void Cheat(int computer)
			{
				Console.Write("컴퓨터는 ");
				switch(computer)
				{
					case 1:
						Console.Write("가위");
						break;
					case 2:
						Console.Write("바위");
						break;
					case 3:
						Console.Write("보");
						break;
				}
				Console.WriteLine("를 냅니다.");
			}
		}
		static void Main(String[] args)
		{
			HW1();
			HW2();
		}
	}
}
