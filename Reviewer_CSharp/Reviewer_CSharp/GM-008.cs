namespace Reviewer_CSharp
{
	internal class GM_008
	{
		static void Main(string[] args)
		{
			Console.WriteLine("----월남뽕----");
			Console.WriteLine();

			Random random = new Random();

			int gold = 10000;
			List<int> cards = new List<int>(52); // reserve
			for (int i = 0; i < 52; i++)
			{
				cards.Add(i); // 0 ~ 51
			}
			Shuffle(cards);

			// 게임 진행
			for (int i = 0; i < cards.Count; i+=3)
			{
				PrintCard(cards[i]);
				Console.Write(" ? ");
				PrintCard(cards[i + 1]);
				Console.WriteLine();

				// 배팅액 입력
				Console.WriteLine($"소지금 : {gold}");
				int input = -1;
				do
				{
					Console.WriteLine("배팅액을 입력해 주세요(1000 이상) : ");
					string str = Console.ReadLine();
					if (str == "fold")
					{
						Console.WriteLine("[폴드] 1000 골드를 사용하고, 이번 판을 건너뜁니다.\n");
						gold -= 1000;
						Console.WriteLine($"소지금 : {gold}");
						continue;
					}
					if (int.TryParse(str, out input))
					{
						switch (input)
						{
							case 1:
								Console.Write("[치트] ?는 ");
								PrintCard(cards[i+2]);
								Console.WriteLine("입니다.");
								Console.WriteLine("");
								break;
							case 2:
								Console.WriteLine("[치트] 남은 카드 목록");
								for (int j = i; j < cards.Count; j++)
								{
									PrintCard(cards[j]);
									Console.Write(" ");
								}
								Console.WriteLine("\n");
								break;
						}
					}
				} while (input < 1000 || gold < input);

				// 카드 공개
				Console.Write("\n숨겨진 카드는 [");
				PrintCard(cards[i + 2]);
				Console.WriteLine("]입니다.");

				// 결과 판정
				int min = Math.Min(cards[i] % 13, cards[i + 1] % 13);
				int max = Math.Max(cards[i] % 13, cards[i + 1] % 13);
				int hidden = cards[i + 2] % 13;

				if (min < hidden && hidden < max)
				{
					Console.WriteLine($"[결과] 축하합니다. 승리했습니다. 획득 골드 : {input * 2}\n");
					gold += input * 2;
				}
				else
				{
					Console.WriteLine($"[결과] 패배했습니다. 배팅액 {input} 골드를 잃었습니다.\n");
					gold -= input;

					if (gold < 1000)
					{
						Console.WriteLine("배팅액이 부족하여 게임이 종료됩니다.");
						return;
					}
				}
			}
			Console.WriteLine("카드가 모두 소진되어 게임이 종료됩니다.");

			// 전체 카드 섞기
			void Shuffle(List<int> cards)
			{
				for (int i = cards.Count - 1; i >= 0; i--)
				{
					int j = random.Next(0, i);
					int tmp = cards[i];
					cards[i] = cards[j];
					cards[j] = tmp;
				}
			}

			// 카드 1개 출력
			void PrintCard(int number)
			{
				int q, r;
				q = number / 13;
				r = number % 13;

				switch (q)
				{
					case 0:
						Console.Write("◆");
						break;
					case 1:
						Console.Write("♠");
						break;
					case 2:
						Console.Write("♥");
						break;
					case 3:
						Console.Write("♣");
						break;
				}
				switch (r)
				{
					case 0:
						Console.Write("A");
						break;
					case 10:
						Console.Write("J");
						break;
					case 11:
						Console.Write("Q");
						break;
					case 12:
						Console.Write("K");
						break;
					default:
						Console.Write(r+1);
						break;
				}
			}
		}
	}
}
