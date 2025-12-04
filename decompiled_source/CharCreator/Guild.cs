using System;
using System.Collections;
using System.IO;
using StringTok;

namespace CharCreator;

public class Guild : IComparable
{
	private bool loaded;

	private string guildname;

	private string filename;

	private int guildlevel;

	private int maxLevels;

	private ArrayList guildlevels;

	private ArrayList subguilds;

	public Guild parent;

	private int subguildNeeded;

	private int availSubLevels;

	private int subguildlevels;

	private ArrayList notGuilds;

	private ArrayList notRaces;

	private bool privateGuild;

	public bool isPrivate => privateGuild;

	public string GuildName => guildname;

	public string GuildString
	{
		get
		{
			string text = getStr;
			for (int i = text.Length; i <= 26; i++)
			{
				text += " ";
			}
			if (level < 10)
			{
				text += " ";
			}
			if (level != 0)
			{
				text += level;
			}
			return text;
		}
	}

	public string SaveGuildString
	{
		get
		{
			string text = getStr;
			for (int i = text.Length; i <= 40; i++)
			{
				text += " ";
			}
			if (level < 10)
			{
				text += " ";
			}
			if (level != 0)
			{
				text += level;
			}
			return text;
		}
	}

	public string getStr
	{
		get
		{
			string text = GuildName;
			if (parent != null)
			{
				text = " - " + text;
			}
			return text;
		}
	}

	public int availLevels
	{
		get
		{
			if (level == 0)
			{
				return subguildNeeded;
			}
			return maxLevels - level;
		}
	}

	public int maxLvls => maxLevels;

	public int level
	{
		get
		{
			return guildlevel;
		}
		set
		{
			if (parent != null)
			{
				updateSubLevels(value - guildlevel);
			}
			guildlevel = value;
		}
	}

	public ArrayList subs
	{
		get
		{
			return subguilds;
		}
		set
		{
			subguilds = value;
		}
	}

	public ArrayList nRaces
	{
		get
		{
			ArrayList arrayList = new ArrayList(notRaces);
			for (int i = 0; i < subguilds.Count; i++)
			{
				Guild guild = (Guild)subguilds[i];
				if (guild.level <= 0)
				{
					continue;
				}
				for (int j = 0; j < guild.nRaces.Count; j++)
				{
					Race race = (Race)guild.nRaces[j];
					if (!arrayList.Contains(race))
					{
						arrayList.Add(race);
					}
				}
			}
			return arrayList;
		}
	}

	public ArrayList nGuilds
	{
		get
		{
			ArrayList arrayList = new ArrayList(notGuilds);
			for (int i = 0; i < subguilds.Count; i++)
			{
				Guild guild = (Guild)subguilds[i];
				if (guild.level <= 0)
				{
					continue;
				}
				for (int j = 0; j < guild.nRaces.Count; j++)
				{
					Guild guild2 = (Guild)guild.nGuilds[j];
					if (!arrayList.Contains(guild2))
					{
						arrayList.Add(guild2);
					}
				}
			}
			return arrayList;
		}
	}

	public Guild(string guildname, bool priv, int max)
	{
		loaded = false;
		privateGuild = priv;
		this.guildname = guildname.Replace("_", " ");
		filename = guildname.ToLower() + ".chr";
		maxLevels = max;
		subguilds = new ArrayList();
		guildlevels = new ArrayList(maxLevels);
		parent = null;
		subguildlevels = 0;
		availSubLevels = 15;
		subguildNeeded = max;
		notGuilds = new ArrayList();
		notRaces = new ArrayList();
	}

	public Guild(string guildname, bool priv, int max, Guild parent)
		: this(guildname, priv, max)
	{
		this.parent = parent;
		availSubLevels = this.parent.availSubLevels - level;
	}

	public bool updateSubGuildInfo(int newLevel, int overallAvail)
	{
		availSubLevels = parent.availSubLevels + level - subguildlevels;
		if ((availSubLevels > 0 || level > newLevel) && overallAvail > 0)
		{
			if (newLevel - level > overallAvail)
			{
				newLevel = overallAvail + level;
			}
			if (newLevel - level > parent.availSubLevels)
			{
				level = availSubLevels;
			}
			else
			{
				level = newLevel;
			}
			return true;
		}
		return false;
	}

