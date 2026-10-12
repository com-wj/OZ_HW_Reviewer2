namespace Reviewer_CSharp
{
	internal class GM_020
	{
		const int MAX_ROW = 5;
		const int MAX_COL = 5;

		// 범위 검사
		static bool IsValid(int row, int col)
		{
			if (row < 0 || MAX_ROW <= row ||
				col < 0 || MAX_ROW <= col)
				return false;

			return true;
		}

		class Building
		{
			protected string _name;
			protected float _baseProsperity;

			public virtual float GetDailyProsperity(Building[,] village, int row, int col)
			{
				return _baseProsperity;
			}
		}

		class House : Building
		{
			public House()
			{
				_name = "House";
				_baseProsperity = 10f;
			}

			public override float GetDailyProsperity(Building[,] village, int row, int col)
			{
				float prosperity = _baseProsperity;
				bool hasNearMarket = false;

				int[] x = { -1, 0, 1, 0, -1, -1, 1, 1 };
				int[] y = { 0, -1, 0, 1, -1, 1, -1, 1 };

				for (int i = 0; i < 4; i++)
				{
					int nx = row + x[i];
					int ny = col + y[i];
					if (!IsValid(nx, ny))
					{
						continue;
					}

					if (village[nx, ny] is House)
					{
						prosperity += 5f;
					}
					else if (!hasNearMarket && village[nx, ny] is Market)
					{
						hasNearMarket = true;
					}
				}

				for (int i = 0; i < 8; i++)
				{
					int nx = row + x[i];
					int ny = col + y[i];
					if (!IsValid(nx, ny))
					{
						continue;
					}

					if (village[nx, ny] is Park)
					{
						prosperity += 5f;
					}
				}

				prosperity += hasNearMarket ? 10f : 0f;

				Console.WriteLine($"{_name}({row}, {col}) : {prosperity}");
				return prosperity;
			}
		}

		class Market : Building
		{
			public Market()
			{
				_name = "Market";
				_baseProsperity = 20f;
			}

			public override float GetDailyProsperity(Building[,] village, int row, int col)
			{
				bool isMarketLine = false;
				for (int i = 0; i < MAX_COL; i++)
				{
					if (i == col) continue;

					if (village[row, i] is Market)
					{
						isMarketLine = true;
						break;
					}
				}
				if (!isMarketLine)
				{
					for (int i = 0; i < MAX_ROW; i++)
					{
						if (i == row) continue;

						if (village[i, col] is Market)
						{
							isMarketLine = true;
							break;
						}
					}
				}
				
				float prosperity = isMarketLine ? 35f : _baseProsperity;

				int[] x = { -1, 0, 1, 0, -1, -1, 1, 1 };
				int[] y = { 0, -1, 0, 1, -1, 1, -1, 1 };

				for (int i = 0; i < 4; i++)
				{
					int nx = row + x[i];
					int ny = col + y[i];
					if (!IsValid(nx, ny))
					{
						continue;
					}

					if (village[nx, ny] is House)
					{
						prosperity += 10f;
					}
				}

				for (int i = 0; i < 8; i++)
				{
					int nx = row + x[i];
					int ny = col + y[i];
					if (!IsValid(nx, ny))
					{
						continue;
					}

					if (village[nx, ny] is Park)
					{
						prosperity += 5f;
					}
				}

				Console.WriteLine($"{_name}({row}, {col}) : {prosperity}");
				return prosperity;
			}
		}

		class Park : Building
		{
			public Park()
			{
				_name = "Park";
				_baseProsperity = 0f;
			}

			public override float GetDailyProsperity(Building[,] village, int row, int col)
			{
				float prosperity = 0f;
				Console.WriteLine($"{_name}({row}, {col}) : {prosperity}");
				return prosperity;
			}
		}

		static void Main(string[] args)
		{
			Building[,] village = new Building[MAX_ROW, MAX_COL];
			village[0, 0] = new House();
			village[0, 1] = new Market();
			village[0, 2] = new Park();

			float totalProsperity = 0f;
			for (int i = 0; i < MAX_ROW; i++)
			{
				for (int j = 0; j < MAX_COL; j++)
				{
					if (village[i, j] != null)
					{
						totalProsperity += village[i, j].GetDailyProsperity(village, i, j);
					}
				}
			}

			Console.WriteLine($"총 번영도는 : {totalProsperity}입니다.");
		}
	}
}
