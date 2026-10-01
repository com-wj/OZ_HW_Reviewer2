namespace Reviewer_CSharp
{
	internal class GM_007
	{
		enum ETarget
		{
			Player,
			Enemy
		}
		static void Main(string[] args)
		{
			Random random = new Random();

			float hp = 100, enemyHp = 200;
			List<int> skillDamage = new List<int>() { 10, 50, 0, 0 };
			List<string> skillName = new List<string>()
			{ "일반 공격",
				"가로 베기", 
				"피해 경감 버프",
				"회복" };
			
			bool isGameOver = false;
			bool isGuard = false;
			bool useRecover = false;
			bool isInvincible = false;
			const float mobCriticalRate = 0.2f;
			bool isMobCharge = false;

			Console.WriteLine("턴제 RPG");
			while (!isGameOver)
			{
				Console.WriteLine($"플레이어 체력 : {hp} / 몬스터 체력 : {enemyHp}\n");
				Console.WriteLine("[스킬 목록]");
				for (int i = 0; i < skillName.Count; i++)
				{
					Console.WriteLine($"{i+1}. {skillName[i]}");
				}

				// 플레이어 턴
				int input = 0;
				do
				{
					Console.Write("사용할 스킬을 선택해 주세요.(1 ~ 4) : ");
					int.TryParse(Console.ReadLine(), out input);

					Print.Line();

					#region 스킬 처리
					switch (input)
					{
						case 1:
						case 2:
							Console.WriteLine($"[{skillName[input - 1]}] 사용!");
							int damage = skillDamage[input-1];
							TakeDamage(ETarget.Enemy, ref enemyHp, damage);
							break;
						case 3:
							isGuard = true;
							Console.WriteLine("1회 피해를 50% 경감합니다.");
							break;
						case 4:
							if (useRecover)
							{
								Console.WriteLine("회복은 한 번만 가능합니다.");
							}
							else if (hp > 100)
							{
								Console.WriteLine("더이상 회복할 수 없습니다.");
							}
							else
							{
								hp = Math.Min(hp + 100, 100);
								Console.WriteLine($"체력을 회복합니다. 현재 체력 : {hp}");
							}
							break;
						case 5:
							// 치트 : 무적
							isInvincible = !isInvincible;
							Console.WriteLine($"[치트] 무적 {isInvincible}");
							break;
							case 6:
							// 치트 : 즉사
							Console.WriteLine($"[치트] 적을 즉사시킵니다.");
							Die(ETarget.Enemy);
							break;
					}
					#endregion
				} while (input < 1 || 6 < input);

				Print.Line();

				if (isGameOver)
				{
					break;
				}

				// 몬스터 턴
				int enemyBehaviour = isMobCharge ? 0 : random.Next(0, 2);

				switch (enemyBehaviour)
				{
					case 0:
						int baseDamage = 10;
						bool isCritical = false;
						Console.WriteLine("적이 일반 공격을 사용합니다. (피해량 10)");
						if(isMobCharge)
						{
							Console.WriteLine("적이 기를 모아서 피해량이 증가됩니다.");
						}
						if (random.NextDouble() < mobCriticalRate)
						{
							isCritical = true;
							Console.WriteLine("적 크리티컬 발동!");
						}

						float damage = baseDamage * (isCritical ? 2 : 1) * (isMobCharge ? 1.5f : 1);
						TakeDamage(ETarget.Player, ref hp, damage);

						isMobCharge = false;
						break;
					case 1:
						isMobCharge = true;
						Console.WriteLine("적이 기를 모읍니다...");
						break;
				}

				Print.Line();
			}
			Console.WriteLine("게임이 종료됩니다.");

			// 피해 처리 로직
			void TakeDamage(ETarget eTarget, ref float targetHp, float damage)
			{
				// 가드
				if (eTarget == ETarget.Player)
				{
					if (isInvincible)
					{
						damage = 0;
						Console.WriteLine("피해 무효화.");
					}
					else if (isGuard)
					{
						damage /= 2;
						Console.WriteLine("피해 경감 효과가 발동됩니다.");
						isGuard = false;
					}
				}

				// 피해 적용
				targetHp = Math.Max(targetHp - damage, 0);
				TargetLog(eTarget);
				Console.WriteLine($"{damage} 피해를 입었습니다. 남은 체력 : {targetHp}");

				// 사망 처리(로그용)
				if (targetHp <= 0)
				{
					Die(eTarget);
				}
			}
			
			void Die(ETarget eTarget)
			{
				TargetLog(eTarget);
				Console.Write($"사망했습니다. ");
				isGameOver = true;
			}

			// 로그 변환용
			void TargetLog(ETarget eTarget)
			{
				switch (eTarget)
				{
					case ETarget.Player:
						Console.Write("플레이어가 ");
						break;
					case ETarget.Enemy:
						Console.Write("적이 ");
						break;
				}
			}
		}
	}
}
