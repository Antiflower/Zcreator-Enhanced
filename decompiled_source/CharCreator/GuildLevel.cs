using System;
using System.Collections;

namespace CharCreator;

public class GuildLevel
{
	public int level;

	public int intel;

	public int str;

	public int dex;

	public int con;

	public int wis;

	public int cha;

	public int hp;

	public int sp;

	public int hpr;

	public int spr;

	public int acid;

	public int asp;

	public int cold;

	public int elec;

	public int fire;

	public int mag;

	public int phys;

	public int pois;

	public int psi;

	private Hashtable skillMax;

	private Hashtable spellMax;

	public GuildLevel(int level)
	{
		this.level = level;
		intel = 0;
		str = 0;
		dex = 0;
		con = 0;
		wis = 0;
		cha = 0;
		hp = 0;
		sp = 0;
		hpr = 0;
		spr = 0;
		acid = 0;
		asp = 0;
		cold = 0;
		elec = 0;
		fire = 0;
		mag = 0;
		phys = 0;
		pois = 0;
		psi = 0;
		skillMax = new Hashtable();
		spellMax = new Hashtable();
	}

	public GuildLevel(GuildLevel gl)
	{
		level = gl.level + 1;
		intel = gl.intel;
		str = gl.str;
		dex = gl.dex;
		con = gl.con;
		wis = gl.wis;
		cha = gl.cha;
		hp = gl.hp;
		sp = gl.sp;
		hpr = gl.hpr;
		spr = gl.spr;
		acid = gl.acid;
		asp = gl.asp;
		cold = gl.cold;
		elec = gl.elec;
		fire = gl.fire;
		mag = gl.mag;
		phys = gl.phys;
		pois = gl.pois;
		psi = gl.psi;
		skillMax = new Hashtable();
		spellMax = new Hashtable();
	}

	public void updateSkillsSpells(GuildLevel gl)
	{
		IDictionaryEnumerator enumerator = gl.skillMax.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string key = (string)enumerator.Key;
			int num = (int)enumerator.Value;
			if (skillMax.ContainsKey(key))
			{
				skillMax[key] = Math.Max(num, (int)skillMax[key]);
			}
			else
			{
				skillMax.Add(key, num);
			}
		}
		enumerator = gl.spellMax.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string key2 = (string)enumerator.Key;
			int num2 = (int)enumerator.Value;
			if (spellMax.ContainsKey(key2))
			{
				spellMax[key2] = Math.Max(num2, (int)spellMax[key2]);
			}
			else
			{
				spellMax.Add(key2, num2);
			}
		}
	}

	public void parseAndSet(string src)
	{
		src.ToLower();
		int num = int.Parse(src.Substring(src.IndexOf("(") + 1, src.IndexOf(")") - src.IndexOf("(") - 1));
		if (src.StartsWith("int"))
		{
			intel += num;
		}
		else if (src.StartsWith("str"))
		{
			str += num;
		}
		else if (src.StartsWith("dex"))
		{
			dex += num;
		}
		else if (src.StartsWith("con"))
		{
			con += num;
		}
		else if (src.StartsWith("wis"))
		{
			wis += num;
		}
		else if (src.StartsWith("cha"))
		{
			cha += num;
		}
		else if (src.StartsWith("hit point r") || src.StartsWith("hp_r"))
		{
			hpr += num;
		}
		else if (src.StartsWith("spell point r") || src.StartsWith("sp_r"))
		{
			spr += num;
		}
		else if (src.StartsWith("hit points") || src.StartsWith("hp"))
		{
			hp += num;
		}
		else if (src.StartsWith("spell points") || src.StartsWith("sp"))
		{
			sp += num;
		}
		else if (src.StartsWith("acid"))
		{
			acid += num;
		}
		else if (src.StartsWith("asp"))
		{
			asp += num;
		}
		else if (src.StartsWith("cold"))
		{
			cold += num;
		}
		else if (src.StartsWith("elec"))
		{
			elec += num;
		}
		else if (src.StartsWith("fire"))
		{
			fire += num;
		}
		else if (src.StartsWith("magical"))
		{
			mag += num;
		}
		else if (src.StartsWith("phys"))
		{
			phys += num;
		}
		else if (src.StartsWith("poison"))
		{
			pois += num;
		}
		else if (src.StartsWith("psi"))
		{
			psi += num;
		}
	}

	public void addSpell(string name, int percentage)
	{
		if (spellMax.ContainsKey(name))
		{
			spellMax[name] = percentage;
		}
		else
		{
			spellMax.Add(name, percentage);
		}
	}

	public void addSkill(string name, int percentage)
	{
		if (skillMax.ContainsKey(name))
		{
			skillMax[name] = percentage;
		}
		else
		{
			skillMax.Add(name, percentage);
		}
	}

	public Hashtable getSkills()
	{
		return skillMax;
	}

	public Hashtable getSpells()
	{
		return spellMax;
	}

	public ArrayList sortedSkills()
	{
		ArrayList arrayList = new ArrayList(getSkills().Keys);
		arrayList.Sort();
		return arrayList;
	}

	public ArrayList sortedSpells()
	{
		ArrayList arrayList = new ArrayList(getSpells().Keys);
		arrayList.Sort();
		return arrayList;
	}
}
