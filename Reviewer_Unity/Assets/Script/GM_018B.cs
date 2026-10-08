using System.Collections.Generic;
using UnityEngine;

public class GM_018B : MonoBehaviour
{
	struct BaseStats
	{
		public int Hp;
		public int Atk;

		public BaseStats(int Hp, int Atk)
		{
			this.Hp = Hp;
			this.Atk = Atk;
		}
	}

	class SkillSet
	{
		public string SkillName { get; set; }
		public float Multiplier { get; set; }

		public SkillSet(string skillName, float multiplier)
		{
			SkillName = skillName;
			Multiplier = multiplier;
		}

		public SkillSet Clone()
		{
			return new SkillSet(SkillName, Multiplier);
		}
	}
	class MonsterTemplate
	{
		private BaseStats _stats;
		public BaseStats Stats
		{
			get { return _stats; } 
			set { _stats = value; }
		}

		public List<SkillSet> Skills { get; set; }

		public MonsterTemplate(BaseStats stats, List<SkillSet> skills)
		{
			_stats = stats;
			Skills = skills;
		}

		public MonsterTemplate Clone()
		{
			List<SkillSet> cloneSkills = new List<SkillSet>();
			for (int i = 0; i < cloneSkills.Count; i++)
			{
				cloneSkills.Add(Skills[i].Clone());
			}
			return new MonsterTemplate(_stats, cloneSkills);
		}

		public void SetHP(int value)
		{
			_stats.Hp = value;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			BaseStats baseStats = new BaseStats(1000, 10);
			List<SkillSet> skills = new List<SkillSet>();
			skills.Add(new SkillSet("화염방사", 1.5f));

			MonsterTemplate dragon = new MonsterTemplate(baseStats, skills);
			MonsterTemplate dragonInstance1 = dragon.Clone();
			dragonInstance1.SetHP(500);
			if (dragonInstance1.Skills.Count > 0)
			{
				dragonInstance1.Skills[0].Multiplier = 9.9f;
			}
			Debug.Log($"원본 HP : {dragon.Stats.Hp}, 원본 스킬 배율 : {dragon.Skills[0].Multiplier}");
		}
	}
}