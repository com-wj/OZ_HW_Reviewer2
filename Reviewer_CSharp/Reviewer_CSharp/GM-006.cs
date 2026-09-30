namespace Reviewer_CSharp
{
	internal class GM_006
	{
		static void Main(string[] args)
		{
			Print.HWNumber(1);
			List<int> computer = new List<int> { 0, 0, 0 };
			List<int> input = new List<int>() { 0, 0, 0 };

			while (true)
			{
				Random random = new Random();
				for (int i = 0; i < computer.Count; i++)
				{
					computer[i] = random.Next(0, 10);
				}
				int count = 0;

				// 입력
				Console.WriteLine("숫자야구 맞추기");
				int Strike = 0, Ball = 0;
				while (Strike != 3)
				{
					for (int i = 0; i < input.Count; i++)
					{
						Console.Write($"{i + 1}번째 자리수(0 ~ 9) : ");
						string? str = Console.ReadLine();
						if (str == "C" || str == "c")
						{
							Console.Write("컴퓨터 숫자는 ");
							for (int j = 0; j < computer.Count; j++)
							{
								Console.Write($"{computer[j]} ");
							}
							Console.WriteLine("입니다.");
							i--;
							continue;
						}
						else if (int.TryParse(str, out int tmp) &&
							(0 <= tmp && tmp <= 9))
						{
							input[i] = tmp;
						}
						else
						{
							Console.WriteLine("비정상적인 값이 입력되었습니다.");
							i--;
							continue;
						}
					}

					// 처리
					Strike = Ball = 0;
					for (int i = 0; i < input.Count; i++)
					{
						if (computer.Contains(input[i]))
						{
							if (input[i] == computer[i])
								Strike++;
							else
								Ball++;
						}
					}

					Console.WriteLine($"{Strike}S {Ball}B {3 - Strike - Ball}O");
					count++;
				}
				Console.WriteLine($"정답입니다. 시도 횟수 : {count}\n");

				Console.WriteLine("종료하시겠습니까?(Q 입력) : ");
				string? str2 = Console.ReadLine();
				if (str2 == "Q" || str2 == "q")
				{
					break;
				}
			}
			Print.Line();
		}
	}
}
