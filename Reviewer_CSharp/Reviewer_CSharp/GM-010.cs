namespace Reviewer_CSharp
{
	internal class GM_010
	{
		static void Main(string[] args)
		{
			int input = -1;
			do
			{
				Console.Write("출력 타입을 설정하세요 : ");
				if (!int.TryParse(Console.ReadLine(), out input))
				{
					Console.WriteLine("입력 값이 올바르지 않습니다.");
					continue;
				}
			} while (input < 1 || 5 < input);

			string str;
			switch (input)
			{
				case 1:
					str = StringInput("문자열");
					for (int i = str.Count() - 1; i >= 0; i--)
					{
						Console.Write(str[i]);
					}
					Console.WriteLine();
					break;
				case 2:
					str = StringInput("문자열");
					for (int i = 0; i < str.Count(); i+=2)
					{
						Console.Write(str[i]);
						if (i < str.Count() - 1)
						{
							if ((str.Count() & 1) == 1) // 홀수 길이
								Console.Write(str[str.Count() - 2 - i]);
							else // 짝수 길이
								Console.Write(str[str.Count() - 1 - i]);
						}
					}
					Console.WriteLine();
					break;
				case 3:
					str = StringInput("문자열");
					for (int i = 0; i < str.Count(); i++)
					{
						if (str[i] < '0' || '9' < str[i])
						{
							continue;
						}
						Console.Write(str[i]);
					}
					Console.WriteLine();
					break;
				case 4:
					str = StringInput("문자열");
					string str2 = StringInput("문자");

					int count = 0;
					for (int i = 0; i < str.Count(); i++)
					{
						if(str[i] == str2[0])
							count++;
					}
					Console.WriteLine($"결과 : {count}");
					break;
				case 5:
					while(true)
					{
						str = StringInput("주민등록번호 전체(13자리) 입력 : ");
						if (str.Count() != 14) // 길이 검사
						{
							Console.WriteLine("입력 자리수가 올바르지 않습니다.");
							continue;
						}
						if(str[6] != '-') // 형식 검사
						{
							Console.WriteLine("하이픈이 포함되어야 합니다.");
							continue;
						}

						// 숫자 유효성 검사
						string substr1 = str.Substring(0, 6);
						string substr2 = str.Substring(8);
						if (CheckStringISNumber(substr1) && CheckStringISNumber(substr2))
						{
							break;
						}
					}
					
					for (int i = 0; i < str.Count(); i++)
					{
						if (str[i] == '-')
							continue;
						Console.Write(i);
					}
					break;
			}

		}
		static string StringInput(string message)
		{
			Console.Write($"{message} : ");
			return Console.ReadLine();
		}

		static bool CheckStringISNumber(string str)
		{
			if (!int.TryParse(str, out int num))
			{
				Console.WriteLine("입력값이 올바르지 않습니다.");
				return false;
			}
			return true;
		}
	}
}
