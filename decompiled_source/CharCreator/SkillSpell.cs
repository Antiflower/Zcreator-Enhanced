using System;
using System.Collections;

namespace CharCreator;

public class SkillSpell : IComparable
{
	private string name;

	private string description;

	private string type;

	private string rawText;

	private int percentage;

	private int scaled;

	private int learnedPercent;

	private double exp;

	private int sscost;

	private int maxcost;

	private int damage;

	private int usageTime;

	private int startingCost;

	private int[] costs;

	private ArrayList related;

	private bool privSS;

	private bool inte;

	private bool wis;

	private bool str;

	private bool dex;

	private bool con;

	private bool cha;

	private bool level;

	public double experience
	{
		get
		{
			updateExp();
			return exp;
		}
	}

	public SkillSpell SS => this;

	public string SSType
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	public int[] costArray => costs;

	public string SSName => name;

	public string SSNamePercent
	{
		get
		{
			string text = name;
			for (int i = text.Length; i <= 30; i++)
			{
				text += " ";
			}
			for (int j = ((learned != 0) ? ((int)Math.Log10(learned)) : 0); j < 2; j++)
			{
				text += " ";
			}
			object obj = text;
			return string.Concat(obj, learned, " / ", scaled);
		}
	}

	public string SaveString
	{
		get
		{
			string text = name + ": ";
			for (int i = text.Length; i <= 30; i++)
			{
				text += " ";
			}
			return text + learned;
		}
	}

	public string Descript
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}

	public int startCost
	{
		get
		{
			return startingCost;
		}
		set
		{
			startingCost = value;
		}
	}

	public int maxPercent
	{
		get
		{
			return percentage;
		}
		set
		{
			percentage = value;
		}
	}

	public int scaledPercent
	{
		get
		{
			return scaled;
		}
		set
		{
			scaled = value;
		}
	}

	public int learned
	{
		get
		{
			if (learnedPercent <= scaled)
			{
				return learnedPercent;
			}
			return scaled;
		}
		set
		{
			learnedPercent = value;
		}
	}

	public string raw
	{
		get
		{
			return rawText;
		}
		set
		{
			rawText = value;
		}
	}

	public bool privateSS
	{
		get
		{
			return privSS;
		}
		set
		{
			privSS = value;
		}
	}

	public SkillSpell(string name, int starting)
	{
		this.name = name;
		startingCost = starting;
		costs = new int[20];
		percentage = 0;
		exp = 0.0;
	}

	public override bool Equals(object obj)
	{
		SkillSpell skillSpell = (SkillSpell)obj;
		return name == skillSpell.name;
	}

	public int CompareTo(object obj)
	{
		if (obj is SkillSpell)
		{
			SkillSpell skillSpell = (SkillSpell)obj;
			return name.CompareTo(skillSpell.name);
		}
		throw new ArgumentException("object is not a SkillSpell object");
	}

	public void setCosts(int skillCost, int[] costs)
	{
		int num = skillCost * 100000;
		for (int i = 0; i < 20; i++)
		{
			float num2 = startCost * costs[i];
			num2 = ((num2 < 100f) ? num2 : (num2 - num2 % 100f));
			float num3 = num2 * (float)skillCost / 100f;
			num2 = ((num3 > (float)num || 0f > num2) ? ((float)num) : num3);
			if (num2 < 100f)
			{
				num2 = 100f;
			}
			num2 += ((num2 % 5f == 0f) ? 0f : (5f - num2 % 5f));
			this.costs[i] = (int)num2;
		}
		maxcost = num;
		updateExp();
	}

	public void updateExp()
	{
		exp = 0.0;
		int num = ((learnedPercent > scaledPercent) ? (scaledPercent / 5) : (learnedPercent / 5));
		if (num > 0)
		{
			for (int i = 0; i < num && i < costs.Length; i++)
			{
				exp += costs[i] - costs[i] % 100;
			}
		}
		if (num > costs.Length)
		{
			int num2 = num - costs.Length;
			for (int j = 0; j < num2; j++)
			{
				exp += maxcost;
			}
		}
	}
}