	public void loadLevels(string path, ArrayList guilds)
	{
		int num = 0;
		if (loaded)
		{
			return;
		}
		try
		{
			StreamReader streamReader = File.OpenText(path + filename);
			string text = streamReader.ReadLine();
			GuildLevel guildLevel = new GuildLevel(0);
			while (text != null && !text.StartsWith("Level"))
			{
				if (text.StartsWith("--More--"))
				{
					text = streamReader.ReadLine();
					while (text.Equals(""))
					{
						text = streamReader.ReadLine();
					}
				}
				StringTokenizer stringTokenizer = new StringTokenizer(text.ToLower(), ",|.");
				string s = stringTokenizer.NextToken().Trim();
				int num2;
				try
				{
					num2 = int.Parse(s);
				}
				catch (Exception)
				{
					num2 = -1;
				}
				if (num2 == num + 1)
				{
					guildLevel = new GuildLevel(guildLevel);
					num++;
					guildlevels.Add(guildLevel);
				}
				if (guildLevel.level != 0)
				{
					while (stringTokenizer.HasMoreTokens())
					{
						s = stringTokenizer.NextToken().Trim();
						while (s.Length != 0 && s.IndexOf(")") == -1)
						{
							s += streamReader.ReadLine();
						}
						if (s.Length != 0)
						{
							guildLevel.parseAndSet(s);
						}
					}
				}
				text = streamReader.ReadLine();
			}
			while (!text.StartsWith("Level"))
			{
				text = streamReader.ReadLine();
			}
			int num3 = 0;
			while (text != null && !text.StartsWith("Subguilds") && !text.StartsWith("Not"))
			{
				num3 = int.Parse(text.Substring(6, 2)) - 1;
				text = streamReader.ReadLine();
				while (text.StartsWith("--More--") || text.Equals(""))
				{
					text = streamReader.ReadLine();
				}
				GuildLevel guildLevel2 = (GuildLevel)guildlevels[num3];
				while (!text.StartsWith("---"))
				{
					if (!text.StartsWith("May"))
					{
						text = streamReader.ReadLine();
						while (!text.StartsWith("May") && !text.StartsWith("---"))
						{
							text = streamReader.ReadLine();
						}
						if (text.StartsWith("---"))
						{
							break;
						}
					}
					while (text.IndexOf("%") == -1)
					{
						text += streamReader.ReadLine();
					}
					text = text.ToLower().Trim();
					int num4 = text.LastIndexOf(" to ") - 16;
					string name = text.Substring(16, num4);
					int percentage = int.Parse(text.Substring(20 + num4, text.Length - 20 - num4 - 1));
					if (text.StartsWith("may study"))
					{
						guildLevel2.addSpell(name, percentage);
					}
					else if (text.StartsWith("may train"))
					{
						guildLevel2.addSkill(name, percentage);
					}
					text = streamReader.ReadLine();
				}
				while (text != null && !text.StartsWith("Level") && !text.StartsWith("Subguilds") && !text.StartsWith("Not"))
				{
					text = streamReader.ReadLine();
				}
			}
			if (text != null)
			{
				while (text != null)
				{
					text = text.ToLower();
					while (text != null && !text.StartsWith("not") && !text.StartsWith("subguilds"))
					{
						text = streamReader.ReadLine().ToLower();
					}
					if (text != null && text.IndexOf("subguild") != -1)
					{
						text = streamReader.ReadLine();
						while (text != null && !text.Equals("") && !text.StartsWith("Not"))
						{
							int num5 = text.IndexOf(" ");
							Guild guild = new Guild(text.Substring(0, num5), privateGuild, int.Parse(text.Substring(num5 + 1)), this);
							if (guild.GuildName == GuildName)
							{
								maxLevels += guild.availLevels;
							}
							else if (!guilds.Contains(guild))
							{
								subguilds.Add(guild);
							}
							else
							{
								Guild guild2 = (Guild)guilds[guilds.IndexOf(guild)];
								guild2.maxLevels = Math.Max(guild2.maxLevels, guild.maxLevels);
								guild2.level = Math.Max(guild2.level, guild.level);
								subguilds.Add(guild2);
							}
							text = streamReader.ReadLine();
						}
					}
					else if (text != null && text.IndexOf("guild") != -1)
					{
						text = streamReader.ReadLine();
						while (text != null && !text.Equals("") && !text.StartsWith("Not"))
						{
							Guild value = new Guild(text.Trim(), privateGuild, 0);
							notGuilds.Add(value);
							text = streamReader.ReadLine();
						}
					}
					else if (text != null && text.IndexOf("race") != -1)
					{
						text = streamReader.ReadLine();
						while (text != null && !text.Equals("") && !text.StartsWith("Not"))
						{
							Race value2 = new Race(text.Trim());
							notRaces.Add(value2);
							text = streamReader.ReadLine();
						}
					}
				}
			}
		}
		catch (Exception)
		{
			Console.WriteLine("hello");
		}
		loaded = true;
		updateSkillSpells();
	}

	public int CompareTo(object g)
	{
		if (g is Guild)
		{
			Guild guild = (Guild)g;
			return GuildName.CompareTo(guild.GuildName);
		}
		throw new ArgumentException("object is not a guild object");
	}

	public override bool Equals(object obj)
	{
		if (obj is Guild)
		{
			Guild guild = (Guild)obj;
			return GuildName.Equals(guild.GuildName);
		}
		throw new ArgumentException("object is not a guild object");
	}

	public void updateSubLevels(int delta)
	{
		if (parent != null)
		{
			parent.updateSubLevels(delta);
		}
		subguildlevels += delta;
		availSubLevels -= delta;
	}

	public bool subsAvailable()
	{
		return subguildNeeded <= guildlevel;
	}

	public GuildLevel getGL(int level)
	{
		if (!loaded)
		{
			return null;
		}
		return (GuildLevel)guildlevels[level - 1];
	}

	public void updateSkillSpells()
	{
		for (int i = 1; i < guildlevels.Count; i++)
		{
			GuildLevel gl = (GuildLevel)guildlevels[i - 1];
			((GuildLevel)guildlevels[i]).updateSkillsSpells(gl);
		}
	}

	public bool rootGuild()
	{
		return parent == null;
	}
}
