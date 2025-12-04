using System;
using System.Collections;

namespace CharCreator;

public class Character
{
	private Race r;

	private ArrayList Guilds;

	private ArrayList skills;

	private ArrayList spells;

	private Hashtable experience;

	private int guildlevels;

	private int questpoints;

	private int freelevels;

	private int[] qpCosts;

	private int[] lvlCosts;

	private int[] statCosts;

	private int trainedStr;

	private int trainedDex;

	private int trainedCon;

	private int trainedWis;

	private int trainedInt;

	private int trainedCha;

	private int statWish;

	private int skillWish;

	private int spellWish;

	private int magWish;

	private int physWish;

	private int lesser;

	private int[] lCosts;

	private int greater;

	private int[] gCosts;

	private bool ambidexterity;

	private bool elementalAttunement;

	private bool giantSize;

	private bool improvedStr;

	private bool improvedDex;

	private bool improvedCon;

	private bool improvedInt;

	private bool improvedWis;

	private bool improvedCha;

	private bool lucky;

	private bool thickSkin;

	private bool trueSeeing;

	private int resistWishes;

	private int battleRegenWishes;

	private int enduranceWishes;

	private int reservesWishes;

	private int spellDamageWishes;

	private bool resistAcid;

	private bool resistAsp;

	private bool resistCold;

	private bool resistElec;

	private bool resistFire;

	private bool resistMag;

	private bool resistPois;

	private bool resistPsi;

	private bool lesserStatsWish;

	private bool superiorStatsWish;

	public Race charRace
	{
		get
		{
			return r;
		}
		set
		{
			r = value;
		}
	}

	public int spWish
	{
		get
		{
			return spellWish;
		}
		set
		{
			spellWish = ((value >= 0) ? value : 0);
		}
	}

	public int skWish
	{
		get
		{
			return skillWish;
		}
		set
		{
			skillWish = ((value >= 0) ? value : 0);
		}
	}

	public int totalLevels => 120 - guildlevels + free;

	public ArrayList guilds
	{
		get
		{
			return Guilds;
		}
		set
		{
			Guilds = value;
		}
	}

	public ArrayList availableSkills
	{
		get
		{
			double num = 0.0;
			if (r != null)
			{
				num = ((r.skillMax + skWish > 100) ? 1.0 : ((double)(r.skillMax + skWish) / 100.0));
			}
			for (int i = 0; i < skills.Count; i++)
			{
				SkillSpell skillSpell = (SkillSpell)skills[i];
				if (skillSpell.maxPercent == 100)
				{
					skillSpell.scaledPercent = r.skillMax + skillWish;
					continue;
				}
				int num2 = 5 * (int)Math.Floor(num * (double)skillSpell.maxPercent / 5.0);
				skillSpell.scaledPercent = ((num2 == 0 && skillSpell.maxPercent != 0 && charRace.skillCost != 0) ? 5 : num2);
			}
			return skills;
		}
	}

	public ArrayList availableSpells
	{
		get
		{
			double num = 0.0;
			if (r != null)
			{
				num = ((r.spellMax + spWish > 100) ? 1.0 : ((double)(r.spellMax + spWish) / 100.0));
			}
			for (int i = 0; i < spells.Count; i++)
			{
				SkillSpell skillSpell = (SkillSpell)spells[i];
				if (skillSpell.maxPercent == 100)
				{
					skillSpell.scaledPercent = r.spellMax + spellWish;
					continue;
				}
				skillSpell.scaledPercent = 5 * (int)Math.Floor(num * (double)skillSpell.maxPercent / 5.0);
				skillSpell.scaledPercent = ((skillSpell.scaledPercent == 0 && skillSpell.maxPercent != 0 && charRace.spellCost != 0) ? 5 : skillSpell.scaledPercent);
			}
			return spells;
		}
	}

