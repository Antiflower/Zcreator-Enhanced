using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CharCreator;

public class GuildDisplay : Form
{
	private Label label1;

	private Label label2;

	private ComboBox skillsDD;

	private ComboBox spellsDD;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Label label3;

	private Button calcButton;

	private TextBox levelsTB;

	private Guild g;

	private bool loading = true;

	private GroupBox groupBox3;

	private Label maxLbl;

	private Label strLbl;

	private Label intLbl;

	private Label dexLbl;

	private Label chaLbl;

	private Label conLbl;

	private Label wisLbl;

	private Label hpLbl;

	private Label spLbl;

	private Label hprLbl;

	private Label sprLbl;

	private Label resistLbl;

	private GroupBox groupBox4;

	private TextBox ssPercLbl;

	private Container components;

	public GuildDisplay(Guild g)
	{
		InitializeComponent();
		this.g = g;
		Text = "Info on " + g.GuildName;
		base.Visible = true;
		maxLbl.Text = "Maximum Levels: " + g.maxLvls;
		levelsTB.Text = g.maxLvls.ToString();
		calculate_Click(null, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.skillsDD = new System.Windows.Forms.ComboBox();
		this.spellsDD = new System.Windows.Forms.ComboBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.calcButton = new System.Windows.Forms.Button();
		this.levelsTB = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.resistLbl = new System.Windows.Forms.Label();
		this.sprLbl = new System.Windows.Forms.Label();
		this.hprLbl = new System.Windows.Forms.Label();
		this.spLbl = new System.Windows.Forms.Label();
		this.hpLbl = new System.Windows.Forms.Label();
		this.intLbl = new System.Windows.Forms.Label();
		this.strLbl = new System.Windows.Forms.Label();
		this.wisLbl = new System.Windows.Forms.Label();
		this.conLbl = new System.Windows.Forms.Label();
		this.chaLbl = new System.Windows.Forms.Label();
		this.dexLbl = new System.Windows.Forms.Label();
		this.maxLbl = new System.Windows.Forms.Label();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.ssPercLbl = new System.Windows.Forms.TextBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox4.SuspendLayout();
		base.SuspendLayout();
		this.label1.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(8, 16);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(72, 24);
		this.label1.TabIndex = 0;
		this.label1.Text = "SKILLS:";
		this.label2.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(8, 48);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(72, 23);
		this.label2.TabIndex = 1;
		this.label2.Text = "SPELLS:";
		this.skillsDD.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.skillsDD.Location = new System.Drawing.Point(96, 16);
		this.skillsDD.Name = "skillsDD";
		this.skillsDD.Size = new System.Drawing.Size(232, 24);
		this.skillsDD.TabIndex = 2;
		this.skillsDD.SelectedIndexChanged += new System.EventHandler(skillsDD_SelectedIndexChanged);
		this.skillsDD.DropDown += new System.EventHandler(skillsDD_DropDown);
		this.spellsDD.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.spellsDD.Location = new System.Drawing.Point(96, 48);
		this.spellsDD.Name = "spellsDD";
		this.spellsDD.Size = new System.Drawing.Size(232, 24);
		this.spellsDD.TabIndex = 3;
		this.spellsDD.SelectedIndexChanged += new System.EventHandler(spellsDD_SelectedIndexChanged);
		this.spellsDD.DropDown += new System.EventHandler(spellsDD_DropDown);
		this.groupBox1.Controls.Add(this.skillsDD);
		this.groupBox1.Controls.Add(this.spellsDD);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(16, 16);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(336, 80);
		this.groupBox1.TabIndex = 4;
		this.groupBox1.TabStop = false;
		this.groupBox2.Controls.Add(this.calcButton);
		this.groupBox2.Controls.Add(this.levelsTB);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Location = new System.Drawing.Point(16, 104);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(336, 48);
		this.groupBox2.TabIndex = 5;
		this.groupBox2.TabStop = false;
		this.calcButton.Location = new System.Drawing.Point(264, 16);
		this.calcButton.Name = "calcButton";
		this.calcButton.Size = new System.Drawing.Size(64, 23);
		this.calcButton.TabIndex = 2;
		this.calcButton.Text = "Calculate";
		this.calcButton.Click += new System.EventHandler(calculate_Click);
		this.levelsTB.Location = new System.Drawing.Point(200, 16);
		this.levelsTB.Name = "levelsTB";
		this.levelsTB.Size = new System.Drawing.Size(48, 20);
		this.levelsTB.TabIndex = 1;
		this.levelsTB.Text = "1";
		this.levelsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.label3.Font = new System.Drawing.Font("Courier New", 9f);
		this.label3.Location = new System.Drawing.Point(3, 16);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(189, 23);
		this.label3.TabIndex = 0;
		this.label3.Text = "Select number of levels:";
		this.groupBox3.Controls.Add(this.resistLbl);
		this.groupBox3.Controls.Add(this.sprLbl);
		this.groupBox3.Controls.Add(this.hprLbl);
		this.groupBox3.Controls.Add(this.spLbl);
		this.groupBox3.Controls.Add(this.hpLbl);
		this.groupBox3.Controls.Add(this.intLbl);
		this.groupBox3.Controls.Add(this.strLbl);
		this.groupBox3.Controls.Add(this.wisLbl);
		this.groupBox3.Controls.Add(this.conLbl);
		this.groupBox3.Controls.Add(this.chaLbl);
		this.groupBox3.Controls.Add(this.dexLbl);
		this.groupBox3.Controls.Add(this.maxLbl);
		this.groupBox3.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox3.Location = new System.Drawing.Point(16, 160);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(336, 264);
		this.groupBox3.TabIndex = 6;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Level Stats";
		this.resistLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.resistLbl.Location = new System.Drawing.Point(16, 168);
		this.resistLbl.Name = "resistLbl";
		this.resistLbl.Size = new System.Drawing.Size(312, 88);
		this.resistLbl.TabIndex = 12;
		this.sprLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.sprLbl.Location = new System.Drawing.Point(152, 136);
		this.sprLbl.Name = "sprLbl";
		this.sprLbl.Size = new System.Drawing.Size(128, 23);
		this.sprLbl.TabIndex = 11;
		this.hprLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.hprLbl.Location = new System.Drawing.Point(152, 120);
		this.hprLbl.Name = "hprLbl";
		this.hprLbl.Size = new System.Drawing.Size(128, 23);
		this.hprLbl.TabIndex = 10;
		this.spLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.spLbl.Location = new System.Drawing.Point(16, 136);
		this.spLbl.Name = "spLbl";
		this.spLbl.TabIndex = 9;
		this.hpLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.hpLbl.Location = new System.Drawing.Point(16, 120);
		this.hpLbl.Name = "hpLbl";
		this.hpLbl.TabIndex = 8;
		this.intLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.intLbl.Location = new System.Drawing.Point(16, 80);
		this.intLbl.Name = "intLbl";
		this.intLbl.Size = new System.Drawing.Size(72, 23);
		this.intLbl.TabIndex = 7;
		this.strLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.strLbl.Location = new System.Drawing.Point(16, 64);
		this.strLbl.Name = "strLbl";
		this.strLbl.Size = new System.Drawing.Size(72, 23);
		this.strLbl.TabIndex = 6;
		this.wisLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.wisLbl.Location = new System.Drawing.Point(112, 80);
		this.wisLbl.Name = "wisLbl";
		this.wisLbl.Size = new System.Drawing.Size(72, 23);
		this.wisLbl.TabIndex = 5;
		this.conLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.conLbl.Location = new System.Drawing.Point(112, 64);
		this.conLbl.Name = "conLbl";
		this.conLbl.Size = new System.Drawing.Size(72, 23);
		this.conLbl.TabIndex = 4;
		this.chaLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chaLbl.Location = new System.Drawing.Point(216, 80);
		this.chaLbl.Name = "chaLbl";
		this.chaLbl.Size = new System.Drawing.Size(72, 23);
		this.chaLbl.TabIndex = 3;
		this.dexLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dexLbl.Location = new System.Drawing.Point(216, 64);
		this.dexLbl.Name = "dexLbl";
		this.dexLbl.Size = new System.Drawing.Size(72, 23);
		this.dexLbl.TabIndex = 2;
		this.maxLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.maxLbl.Location = new System.Drawing.Point(16, 24);
		this.maxLbl.Name = "maxLbl";
		this.maxLbl.Size = new System.Drawing.Size(272, 23);
		this.maxLbl.TabIndex = 0;
		this.groupBox4.Controls.Add(this.ssPercLbl);
		this.groupBox4.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox4.Location = new System.Drawing.Point(368, 16);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(232, 408);
		this.groupBox4.TabIndex = 13;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Skill/Spell Percentages:";
		this.ssPercLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.ssPercLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.ssPercLbl.Location = new System.Drawing.Point(16, 24);
		this.ssPercLbl.Multiline = true;
		this.ssPercLbl.Name = "ssPercLbl";
		this.ssPercLbl.ReadOnly = true;
		this.ssPercLbl.Size = new System.Drawing.Size(208, 376);
		this.ssPercLbl.TabIndex = 0;
		this.ssPercLbl.Text = "";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.WhiteSmoke;
		base.ClientSize = new System.Drawing.Size(616, 445);
		base.Controls.Add(this.groupBox3);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.groupBox4);
		base.Name = "GuildDisplay";
		this.groupBox1.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox4.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void calculate_Click(object sender, EventArgs e)
	{
		if (isNumber(levelsTB.Text))
		{
			int level = ((int.Parse(levelsTB.Text) > g.maxLvls) ? g.maxLvls : int.Parse(levelsTB.Text));
			levelsTB.Text = level.ToString();
			GuildLevel gL = g.getGL(level);
			updateLvlStats(gL);
			updateDropDown(spellsDD, gL.sortedSpells());
			updateDropDown(skillsDD, gL.sortedSkills());
			ssPercLbl.Text = "";
		}
	}

	public void updateDropDown(ComboBox cb, ArrayList data)
	{
		loading = true;
		cb.BeginUpdate();
		((ListControl)cb).DataSource = new ArrayList();
		if (data != null)
		{
			string text = ssPercLbl.Text;
			((ListControl)cb).DataSource = data;
			cb.SelectedIndex = -1;
			ssPercLbl.Text = text;
		}
		cb.EndUpdate();
		loading = false;
	}

	private bool isNumber(string test)
	{
		return new Regex("^[0-9]+$").IsMatch(test);
	}

	public string percString(int perc)
	{
		string text = "";
		if (perc < 10)
		{
			text += " ";
		}
		if (perc < 100)
		{
			text += " ";
		}
		return text + perc;
	}

	public void updateLvlStats(GuildLevel gl)
	{
		strLbl.Text = "Str: " + gl.str;
		conLbl.Text = "Con: " + gl.con;
		dexLbl.Text = "Dex: " + gl.dex;
		intLbl.Text = "Int: " + gl.intel;
		wisLbl.Text = "Wis: " + gl.wis;
		chaLbl.Text = "Cha: " + gl.cha;
		hpLbl.Text = "HP: " + gl.hp;
		spLbl.Text = "SP: " + gl.sp;
		hprLbl.Text = "HP Regen: " + gl.hpr;
		sprLbl.Text = "SP Regen: " + gl.spr;
		resistLbl.Text = "";
		if (gl.acid != 0)
		{
			Label label = resistLbl;
			object obj = label.Text;
			label.Text = string.Concat(obj, "Acid: ", gl.acid, "\r\n");
		}
		if (gl.asp != 0)
		{
			Label label2 = resistLbl;
			object obj2 = label2.Text;
			label2.Text = string.Concat(obj2, "Asphyxiation: ", gl.asp, "\r\n");
		}
		if (gl.cold != 0)
		{
			Label label3 = resistLbl;
			object obj3 = label3.Text;
			label3.Text = string.Concat(obj3, "Cold: ", gl.cold, "\r\n");
		}
		if (gl.elec != 0)
		{
			Label label4 = resistLbl;
			object obj4 = label4.Text;
			label4.Text = string.Concat(obj4, "Electric: ", gl.elec, "\r\n");
		}
		if (gl.mag != 0)
		{
			Label label5 = resistLbl;
			object obj5 = label5.Text;
			label5.Text = string.Concat(obj5, "Magical: ", gl.mag, "\r\n");
		}
		if (gl.phys != 0)
		{
			Label label6 = resistLbl;
			object obj6 = label6.Text;
			label6.Text = string.Concat(obj6, "Physical: ", gl.phys, "\r\n");
		}
		if (gl.pois != 0)
		{
			Label label7 = resistLbl;
			object obj7 = label7.Text;
			label7.Text = string.Concat(obj7, "Poison: ", gl.pois, "\r\n");
		}
		if (gl.psi != 0)
		{
			Label label8 = resistLbl;
			object obj8 = label8.Text;
			label8.Text = string.Concat(obj8, "Psionic: ", gl.psi, "\r\n");
		}
		if (gl.fire != 0)
		{
			Label label9 = resistLbl;
			object obj9 = label9.Text;
			label9.Text = string.Concat(obj9, "Fire: ", gl.fire, "\r\n");
		}
		if (resistLbl.Text.Equals(""))
		{
			resistLbl.Text += "No resistances.";
		}
	}

	private void skillsDD_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!isNumber(levelsTB.Text) || skillsDD.SelectedIndex == -1 || loading)
		{
			return;
		}
		updateDropDown(spellsDD, null);
		string key = (string)skillsDD.SelectedItem;
		ssPercLbl.Text = "";
		for (int i = 0; (double)i < Math.Ceiling((double)g.maxLvls / 2.0); i++)
		{
			string text = ((i < 9) ? " " : "");
			text += i + 1;
			GuildLevel gL = g.getGL(i + 1);
			TextBox textBox = ssPercLbl;
			textBox.Text = textBox.Text + text + ". ";
			if (gL.getSkills().ContainsKey(key))
			{
				ssPercLbl.Text += percString((int)gL.getSkills()[key]);
			}
			else
			{
				ssPercLbl.Text += "  0";
			}
			int num = (int)((double)(i + 1) + Math.Ceiling((double)g.maxLvls / 2.0));
			if (num <= g.maxLvls)
			{
				TextBox textBox2 = ssPercLbl;
				object obj = textBox2.Text;
				textBox2.Text = string.Concat(obj, "%\t", num, ". ");
				gL = g.getGL(num);
				if (gL.getSkills().ContainsKey(key))
				{
					ssPercLbl.Text += percString((int)gL.getSkills()[key]);
				}
				else
				{
					ssPercLbl.Text += "  0";
				}
			}
			ssPercLbl.Text += "%\r\n";
		}
	}

	private void spellsDD_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!isNumber(levelsTB.Text) || spellsDD.SelectedIndex == -1 || loading)
		{
			return;
		}
		updateDropDown(skillsDD, null);
		string key = (string)spellsDD.SelectedItem;
		ssPercLbl.Text = "";
		for (int i = 0; (double)i < Math.Ceiling((double)g.maxLvls / 2.0); i++)
		{
			string text = ((i < 9) ? " " : "");
			text += i + 1;
			GuildLevel gL = g.getGL(i + 1);
			TextBox textBox = ssPercLbl;
			textBox.Text = textBox.Text + text + ". ";
			if (gL.getSpells().ContainsKey(key))
			{
				ssPercLbl.Text += percString((int)gL.getSpells()[key]);
			}
			else
			{
				ssPercLbl.Text += "  0";
			}
			int num = (int)((double)(i + 1) + Math.Ceiling((double)g.maxLvls / 2.0));
			if (num <= g.maxLvls)
			{
				TextBox textBox2 = ssPercLbl;
				object obj = textBox2.Text;
				textBox2.Text = string.Concat(obj, "%\t", num, ". ");
				gL = g.getGL(num);
				if (gL.getSpells().ContainsKey(key))
				{
					ssPercLbl.Text += percString((int)gL.getSpells()[key]);
				}
				else
				{
					ssPercLbl.Text += "  0";
				}
			}
			ssPercLbl.Text += "%\r\n";
		}
	}

	private void skillsDD_DropDown(object sender, EventArgs e)
	{
		int level = ((int.Parse(levelsTB.Text) > g.maxLvls) ? g.maxLvls : int.Parse(levelsTB.Text));
		GuildLevel gL = g.getGL(level);
		updateDropDown(skillsDD, gL.sortedSkills());
	}

	private void spellsDD_DropDown(object sender, EventArgs e)
	{
		int level = ((int.Parse(levelsTB.Text) > g.maxLvls) ? g.maxLvls : int.Parse(levelsTB.Text));
		GuildLevel gL = g.getGL(level);
		updateDropDown(spellsDD, gL.sortedSpells());
	}
}
