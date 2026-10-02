namespace Reviewer_CSharp
{
	internal class GM_011
	{
		struct Person
		{
			public int year;
			public int month;
			public int day;
			public int gender;
		}

		static void Main(string[] args)
		{
			Random random = new Random();
			Person person = new Person();
			string input;

			// 년도
			do
			{
				input = StringInput("태어난 년도를 입력하세요(2자리 혹은 4자리)");
				if (!CheckStringISNumber(input, out person.year))
				{
					continue;
				}
			} while (person.year < 1 || (100 <= person.year && person.year <= 999) || 9999 < person.year);

			if (person.year < 100) // 두 자리 입력
			{
				int tmp = -1;
				do
				{
					Console.WriteLine($"1. {1900 + person.year}");
					Console.WriteLine($"2. {2000 + person.year}");
					Console.WriteLine($"3. 자동");
					input = StringInput("선택하세요");

					if (!CheckStringISNumber(input, out tmp))
					{
						continue;
					}
				} while (tmp < 1 || 3 < tmp);

				switch(tmp)
				{
					case 1:
						person.year += 1900;
						break;
					case 2:
						person.year += 2000;
						break;
					case 3:
						person.year += (person.year >= 25) ? 1900 : 2000;
						break;
				}
				Console.WriteLine(person.year);
			}

			// 월
			do
			{
				input = StringInput("태어난 월을 입력하세요(1~12)");
				if (!CheckStringISNumber(input, out person.month))
				{
					continue;
				}
			} while (person.month < 1 || 12 < person.month);

			// 일
			int maxDay = GetDayPerMonth(person.month);
			do
			{
				input = StringInput($"태어난 일을 입력하세요(1~{maxDay})");
				if (!CheckStringISNumber(input, out person.day))
				{
					continue;
				}
			} while (person.day < 1 || maxDay < person.day);

			// 성별
			do
			{
				input = StringInput("성별 코드를 입력하세요(1~4)");
				if (!CheckStringISNumber(input, out person.gender))
				{
					continue;
				}
				if (person.gender < 1 || 4 < person.gender)
				{
					person.gender = person.year < 2000 ? random.Next(1, 3) : random.Next(3, 5); // 1, 2 or 3, 4
				}
			} while (person.gender < 1 || 4 < person.gender);

			// 출력
			int n = 3;
			do
			{
				Console.Write(person.year % 100);
				Console.Write(person.month >= 10 ? person.month : $"0{person.month}");
				Console.Write(person.day >= 10 ? person.day : $"0{person.day}");
				Console.Write('-');
				Console.Write(person.gender);
				for (int i = 0; i < 6; i++)
				{
					Console.Write(random.Next(0, 10));
				}
				Console.WriteLine();

				while (n > 0)
				{
					input = StringInput("다시 생성하시겠습니까? (Y/N)");
					if (input[0] == 'Y' || input[0] == 'y')
					{
						break;
					}
					if (input[0] == 'N' || input[0] == 'n')
					{
						return;
					}
					Console.WriteLine("입력값이 올바르지 않습니다.");
				}
			} while (n-- > 0); 
		}

		static string StringInput(string message)
		{
			Console.Write($"{message} : ");
			return Console.ReadLine();
		}

		static bool CheckStringISNumber(string str, out int num)
		{
			if (!int.TryParse(str, out num))
			{
				Console.WriteLine("입력값이 올바르지 않습니다.");
				return false;
			}
			return true;
		}

		static int GetDayPerMonth(int month)
		{
			int day = 0;
			switch (month)
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
			return day;
		}
	}
}