	public int[] resistances
	{
		get
		{
			int[] array = new int[9];
			for (int i = 0; i < guilds.Count; i++)
			{
				Guild obj = (Guild)guilds[i];
				GuildLevel gL = obj.getGL(obj.level);
				int[] array2;
				(array2 = array)[0] = array2[0] + gL.acid;
				(array2 = array)[1] = array2[1] + gL.asp;
				(array2 = array)[2] = array2[2] + gL.cold;
				(array2 = array)[3] = array2[3] + gL.elec;
				(array2 = array)[4] = array2[4] + gL.fire;
				(array2 = array)[5] = array2[5] + gL.mag;
				(array2 = array)[6] = array2[6] + gL.phys;
				(array2 = array)[7] = array2[7] + gL.pois;
				(array2 = array)[8] = array2[8] + gL.psi;
			}
			if (thickSkin)
			{
				array[6] += 5;
			}
			if (resistAcid)
			{
				array[0] += 5;
			}
			if (resistAsp)
			{
				array[1] += 5;
			}
			if (resistCold)
			{
				array[2] += 5;
			}
			if (resistElec)
			{
				array[3] += 5;
			}
			if (resistFire)
			{
				array[4] += 5;
			}
			if (resistMag)
			{
				array[5] += 5;
			}
			if (resistPois)
			{
				array[7] += 5;
			}
			if (resistPsi)
			{
				array[8] += 5;
			}
			return array;
		}
	}

