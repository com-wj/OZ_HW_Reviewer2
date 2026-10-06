namespace Reviewer_CSharp
{
	internal class GM_012
	{
		enum EAge
		{
			All,
			Teen,
			Adult
		}

		struct GameInfo
		{
			public string name;
			public EAge age;
			public float price;
			public float score;
			public (string first, string second) etc;

			public GameInfo(string name, EAge age, float price, float score, (string, string) etc)
			{
				this.name = name;
				this.age = age;
				this.price = price;
				this.score = score;
				this.etc = etc;
			}

			public void PrintInfo()
			{
				Console.WriteLine($"이름 : {name}");
				Console.Write($"이용 등급 : ");
				switch (age)
				{
					case EAge.All:
						Console.WriteLine("전체 이용가");
						break;
					case EAge.Teen:
						Console.WriteLine("12세 이용가");
						break;
					case EAge.Adult:
						Console.WriteLine("19세 이용가");
						break;
				}

				Console.WriteLine($"가격 : {(price == 0.0f ? "Free" : price)}");
				Console.WriteLine($"평점 : {(score == 0.0f ? "No Data" : "★"+score)}");

				Console.Write($"특이사항 : ");
				if(string.IsNullOrEmpty(etc.first) && string.IsNullOrEmpty(etc.second))
				{
					Console.Write("없음");
				}
				if(!string.IsNullOrEmpty(etc.first))
					Console.Write($"{etc.first} ");
				if(!string.IsNullOrEmpty(etc.second))
					Console.Write(etc.second);
				Console.WriteLine();
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			GameInfo[] gameinfo = new GameInfo[]
			{
				new GameInfo("PUBG : BATTLEGROUNDS", EAge.Adult, 0.0f, 5.9f, ("무료 게임", "성인 이용가")),
				new GameInfo("Maplestory", EAge.All, 0.0f, 0.0f, ("무료 게임", "")),
				new GameInfo("PEAK", EAge.Teen, 8400, 9.8f, ("", "")),
				new GameInfo("R.E.P.O", EAge.Teen, 11000, 5.0f, ("공포 장르", "")),
				new GameInfo("Lethal Company", EAge.Adult, 8400, 5.0f, ("성인 이용가", "공포 장르")),
			};

			int input = -1;
			do
			{
				Console.Clear();
				Console.WriteLine("1. 모든 게임 정보 출력");
				Console.WriteLine("2. 특정 조건 게임 정보 출력");
				Console.WriteLine("3. 종료");
				Console.Write("출력 방식을 선택하세요 : ");
				string str = Console.ReadLine();
				int.TryParse(str, out input);
			}while(input < 1 || 3 < input);

			if (input == 1)
			{
				for (int i = 0; i < gameinfo.Count(); i++)
				{
					gameinfo[i].PrintInfo();
				}
			}
			else if (input == 2)
			{
				do
				{
					Console.Clear();
					Console.WriteLine("1. 평점 9.0 이상 게임");
					Console.WriteLine("2. 성인용 게임");
					Console.WriteLine("3. 특이 사항이 있는 게임");
					Console.Write("출력 방식을 선택하세요 : ");
					string str = Console.ReadLine();
					int.TryParse(str, out input);
				} while (input < 1 || 3 < input);

				for (int i = 0; i < gameinfo.Count(); i++)
				{
					switch (input)
					{
						case 1:
							if (gameinfo[i].score >= 9.0f)
							{
								gameinfo[i].PrintInfo();
							}
							break;
						case 2:
							if (gameinfo[i].age == EAge.Adult)
							{
								gameinfo[i].PrintInfo();
							}
							break;
						case 3:
							if (!string.IsNullOrEmpty(gameinfo[i].etc.first) ||
								!string.IsNullOrEmpty(gameinfo[i].etc.second))
							{
								gameinfo[i].PrintInfo();
							}
							break;
					}
				}
			}
		}
	}
}
