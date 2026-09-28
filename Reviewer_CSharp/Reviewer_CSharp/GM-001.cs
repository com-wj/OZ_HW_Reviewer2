using System.Text;

namespace Reviewer_CSharp
{
	internal class GM_001
	{
		static void Start()
		{
			int currentGold = 0;
			PrintGold();

			MiningGold(ref currentGold);
			PrintGold();

			MiningGold(ref currentGold);
			PrintGold();
			Console.WriteLine("------------------\n");

			// -----

			int a = 0, b = 5;
			Console.WriteLine($"a : {a}, b : {b}\n");

			Swap(a, b);
			Console.WriteLine($"a : {a}, b : {b}\n");

			Swap(ref a, ref b);
			Console.WriteLine($"a : {a}, b : {b}\n");
			Console.WriteLine("------------------\n");

			// -----
			int cost = 5;
			if (TryGoldUse(currentGold, cost, out currentGold))
			{
				Console.WriteLine($"{cost}골드 사용.\n");
			}
			else
			{
				Console.WriteLine($"소지금이 부족합니다.\n");
			}
			PrintGold();

			void PrintGold()
			{
				Console.WriteLine($"현재 보유 골드 : {currentGold}\n");
			}
		}
		static void MiningGold(ref int gold)
		{
			Console.WriteLine("골드 채집.");

			if (gold >= 10)
			{
				Console.WriteLine("[보너스] 추가 골드 획득");
				for (int i = 0; i < 3; i++)
				{
					gold += 10;
				}
			}
			else
			{
				gold += 10;
			}
		}
		// Call By Value
		static void Swap(int a, int b)
		{
			Console.WriteLine("Call By Value");
			int tmp = a;
			a = b;
			b = tmp;
		}
		// Call By Reference
		static void Swap(ref int a, ref int b)
		{
			Console.WriteLine("Call By Reference");
			int tmp = a;
			a = b;
			b = tmp;
		}
		static bool TryGoldUse(int currentGold, int cost, out int result)
		{
			result = 0;
			if (currentGold >= cost)
			{
				result = currentGold - cost;
				return true;
			}
			else
				return false;
		}
		static void Main(string[] args)
		{
			Start();
		}
	}
}