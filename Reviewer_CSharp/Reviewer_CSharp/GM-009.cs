namespace Reviewer_CSharp
{
	internal class GM_009
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--로또 당첨기--");
			
			Random random = new Random();
			const int LottoRange = 45;
			const int NumberCount = 6;
			List<int> input = new List<int>(NumberCount);
			List<int> Lotto = new List<int>(LottoRange);
			for (int i = 0; i < LottoRange; i++)
			{
				Lotto.Add(i+1);
			}
			Shuffle(Lotto);

			int type = -1;
			do
			{
				Console.WriteLine("1. 사용자 입력 / 2. 자동");
				Console.WriteLine("입력 방식을 선택하세요 : ");
				string str = Console.ReadLine();
				int.TryParse(str, out type);
			}while(type < 1 || 2 < type);

			switch (type)
			{
				case 1: // 수동
					for (int i = 0; i < NumberCount; i++)
					{
						Console.WriteLine($"{i+1}번째 번호를 입력하세요 : ");
						string str = Console.ReadLine();
						int.TryParse(str, out int num);
						// 범위 검사
						if (num < 1 || LottoRange < num)
						{
							Console.WriteLine("입력 범위가 올바르지 않습니다.");
							i--;
							continue;
						}
						
						// 중복 검사
						bool isError = false;
						for (int j = 0; j < i; j++)
						{
							if (input[j] == input[i])
							{
								Console.WriteLine("입력 값은 중복될 수 없습니다.");
								isError = true;
								break;
							}
						}
						if (isError)
						{
							i--;
							continue;
						}

						input[i] = num;
					}
					break;
				case 2: // 자동
					for (int i = 0; i < NumberCount; i++)
					{
						input.Add(Lotto[i]);
					}
					Shuffle(Lotto);
					break;
			}

			// 번호 출력
			Console.WriteLine();
			Console.Write($"내 번호 : ");
			for (int i = 0; i < NumberCount; i++)
			{
				Console.Write($"{input[i]} ");
			}
			Console.WriteLine();

			Console.Write($"당첨 번호 :");
			for (int i = 0; i < NumberCount+1; i++)
			{
				Console.Write($" {Lotto[i]}");
				if (i == NumberCount)
				{
					Console.Write("(보너스 번호)");
				}
			}
			Console.WriteLine();
			Console.WriteLine();

			// 판정
			int correct = 0;
			bool isBonus = false;
			for(int i = 0; i<NumberCount; i++)
			{
				if (input.Contains(Lotto[i]))
				{
					correct++;
				}
			}
			isBonus = input.Contains(Lotto[NumberCount]); // 보너스 번호 유무

			Console.Write($"[결과] {correct}개 일치. ");
			switch (correct)
			{
				case 3:
					Console.WriteLine("5등입니다.");
					break;
				case 4:
					Console.WriteLine("4등입니다.");
					break;
				case 5:
					if (isBonus)
					{
						Console.WriteLine("2등입니다.");
					}
					else
					{
						Console.WriteLine("3등입니다.");
					}
					break;
				case 6:
					Console.WriteLine("1등입니다. 축하합니다.");
					break;
				default:
					Console.WriteLine("당첨되지 못했습니다.");
					break;
			}

			void Shuffle(List<int> list)
			{
				for (int i = list.Count() - 1; i >= 0; i--)
				{
					int j = random.Next(0, i);
					int tmp = list[i];
					list[i] = list[j];
					list[j] = tmp;
				}
			}
		}
	}
}
