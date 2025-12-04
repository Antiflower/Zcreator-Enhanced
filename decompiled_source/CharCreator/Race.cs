using System.Collections;
using StringTok;

namespace CharCreator;

public class Race
{
	public int maxInt;

	public int maxWis;

	public int maxStr;

	public int maxDex;

	public int maxCon;

	public int maxCha;

	public int size;

	public int hpregen;

	public int spregen;

	public int expRate;

	public int spellCost;

	public int skillCost;

	public int spellMax;

	public int skillMax;

	private string race;

	private string racialDescription;

	private ArrayList racialAbilities;

	private ArrayList autoSkills;

	private ArrayList autoSpells;

	private ArrayList condSkills;

	private ArrayList condSpells;

	private Race subrace;

	public string RaceName => race;

	public string descript
	{
		get
		{
			return racialDescription;
		}
		set
		{
			racialDescription = value;
		}
	}

	public Race(string name)
	{
		race = name;
	}

	public Race(string name, StringTokenizer st)
	{
		race = name;
		maxStr = int.Parse(st.NextToken().Trim());
		maxDex = int.Parse(st.NextToken().Trim());
		maxCon = int.Parse(st.NextToken().Trim());
		maxInt = int.Parse(st.NextToken().Trim());
		maxWis = int.Parse(st.NextToken().Trim());
		maxCha = int.Parse(st.NextToken().Trim());
		size = int.Parse(st.NextToken().Trim());
		expRate = int.Parse(st.NextToken().Trim());
		spregen = int.Parse(st.NextToken().Trim());
		hpregen = int.Parse(st.NextToken().Trim());
		skillMax = int.Parse(st.NextToken().Trim());
		spellMax = int.Parse(st.NextToken().Trim());
		skillCost = int.Parse(st.NextToken().Trim());
		spellCost = int.Parse(st.NextToken().Trim());
	}

	public override string ToString()
	{
		return race + "\nStr: " + maxStr + ", Dex: " + maxDex + ", Con: " + maxCon + ", Int: " + maxInt + ", Wis: " + maxWis + ", Cha: " + maxCha + "\nHP Regen: " + hpregen + ", SP Regen: " + spregen + ", Exp rate: " + expRate + "\nSkill max: " + skillMax + ", skill cost: " + skillCost + "\nSpell max: " + spellMax + ", spell cost: " + spellCost + "\n";
	}

	public string[] ToStrings()
	{
		return new string[6]
		{
			"Exp rate: " + expRate + ", Size: " + size,
			"Str: " + maxStr + ", Int: " + maxInt + ", Wis: " + maxWis,
			"Con: " + maxCon + ", Dex: " + maxDex + ", Cha: " + maxCha,
			"HP Regen: " + hpregen + ", SP Regen: " + spregen,
			"Skill max: " + skillMax + ", Skill cost: " + skillCost,
			"Spell max: " + spellMax + ", Spell cost: " + spellCost
		};
	}

	public override bool Equals(object obj)
	{
		return ((Race)obj).RaceName.ToLower().Equals(RaceName.ToLower());
	}
}