	public double totalExp
	{
		get
		{
			double num = 0.0;
			IDictionaryEnumerator enumerator = experience.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num += (double)enumerator.Value;
			}
			return num;
		}
	}

	public double skillsExp
	{
		get
		{
			if (experience.ContainsKey("Skills"))
			{
				return (double)experience["Skills"];
			}
			return 0.0;
		}
	}

	public double spellsExp
	{
		get
		{
			if (experience.ContainsKey("Spells"))
			{
				return (double)experience["Spells"];
			}
			return 0.0;
		}
	}

	public double RaceExp
	{
		get
		{
			if (experience.ContainsKey("Race"))
			{
				return (double)experience["Race"];
			}
			return 0.0;
		}
	}

	public double GuildExp
	{
		get
		{
			if (experience.ContainsKey("Guild"))
			{
				return (double)experience["Guild"];
			}
			return 0.0;
		}
	}

	public double statExp
	{
		get
		{
			if (experience.ContainsKey("Stats"))
			{
				return (double)experience["Stats"];
			}
			return 0.0;
		}
	}

	public int gold => (int)((skillsExp + spellsExp) / 2250.0);

	public int qps
	{
		get
		{
			return questpoints;
		}
		set
		{
			questpoints = value;
			updateExperience();
		}
	}

	public int free
	{
		get
		{
			return freelevels;
		}
		set
		{
			if (value > guildlevels)
			{
				freelevels = guildlevels;
			}
			else
			{
				freelevels = value;
			}
			updateExperience();
		}
	}

	public int[] qpArray
	{
		set
		{
			qpCosts = value;
		}
	}

	public int[] lvlArray
	{
		set
		{
			lvlCosts = value;
		}
	}

	public int[] statArray
	{
		set
		{
			statCosts = value;
		}
	}

	public int[] lesserCosts
	{
		set
		{
			lCosts = value;
		}
	}

	public int[] greaterCosts
	{
		set
		{
			gCosts = value;
		}
	}

	public int taskpoints
	{
		get
		{
			int num = 0;
			if (lCosts != null)
			{
				int num2 = ((lesser < lCosts.Length) ? lesser : lCosts.Length);
				for (int i = 0; i < num2; i++)
				{
					num += lCosts[i];
				}
			}
			else
			{
				num += 12345;
			}
			if (gCosts != null)
			{
				int num3 = ((greater < gCosts.Length) ? greater : gCosts.Length);
				for (int j = 0; j < num3; j++)
				{
					num += gCosts[j];
				}
			}
			else
			{
				num += 123456;
			}
			if (ambidexterity)
			{
				num += 500;
			}
			if (elementalAttunement)
			{
				num += 250;
			}
			if (giantSize)
			{
				num += 500;
			}
			if (improvedStr)
			{
				num += 40;
			}
			if (improvedDex)
			{
				num += 40;
			}
			if (improvedCon)
			{
				num += 40;
			}
			if (improvedInt)
			{
				num += 40;
			}
			if (improvedWis)
			{
				num += 40;
			}
			if (improvedCha)
			{
				num += 40;
			}
			if (lucky)
			{
				num += 75;
			}
			if (thickSkin)
			{
				num += 100;
			}
			if (trueSeeing)
			{
				num += 100;
			}
			if (resistAcid)
			{
				num += 150;
			}
			if (resistAsp)
			{
				num += 150;
			}
			if (resistCold)
			{
				num += 150;
			}
			if (resistElec)
			{
				num += 150;
			}
			if (resistFire)
			{
				num += 150;
			}
			if (resistMag)
			{
				num += 150;
			}
			if (resistPois)
			{
				num += 150;
			}
			if (resistPsi)
			{
				num += 150;
			}
			return num;
		}
	}

	public int[] trained
	{
		get
		{
			return new int[6] { trainedStr, trainedInt, trainedWis, trainedCon, trainedDex, trainedCha };
		}
		set
		{
			if (value[0] > 50 || value[0] > r.maxStr / 2)
			{
				trainedStr = Math.Min(r.maxStr / 2, 50);
			}
			else
			{
				trainedStr = value[0];
			}
			if (value[1] > 50 || value[1] > r.maxInt / 2)
			{
				trainedInt = Math.Min(r.maxInt / 2, 50);
			}
			else
			{
				trainedInt = value[1];
			}
			if (value[2] > 50 || value[2] > r.maxWis / 2)
			{
				trainedWis = Math.Min(r.maxWis / 2, 50);
			}
			else
			{
				trainedWis = value[2];
			}
			if (value[3] > 50 || value[3] > r.maxCon / 2)
			{
				trainedCon = Math.Min(r.maxCon / 2, 50);
			}
			else
			{
				trainedCon = value[3];
			}
			if (value[4] > 50 || value[4] > r.maxDex / 2)
			{
				trainedDex = Math.Min(r.maxDex / 2, 50);
			}
			else
			{
				trainedDex = value[4];
			}
			if (value[5] > 50 || value[5] > r.maxCha / 2)
			{
				trainedCha = Math.Min(r.maxCha / 2, 50);
			}
			else
			{
				trainedCha = value[5];
			}
			updateStatExp();
		}
	}

	public int statWishes
	{
		get
		{
			return statWish;
		}
		set
		{
			statWish = ((value >= 0) ? value : 0);
		}
	}

	public int lesserWishes
	{
		get
		{
			return lesser;
		}
		set
		{
			lesser = ((value >= 0) ? value : 0);
		}
	}

	public int greaterWishes
	{
		get
		{
			return greater;
		}
		set
		{
			greater = ((value >= 0) ? value : 0);
		}
	}

	public int magWishes
	{
		get
		{
			return magWish;
		}
		set
		{
			magWish = value;
		}
	}

	public int physWishes
	{
		get
		{
			return physWish;
		}
		set
		{
			physWish = value;
		}
	}

	public bool Ambidexterity
	{
		get
		{
			return ambidexterity;
		}
		set
		{
			ambidexterity = value;
		}
	}

	public bool ElementalAttunement
	{
		get
		{
			return elementalAttunement;
		}
		set
		{
			elementalAttunement = value;
		}
	}

	public bool GiantSize
	{
		get
		{
			return giantSize;
		}
		set
		{
			giantSize = value;
		}
	}

	public bool ImprovedStr
	{
		get
		{
			return improvedStr;
		}
		set
		{
			improvedStr = value;
		}
	}

	public bool ImprovedDex
	{
		get
		{
			return improvedDex;
		}
		set
		{
			improvedDex = value;
		}
	}

	public bool ImprovedCon
	{
		get
		{
			return improvedCon;
		}
		set
		{
			improvedCon = value;
		}
	}

	public bool ImprovedInt
	{
		get
		{
			return improvedInt;
		}
		set
		{
			improvedInt = value;
		}
	}

	public bool ImprovedWis
	{
		get
		{
			return improvedWis;
		}
		set
		{
			improvedWis = value;
		}
	}

	public bool ImprovedCha
	{
		get
		{
			return improvedCha;
		}
		set
		{
			improvedCha = value;
		}
	}

	public bool Lucky
	{
		get
		{
			return lucky;
		}
		set
		{
			lucky = value;
		}
	}

	public bool LesserStatsWish
	{
		get
		{
			return lesserStatsWish;
		}
		set
		{
			lesserStatsWish = value;
		}
	}

	public bool SuperiorStatsWish
	{
		get
		{
			return superiorStatsWish;
		}
		set
		{
			superiorStatsWish = value;
		}
	}

	public bool ThickSkin
	{
		get
		{
			return thickSkin;
		}
		set
		{
			thickSkin = value;
		}
	}

	public bool TrueSeeing
	{
		get
		{
			return trueSeeing;
		}
		set
		{
			trueSeeing = value;
		}
	}

	public int ResistWishes
	{
		get
		{
			return resistWishes;
		}
		set
		{
			resistWishes = ((value >= 0) ? value : 0);
		}
	}

	public int BattleRegenWishes
	{
		get
		{
			return battleRegenWishes;
		}
		set
		{
			battleRegenWishes = value;
		}
	}

	public int EnduranceWishes
	{
		get
		{
			return enduranceWishes;
		}
		set
		{
			enduranceWishes = value;
		}
	}

	public int ReservesWishes
	{
		get
		{
			return reservesWishes;
		}
		set
		{
			reservesWishes = value;
		}
	}

	public int SpellDamageWishes
	{
		get
		{
			return spellDamageWishes;
		}
		set
		{
			spellDamageWishes = value;
		}
	}

	public bool ResistAcid
	{
		get
		{
			return resistAcid;
		}
		set
		{
			resistAcid = value;
		}
	}

	public bool ResistAsp
	{
		get
		{
			return resistAsp;
		}
		set
		{
			resistAsp = value;
		}
	}

	public bool ResistCold
	{
		get
		{
			return resistCold;
		}
		set
		{
			resistCold = value;
		}
	}

	public bool ResistElec
	{
		get
		{
			return resistElec;
		}
		set
		{
			resistElec = value;
		}
	}

	public bool ResistFire
	{
		get
		{
			return resistFire;
		}
		set
		{
			resistFire = value;
		}
	}

	public bool ResistMag
	{
		get
		{
			return resistMag;
		}
		set
		{
			resistMag = value;
		}
	}

	public bool ResistPois
	{
		get
		{
			return resistPois;
		}
		set
		{
			resistPois = value;
		}
	}

	public bool ResistPsi
	{
		get
		{
			return resistPsi;
		}
		set
		{
			resistPsi = value;
		}
	}

	public int qpsneeded
	{
		get
		{
			int num = 0;
			for (int i = 0; i < guilds.Count; i++)
			{
				Guild guild = (Guild)guilds[i];
				num += guild.level;
			}
			num += freelevels;
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				num2 += qpCosts[j];
			}
			return num2;
		}
	}

	public Character()
	{
		Guilds = new ArrayList();
		skills = new ArrayList();
		spells = new ArrayList();
		experience = new Hashtable();
		guildlevels = 120;
		qpCosts = new int[120];
		lvlCosts = new int[120];
		trainedStr = 0;
		trainedDex = 0;
		trainedCon = 0;
		trainedWis = 0;
		trainedInt = 0;
		trainedCha = 0;
		statWish = 0;
		skillWish = 0;
		spellWish = 0;
		lesser = 0;
		greater = 0;
		ambidexterity = false;
		elementalAttunement = false;
		giantSize = false;
		improvedStr = false;
		improvedDex = false;
		improvedCon = false;
		improvedInt = false;
		improvedWis = false;
		improvedCha = false;
		lucky = false;
		thickSkin = false;
		trueSeeing = false;
		resistWishes = 0;
		battleRegenWishes = 0;
		enduranceWishes = 0;
	}

	public double getExperience(ArrayList list)
	{
		double num = 0.0;
		for (int i = 0; i < list.Count; i++)
		{
			SkillSpell skillSpell = (SkillSpell)list[i];
			num += skillSpell.experience;
		}
		return num;
	}

	public void updateExperience()
	{
		int num = 0;
		for (int i = 0; i < guilds.Count; i++)
		{
			Guild guild = (Guild)guilds[i];
			num += guild.level;
		}
		int num2 = freelevels + num;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = qps;
		int num6 = num2;
		if (qpCosts != null && num2 > qpCosts.Length)
		{
			num6 = qpCosts.Length;
		}
		if (lvlCosts != null && num2 > lvlCosts.Length)
		{
			num6 = Math.Min(num6, lvlCosts.Length);
		}
		for (int j = 0; j < num6; j++)
		{
			if (qpCosts != null && j < qpCosts.Length && qpCosts[j] <= num5)
			{
				num5 -= qpCosts[j];
				if (lvlCosts != null && j < lvlCosts.Length)
				{
					num3 += (double)lvlCosts[j] * 0.75 - (double)lvlCosts[j] * 0.75 % 100.0;
				}
			}
			else if (lvlCosts != null && j < lvlCosts.Length)
			{
				num3 += (double)lvlCosts[j];
			}
			if (j < num && lvlCosts != null && j < lvlCosts.Length)
			{
				num4 += (double)lvlCosts[j] * 0.4 - (double)lvlCosts[j] * 0.4 % 100.0;
			}
		}
		if (experience.ContainsKey("Race"))
		{
			experience["Race"] = num3;
		}
		else
		{
			experience.Add("Race", num3);
		}
		if (experience.ContainsKey("Guild"))
		{
			experience["Guild"] = num4;
		}
		else
		{
			experience.Add("Guild", num4);
		}
		if (experience.ContainsKey("Skills"))
		{
			experience["Skills"] = getExperience(skills);
		}
		else
		{
			experience.Add("Skills", getExperience(skills));
		}
		if (experience.ContainsKey("Spells"))
		{
			experience["Spells"] = getExperience(spells);
		}
		else
		{
			experience.Add("Spells", getExperience(spells));
		}
		updateStatExp();
	}

	public void updateStatExp()
	{
		double num = 0.0;
		if (statCosts != null)
		{
			int num2 = ((trainedStr < statCosts.Length) ? trainedStr : statCosts.Length);
			for (int i = 0; i < num2; i++)
			{
				num += (double)statCosts[i];
			}
			int num3 = ((trainedInt < statCosts.Length) ? trainedInt : statCosts.Length);
			for (int j = 0; j < num3; j++)
			{
				num += (double)statCosts[j];
			}
			int num4 = ((trainedWis < statCosts.Length) ? trainedWis : statCosts.Length);
			for (int k = 0; k < num4; k++)
			{
				num += (double)statCosts[k];
			}
			int num5 = ((trainedCon < statCosts.Length) ? trainedCon : statCosts.Length);
			for (int l = 0; l < num5; l++)
			{
				num += (double)statCosts[l];
			}
			int num6 = ((trainedDex < statCosts.Length) ? trainedDex : statCosts.Length);
			for (int m = 0; m < num6; m++)
			{
				num += (double)statCosts[m];
			}
			int num7 = ((trainedCha < statCosts.Length) ? trainedCha : statCosts.Length);
			for (int n = 0; n < num7; n++)
			{
				num += (double)statCosts[n];
			}
		}
		if (experience.ContainsKey("Stats"))
		{
			experience["Stats"] = num;
		}
		else
		{
			experience.Add("Stats", num);
		}
	}

	public void addGuild(Guild g, int newLevel)
	{
		if (newLevel == 0)
		{
			g.level = newLevel;
			Guilds.Remove(g);
		}
		else if (g.parent != null)
		{
			if (g.updateSubGuildInfo(newLevel, guildlevels - freelevels) && !Guilds.Contains(g) && g.level > 0)
			{
				Guilds.Add(g);
			}
		}
		else
		{
			if (newLevel - g.level > guildlevels - freelevels)
			{
				newLevel = g.level + (guildlevels - freelevels);
			}
			g.level = newLevel;
			if (!Guilds.Contains(g) && g.level != 0)
			{
				Guilds.Add(g);
			}
		}
		guilds = sortGuilds(guilds, trained: true);
	}

	public void resetSkillsSpells(ArrayList sk, ArrayList sp)
	{
		skills = new ArrayList();
		spells = new ArrayList();
		for (int i = 0; i < sk.Count; i++)
		{
			((SkillSpell)sk[i]).maxPercent = 0;
		}
		for (int j = 0; j < sp.Count; j++)
		{
			((SkillSpell)sp[j]).maxPercent = 0;
		}
		for (int k = 0; k < guilds.Count; k++)
		{
			addSkillsSpells((Guild)guilds[k], sk, sp);
		}
	}

	public void addSkillsSpells(Guild g, ArrayList skills, ArrayList spells)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		GuildLevel gL = g.getGL(g.level);
		IDictionaryEnumerator enumerator = gL.getSkills().GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text = (string)enumerator.Key;
			SkillSpell skillSpell = new SkillSpell(text, 0);
			if (skills.Contains(skillSpell))
			{
				SkillSpell skillSpell2 = (SkillSpell)skills[skills.IndexOf(skillSpell)];
				skillSpell2.maxPercent = Math.Max(skillSpell2.maxPercent, (int)enumerator.Value);
				if (!this.skills.Contains(skillSpell))
				{
					this.skills.Add(skillSpell2);
				}
			}
			else
			{
				arrayList.Add(text);
			}
		}
		enumerator = gL.getSpells().GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text2 = (string)enumerator.Key;
			SkillSpell skillSpell3 = new SkillSpell(text2, 0);
			if (spells.Contains(skillSpell3))
			{
				SkillSpell skillSpell4 = (SkillSpell)spells[spells.IndexOf(skillSpell3)];
				skillSpell4.maxPercent = Math.Max(skillSpell4.maxPercent, (int)enumerator.Value);
				if (!this.spells.Contains(skillSpell3))
				{
					this.spells.Add(skillSpell4);
				}
			}
			else
			{
				arrayList2.Add(text2);
			}
		}
		this.skills.Sort();
		this.spells.Sort();
	}

	public ArrayList sortGuilds(ArrayList start, bool trained)
	{
		guildlevels = 120;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < start.Count; i++)
		{
			Guild guild = (Guild)start[i];
			guildlevels -= guild.level;
			if (guild.parent == null)
			{
				arrayList.Add(guild);
			}
		}
		arrayList.Sort();
		ArrayList arrayList2 = new ArrayList(start.Count);
		for (int j = 0; j < arrayList.Count; j++)
		{
			Guild guild2 = (Guild)arrayList[j];
			arrayList2.Add(guild2);
			ArrayList allSubs = getAllSubs(guild2, trained);
			for (int k = 0; k < guild2.subs.Count; k++)
			{
				Guild guild3 = (Guild)guild2.subs[k];
				if (!start.Contains(guild3))
				{
					allSubs.Remove(guild3);
				}
			}
			allSubs.Sort();
			arrayList2.AddRange(allSubs);
		}
		return arrayList2;
	}

	public ArrayList getAllSubs(Guild g, bool trained)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < g.subs.Count; i++)
		{
			Guild guild = (Guild)g.subs[i];
			if (!arrayList.Contains(guild))
			{
				arrayList.Add(guild);
			}
			if (!guild.subsAvailable())
			{
				continue;
			}
			ArrayList allSubs = getAllSubs(guild, trained);
			for (int j = 0; j < allSubs.Count; j++)
			{
				Guild guild2 = (Guild)allSubs[j];
				if (!arrayList.Contains(guild2))
				{
					arrayList.Add(guild2);
				}
			}
		}
		if (trained)
		{
			for (int k = 0; k < arrayList.Count; k++)
			{
				Guild guild3 = (Guild)arrayList[k];
				if (!guilds.Contains(guild3))
				{
					arrayList.Remove(guild3);
				}
			}
		}
		return arrayList;
	}

	public int[] charInfo()
	{
		int[] array = new int[10];
		int[] array2;
		for (int i = 0; i < Guilds.Count; i++)
		{
			Guild guild = (Guild)Guilds[i];
			if (guild.level != 0)
			{
				GuildLevel gL = guild.getGL(guild.level);
				(array2 = array)[0] = array2[0] + gL.hp;
				(array2 = array)[1] = array2[1] + gL.sp;
				(array2 = array)[2] = array2[2] + gL.hpr;
				(array2 = array)[3] = array2[3] + gL.spr;
				(array2 = array)[4] = array2[4] + gL.str;
				(array2 = array)[5] = array2[5] + gL.intel;
				(array2 = array)[6] = array2[6] + gL.con;
				(array2 = array)[7] = array2[7] + gL.wis;
				(array2 = array)[8] = array2[8] + gL.dex;
				(array2 = array)[9] = array2[9] + gL.cha;
			}
		}
		(array2 = array)[2] = array2[2] + r.hpregen;
		(array2 = array)[3] = array2[3] + r.spregen;
		int num = (improvedStr ? (r.maxStr / 10) : 0);
		int num2 = (improvedInt ? (r.maxInt / 10) : 0);
		int num3 = (improvedCon ? (r.maxCon / 10) : 0);
		int num4 = (improvedWis ? (r.maxWis / 10) : 0);
		int num5 = (improvedDex ? (r.maxDex / 10) : 0);
		int num6 = (improvedCha ? (r.maxCha / 10) : 0);
		int lesserStatsBonus = (lesserStatsWish ? ((int)Math.Floor((double)r.maxStr * 0.05)) : 0);
		int lesserStatsBonusInt = (lesserStatsWish ? ((int)Math.Floor((double)r.maxInt * 0.05)) : 0);
		int lesserStatsBonusCon = (lesserStatsWish ? ((int)Math.Floor((double)r.maxCon * 0.05)) : 0);
		int lesserStatsBonusWis = (lesserStatsWish ? ((int)Math.Floor((double)r.maxWis * 0.05)) : 0);
		int lesserStatsBonusDex = (lesserStatsWish ? ((int)Math.Floor((double)r.maxDex * 0.05)) : 0);
		int lesserStatsBonusCha = (lesserStatsWish ? ((int)Math.Floor((double)r.maxCha * 0.05)) : 0);
		int superiorStatsBonus = (superiorStatsWish ? ((int)Math.Floor((double)r.maxStr * 0.10)) : 0);
		int superiorStatsBonusInt = (superiorStatsWish ? ((int)Math.Floor((double)r.maxInt * 0.10)) : 0);
		int superiorStatsBonusCon = (superiorStatsWish ? ((int)Math.Floor((double)r.maxCon * 0.10)) : 0);
		int superiorStatsBonusWis = (superiorStatsWish ? ((int)Math.Floor((double)r.maxWis * 0.10)) : 0);
		int superiorStatsBonusDex = (superiorStatsWish ? ((int)Math.Floor((double)r.maxDex * 0.10)) : 0);
		int superiorStatsBonusCha = (superiorStatsWish ? ((int)Math.Floor((double)r.maxCha * 0.10)) : 0);
		int effectiveBasePercentStr = r.maxStr + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		int effectiveBasePercentInt = r.maxInt + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		int effectiveBasePercentCon = r.maxCon + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		int effectiveBasePercentWis = r.maxWis + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		int effectiveBasePercentDex = r.maxDex + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		int effectiveBasePercentCha = r.maxCha + (lesserStatsWish ? 5 : 0) + (superiorStatsWish ? 10 : 0);
		array[4] = r.maxStr + (int)Math.Floor((double)effectiveBasePercentStr / 100.0 * (double)array[4]) + trainedStr + num + lesserStatsBonus + superiorStatsBonus;
		array[5] = r.maxInt + (int)Math.Floor((double)effectiveBasePercentInt / 100.0 * (double)array[5]) + trainedInt + num2 + lesserStatsBonusInt + superiorStatsBonusInt;
		array[6] = r.maxCon + (int)Math.Floor((double)effectiveBasePercentCon / 100.0 * (double)array[6]) + trainedCon + num3 + lesserStatsBonusCon + superiorStatsBonusCon;
		array[7] = r.maxWis + (int)Math.Floor((double)effectiveBasePercentWis / 100.0 * (double)array[7]) + trainedWis + num4 + lesserStatsBonusWis + superiorStatsBonusWis;
		array[8] = r.maxDex + (int)Math.Floor((double)effectiveBasePercentDex / 100.0 * (double)array[8]) + trainedDex + num5 + lesserStatsBonusDex + superiorStatsBonusDex;
		array[9] = r.maxCha + (int)Math.Floor((double)effectiveBasePercentCha / 100.0 * (double)array[9]) + trainedCha + num6 + lesserStatsBonusCha + superiorStatsBonusCha;
		(array2 = array)[0] = array2[0] + (3 * array[6] + 2 * (r.size + statWish / 15));
		(array2 = array)[1] = array2[1] + (4 * array[5] + 3 * array[7]);
		if (physWish % 2 == 1)
		{
			(array2 = array)[0] = array2[0] + (int)Math.Floor(0.5 * (1.5 * (double)r.maxCon + (double)charRace.size + 50.0));
		}
		if (physWish > 1)
		{
			(array2 = array)[0] = array2[0] + (int)Math.Floor(1.5 * (double)r.maxCon + (double)charRace.size + 50.0);
		}
		if (magWish % 2 == 1)
		{
			(array2 = array)[1] = array2[1] + (int)Math.Floor(0.75 * (double)r.maxInt + 0.5 * (double)r.maxWis + 50.0);
		}
		if (magWish > 1)
		{
			(array2 = array)[1] = array2[1] + (int)Math.Floor(1.5 * (double)r.maxInt + (double)r.maxWis + 100.0);
		}
		if (battleRegenWishes % 2 == 1)
		{
			(array2 = array)[3] = array2[3] + 1;
		}
		if (battleRegenWishes > 1)
		{
			(array2 = array)[3] = array2[3] + 2;
		}
		return array;
	}
}
