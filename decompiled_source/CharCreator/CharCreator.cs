using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using StringTok;

namespace CharCreator;

public class CharCreator : Form
{
	private TabControl tabController;

	private IContainer components;

	private Label selGuild;

	private Label selRace;

	private TextBox guildlevels;

	private Label label1;

	private MenuItem guildInfo;

	private MenuItem raceInfo;

	private Point mousePoint;

	private string dataPath;

	private string privatePath;

	private string rootPath;

	private ArrayList completeGuilds;

	private ArrayList displayGuilds;

	private ArrayList completeRaces;

	private ArrayList displayRaces;

	private ArrayList skills;

	private ArrayList spells;

	private int[] costs;

	private bool loading;

	private Button addGuild;

	private ListBox SkillsData;

	private ListBox MainGuildBox;

	private Label SkillsLbl;

	private Label SpellsLbl;

	private ListBox SpellsData;

	private TextBox SkillDescript;

	private Label label3;

	private Label label4;

	private TextBox SkillCost1;

	private TextBox SkillCost2;

	private TextBox SpellCost2;

	private TextBox SpellCost1;

	private Label SpellCostLbl;

	private Label SpellDLbl;

	private TextBox SpellDescript;

	private TabPage SpellsTab;

	private Button SkillSBtn;

	private Button SkillMBtn;

	private TextBox SkillPercTB;

	private Panel panel1;

	private Label chaLbl;

	private Label wisLbl;

	private Label intLbl;

	private Label strLbl;

	private Label sprLbl;

	private Label hprLbl;

	private Label hpLbl;

	private Label spLbl;

	private TextBox raceTB;

	private Label lblRace;

	private TabPage SkillsTab;

	private Label label5;

	private Label label6;

	private TextBox SkAllTB;

	private TextBox SkSelectedTB;

	private Label label7;

	private Label label8;

	private TextBox SpSelectedTB;

	private TextBox SpAllTB;

	private Button SpellsSBtn;

	private Button SpellsMBtn;

	private Button copySkillsBtn;

	private Button copySpellsBtn;

	private TextBox SpellPercTB;

	private Label label9;

	private TextBox QPTB;

	private TextBox StrTB;

	private TextBox WisTB;

	private TextBox IntTB;

	private TextBox SPRTB;

	private TextBox HPRTB;

	private TextBox SPTB;

	private TextBox HPTB;

	private TextBox ChaTB;

	private Label label10;

	private TextBox freeLevelsTB;

	private TextBox SkillsEXP;

	private TextBox SpellsEXP;

	private Label label11;

	private Label label12;

	private Label label13;

	private TextBox TotalEXP;

	private Label label14;

	private TextBox RaceEXP;

	private TextBox GuildExp;

	private Label label15;

	private Label label16;

	private TextBox GoldTB;

	private Button ResetBTN;

	private Label label2;

	private Label label19;

	private Label label20;

	private Label label21;

	private Label label22;

	private Label label23;

	private Label label24;

	private TextBox wisStTB;

	private TextBox strStTB;

	private TextBox conStTB;

	private TextBox dexStTB;

	private TextBox chaStTB;

	private Button statBtn;

	private TextBox intStTB;

	private Label label25;

	private TextBox StatExp;

	private Label label26;

	private CheckBox lSpell;

	private CheckBox lStats;

	private CheckBox lSkill;

	private CheckBox lHaste;

	private CheckBox lCriticalBlow;

	private CheckBox lMag;

	private CheckBox lPhys;

	private CheckBox thickSkin;

	private CheckBox trueSeeing;

	private CheckBox gHaste;

	private CheckBox gCriticalBlow;

	private CheckBox gMag;

	private CheckBox gPhys;

	private CheckBox gSpell;

	private CheckBox gSkill;

	private TabPage MiscTab;

	private TabPage WishesTab;

	private CheckBox gStats;

	private CheckBox ambidexterity;

	private CheckBox elementalAttunement;

	private CheckBox giantSize;

	private CheckBox improvedStr;

	private CheckBox improvedDex;

	private CheckBox improvedCon;

	private CheckBox improvedInt;

	private CheckBox improvedWis;

	private CheckBox improvedCha;

	private CheckBox lucky;

	private CheckBox lBattleRegen;

	private CheckBox gBattleRegen;

	private CheckBox lEndurance;

	private CheckBox gEndurance;

	private CheckBox gReserves;

	private CheckBox lReserves;

	private CheckBox gSpellDamage;

	private CheckBox lSpellDamage;

	private CheckBox resistAcid;

	private CheckBox resistAsp;

	private CheckBox resistCold;

	private CheckBox resistElec;

	private CheckBox resistFire;

	private CheckBox resistMag;

	private CheckBox resistPois;

	private CheckBox resistPsi;

	private GroupBox groupBox1;

	private Label label27;

	private TextBox TpTB;

	private TextBox skMax;

	private TextBox spMax;

	private Label label28;

	private Label label29;

	private Label label30;

	private TextBox sizeTB;

	private Label dexLbl;

	private Label conLbl;

	private TextBox ConTB;

	private TextBox DexTB;

	private Label label31;

	private TabPage generalTab;

	private TextBox levelsTB;

	private SaveFileDialog saveCharacter;

	private SaveFileDialog saveTrainStudy;

	private OpenFileDialog loadCharacter;

	private MainMenu mainMenu1;

	private TextBox qpNeededTB;

	private Label label18;

	private MenuItem load;

	private ContextMenu contextMenu;

	private TabPage helpTab;

	private TextBox helpLBL;

	private Label label17;

	private ListBox RaceBox;

	private MenuItem save;

	private MenuItem checkUpdates;

	private MenuItem saveTrainStudyMenuItem;

	private TextBox passTB;

	private Label label32;

	private Label resistLbl;

	private Character cs;

	public static int waitTime = 250000000;

	public CharCreator()
	{
		InitializeComponent();
		dataPath = Path.GetFullPath("./data/");
		privatePath = Path.GetFullPath("./private/");
		rootPath = Path.GetFullPath("./");
		Text = Text + " v" + GetFileVersion();
		resetALL();
	}

	public string GetFileVersion()
	{
		return FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
	}

	public void resetALL()
	{
		loading = true;
		displayGuilds = new ArrayList();
		completeGuilds = new ArrayList();
		displayRaces = new ArrayList();
		completeRaces = new ArrayList();
		skills = new ArrayList();
		spells = new ArrayList();
		costs = new int[20];
		levelsTB.Text = "0";
		QPTB.Text = "0";
		lCriticalBlow.Checked = false;
		lHaste.Checked = false;
		lMag.Checked = false;
		lPhys.Checked = false;
		lSkill.Checked = false;
		lSpell.Checked = false;
		lStats.Checked = false;
		thickSkin.Checked = false;
		trueSeeing.Checked = false;
		gCriticalBlow.Checked = false;
		gHaste.Checked = false;
		gMag.Checked = false;
		gPhys.Checked = false;
		gSkill.Checked = false;
		gStats.Checked = false;
		ambidexterity.Checked = false;
		elementalAttunement.Checked = false;
		giantSize.Checked = false;
		improvedStr.Checked = false;
		improvedDex.Checked = false;
		improvedCon.Checked = false;
		improvedInt.Checked = false;
		improvedWis.Checked = false;
		improvedCha.Checked = false;
		lucky.Checked = false;
		lBattleRegen.Checked = false;
		gBattleRegen.Checked = false;
		lEndurance.Checked = false;
		gEndurance.Checked = false;
		gReserves.Checked = false;
		lReserves.Checked = false;
		gSpellDamage.Checked = false;
		lSpellDamage.Checked = false;
		resistAcid.Checked = false;
		resistAsp.Checked = false;
		resistCold.Checked = false;
		resistElec.Checked = false;
		resistFire.Checked = false;
		resistMag.Checked = false;
		resistPois.Checked = false;
		resistPsi.Checked = false;
		cs = new Character();
		loading = false;
		loadAll();
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
		this.tabController = new System.Windows.Forms.TabControl();
		this.generalTab = new System.Windows.Forms.TabPage();
		this.passTB = new System.Windows.Forms.TextBox();
		this.RaceBox = new System.Windows.Forms.ListBox();
		this.contextMenu = new System.Windows.Forms.ContextMenu();
		this.label18 = new System.Windows.Forms.Label();
		this.qpNeededTB = new System.Windows.Forms.TextBox();
		this.label31 = new System.Windows.Forms.Label();
		this.levelsTB = new System.Windows.Forms.TextBox();
		this.label25 = new System.Windows.Forms.Label();
		this.StatExp = new System.Windows.Forms.TextBox();
		this.ResetBTN = new System.Windows.Forms.Button();
		this.GoldTB = new System.Windows.Forms.TextBox();
		this.label16 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.GuildExp = new System.Windows.Forms.TextBox();
		this.TotalEXP = new System.Windows.Forms.TextBox();
		this.label14 = new System.Windows.Forms.Label();
		this.RaceEXP = new System.Windows.Forms.TextBox();
		this.label13 = new System.Windows.Forms.Label();
		this.SkillsEXP = new System.Windows.Forms.TextBox();
		this.SpellsEXP = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.freeLevelsTB = new System.Windows.Forms.TextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.QPTB = new System.Windows.Forms.TextBox();
		this.panel1 = new System.Windows.Forms.Panel();
		this.dexLbl = new System.Windows.Forms.Label();
		this.conLbl = new System.Windows.Forms.Label();
		this.ConTB = new System.Windows.Forms.TextBox();
		this.DexTB = new System.Windows.Forms.TextBox();
		this.label30 = new System.Windows.Forms.Label();
		this.sizeTB = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.label29 = new System.Windows.Forms.Label();
		this.skMax = new System.Windows.Forms.TextBox();
		this.spMax = new System.Windows.Forms.TextBox();
		this.chaLbl = new System.Windows.Forms.Label();
		this.wisLbl = new System.Windows.Forms.Label();
		this.intLbl = new System.Windows.Forms.Label();
		this.strLbl = new System.Windows.Forms.Label();
		this.sprLbl = new System.Windows.Forms.Label();
		this.hprLbl = new System.Windows.Forms.Label();
		this.hpLbl = new System.Windows.Forms.Label();
		this.spLbl = new System.Windows.Forms.Label();
		this.HPTB = new System.Windows.Forms.TextBox();
		this.SPTB = new System.Windows.Forms.TextBox();
		this.IntTB = new System.Windows.Forms.TextBox();
		this.ChaTB = new System.Windows.Forms.TextBox();
		this.StrTB = new System.Windows.Forms.TextBox();
		this.WisTB = new System.Windows.Forms.TextBox();
		this.HPRTB = new System.Windows.Forms.TextBox();
		this.SPRTB = new System.Windows.Forms.TextBox();
		this.raceTB = new System.Windows.Forms.TextBox();
		this.lblRace = new System.Windows.Forms.Label();
		this.MainGuildBox = new System.Windows.Forms.ListBox();
		this.label1 = new System.Windows.Forms.Label();
		this.guildlevels = new System.Windows.Forms.TextBox();
		this.addGuild = new System.Windows.Forms.Button();
		this.selGuild = new System.Windows.Forms.Label();
		this.selRace = new System.Windows.Forms.Label();
		this.SkillsTab = new System.Windows.Forms.TabPage();
		this.SkSelectedTB = new System.Windows.Forms.TextBox();
		this.SkAllTB = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.SkillPercTB = new System.Windows.Forms.TextBox();
		this.SkillSBtn = new System.Windows.Forms.Button();
		this.SkillMBtn = new System.Windows.Forms.Button();
		this.SkillCost2 = new System.Windows.Forms.TextBox();
		this.SkillCost1 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.SkillDescript = new System.Windows.Forms.TextBox();
		this.SkillsLbl = new System.Windows.Forms.Label();
		this.SkillsData = new System.Windows.Forms.ListBox();
		this.SpellsTab = new System.Windows.Forms.TabPage();
		this.SpSelectedTB = new System.Windows.Forms.TextBox();
		this.SpAllTB = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.SpellPercTB = new System.Windows.Forms.TextBox();
		this.SpellsSBtn = new System.Windows.Forms.Button();
		this.SpellsMBtn = new System.Windows.Forms.Button();
		this.copySkillsBtn = new System.Windows.Forms.Button();
		this.copySpellsBtn = new System.Windows.Forms.Button();
		this.SpellCost2 = new System.Windows.Forms.TextBox();
		this.SpellCost1 = new System.Windows.Forms.TextBox();
		this.SpellCostLbl = new System.Windows.Forms.Label();
		this.SpellDLbl = new System.Windows.Forms.Label();
		this.SpellDescript = new System.Windows.Forms.TextBox();
		this.SpellsLbl = new System.Windows.Forms.Label();
		this.SpellsData = new System.Windows.Forms.ListBox();
		this.MiscTab = new System.Windows.Forms.TabPage();
		this.resistLbl = new System.Windows.Forms.Label();
		this.label32 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.gSkill = new System.Windows.Forms.CheckBox();
		this.gStats = new System.Windows.Forms.CheckBox();
		this.gSpell = new System.Windows.Forms.CheckBox();
		this.gPhys = new System.Windows.Forms.CheckBox();
		this.gMag = new System.Windows.Forms.CheckBox();
		this.gCriticalBlow = new System.Windows.Forms.CheckBox();
		this.gHaste = new System.Windows.Forms.CheckBox();
		this.trueSeeing = new System.Windows.Forms.CheckBox();
		this.thickSkin = new System.Windows.Forms.CheckBox();
		this.lPhys = new System.Windows.Forms.CheckBox();
		this.lMag = new System.Windows.Forms.CheckBox();
		this.lCriticalBlow = new System.Windows.Forms.CheckBox();
		this.lHaste = new System.Windows.Forms.CheckBox();
		this.lSkill = new System.Windows.Forms.CheckBox();
		this.lStats = new System.Windows.Forms.CheckBox();
		this.lSpell = new System.Windows.Forms.CheckBox();
		this.ambidexterity = new System.Windows.Forms.CheckBox();
		this.elementalAttunement = new System.Windows.Forms.CheckBox();
		this.giantSize = new System.Windows.Forms.CheckBox();
		this.improvedStr = new System.Windows.Forms.CheckBox();
		this.improvedDex = new System.Windows.Forms.CheckBox();
		this.improvedCon = new System.Windows.Forms.CheckBox();
		this.improvedInt = new System.Windows.Forms.CheckBox();
		this.improvedWis = new System.Windows.Forms.CheckBox();
		this.improvedCha = new System.Windows.Forms.CheckBox();
		this.lucky = new System.Windows.Forms.CheckBox();
		this.lBattleRegen = new System.Windows.Forms.CheckBox();
		this.gBattleRegen = new System.Windows.Forms.CheckBox();
		this.lEndurance = new System.Windows.Forms.CheckBox();
		this.gEndurance = new System.Windows.Forms.CheckBox();
		this.gReserves = new System.Windows.Forms.CheckBox();
		this.lReserves = new System.Windows.Forms.CheckBox();
		this.gSpellDamage = new System.Windows.Forms.CheckBox();
		this.lSpellDamage = new System.Windows.Forms.CheckBox();
		this.resistAcid = new System.Windows.Forms.CheckBox();
		this.resistAsp = new System.Windows.Forms.CheckBox();
		this.resistCold = new System.Windows.Forms.CheckBox();
		this.resistElec = new System.Windows.Forms.CheckBox();
		this.resistFire = new System.Windows.Forms.CheckBox();
		this.resistMag = new System.Windows.Forms.CheckBox();
		this.resistPois = new System.Windows.Forms.CheckBox();
		this.resistPsi = new System.Windows.Forms.CheckBox();
		this.label27 = new System.Windows.Forms.Label();
		this.TpTB = new System.Windows.Forms.TextBox();
		this.label26 = new System.Windows.Forms.Label();
		this.statBtn = new System.Windows.Forms.Button();
		this.strStTB = new System.Windows.Forms.TextBox();
		this.chaStTB = new System.Windows.Forms.TextBox();
		this.dexStTB = new System.Windows.Forms.TextBox();
		this.conStTB = new System.Windows.Forms.TextBox();
		this.wisStTB = new System.Windows.Forms.TextBox();
		this.intStTB = new System.Windows.Forms.TextBox();
		this.label24 = new System.Windows.Forms.Label();
		this.label23 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.helpTab = new System.Windows.Forms.TabPage();
		this.WishesTab = new System.Windows.Forms.TabPage();
		this.label17 = new System.Windows.Forms.Label();
		this.helpLBL = new System.Windows.Forms.TextBox();
		this.saveCharacter = new System.Windows.Forms.SaveFileDialog();
		this.saveTrainStudy = new System.Windows.Forms.SaveFileDialog();
		this.loadCharacter = new System.Windows.Forms.OpenFileDialog();
		this.mainMenu1 = new System.Windows.Forms.MainMenu();
		this.save = new System.Windows.Forms.MenuItem();
		this.load = new System.Windows.Forms.MenuItem();
		this.checkUpdates = new System.Windows.Forms.MenuItem();
		this.saveTrainStudyMenuItem = new System.Windows.Forms.MenuItem();
		this.guildInfo = new System.Windows.Forms.MenuItem();
		this.raceInfo = new System.Windows.Forms.MenuItem();
		this.tabController.SuspendLayout();
		this.generalTab.SuspendLayout();
		this.panel1.SuspendLayout();
		this.SkillsTab.SuspendLayout();
		this.SpellsTab.SuspendLayout();
		this.MiscTab.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.helpTab.SuspendLayout();
		base.SuspendLayout();
		this.tabController.Controls.Add(this.generalTab);
		this.tabController.Controls.Add(this.SkillsTab);
		this.tabController.Controls.Add(this.SpellsTab);
		this.tabController.Controls.Add(this.MiscTab);
		this.tabController.Controls.Add(this.WishesTab);
		this.tabController.Controls.Add(this.helpTab);
		this.tabController.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
		this.tabController.Font = new System.Drawing.Font("Courier New", 10f);
		this.tabController.ItemSize = new System.Drawing.Size(68, 21);
		this.tabController.Location = new System.Drawing.Point(0, 0);
		this.tabController.Multiline = true;
		this.tabController.Name = "tabController";
		this.tabController.SelectedIndex = 0;
		this.tabController.Size = new System.Drawing.Size(912, 629);
		this.tabController.TabIndex = 0;
		this.tabController.DrawItem += new System.Windows.Forms.DrawItemEventHandler(tabController_DrawItem);
		this.generalTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.generalTab.Controls.Add(this.passTB);
		this.generalTab.Controls.Add(this.RaceBox);
		this.generalTab.Controls.Add(this.label18);
		this.generalTab.Controls.Add(this.qpNeededTB);
		this.generalTab.Controls.Add(this.label31);
		this.generalTab.Controls.Add(this.levelsTB);
		this.generalTab.Controls.Add(this.label25);
		this.generalTab.Controls.Add(this.StatExp);
		this.generalTab.Controls.Add(this.ResetBTN);
		this.generalTab.Controls.Add(this.GoldTB);
		this.generalTab.Controls.Add(this.label16);
		this.generalTab.Controls.Add(this.label15);
		this.generalTab.Controls.Add(this.GuildExp);
		this.generalTab.Controls.Add(this.TotalEXP);
		this.generalTab.Controls.Add(this.label14);
		this.generalTab.Controls.Add(this.RaceEXP);
		this.generalTab.Controls.Add(this.label13);
		this.generalTab.Controls.Add(this.SkillsEXP);
		this.generalTab.Controls.Add(this.SpellsEXP);
		this.generalTab.Controls.Add(this.label11);
		this.generalTab.Controls.Add(this.label12);
		this.generalTab.Controls.Add(this.freeLevelsTB);
		this.generalTab.Controls.Add(this.label10);
		this.generalTab.Controls.Add(this.label9);
		this.generalTab.Controls.Add(this.QPTB);
		this.generalTab.Controls.Add(this.panel1);
		this.generalTab.Controls.Add(this.raceTB);
		this.generalTab.Controls.Add(this.lblRace);
		this.generalTab.Controls.Add(this.MainGuildBox);
		this.generalTab.Controls.Add(this.label1);
		this.generalTab.Controls.Add(this.guildlevels);
		this.generalTab.Controls.Add(this.addGuild);
		this.generalTab.Controls.Add(this.selGuild);
		this.generalTab.Controls.Add(this.selRace);
		((System.Windows.Forms.Control)this.generalTab).Location = new System.Drawing.Point(4, 25);
		this.generalTab.Name = "generalTab";
		this.generalTab.Size = new System.Drawing.Size(904, 600);
		this.generalTab.TabIndex = 1;
		this.generalTab.Text = "General";
		this.passTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.passTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.passTB.Location = new System.Drawing.Point(632, 536);
		this.passTB.Name = "passTB";
		this.passTB.Size = new System.Drawing.Size(112, 16);
		this.passTB.TabIndex = 43;
		this.passTB.Text = "";
		this.RaceBox.ContextMenu = this.contextMenu;
		this.RaceBox.ItemHeight = 16;
		this.RaceBox.Location = new System.Drawing.Point(40, 56);
		this.RaceBox.Name = "RaceBox";
		this.RaceBox.Size = new System.Drawing.Size(272, 84);
		this.RaceBox.TabIndex = 42;
		this.RaceBox.SelectedIndexChanged += new System.EventHandler(RaceBox_SelectedIndexChanged);
		this.contextMenu.Popup += new System.EventHandler(MyPopupHandler);
		this.label18.Font = new System.Drawing.Font("Courier New", 11f);
		this.label18.Location = new System.Drawing.Point(72, 480);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(112, 23);
		this.label18.TabIndex = 41;
		this.label18.Text = "QPs Needed:";
		this.qpNeededTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.qpNeededTB.Font = new System.Drawing.Font("Courier New", 11f);
		this.qpNeededTB.Location = new System.Drawing.Point(184, 480);
		this.qpNeededTB.Name = "qpNeededTB";
		this.qpNeededTB.ReadOnly = true;
		this.qpNeededTB.Size = new System.Drawing.Size(56, 24);
		this.qpNeededTB.TabIndex = 40;
		this.qpNeededTB.Text = "0";
		this.qpNeededTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label31.Font = new System.Drawing.Font("Courier New", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label31.Location = new System.Drawing.Point(56, 384);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(128, 16);
		this.label31.TabIndex = 39;
		this.label31.Text = "Total Levels:";
		this.levelsTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.levelsTB.Font = new System.Drawing.Font("Courier New", 11f);
		this.levelsTB.Location = new System.Drawing.Point(184, 384);
		this.levelsTB.Name = "levelsTB";
		this.levelsTB.ReadOnly = true;
		this.levelsTB.Size = new System.Drawing.Size(56, 24);
		this.levelsTB.TabIndex = 38;
		this.levelsTB.Text = "0";
		this.levelsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label25.Location = new System.Drawing.Point(424, 408);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(256, 24);
		this.label25.TabIndex = 37;
		this.label25.Text = "Experience for Stat Training:";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.StatExp.BackColor = System.Drawing.Color.WhiteSmoke;
		this.StatExp.Location = new System.Drawing.Point(704, 408);
		this.StatExp.Name = "StatExp";
		this.StatExp.ReadOnly = true;
		this.StatExp.Size = new System.Drawing.Size(160, 23);
		this.StatExp.TabIndex = 36;
		this.StatExp.Text = "";
		this.StatExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.ResetBTN.BackColor = System.Drawing.Color.Firebrick;
		this.ResetBTN.Font = new System.Drawing.Font("Courier New", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ResetBTN.Location = new System.Drawing.Point(768, 528);
		this.ResetBTN.Name = "ResetBTN";
		this.ResetBTN.Size = new System.Drawing.Size(96, 32);
		this.ResetBTN.TabIndex = 34;
		this.ResetBTN.Text = "RESET";
		this.ResetBTN.Click += new System.EventHandler(ResetBTN_Click);
		this.GoldTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.GoldTB.Location = new System.Drawing.Point(704, 480);
		this.GoldTB.Name = "GoldTB";
		this.GoldTB.ReadOnly = true;
		this.GoldTB.Size = new System.Drawing.Size(160, 23);
		this.GoldTB.TabIndex = 33;
		this.GoldTB.Text = "";
		this.GoldTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label16.Location = new System.Drawing.Point(560, 480);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(120, 24);
		this.label16.TabIndex = 32;
		this.label16.Text = "Gold Required:";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label15.Location = new System.Drawing.Point(440, 384);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(240, 24);
		this.label15.TabIndex = 31;
		this.label15.Text = "Experience for Guild Levels:";
		this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.GuildExp.BackColor = System.Drawing.Color.WhiteSmoke;
		this.GuildExp.Location = new System.Drawing.Point(704, 384);
		this.GuildExp.Name = "GuildExp";
		this.GuildExp.ReadOnly = true;
		this.GuildExp.Size = new System.Drawing.Size(160, 23);
		this.GuildExp.TabIndex = 30;
		this.GuildExp.Text = "";
		this.GuildExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.TotalEXP.BackColor = System.Drawing.Color.WhiteSmoke;
		this.TotalEXP.Location = new System.Drawing.Point(704, 456);
		this.TotalEXP.Name = "TotalEXP";
		this.TotalEXP.ReadOnly = true;
		this.TotalEXP.Size = new System.Drawing.Size(160, 23);
		this.TotalEXP.TabIndex = 28;
		this.TotalEXP.Text = "";
		this.TotalEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label14.Location = new System.Drawing.Point(520, 456);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(160, 24);
		this.label14.TabIndex = 27;
		this.label14.Text = "Total Experience:";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.RaceEXP.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RaceEXP.Location = new System.Drawing.Point(704, 360);
		this.RaceEXP.Name = "RaceEXP";
		this.RaceEXP.ReadOnly = true;
		this.RaceEXP.Size = new System.Drawing.Size(160, 23);
		this.RaceEXP.TabIndex = 26;
		this.RaceEXP.Text = "";
		this.RaceEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label13.Location = new System.Drawing.Point(440, 360);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(240, 24);
		this.label13.TabIndex = 25;
		this.label13.Text = "Experience for Race Levels:";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.SkillsEXP.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkillsEXP.Location = new System.Drawing.Point(704, 312);
		this.SkillsEXP.Name = "SkillsEXP";
		this.SkillsEXP.ReadOnly = true;
		this.SkillsEXP.Size = new System.Drawing.Size(160, 23);
		this.SkillsEXP.TabIndex = 24;
		this.SkillsEXP.Text = "";
		this.SkillsEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.SpellsEXP.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpellsEXP.Location = new System.Drawing.Point(704, 336);
		this.SpellsEXP.Name = "SpellsEXP";
		this.SpellsEXP.ReadOnly = true;
		this.SpellsEXP.Size = new System.Drawing.Size(160, 23);
		this.SpellsEXP.TabIndex = 23;
		this.SpellsEXP.Text = "";
		this.SpellsEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label11.Location = new System.Drawing.Point(440, 336);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(240, 24);
		this.label11.TabIndex = 22;
		this.label11.Text = "Experience for Spells:";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label12.Location = new System.Drawing.Point(440, 312);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(240, 24);
		this.label12.TabIndex = 21;
		this.label12.Text = "Experience for Skills:";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.freeLevelsTB.Font = new System.Drawing.Font("Courier New", 11f);
		this.freeLevelsTB.Location = new System.Drawing.Point(184, 416);
		this.freeLevelsTB.MaxLength = 3;
		this.freeLevelsTB.Name = "freeLevelsTB";
		this.freeLevelsTB.Size = new System.Drawing.Size(56, 24);
		this.freeLevelsTB.TabIndex = 20;
		this.freeLevelsTB.Text = "0";
		this.freeLevelsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.freeLevelsTB.TextChanged += new System.EventHandler(freeLevelsTB_TextChanged);
		this.label10.Font = new System.Drawing.Font("Courier New", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.Location = new System.Drawing.Point(64, 416);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(120, 16);
		this.label10.TabIndex = 19;
		this.label10.Text = "Free Levels:";
		this.label9.Font = new System.Drawing.Font("Courier New", 11f);
		this.label9.Location = new System.Drawing.Point(56, 448);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(128, 23);
		this.label9.TabIndex = 16;
		this.label9.Text = "Quest Points:";
		this.QPTB.Font = new System.Drawing.Font("Courier New", 11f);
		this.QPTB.Location = new System.Drawing.Point(184, 448);
		this.QPTB.MaxLength = 6;
		this.QPTB.Name = "QPTB";
		this.QPTB.Size = new System.Drawing.Size(56, 24);
		this.QPTB.TabIndex = 15;
		this.QPTB.Text = "0";
		this.QPTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.QPTB.TextChanged += new System.EventHandler(QPTB_TextChanged);
		this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.dexLbl);
		this.panel1.Controls.Add(this.conLbl);
		this.panel1.Controls.Add(this.ConTB);
		this.panel1.Controls.Add(this.DexTB);
		this.panel1.Controls.Add(this.label30);
		this.panel1.Controls.Add(this.sizeTB);
		this.panel1.Controls.Add(this.label28);
		this.panel1.Controls.Add(this.label29);
		this.panel1.Controls.Add(this.skMax);
		this.panel1.Controls.Add(this.spMax);
		this.panel1.Controls.Add(this.chaLbl);
		this.panel1.Controls.Add(this.wisLbl);
		this.panel1.Controls.Add(this.intLbl);
		this.panel1.Controls.Add(this.strLbl);
		this.panel1.Controls.Add(this.sprLbl);
		this.panel1.Controls.Add(this.hprLbl);
		this.panel1.Controls.Add(this.hpLbl);
		this.panel1.Controls.Add(this.spLbl);
		this.panel1.Controls.Add(this.HPTB);
		this.panel1.Controls.Add(this.SPTB);
		this.panel1.Controls.Add(this.IntTB);
		this.panel1.Controls.Add(this.ChaTB);
		this.panel1.Controls.Add(this.StrTB);
		this.panel1.Controls.Add(this.WisTB);
		this.panel1.Controls.Add(this.HPRTB);
		this.panel1.Controls.Add(this.SPRTB);
		this.panel1.Font = new System.Drawing.Font("Courier New", 11f);
		this.panel1.Location = new System.Drawing.Point(368, 176);
		this.panel1.Name = "panel1";
		this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.panel1.Size = new System.Drawing.Size(496, 112);
		this.panel1.TabIndex = 14;
		this.dexLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.dexLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.dexLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.dexLbl.Location = new System.Drawing.Point(120, 56);
		this.dexLbl.Name = "dexLbl";
		this.dexLbl.Size = new System.Drawing.Size(48, 16);
		this.dexLbl.TabIndex = 43;
		this.dexLbl.Text = "Dex:";
		this.conLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.conLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.conLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.conLbl.Location = new System.Drawing.Point(120, 32);
		this.conLbl.Name = "conLbl";
		this.conLbl.Size = new System.Drawing.Size(48, 16);
		this.conLbl.TabIndex = 42;
		this.conLbl.Text = "Con:";
		this.ConTB.AutoSize = false;
		this.ConTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.ConTB.Location = new System.Drawing.Point(168, 32);
		this.ConTB.MaxLength = 5;
		this.ConTB.Name = "ConTB";
		this.ConTB.ReadOnly = true;
		this.ConTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.ConTB.Size = new System.Drawing.Size(50, 24);
		this.ConTB.TabIndex = 44;
		this.ConTB.TabStop = false;
		this.ConTB.Text = "0";
		this.ConTB.WordWrap = false;
		this.DexTB.AutoSize = false;
		this.DexTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.DexTB.Location = new System.Drawing.Point(168, 56);
		this.DexTB.MaxLength = 5;
		this.DexTB.Name = "DexTB";
		this.DexTB.ReadOnly = true;
		this.DexTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.DexTB.Size = new System.Drawing.Size(50, 24);
		this.DexTB.TabIndex = 45;
		this.DexTB.TabStop = false;
		this.DexTB.Text = "0";
		this.DexTB.WordWrap = false;
		this.label30.BackColor = System.Drawing.Color.WhiteSmoke;
		this.label30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label30.Font = new System.Drawing.Font("Courier New", 11f);
		this.label30.Location = new System.Drawing.Point(368, 56);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(56, 16);
		this.label30.TabIndex = 32;
		this.label30.Text = "Size:";
		this.sizeTB.AutoSize = false;
		this.sizeTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.sizeTB.Location = new System.Drawing.Point(432, 56);
		this.sizeTB.MaxLength = 5;
		this.sizeTB.Name = "sizeTB";
		this.sizeTB.ReadOnly = true;
		this.sizeTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.sizeTB.Size = new System.Drawing.Size(50, 24);
		this.sizeTB.TabIndex = 31;
		this.sizeTB.TabStop = false;
		this.sizeTB.Text = "0";
		this.sizeTB.WordWrap = false;
		this.label28.BackColor = System.Drawing.Color.WhiteSmoke;
		this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label28.Font = new System.Drawing.Font("Courier New", 11f);
		this.label28.Location = new System.Drawing.Point(360, 32);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(64, 16);
		this.label28.TabIndex = 30;
		this.label28.Text = "SpMax:";
		this.label29.BackColor = System.Drawing.Color.WhiteSmoke;
		this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label29.Font = new System.Drawing.Font("Courier New", 11f);
		this.label29.Location = new System.Drawing.Point(360, 8);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(64, 16);
		this.label29.TabIndex = 29;
		this.label29.Text = "SkMax:";
		this.skMax.AutoSize = false;
		this.skMax.BackColor = System.Drawing.Color.WhiteSmoke;
		this.skMax.Location = new System.Drawing.Point(432, 8);
		this.skMax.MaxLength = 5;
		this.skMax.Name = "skMax";
		this.skMax.ReadOnly = true;
		this.skMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.skMax.Size = new System.Drawing.Size(50, 24);
		this.skMax.TabIndex = 27;
		this.skMax.TabStop = false;
		this.skMax.Text = "0";
		this.skMax.WordWrap = false;
		this.spMax.AutoSize = false;
		this.spMax.BackColor = System.Drawing.Color.WhiteSmoke;
		this.spMax.Location = new System.Drawing.Point(432, 32);
		this.spMax.MaxLength = 5;
		this.spMax.Name = "spMax";
		this.spMax.ReadOnly = true;
		this.spMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.spMax.Size = new System.Drawing.Size(50, 24);
		this.spMax.TabIndex = 28;
		this.spMax.TabStop = false;
		this.spMax.Text = "0";
		this.spMax.WordWrap = false;
		this.chaLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.chaLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.chaLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.chaLbl.Location = new System.Drawing.Point(240, 56);
		this.chaLbl.Name = "chaLbl";
		this.chaLbl.Size = new System.Drawing.Size(48, 16);
		this.chaLbl.TabIndex = 6;
		this.chaLbl.Text = "Cha:";
		this.wisLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.wisLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.wisLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.wisLbl.Location = new System.Drawing.Point(240, 32);
		this.wisLbl.Name = "wisLbl";
		this.wisLbl.Size = new System.Drawing.Size(48, 16);
		this.wisLbl.TabIndex = 4;
		this.wisLbl.Text = "Wis:";
		this.intLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.intLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.intLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.intLbl.Location = new System.Drawing.Point(240, 8);
		this.intLbl.Name = "intLbl";
		this.intLbl.Size = new System.Drawing.Size(48, 16);
		this.intLbl.TabIndex = 3;
		this.intLbl.Text = "Int:";
		this.strLbl.BackColor = System.Drawing.Color.WhiteSmoke;
		this.strLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.strLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.strLbl.Location = new System.Drawing.Point(120, 8);
		this.strLbl.Name = "strLbl";
		this.strLbl.Size = new System.Drawing.Size(48, 16);
		this.strLbl.TabIndex = 1;
		this.strLbl.Text = "Str:";
		this.sprLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.sprLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.sprLbl.Location = new System.Drawing.Point(8, 80);
		this.sprLbl.Name = "sprLbl";
		this.sprLbl.Size = new System.Drawing.Size(48, 24);
		this.sprLbl.TabIndex = 0;
		this.sprLbl.Text = "SPR:";
		this.hprLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.hprLbl.Location = new System.Drawing.Point(8, 56);
		this.hprLbl.Name = "hprLbl";
		this.hprLbl.Size = new System.Drawing.Size(48, 24);
		this.hprLbl.TabIndex = 0;
		this.hprLbl.Text = "HPR:";
		this.hpLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.hpLbl.Location = new System.Drawing.Point(16, 8);
		this.hpLbl.Name = "hpLbl";
		this.hpLbl.Size = new System.Drawing.Size(40, 24);
		this.hpLbl.TabIndex = 0;
		this.hpLbl.Text = "HP:";
		this.spLbl.Font = new System.Drawing.Font("Courier New", 11f);
		this.spLbl.Location = new System.Drawing.Point(16, 32);
		this.spLbl.Name = "spLbl";
		this.spLbl.Size = new System.Drawing.Size(40, 24);
		this.spLbl.TabIndex = 0;
		this.spLbl.Text = "SP:";
		this.HPTB.AutoSize = false;
		this.HPTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.HPTB.Location = new System.Drawing.Point(56, 8);
		this.HPTB.MaxLength = 5;
		this.HPTB.Name = "HPTB";
		this.HPTB.ReadOnly = true;
		this.HPTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.HPTB.Size = new System.Drawing.Size(50, 24);
		this.HPTB.TabIndex = 26;
		this.HPTB.TabStop = false;
		this.HPTB.Text = "0";
		this.HPTB.WordWrap = false;
		this.SPTB.AutoSize = false;
		this.SPTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SPTB.Location = new System.Drawing.Point(56, 32);
		this.SPTB.MaxLength = 5;
		this.SPTB.Name = "SPTB";
		this.SPTB.ReadOnly = true;
		this.SPTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.SPTB.Size = new System.Drawing.Size(50, 24);
		this.SPTB.TabIndex = 25;
		this.SPTB.TabStop = false;
		this.SPTB.Text = "0";
		this.SPTB.WordWrap = false;
		this.IntTB.AutoSize = false;
		this.IntTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.IntTB.Location = new System.Drawing.Point(288, 8);
		this.IntTB.MaxLength = 5;
		this.IntTB.Name = "IntTB";
		this.IntTB.ReadOnly = true;
		this.IntTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.IntTB.Size = new System.Drawing.Size(50, 24);
		this.IntTB.TabIndex = 20;
		this.IntTB.TabStop = false;
		this.IntTB.Text = "0";
		this.IntTB.WordWrap = false;
		this.ChaTB.AutoSize = false;
		this.ChaTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.ChaTB.Location = new System.Drawing.Point(288, 56);
		this.ChaTB.MaxLength = 5;
		this.ChaTB.Name = "ChaTB";
		this.ChaTB.ReadOnly = true;
		this.ChaTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.ChaTB.Size = new System.Drawing.Size(50, 24);
		this.ChaTB.TabIndex = 17;
		this.ChaTB.TabStop = false;
		this.ChaTB.Text = "0";
		this.ChaTB.WordWrap = false;
		this.StrTB.AutoSize = false;
		this.StrTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.StrTB.Location = new System.Drawing.Point(168, 8);
		this.StrTB.MaxLength = 5;
		this.StrTB.Name = "StrTB";
		this.StrTB.ReadOnly = true;
		this.StrTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.StrTB.Size = new System.Drawing.Size(50, 24);
		this.StrTB.TabIndex = 18;
		this.StrTB.TabStop = false;
		this.StrTB.Text = "0";
		this.StrTB.WordWrap = false;
		this.WisTB.AutoSize = false;
		this.WisTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.WisTB.Location = new System.Drawing.Point(288, 32);
		this.WisTB.MaxLength = 5;
		this.WisTB.Name = "WisTB";
		this.WisTB.ReadOnly = true;
		this.WisTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.WisTB.Size = new System.Drawing.Size(50, 24);
		this.WisTB.TabIndex = 19;
		this.WisTB.TabStop = false;
		this.WisTB.Text = "0";
		this.WisTB.WordWrap = false;
		this.HPRTB.AutoSize = false;
		this.HPRTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.HPRTB.Location = new System.Drawing.Point(56, 56);
		this.HPRTB.MaxLength = 5;
		this.HPRTB.Name = "HPRTB";
		this.HPRTB.ReadOnly = true;
		this.HPRTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.HPRTB.Size = new System.Drawing.Size(50, 24);
		this.HPRTB.TabIndex = 24;
		this.HPRTB.TabStop = false;
		this.HPRTB.Text = "0";
		this.HPRTB.WordWrap = false;
		this.SPRTB.AutoSize = false;
		this.SPRTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SPRTB.Location = new System.Drawing.Point(56, 80);
		this.SPRTB.MaxLength = 5;
		this.SPRTB.Name = "SPRTB";
		this.SPRTB.ReadOnly = true;
		this.SPRTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.SPRTB.Size = new System.Drawing.Size(50, 24);
		this.SPRTB.TabIndex = 23;
		this.SPRTB.TabStop = false;
		this.SPRTB.Text = "0";
		this.SPRTB.WordWrap = false;
		this.raceTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.raceTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.raceTB.Location = new System.Drawing.Point(368, 56);
		this.raceTB.Multiline = true;
		this.raceTB.Name = "raceTB";
		this.raceTB.ReadOnly = true;
		this.raceTB.Size = new System.Drawing.Size(496, 104);
		this.raceTB.TabIndex = 12;
		this.raceTB.Text = "No race has been selected.";
		this.lblRace.Font = new System.Drawing.Font("Times New Roman", 14f);
		this.lblRace.Location = new System.Drawing.Point(360, 24);
		this.lblRace.Name = "lblRace";
		this.lblRace.Size = new System.Drawing.Size(264, 24);
		this.lblRace.TabIndex = 13;
		this.lblRace.Text = "Racial Stats";
		this.MainGuildBox.ContextMenu = this.contextMenu;
		this.MainGuildBox.Font = new System.Drawing.Font("Courier New", 10f);
		this.MainGuildBox.ItemHeight = 16;
		this.MainGuildBox.Location = new System.Drawing.Point(40, 184);
		this.MainGuildBox.Name = "MainGuildBox";
		this.MainGuildBox.Size = new System.Drawing.Size(272, 148);
		this.MainGuildBox.TabIndex = 11;
		this.MainGuildBox.DoubleClick += new System.EventHandler(addGuildBTN_Click);
		this.MainGuildBox.SelectedIndexChanged += new System.EventHandler(MainGuildBox_SelectedIndexChanged);
		this.label1.Font = new System.Drawing.Font("Courier New", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(40, 344);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(64, 16);
		this.label1.TabIndex = 10;
		this.label1.Text = "Level:";
		this.guildlevels.Location = new System.Drawing.Point(112, 344);
		this.guildlevels.MaxLength = 5;
		this.guildlevels.Name = "guildlevels";
		this.guildlevels.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.guildlevels.Size = new System.Drawing.Size(64, 23);
		this.guildlevels.TabIndex = 9;
		this.guildlevels.Text = "";
		this.guildlevels.LostFocus += new System.EventHandler(guildlevels_LostFocus);
		this.guildlevels.GotFocus += new System.EventHandler(guildlevels_GotFocus);
		this.addGuild.BackColor = System.Drawing.Color.WhiteSmoke;
		this.addGuild.Location = new System.Drawing.Point(184, 344);
		this.addGuild.Name = "addGuild";
		this.addGuild.Size = new System.Drawing.Size(72, 23);
		this.addGuild.TabIndex = 7;
		this.addGuild.Text = "Update";
		this.addGuild.Click += new System.EventHandler(addGuildBTN_Click);
		this.selGuild.Font = new System.Drawing.Font("Times New Roman", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.selGuild.Location = new System.Drawing.Point(16, 152);
		this.selGuild.Name = "selGuild";
		this.selGuild.Size = new System.Drawing.Size(136, 23);
		this.selGuild.TabIndex = 5;
		this.selGuild.Text = "Select Guilds:";
		this.selRace.Font = new System.Drawing.Font("Times New Roman", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.selRace.Location = new System.Drawing.Point(16, 16);
		this.selRace.Name = "selRace";
		this.selRace.Size = new System.Drawing.Size(120, 23);
		this.selRace.TabIndex = 4;
		this.selRace.Text = "Select Race:";
		this.SkillsTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkillsTab.Controls.Add(this.SkSelectedTB);
		this.SkillsTab.Controls.Add(this.SkAllTB);
		this.SkillsTab.Controls.Add(this.label6);
		this.SkillsTab.Controls.Add(this.label5);
		this.SkillsTab.Controls.Add(this.SkillPercTB);
		this.SkillsTab.Controls.Add(this.SkillSBtn);
		this.SkillsTab.Controls.Add(this.SkillMBtn);
		this.SkillsTab.Controls.Add(this.copySkillsBtn);
		this.SkillsTab.Controls.Add(this.SkillCost2);
		this.SkillsTab.Controls.Add(this.SkillCost1);
		this.SkillsTab.Controls.Add(this.label4);
		this.SkillsTab.Controls.Add(this.label3);
		this.SkillsTab.Controls.Add(this.SkillDescript);
		this.SkillsTab.Controls.Add(this.SkillsLbl);
		this.SkillsTab.Controls.Add(this.SkillsData);
		((System.Windows.Forms.Control)this.SkillsTab).Location = new System.Drawing.Point(4, 25);
		this.SkillsTab.Name = "SkillsTab";
		this.SkillsTab.Size = new System.Drawing.Size(904, 600);
		this.SkillsTab.TabIndex = 3;
		this.SkillsTab.Text = "Skills";
		this.SkSelectedTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkSelectedTB.Location = new System.Drawing.Point(264, 496);
		this.SkSelectedTB.Name = "SkSelectedTB";
		this.SkSelectedTB.ReadOnly = true;
		this.SkSelectedTB.Size = new System.Drawing.Size(120, 23);
		this.SkSelectedTB.TabIndex = 17;
		this.SkSelectedTB.Text = "0";
		this.SkSelectedTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.SkAllTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkAllTB.Location = new System.Drawing.Point(264, 528);
		this.SkAllTB.Name = "SkAllTB";
		this.SkAllTB.ReadOnly = true;
		this.SkAllTB.Size = new System.Drawing.Size(120, 23);
		this.SkAllTB.TabIndex = 16;
		this.SkAllTB.Text = "0";
		this.SkAllTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label6.Location = new System.Drawing.Point(40, 528);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(216, 24);
		this.label6.TabIndex = 15;
		this.label6.Text = "Total Exp for all Skills:";
		this.label5.Location = new System.Drawing.Point(40, 496);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(208, 24);
		this.label5.TabIndex = 14;
		this.label5.Text = "Exp for selected Skills:";
		this.SkillPercTB.Location = new System.Drawing.Point(40, 456);
		this.SkillPercTB.MaxLength = 3;
		this.SkillPercTB.Name = "SkillPercTB";
		this.SkillPercTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.SkillPercTB.Size = new System.Drawing.Size(72, 23);
		this.SkillPercTB.TabIndex = 13;
		this.SkillPercTB.Text = "0";
		this.SkillSBtn.Location = new System.Drawing.Point(128, 456);
		this.SkillSBtn.Name = "SkillSBtn";
		this.SkillSBtn.Size = new System.Drawing.Size(98, 23);
		this.SkillSBtn.TabIndex = 12;
		this.SkillSBtn.TabStop = false;
		this.SkillSBtn.Text = "Set Selected";
		this.SkillSBtn.Click += new System.EventHandler(SkillSBtn_Click);
		this.SkillMBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
		this.SkillMBtn.Location = new System.Drawing.Point(232, 456);
		this.SkillMBtn.Name = "SkillMBtn";
		this.SkillMBtn.Size = new System.Drawing.Size(98, 23);
		this.SkillMBtn.TabIndex = 0;
		this.SkillMBtn.TabStop = false;
		this.SkillMBtn.Text = "Max Selected";
		this.SkillMBtn.Click += new System.EventHandler(SkillMBtn_Click);
		this.copySkillsBtn.Location = new System.Drawing.Point(336, 456);
		this.copySkillsBtn.Name = "copySkillsBtn";
		this.copySkillsBtn.Size = new System.Drawing.Size(98, 23);
		this.copySkillsBtn.TabIndex = 13;
		this.copySkillsBtn.Text = "Copy";
		this.copySkillsBtn.Click += new System.EventHandler(copySkillsBtn_Click);
		this.SkillCost2.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkillCost2.Font = new System.Drawing.Font("Courier New", 9f);
		this.SkillCost2.Location = new System.Drawing.Point(664, 344);
		this.SkillCost2.Multiline = true;
		this.SkillCost2.Name = "SkillCost2";
		this.SkillCost2.ReadOnly = true;
		this.SkillCost2.Size = new System.Drawing.Size(216, 208);
		this.SkillCost2.TabIndex = 10;
		this.SkillCost2.Text = "";
		this.SkillCost1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkillCost1.Font = new System.Drawing.Font("Courier New", 9f);
		this.SkillCost1.Location = new System.Drawing.Point(448, 344);
		this.SkillCost1.Multiline = true;
		this.SkillCost1.Name = "SkillCost1";
		this.SkillCost1.ReadOnly = true;
		this.SkillCost1.Size = new System.Drawing.Size(216, 208);
		this.SkillCost1.TabIndex = 9;
		this.SkillCost1.Text = "";
		this.label4.Font = new System.Drawing.Font("Times New Roman", 14f);
		this.label4.Location = new System.Drawing.Point(432, 320);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(240, 23);
		this.label4.TabIndex = 8;
		this.label4.Text = "Estimated Skill Costs:";
		this.label3.Font = new System.Drawing.Font("Times New Roman", 14f);
		this.label3.Location = new System.Drawing.Point(424, 24);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(240, 23);
		this.label3.TabIndex = 7;
		this.label3.Text = "Skill Description:";
		this.SkillDescript.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SkillDescript.Font = new System.Drawing.Font("Courier New", 10f);
		this.SkillDescript.Location = new System.Drawing.Point(448, 56);
		this.SkillDescript.Multiline = true;
		this.SkillDescript.Name = "SkillDescript";
		this.SkillDescript.ReadOnly = true;
		this.SkillDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.SkillDescript.Size = new System.Drawing.Size(424, 248);
		this.SkillDescript.TabIndex = 6;
		this.SkillDescript.Text = "";
		this.SkillsLbl.Font = new System.Drawing.Font("Times New Roman", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.SkillsLbl.Location = new System.Drawing.Point(8, 16);
		this.SkillsLbl.Name = "SkillsLbl";
		this.SkillsLbl.Size = new System.Drawing.Size(240, 23);
		this.SkillsLbl.TabIndex = 5;
		this.SkillsLbl.Text = "Available Skills:";
		this.SkillsData.Font = new System.Drawing.Font("Courier New", 10f);
		this.SkillsData.ItemHeight = 16;
		this.SkillsData.Location = new System.Drawing.Point(40, 56);
		this.SkillsData.Name = "SkillsData";
		this.SkillsData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		this.SkillsData.Size = new System.Drawing.Size(350, 388);
		this.SkillsData.TabIndex = 0;
		this.SkillsData.KeyDown += new System.Windows.Forms.KeyEventHandler(skills_keyDown);
		this.SkillsData.SelectedIndexChanged += new System.EventHandler(SkillsData_SelectedIndexChanged);
		this.SkillsData.DoubleClick += new System.EventHandler(skillsDblClick);
		this.SpellsTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpellsTab.Controls.Add(this.SpSelectedTB);
		this.SpellsTab.Controls.Add(this.SpAllTB);
		this.SpellsTab.Controls.Add(this.label7);
		this.SpellsTab.Controls.Add(this.label8);
		this.SpellsTab.Controls.Add(this.SpellPercTB);
		this.SpellsTab.Controls.Add(this.SpellsSBtn);
		this.SpellsTab.Controls.Add(this.SpellsMBtn);
		this.SpellsTab.Controls.Add(this.copySpellsBtn);
		this.SpellsTab.Controls.Add(this.SpellCost2);
		this.SpellsTab.Controls.Add(this.SpellCost1);
		this.SpellsTab.Controls.Add(this.SpellCostLbl);
		this.SpellsTab.Controls.Add(this.SpellDLbl);
		this.SpellsTab.Controls.Add(this.SpellDescript);
		this.SpellsTab.Controls.Add(this.SpellsLbl);
		this.SpellsTab.Controls.Add(this.SpellsData);
		((System.Windows.Forms.Control)this.SpellsTab).Location = new System.Drawing.Point(4, 25);
		this.SpellsTab.Name = "SpellsTab";
		this.SpellsTab.Size = new System.Drawing.Size(904, 600);
		this.SpellsTab.TabIndex = 4;
		this.SpellsTab.Text = "Spells";
		this.SpSelectedTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpSelectedTB.Location = new System.Drawing.Point(264, 496);
		this.SpSelectedTB.Name = "SpSelectedTB";
		this.SpSelectedTB.ReadOnly = true;
		this.SpSelectedTB.Size = new System.Drawing.Size(120, 23);
		this.SpSelectedTB.TabIndex = 24;
		this.SpSelectedTB.Text = "0";
		this.SpSelectedTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.SpAllTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpAllTB.Location = new System.Drawing.Point(264, 528);
		this.SpAllTB.Name = "SpAllTB";
		this.SpAllTB.ReadOnly = true;
		this.SpAllTB.Size = new System.Drawing.Size(120, 23);
		this.SpAllTB.TabIndex = 23;
		this.SpAllTB.Text = "0";
		this.SpAllTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label7.Location = new System.Drawing.Point(40, 528);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(216, 24);
		this.label7.TabIndex = 22;
		this.label7.Text = "Total Exp for all Spells:";
		this.label8.Location = new System.Drawing.Point(40, 496);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(208, 24);
		this.label8.TabIndex = 21;
		this.label8.Text = "Exp for selected Spells:";
		this.SpellPercTB.Location = new System.Drawing.Point(40, 456);
		this.SpellPercTB.MaxLength = 3;
		this.SpellPercTB.Name = "SpellPercTB";
		this.SpellPercTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.SpellPercTB.Size = new System.Drawing.Size(72, 23);
		this.SpellPercTB.TabIndex = 20;
		this.SpellPercTB.Text = "0";
		this.SpellsSBtn.Location = new System.Drawing.Point(128, 456);
		this.SpellsSBtn.Name = "SpellsSBtn";
		this.SpellsSBtn.Size = new System.Drawing.Size(98, 23);
		this.SpellsSBtn.TabIndex = 19;
		this.SpellsSBtn.Text = "Set Selected";
		this.SpellsSBtn.Click += new System.EventHandler(SpellsSBtn_Click);
		this.SpellsMBtn.Location = new System.Drawing.Point(232, 456);
		this.SpellsMBtn.Name = "SpellsMBtn";
		this.SpellsMBtn.Size = new System.Drawing.Size(98, 23);
		this.SpellsMBtn.TabIndex = 18;
		this.SpellsMBtn.Text = "Max Selected";
		this.SpellsMBtn.Click += new System.EventHandler(SpellsMBtn_Click);
		this.copySpellsBtn.Location = new System.Drawing.Point(336, 456);
		this.copySpellsBtn.Name = "copySpellsBtn";
		this.copySpellsBtn.Size = new System.Drawing.Size(98, 23);
		this.copySpellsBtn.TabIndex = 20;
		this.copySpellsBtn.Text = "Copy";
		this.copySpellsBtn.Click += new System.EventHandler(copySpellsBtn_Click);
		this.SpellCost2.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpellCost2.Font = new System.Drawing.Font("Courier New", 9f);
		this.SpellCost2.Location = new System.Drawing.Point(664, 344);
		this.SpellCost2.Multiline = true;
		this.SpellCost2.Name = "SpellCost2";
		this.SpellCost2.ReadOnly = true;
		this.SpellCost2.Size = new System.Drawing.Size(216, 208);
		this.SpellCost2.TabIndex = 15;
		this.SpellCost2.Text = "";
		this.SpellCost1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpellCost1.Font = new System.Drawing.Font("Courier New", 9f);
		this.SpellCost1.Location = new System.Drawing.Point(448, 344);
		this.SpellCost1.Multiline = true;
		this.SpellCost1.Name = "SpellCost1";
		this.SpellCost1.ReadOnly = true;
		this.SpellCost1.Size = new System.Drawing.Size(216, 208);
		this.SpellCost1.TabIndex = 14;
		this.SpellCost1.Text = "";
		this.SpellCostLbl.Font = new System.Drawing.Font("Times New Roman", 14f);
		this.SpellCostLbl.Location = new System.Drawing.Point(432, 320);
		this.SpellCostLbl.Name = "SpellCostLbl";
		this.SpellCostLbl.Size = new System.Drawing.Size(240, 23);
		this.SpellCostLbl.TabIndex = 13;
		this.SpellCostLbl.Text = "Estimated Spell Costs:";
		this.SpellDLbl.Font = new System.Drawing.Font("Times New Roman", 14f);
		this.SpellDLbl.Location = new System.Drawing.Point(424, 24);
		this.SpellDLbl.Name = "SpellDLbl";
		this.SpellDLbl.Size = new System.Drawing.Size(240, 23);
		this.SpellDLbl.TabIndex = 12;
		this.SpellDLbl.Text = "Spell Description:";
		this.SpellDescript.BackColor = System.Drawing.Color.WhiteSmoke;
		this.SpellDescript.Font = new System.Drawing.Font("Courier New", 10f);
		this.SpellDescript.Location = new System.Drawing.Point(448, 56);
		this.SpellDescript.Multiline = true;
		this.SpellDescript.Name = "SpellDescript";
		this.SpellDescript.ReadOnly = true;
		this.SpellDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.SpellDescript.Size = new System.Drawing.Size(424, 248);
		this.SpellDescript.TabIndex = 11;
		this.SpellDescript.Text = "";
		this.SpellsLbl.Font = new System.Drawing.Font("Times New Roman", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.SpellsLbl.Location = new System.Drawing.Point(8, 16);
		this.SpellsLbl.Name = "SpellsLbl";
		this.SpellsLbl.Size = new System.Drawing.Size(240, 23);
		this.SpellsLbl.TabIndex = 7;
		this.SpellsLbl.Text = "Available Spells:";
		this.SpellsData.Font = new System.Drawing.Font("Courier New", 10f);
		this.SpellsData.ItemHeight = 16;
		this.SpellsData.Location = new System.Drawing.Point(40, 56);
		this.SpellsData.Name = "SpellsData";
		this.SpellsData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		this.SpellsData.Size = new System.Drawing.Size(350, 388);
		this.SpellsData.TabIndex = 0;
		this.SpellsData.TabStop = false;
		this.SpellsData.KeyDown += new System.Windows.Forms.KeyEventHandler(spells_keyDown);
		this.SpellsData.SelectedIndexChanged += new System.EventHandler(SpellsData_SelectedIndexChanged);
		this.SpellsData.DoubleClick += new System.EventHandler(spellsDblClick);
		this.MiscTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.MiscTab.Controls.Add(this.resistLbl);
		this.MiscTab.Controls.Add(this.label32);
		this.MiscTab.Controls.Add(this.statBtn);
		this.MiscTab.Controls.Add(this.strStTB);
		this.MiscTab.Controls.Add(this.chaStTB);
		this.MiscTab.Controls.Add(this.dexStTB);
		this.MiscTab.Controls.Add(this.conStTB);
		this.MiscTab.Controls.Add(this.wisStTB);
		this.MiscTab.Controls.Add(this.intStTB);
		this.MiscTab.Controls.Add(this.label24);
		this.MiscTab.Controls.Add(this.label23);
		this.MiscTab.Controls.Add(this.label22);
		this.MiscTab.Controls.Add(this.label21);
		this.MiscTab.Controls.Add(this.label20);
		this.MiscTab.Controls.Add(this.label19);
		this.MiscTab.Controls.Add(this.label2);
		((System.Windows.Forms.Control)this.MiscTab).Location = new System.Drawing.Point(4, 25);
		this.MiscTab.Name = "MiscTab";
		this.MiscTab.Size = new System.Drawing.Size(904, 600);
		this.MiscTab.TabIndex = 6;
		this.MiscTab.Text = "Miscellaneous";
		this.WishesTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.WishesTab.Controls.Add(this.label26);
		this.WishesTab.Controls.Add(this.groupBox1);
		this.WishesTab.Controls.Add(this.label27);
		this.WishesTab.Controls.Add(this.TpTB);
		((System.Windows.Forms.Control)this.WishesTab).Location = new System.Drawing.Point(4, 25);
		this.WishesTab.Name = "WishesTab";
		this.WishesTab.Size = new System.Drawing.Size(904, 700);
		this.WishesTab.TabIndex = 7;
		this.WishesTab.Text = "Wishes";
		this.resistLbl.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.resistLbl.Location = new System.Drawing.Point(72, 440);
		this.resistLbl.Name = "resistLbl";
		this.resistLbl.Size = new System.Drawing.Size(312, 136);
		this.resistLbl.TabIndex = 32;
		this.label32.Font = new System.Drawing.Font("Courier New", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label32.Location = new System.Drawing.Point(40, 400);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(200, 23);
		this.label32.TabIndex = 31;
		this.label32.Text = "Resistances:";
		this.groupBox1.Controls.Add(this.gSkill);
		this.groupBox1.Controls.Add(this.gStats);
		this.groupBox1.Controls.Add(this.gPhys);
		this.groupBox1.Controls.Add(this.gMag);
		this.groupBox1.Controls.Add(this.gCriticalBlow);
		this.groupBox1.Controls.Add(this.gHaste);
		this.groupBox1.Controls.Add(this.trueSeeing);
		this.groupBox1.Controls.Add(this.thickSkin);
		this.groupBox1.Controls.Add(this.lPhys);
		this.groupBox1.Controls.Add(this.lMag);
		this.groupBox1.Controls.Add(this.lCriticalBlow);
		this.groupBox1.Controls.Add(this.lHaste);
		this.groupBox1.Controls.Add(this.lSkill);
		this.groupBox1.Controls.Add(this.lStats);
		this.groupBox1.Controls.Add(this.ambidexterity);
		this.groupBox1.Controls.Add(this.elementalAttunement);
		this.groupBox1.Controls.Add(this.giantSize);
		this.groupBox1.Controls.Add(this.improvedStr);
		this.groupBox1.Controls.Add(this.improvedDex);
		this.groupBox1.Controls.Add(this.improvedCon);
		this.groupBox1.Controls.Add(this.improvedInt);
		this.groupBox1.Controls.Add(this.improvedWis);
		this.groupBox1.Controls.Add(this.improvedCha);
		this.groupBox1.Controls.Add(this.lucky);
		this.groupBox1.Controls.Add(this.lBattleRegen);
		this.groupBox1.Controls.Add(this.gBattleRegen);
		this.groupBox1.Controls.Add(this.lEndurance);
		this.groupBox1.Controls.Add(this.gEndurance);
		this.groupBox1.Controls.Add(this.gReserves);
		this.groupBox1.Controls.Add(this.lReserves);
		this.groupBox1.Controls.Add(this.gSpellDamage);
		this.groupBox1.Controls.Add(this.lSpellDamage);
		this.groupBox1.Controls.Add(this.resistAcid);
		this.groupBox1.Controls.Add(this.resistAsp);
		this.groupBox1.Controls.Add(this.resistCold);
		this.groupBox1.Controls.Add(this.resistElec);
		this.groupBox1.Controls.Add(this.resistFire);
		this.groupBox1.Controls.Add(this.resistMag);
		this.groupBox1.Controls.Add(this.resistPois);
		this.groupBox1.Controls.Add(this.resistPsi);
		this.groupBox1.Location = new System.Drawing.Point(16, 40);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(880, 820);
		this.groupBox1.TabIndex = 30;
		this.groupBox1.TabStop = false;
		this.gStats.Location = new System.Drawing.Point(576, 24);
		this.gStats.Name = "gStats";
		this.gStats.Size = new System.Drawing.Size(300, 22);
		this.gStats.TabIndex = 28;
		this.gStats.Text = "Superior stats";
		this.gStats.CheckedChanged += new System.EventHandler(gStats_CheckedChanged);
		this.gSkill.Location = new System.Drawing.Point(576, 48);
		this.gSkill.Name = "gSkill";
		this.gSkill.Size = new System.Drawing.Size(300, 22);
		this.gSkill.TabIndex = 29;
		this.gSkill.Text = "Superior knowledge";
		this.gSkill.CheckedChanged += new System.EventHandler(gSkill_CheckedChanged);
		this.gHaste.Location = new System.Drawing.Point(576, 72);
		this.gHaste.Name = "gHaste";
		this.gHaste.Size = new System.Drawing.Size(300, 22);
		this.gHaste.TabIndex = 23;
		this.gHaste.Text = "Greater casting haste";
		this.gHaste.CheckedChanged += new System.EventHandler(gHaste_CheckedChanged);
		this.gCriticalBlow.Location = new System.Drawing.Point(576, 96);
		this.gCriticalBlow.Name = "gCriticalBlow";
		this.gCriticalBlow.Size = new System.Drawing.Size(300, 22);
		this.gCriticalBlow.TabIndex = 24;
		this.gCriticalBlow.Text = "Greater critical blow";
		this.gCriticalBlow.CheckedChanged += new System.EventHandler(gCriticalBlow_CheckedChanged);
		this.gMag.Location = new System.Drawing.Point(576, 120);
		this.gMag.Name = "gMag";
		this.gMag.Size = new System.Drawing.Size(300, 22);
		this.gMag.TabIndex = 25;
		this.gMag.Text = "Greater magical improvement";
		this.gMag.CheckedChanged += new System.EventHandler(gMag_CheckedChanged);
		this.gPhys.Location = new System.Drawing.Point(576, 144);
		this.gPhys.Name = "gPhys";
		this.gPhys.Size = new System.Drawing.Size(300, 22);
		this.gPhys.TabIndex = 26;
		this.gPhys.Text = "Greater physical improvement";
		this.gPhys.CheckedChanged += new System.EventHandler(gPhys_CheckedChanged);
		this.gBattleRegen.Location = new System.Drawing.Point(576, 168);
		this.gBattleRegen.Name = "gBattleRegen";
		this.gBattleRegen.Size = new System.Drawing.Size(300, 22);
		this.gBattleRegen.TabIndex = 44;
		this.gBattleRegen.Text = "Superior battle regeneration";
		this.gBattleRegen.CheckedChanged += new System.EventHandler(gBattleRegen_CheckedChanged);
		this.gEndurance.Location = new System.Drawing.Point(576, 192);
		this.gEndurance.Name = "gEndurance";
		this.gEndurance.Size = new System.Drawing.Size(300, 22);
		this.gEndurance.TabIndex = 46;
		this.gEndurance.Text = "Superior endurance";
		this.gEndurance.CheckedChanged += new System.EventHandler(gEndurance_CheckedChanged);
		this.gReserves.Location = new System.Drawing.Point(576, 216);
		this.gReserves.Name = "gReserves";
		this.gReserves.Size = new System.Drawing.Size(300, 22);
		this.gReserves.TabIndex = 47;
		this.gReserves.Text = "Superior reserves";
		this.gReserves.CheckedChanged += new System.EventHandler(gReserves_CheckedChanged);
		this.gSpellDamage.Location = new System.Drawing.Point(576, 240);
		this.gSpellDamage.Name = "gSpellDamage";
		this.gSpellDamage.Size = new System.Drawing.Size(300, 22);
		this.gSpellDamage.TabIndex = 49;
		this.gSpellDamage.Text = "Superior spell damage";
		this.gSpellDamage.CheckedChanged += new System.EventHandler(gSpellDamage_CheckedChanged);
		this.thickSkin.Location = new System.Drawing.Point(16, 24);
		this.thickSkin.Name = "thickSkin";
		this.thickSkin.Size = new System.Drawing.Size(248, 22);
		this.thickSkin.TabIndex = 21;
		this.thickSkin.Text = "Thick skin";
		this.thickSkin.CheckedChanged += new System.EventHandler(thickSkin_CheckedChanged);
		this.trueSeeing.Location = new System.Drawing.Point(16, 48);
		this.trueSeeing.Name = "trueSeeing";
		this.trueSeeing.Size = new System.Drawing.Size(248, 22);
		this.trueSeeing.TabIndex = 22;
		this.trueSeeing.Text = "True seeing";
		this.trueSeeing.CheckedChanged += new System.EventHandler(trueSeeing_CheckedChanged);
		this.ambidexterity.Location = new System.Drawing.Point(16, 72);
		this.ambidexterity.Name = "ambidexterity";
		this.ambidexterity.Size = new System.Drawing.Size(248, 22);
		this.ambidexterity.TabIndex = 33;
		this.ambidexterity.Text = "Ambidexterity";
		this.ambidexterity.CheckedChanged += new System.EventHandler(ambidexterity_CheckedChanged);
		this.elementalAttunement.Location = new System.Drawing.Point(16, 96);
		this.elementalAttunement.Name = "elementalAttunement";
		this.elementalAttunement.Size = new System.Drawing.Size(248, 22);
		this.elementalAttunement.TabIndex = 34;
		this.elementalAttunement.Text = "Elemental attunement";
		this.elementalAttunement.CheckedChanged += new System.EventHandler(elementalAttunement_CheckedChanged);
		this.giantSize.Location = new System.Drawing.Point(16, 120);
		this.giantSize.Name = "giantSize";
		this.giantSize.Size = new System.Drawing.Size(248, 22);
		this.giantSize.TabIndex = 35;
		this.giantSize.Text = "Giant size";
		this.giantSize.CheckedChanged += new System.EventHandler(giantSize_CheckedChanged);
		this.improvedStr.Location = new System.Drawing.Point(16, 144);
		this.improvedStr.Name = "improvedStr";
		this.improvedStr.Size = new System.Drawing.Size(248, 22);
		this.improvedStr.TabIndex = 36;
		this.improvedStr.Text = "Improved strength";
		this.improvedStr.CheckedChanged += new System.EventHandler(improvedStr_CheckedChanged);
		this.improvedDex.Location = new System.Drawing.Point(16, 168);
		this.improvedDex.Name = "improvedDex";
		this.improvedDex.Size = new System.Drawing.Size(248, 22);
		this.improvedDex.TabIndex = 37;
		this.improvedDex.Text = "Improved dexterity";
		this.improvedDex.CheckedChanged += new System.EventHandler(improvedDex_CheckedChanged);
		this.improvedCon.Location = new System.Drawing.Point(16, 192);
		this.improvedCon.Name = "improvedCon";
		this.improvedCon.Size = new System.Drawing.Size(248, 22);
		this.improvedCon.TabIndex = 38;
		this.improvedCon.Text = "Improved constitution";
		this.improvedCon.CheckedChanged += new System.EventHandler(improvedCon_CheckedChanged);
		this.improvedInt.Location = new System.Drawing.Point(16, 216);
		this.improvedInt.Name = "improvedInt";
		this.improvedInt.Size = new System.Drawing.Size(248, 22);
		this.improvedInt.TabIndex = 39;
		this.improvedInt.Text = "Improved intelligence";
		this.improvedInt.CheckedChanged += new System.EventHandler(improvedInt_CheckedChanged);
		this.improvedWis.Location = new System.Drawing.Point(16, 240);
		this.improvedWis.Name = "improvedWis";
		this.improvedWis.Size = new System.Drawing.Size(248, 22);
		this.improvedWis.TabIndex = 40;
		this.improvedWis.Text = "Improved wisdom";
		this.improvedWis.CheckedChanged += new System.EventHandler(improvedWis_CheckedChanged);
		this.improvedCha.Location = new System.Drawing.Point(16, 264);
		this.improvedCha.Name = "improvedCha";
		this.improvedCha.Size = new System.Drawing.Size(248, 22);
		this.improvedCha.TabIndex = 41;
		this.improvedCha.Text = "Improved charisma";
		this.improvedCha.CheckedChanged += new System.EventHandler(improvedCha_CheckedChanged);
		this.lucky.Location = new System.Drawing.Point(16, 288);
		this.lucky.Name = "lucky";
		this.lucky.Size = new System.Drawing.Size(248, 22);
		this.lucky.TabIndex = 42;
		this.lucky.Text = "Lucky";
		this.lucky.CheckedChanged += new System.EventHandler(lucky_CheckedChanged);
		this.resistAcid.Location = new System.Drawing.Point(16, 312);
		this.resistAcid.Name = "resistAcid";
		this.resistAcid.Size = new System.Drawing.Size(248, 22);
		this.resistAcid.TabIndex = 51;
		this.resistAcid.Text = "Resist acid";
		this.resistAcid.CheckedChanged += new System.EventHandler(resistAcid_CheckedChanged);
		this.resistAsp.Location = new System.Drawing.Point(16, 336);
		this.resistAsp.Name = "resistAsp";
		this.resistAsp.Size = new System.Drawing.Size(248, 22);
		this.resistAsp.TabIndex = 52;
		this.resistAsp.Text = "Resist asphyxiation";
		this.resistAsp.CheckedChanged += new System.EventHandler(resistAsp_CheckedChanged);
		this.resistCold.Location = new System.Drawing.Point(16, 360);
		this.resistCold.Name = "resistCold";
		this.resistCold.Size = new System.Drawing.Size(248, 22);
		this.resistCold.TabIndex = 53;
		this.resistCold.Text = "Resist cold";
		this.resistCold.CheckedChanged += new System.EventHandler(resistCold_CheckedChanged);
		this.resistElec.Location = new System.Drawing.Point(16, 384);
		this.resistElec.Name = "resistElec";
		this.resistElec.Size = new System.Drawing.Size(248, 22);
		this.resistElec.TabIndex = 54;
		this.resistElec.Text = "Resist electric";
		this.resistElec.CheckedChanged += new System.EventHandler(resistElec_CheckedChanged);
		this.resistFire.Location = new System.Drawing.Point(16, 408);
		this.resistFire.Name = "resistFire";
		this.resistFire.Size = new System.Drawing.Size(248, 22);
		this.resistFire.TabIndex = 55;
		this.resistFire.Text = "Resist fire";
		this.resistFire.CheckedChanged += new System.EventHandler(resistFire_CheckedChanged);
		this.resistMag.Location = new System.Drawing.Point(16, 432);
		this.resistMag.Name = "resistMag";
		this.resistMag.Size = new System.Drawing.Size(248, 22);
		this.resistMag.TabIndex = 56;
		this.resistMag.Text = "Resist magical";
		this.resistMag.CheckedChanged += new System.EventHandler(resistMag_CheckedChanged);
		this.resistPois.Location = new System.Drawing.Point(16, 456);
		this.resistPois.Name = "resistPois";
		this.resistPois.Size = new System.Drawing.Size(248, 22);
		this.resistPois.TabIndex = 57;
		this.resistPois.Text = "Resist poison";
		this.resistPois.CheckedChanged += new System.EventHandler(resistPois_CheckedChanged);
		this.resistPsi.Location = new System.Drawing.Point(16, 480);
		this.resistPsi.Name = "resistPsi";
		this.resistPsi.Size = new System.Drawing.Size(248, 22);
		this.resistPsi.TabIndex = 58;
		this.resistPsi.Text = "Resist psionic";
		this.resistPsi.CheckedChanged += new System.EventHandler(resistPsi_CheckedChanged);
		this.lStats.Location = new System.Drawing.Point(266, 24);
		this.lStats.Name = "lStats";
		this.lStats.Size = new System.Drawing.Size(248, 22);
		this.lStats.TabIndex = 15;
		this.lStats.Text = "Lesser stats";
		this.lStats.CheckedChanged += new System.EventHandler(lStats_CheckedChanged);
		this.lSkill.Location = new System.Drawing.Point(266, 48);
		this.lSkill.Name = "lSkill";
		this.lSkill.Size = new System.Drawing.Size(248, 22);
		this.lSkill.TabIndex = 16;
		this.lSkill.Text = "Better knowledge";
		this.lSkill.CheckedChanged += new System.EventHandler(lSkill_CheckedChanged);
		this.lSpell.Visible = false;
		this.lSpell.Enabled = false;
		this.gSpell.Visible = false;
		this.gSpell.Enabled = false;
		this.lHaste.Location = new System.Drawing.Point(266, 72);
		this.lHaste.Name = "lHaste";
		this.lHaste.Size = new System.Drawing.Size(248, 22);
		this.lHaste.TabIndex = 17;
		this.lHaste.Text = "Lesser casting haste";
		this.lHaste.CheckedChanged += new System.EventHandler(lHaste_CheckedChanged);
		this.lCriticalBlow.Location = new System.Drawing.Point(266, 96);
		this.lCriticalBlow.Name = "lCriticalBlow";
		this.lCriticalBlow.Size = new System.Drawing.Size(248, 22);
		this.lCriticalBlow.TabIndex = 18;
		this.lCriticalBlow.Text = "Lesser critical blow";
		this.lCriticalBlow.CheckedChanged += new System.EventHandler(lCriticalBlow_CheckedChanged);
		this.lMag.Location = new System.Drawing.Point(266, 120);
		this.lMag.Name = "lMag";
		this.lMag.Size = new System.Drawing.Size(248, 22);
		this.lMag.TabIndex = 19;
		this.lMag.Text = "Lesser magical improvement";
		this.lMag.CheckedChanged += new System.EventHandler(lMag_CheckedChanged);
		this.lPhys.Location = new System.Drawing.Point(266, 144);
		this.lPhys.Name = "lPhys";
		this.lPhys.Size = new System.Drawing.Size(248, 22);
		this.lPhys.TabIndex = 20;
		this.lPhys.Text = "Lesser physical improvement";
		this.lPhys.CheckedChanged += new System.EventHandler(lPhys_CheckedChanged);
		this.lBattleRegen.Location = new System.Drawing.Point(266, 168);
		this.lBattleRegen.Name = "lBattleRegen";
		this.lBattleRegen.Size = new System.Drawing.Size(300, 22);
		this.lBattleRegen.TabIndex = 43;
		this.lBattleRegen.Text = "Improved battle regeneration";
		this.lBattleRegen.CheckedChanged += new System.EventHandler(lBattleRegen_CheckedChanged);
		this.lEndurance.Location = new System.Drawing.Point(266, 192);
		this.lEndurance.Name = "lEndurance";
		this.lEndurance.Size = new System.Drawing.Size(248, 22);
		this.lEndurance.TabIndex = 45;
		this.lEndurance.Text = "Improved endurance";
		this.lEndurance.CheckedChanged += new System.EventHandler(lEndurance_CheckedChanged);
		this.lReserves.Location = new System.Drawing.Point(266, 216);
		this.lReserves.Name = "lReserves";
		this.lReserves.Size = new System.Drawing.Size(248, 22);
		this.lReserves.TabIndex = 48;
		this.lReserves.Text = "Improved reserves";
		this.lReserves.CheckedChanged += new System.EventHandler(lReserves_CheckedChanged);
		this.lSpellDamage.Location = new System.Drawing.Point(266, 240);
		this.lSpellDamage.Name = "lSpellDamage";
		this.lSpellDamage.Size = new System.Drawing.Size(248, 22);
		this.lSpellDamage.TabIndex = 50;
		this.lSpellDamage.Text = "Improved spell damage";
		this.lSpellDamage.CheckedChanged += new System.EventHandler(lSpellDamage_CheckedChanged);
		this.resistPsi.CheckedChanged += new System.EventHandler(resistPsi_CheckedChanged);
		this.label27.Location = new System.Drawing.Point(222, 16);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(48, 23);
		this.label27.TabIndex = 32;
		this.label27.Text = "TPs:";
		this.TpTB.BackColor = System.Drawing.Color.WhiteSmoke;
		this.TpTB.Location = new System.Drawing.Point(270, 16);
		this.TpTB.Name = "TpTB";
		this.TpTB.ReadOnly = true;
		this.TpTB.Size = new System.Drawing.Size(120, 23);
		this.TpTB.TabIndex = 31;
		this.TpTB.Text = "0";
		this.TpTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label26.Font = new System.Drawing.Font("Courier New", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label26.Location = new System.Drawing.Point(16, 16);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(200, 23);
		this.label26.TabIndex = 13;
		this.label26.Text = "Wishes:";
		this.statBtn.Location = new System.Drawing.Point(96, 240);
		this.statBtn.Name = "statBtn";
		this.statBtn.TabIndex = 12;
		this.statBtn.Text = "Update";
		this.statBtn.Click += new System.EventHandler(statBtn_Click);
		this.strStTB.Location = new System.Drawing.Point(120, 72);
		this.strStTB.MaxLength = 2;
		this.strStTB.Name = "strStTB";
		this.strStTB.Size = new System.Drawing.Size(48, 23);
		this.strStTB.TabIndex = 6;
		this.strStTB.Text = "0";
		this.strStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.chaStTB.Location = new System.Drawing.Point(120, 192);
		this.chaStTB.MaxLength = 2;
		this.chaStTB.Name = "chaStTB";
		this.chaStTB.Size = new System.Drawing.Size(48, 23);
		this.chaStTB.TabIndex = 11;
		this.chaStTB.Text = "0";
		this.chaStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.dexStTB.Location = new System.Drawing.Point(120, 120);
		this.dexStTB.MaxLength = 2;
		this.dexStTB.Name = "dexStTB";
		this.dexStTB.Size = new System.Drawing.Size(48, 23);
		this.dexStTB.TabIndex = 8;
		this.dexStTB.Text = "0";
		this.dexStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.conStTB.Location = new System.Drawing.Point(120, 96);
		this.conStTB.MaxLength = 2;
		this.conStTB.Name = "conStTB";
		this.conStTB.Size = new System.Drawing.Size(48, 23);
		this.conStTB.TabIndex = 7;
		this.conStTB.Text = "0";
		this.conStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.wisStTB.Location = new System.Drawing.Point(120, 168);
		this.wisStTB.MaxLength = 2;
		this.wisStTB.Name = "wisStTB";
		this.wisStTB.Size = new System.Drawing.Size(48, 23);
		this.wisStTB.TabIndex = 10;
		this.wisStTB.Text = "0";
		this.wisStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.intStTB.Location = new System.Drawing.Point(120, 144);
		this.intStTB.MaxLength = 2;
		this.intStTB.Name = "intStTB";
		this.intStTB.Size = new System.Drawing.Size(48, 23);
		this.intStTB.TabIndex = 9;
		this.intStTB.Text = "0";
		this.intStTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.label24.Location = new System.Drawing.Point(64, 192);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(48, 23);
		this.label24.TabIndex = 6;
		this.label24.Text = "Cha:";
		this.label23.Location = new System.Drawing.Point(64, 168);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(48, 23);
		this.label23.TabIndex = 5;
		this.label23.Text = "Wis:";
		this.label22.Location = new System.Drawing.Point(64, 96);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(48, 23);
		this.label22.TabIndex = 4;
		this.label22.Text = "Con: ";
		this.label21.Location = new System.Drawing.Point(64, 120);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(48, 23);
		this.label21.TabIndex = 3;
		this.label21.Text = "Dex:";
		this.label20.Location = new System.Drawing.Point(64, 144);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(48, 23);
		this.label20.TabIndex = 2;
		this.label20.Text = "Int: ";
		this.label19.Location = new System.Drawing.Point(64, 72);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(48, 23);
		this.label19.TabIndex = 1;
		this.label19.Text = "Str:";
		this.label2.Font = new System.Drawing.Font("Courier New", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(24, 24);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(200, 23);
		this.label2.TabIndex = 0;
		this.label2.Text = "Stat Training:";
		this.helpTab.BackColor = System.Drawing.Color.WhiteSmoke;
		this.helpTab.Controls.Add(this.label17);
		this.helpTab.Controls.Add(this.helpLBL);
		((System.Windows.Forms.Control)this.helpTab).Location = new System.Drawing.Point(4, 25);
		this.helpTab.Name = "helpTab";
		this.helpTab.Size = new System.Drawing.Size(904, 600);
		this.helpTab.TabIndex = 7;
		this.helpTab.Text = "Help";
		this.label17.Font = new System.Drawing.Font("Times New Roman", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label17.Location = new System.Drawing.Point(16, 16);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(272, 23);
		this.label17.TabIndex = 1;
		this.label17.Text = "Helpful Information:";
		this.helpLBL.Location = new System.Drawing.Point(40, 56);
		this.helpLBL.Name = "helpLBL";
		this.helpLBL.Size = new System.Drawing.Size(832, 512);
		this.helpLBL.TabIndex = 0;
		this.helpLBL.Multiline = true;
		this.helpLBL.ReadOnly = true;
		this.helpLBL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.helpLBL.BackColor = System.Drawing.Color.WhiteSmoke;
		this.helpLBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.helpLBL.Font = new System.Drawing.Font("Courier New", 9f);
		this.helpLBL.WordWrap = false;
		this.helpLBL.AcceptsReturn = true;
		this.helpLBL.AcceptsTab = false;
		this.saveCharacter.Filter = "Text file|*.txt";
		this.saveCharacter.FileOk += new System.ComponentModel.CancelEventHandler(saveCharacter_FileOk);
		this.saveTrainStudy.Filter = "Text file|*.txt";
		this.saveTrainStudy.FileOk += new System.ComponentModel.CancelEventHandler(saveTrainStudy_FileOk);
		this.saveTrainStudy.DefaultExt = "txt";
		this.loadCharacter.Filter = "Text file|*.txt";
		this.loadCharacter.FileOk += new System.ComponentModel.CancelEventHandler(loadCharacter_FileOk);
		this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[4] { this.save, this.load, this.checkUpdates, this.saveTrainStudyMenuItem });
		this.save.Index = 0;
		this.save.Text = "S&ave Character";
		this.save.Click += new System.EventHandler(save_Click);
		this.load.Index = 1;
		this.load.Text = "&Load Character";
		this.load.Click += new System.EventHandler(load_Click);
		this.checkUpdates.Index = 2;
		this.checkUpdates.Text = "Check for Updates (GitHub)";
		this.checkUpdates.Click += new System.EventHandler(checkUpdates_Click);
		this.saveTrainStudyMenuItem.Index = 3;
		this.saveTrainStudyMenuItem.Text = "Save Train/Study Commands";
		this.saveTrainStudyMenuItem.Click += new System.EventHandler(saveTrainStudyMenu_Click);
		this.guildInfo.Index = -1;
		this.guildInfo.Text = "";
		this.guildInfo.Click += new System.EventHandler(guildInfo_Click);
		this.raceInfo.Index = -1;
		this.raceInfo.Text = "";
		this.raceInfo.Click += new System.EventHandler(raceInfo_Click);
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(904, 602);
		base.Controls.Add(this.tabController);
		this.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Menu = this.mainMenu1;
		base.Name = "CharCreator";
		this.Text = "Nashira's zCreator";
		this.tabController.ResumeLayout(false);
		this.generalTab.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.SkillsTab.ResumeLayout(false);
		this.SpellsTab.ResumeLayout(false);
		this.MiscTab.ResumeLayout(false);
		this.WishesTab.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.helpTab.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void tabController_DrawItem(object sender, DrawItemEventArgs e)
	{
		TabPage tabPage = tabController.TabPages[e.Index];
		Rectangle rectangle = tabController.GetTabRect(e.Index);
		SolidBrush solidBrush = new SolidBrush(Color.WhiteSmoke);
		SolidBrush solidBrush2 = new SolidBrush(Color.DarkGray);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		if (Convert.ToBoolean(e.State & DrawItemState.Selected))
		{
			solidBrush.Color = Color.WhiteSmoke;
			solidBrush2.Color = Color.Black;
			rectangle.Inflate(2, 3);
		}
		if (tabController.Alignment == TabAlignment.Left || tabController.Alignment == TabAlignment.Right)
		{
			float angle = 90f;
			if (tabController.Alignment == TabAlignment.Left)
			{
				angle = 270f;
			}
			PointF pointF = new PointF(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2);
			e.Graphics.TranslateTransform(pointF.X, pointF.Y);
			e.Graphics.RotateTransform(angle);
			rectangle = new Rectangle(-(rectangle.Height / 2), -(rectangle.Width / 2), rectangle.Height, rectangle.Width);
		}
		e.Graphics.FillRectangle(solidBrush, rectangle);
		e.Graphics.DrawString(tabPage.Text, e.Font, solidBrush2, rectangle, stringFormat);
		e.Graphics.ResetTransform();
		solidBrush.Dispose();
		solidBrush2.Dispose();
	}

	protected void MyPopupHandler(object sender, EventArgs e)
	{
		contextMenu.MenuItems.Clear();
		if (contextMenu.SourceControl == MainGuildBox)
		{
			mousePoint = Control.MousePosition;
			int index = MainGuildBox.IndexFromPoint(MainGuildBox.PointToClient(mousePoint));
			Guild guild = (Guild)displayGuilds[index];
			guildInfo.Text = "Info on " + guild.GuildName;
			contextMenu.MenuItems.Add(guildInfo);
		}
		else
		{
			mousePoint = Control.MousePosition;
			int index2 = RaceBox.IndexFromPoint(RaceBox.PointToClient(mousePoint));
			Race race = (Race)displayRaces[index2];
			raceInfo.Text = "Info on " + race.RaceName;
			contextMenu.MenuItems.Add(raceInfo);
		}
	}

	[STAThread]
	private static void Main(string[] args)
	{
		try
		{
			Application.Run(new CharCreator());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public void loadAll()
	{
		try
		{
			StreamReader streamReader = File.OpenText(dataPath + "races.chr");
			loadRaces(streamReader);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "guilds.chr");
			loadGuilds(streamReader, priv: false);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "skills.chr");
			loadSkillsSpells(streamReader, skills);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "spells.chr");
			loadSkillsSpells(streamReader, spells);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "costs.txt");
			loadSSCosts(streamReader);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "help_skill.chr");
			loadHelp(streamReader, skills, priv: false);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "help_spell.chr");
			loadHelp(streamReader, spells, priv: false);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "levelcosts.chr");
			cs.lvlArray = loadCosts(streamReader, 120);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "questpoints.chr");
			cs.qpArray = loadCosts(streamReader, 120);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "statcost.chr");
			cs.statArray = loadCosts(streamReader, 120);
			streamReader.Close();
			streamReader = File.OpenText(dataPath + "wishcost.chr");
			cs.lesserCosts = loadCosts(streamReader, 9);
			cs.greaterCosts = loadCosts(streamReader, 9);
			streamReader.Close();
			string text = dataPath.Substring(0, dataPath.LastIndexOf("\\"));
			text = text.Substring(0, text.LastIndexOf("\\") + 1) + "HELP.txt";
			if (File.Exists(text))
			{
				streamReader = File.OpenText(text);
				loadHelpFile(streamReader);
				streamReader.Close();
			}
			else
			{
				helpLBL.Text = "Unable to find file HELP.txt, so no information available." + Environment.NewLine;
			}
			streamReader = File.OpenText(dataPath + "help_races.chr");
			loadRaceHelp(streamReader);
			streamReader.Close();
			loadPrivateFiles();
			RaceBox.DisplayMember = "RaceName";
			RaceBox.ValueMember = "RaceName";
			RaceBox.DataSource = displayRaces;
			MainGuildBox.DisplayMember = "GuildString";
			MainGuildBox.ValueMember = "GuildString";
			MainGuildBox.DataSource = displayGuilds;
			updateDisplay();
		}
		catch (Exception)
		{
			MessageBox.Show("Error loading one or more files.  Hit the update button to download\r\nanything that is missing or has since been updated!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public void loadPrivateFiles()
	{
		if (File.Exists(privatePath + "help_privateSkill.chr"))
		{
			StreamReader streamReader = File.OpenText(privatePath + "help_privateSkill.chr");
			loadHelp(streamReader, skills, priv: true);
			streamReader.Close();
		}
		if (File.Exists(privatePath + "help_privateSpell.chr"))
		{
			StreamReader streamReader2 = File.OpenText(privatePath + "help_privateSpell.chr");
			loadHelp(streamReader2, spells, priv: true);
			streamReader2.Close();
		}
		if (File.Exists(privatePath + "privateGuilds.chr"))
		{
			StreamReader streamReader3 = File.OpenText(privatePath + "privateGuilds.chr");
			loadGuilds(streamReader3, priv: true);
			streamReader3.Close();
		}
		if (File.Exists(privatePath + "privateRaces.chr"))
		{
			StreamReader streamReader4 = File.OpenText(privatePath + "privateRaces.chr");
			loadRaces(streamReader4);
			streamReader4.Close();
		}
	}

	public void loadRaces(StreamReader br)
	{
		for (string text = br.ReadLine(); text != null; text = br.ReadLine())
		{
			if (!text.StartsWith("#"))
			{
				StringTokenizer stringTokenizer = new StringTokenizer(text, ":");
				Race value = new Race(stringTokenizer.NextToken().Trim(), stringTokenizer);
				completeRaces.Add(value);
			}
		}
		displayRaces = new ArrayList(completeRaces);
	}

	public void loadGuilds(StreamReader br, bool priv)
	{
		for (string text = br.ReadLine(); text != null; text = br.ReadLine())
		{
			int num = text.IndexOf(" ");
			Guild value = new Guild(text.Substring(0, num), priv, int.Parse(text.Substring(num + 1)));
			completeGuilds.Add(value);
		}
		for (int i = 0; i < completeGuilds.Count; i++)
		{
			Guild obj = (Guild)completeGuilds[i];
			string path = (obj.isPrivate ? privatePath : dataPath);
			obj.loadLevels(path, completeGuilds);
		}
		displayGuilds = new ArrayList(completeGuilds);
		displayGuilds.Sort();
	}

	public void loadSkillsSpells(StreamReader br, ArrayList stuff)
	{
		string text = br.ReadLine();
		for (text = br.ReadLine(); text != null; text = br.ReadLine())
		{
			if (!text.Equals(""))
			{
				int num = text.IndexOf(":");
				string name = text.Substring(0, num).Trim();
				string s = text.Substring(num + 1, text.Length - num - 1).Trim();
				SkillSpell value = new SkillSpell(name, int.Parse(s));
				stuff.Add(value);
			}
		}
	}

	public void loadSSCosts(StreamReader br)
	{
		for (string text = br.ReadLine(); text != null; text = br.ReadLine())
		{
			StringTokenizer stringTokenizer = new StringTokenizer(text, " \t");
			int num = int.Parse(stringTokenizer.NextToken().Trim());
			int.Parse(stringTokenizer.NextToken().Trim());
			int num2 = int.Parse(stringTokenizer.NextToken().Trim());
			int num3 = num / 5;
			costs[num3] = num2;
		}
	}

	public void updateSkillSpellCosts()
	{
		for (int i = 0; i < skills.Count; i++)
		{
			((SkillSpell)skills[i]).setCosts(cs.charRace.skillCost, costs);
		}
		for (int j = 0; j < spells.Count; j++)
		{
			((SkillSpell)spells[j]).setCosts(cs.charRace.spellCost, costs);
		}
	}

	public void loadHelp(StreamReader br, ArrayList list, bool priv)
	{
		ArrayList arrayList = new ArrayList();
		int num = 1;
		string text = br.ReadLine();
		try
		{
			while (text != null)
			{
				string text2 = text;
				string text3 = ((text.IndexOf(".") == -1) ? text.Substring(14, text.Length - 14).Trim().ToLower() : text.Substring(14, text.Length - 15).Trim().ToLower());
				SkillSpell skillSpell = new SkillSpell(text3, 0);
				SkillSpell skillSpell2;
				if (!list.Contains(skillSpell))
				{
					skillSpell2 = skillSpell;
					arrayList.Add(text3);
				}
				else
				{
					skillSpell2 = (SkillSpell)list[list.IndexOf(skillSpell)];
				}
				text = br.ReadLine();
				text2 = text2 + "\n" + text;
				text = br.ReadLine();
				text2 = text2 + "\n" + text;
				num += 2;
				int num2 = text.IndexOf(":");
				skillSpell2.SSType = text.Substring(num2 + 1, text.Length - num2 - 2).Trim();
				bool flag = skillSpell2.Descript != null;
				text = br.ReadLine();
				num++;
				while (text.Equals(""))
				{
					num++;
					text = br.ReadLine();
				}
				while (text != null && !text.StartsWith("Help on"))
				{
					if (!flag)
					{
						SkillSpell skillSpell3 = skillSpell2;
						skillSpell3.Descript = skillSpell3.Descript + text.Trim() + " ";
						text2 = text2 + "\n" + text;
					}
					text = br.ReadLine();
					num++;
					while (text != null && (text.Equals("") || text.StartsWith("-----")))
					{
						text = br.ReadLine();
						num++;
						skillSpell2.Descript += "\r\n";
					}
				}
				if (!flag)
				{
					skillSpell2.raw = text2;
				}
				skillSpell2.privateSS = priv;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		if (arrayList.Count <= 0)
		{
			return;
		}
		string text4 = "";
		int num3 = 0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			if ((text4.Length - 3 * num3) / 40 != num3)
			{
				text4 += "\r\n\t";
				num3++;
			}
			text4 = string.Concat(text4, arrayList[i], ", ");
		}
		text4 = "The following files were found the in help_skill/spell file\r\n, but not in skill/spell.chr respectively:\r\n\t" + text4.Substring(0, text4.Length - 2);
		MessageBox.Show(text4, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public int[] loadCosts(StreamReader br, int num)
	{
		int[] array = new int[num];
		string text = br.ReadLine();
		int num2 = 0;
		while (text != null && num2 < num)
		{
			array[num2] = int.Parse(text);
			num2++;
			if (num2 < num)
			{
				text = br.ReadLine();
			}
		}
		return array;
	}

	public void loadHelpFile(StreamReader br)
	{
		string text = br.ReadLine();
		while (text != null && !text.StartsWith("-----"))
		{
			text = br.ReadLine();
		}
		StringBuilder stringBuilder = new StringBuilder();
		while ((text = br.ReadLine()) != null)
		{
			stringBuilder.AppendLine(text);
		}
		helpLBL.Text = stringBuilder.ToString();
	}

	public void loadRaceHelp(StreamReader br)
	{
		for (string text = br.ReadLine(); text != null; text = br.ReadLine())
		{
			while (!text.ToLower().StartsWith("help"))
			{
				text = br.ReadLine();
			}
			Race race = new Race(text.Substring(10, text.Length - 10).Trim());
			if (completeRaces.Contains(race))
			{
				Race race2 = (Race)completeRaces[completeRaces.IndexOf(race)];
				text = br.ReadLine();
				while (text != null && !text.StartsWith("-----"))
				{
					race2.descript = race2.descript + text + "\r\n";
					text = br.ReadLine();
				}
			}
		}
	}

	private void ResetBTN_Click(object sender, EventArgs e)
	{
		resetALL();
	}

	private void RaceBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!loading)
		{
			cs.charRace = (Race)displayRaces[RaceBox.SelectedIndex];
			updateSkillSpellCosts();
			int[] trained = cs.trained;
			cs.trained = trained;
			updateDisplay();
		}
	}

	private void MainGuildBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		Guild guild = (Guild)displayGuilds[MainGuildBox.SelectedIndex];
		guildlevels.Text = guild.level + "/" + (guild.availLevels + guild.level);
	}

	public void updateGuildInfo(Guild g, int add)
	{
		if (add > g.availLevels + g.level)
		{
			add = g.availLevels + g.level;
		}
		int delta = add - g.level;
		cs.addGuild(g, add);
		addSubGuilds(g, g.isPrivate, delta);
		if (add != 0 && g.level != add && cs.free != 0)
		{
			MessageBox.Show("You've maxed out on available levels, please decrease the number of free levels and try again.", "FYI....", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		cs.updateExperience();
	}

	public void updateGuildRaceList()
	{
		Race charRace = cs.charRace;
		displayGuilds = new ArrayList(completeGuilds);
		displayRaces = new ArrayList(completeRaces);
		for (int i = 0; i < cs.guilds.Count; i++)
		{
			Guild guild = (Guild)cs.guilds[i];
			for (int j = 0; j < guild.nGuilds.Count; j++)
			{
				Guild guild2 = (Guild)guild.nGuilds[j];
				if (displayGuilds.Contains(guild2))
				{
					displayGuilds.Remove(guild2);
				}
			}
			for (int k = 0; k < guild.nRaces.Count; k++)
			{
				Race race = (Race)guild.nRaces[k];
				if (displayRaces.Contains(race))
				{
					displayRaces.Remove(race);
				}
			}
		}
		for (int l = 0; l < displayGuilds.Count; l++)
		{
			Guild guild3 = (Guild)displayGuilds[l];
			for (int m = 0; m < cs.guilds.Count; m++)
			{
				Guild item = (Guild)cs.guilds[m];
				if (guild3.nGuilds.Contains(item))
				{
					displayGuilds.Remove(guild3);
					break;
				}
			}
		}
		RaceBox.BeginUpdate();
		RaceBox.DataSource = new ArrayList();
		RaceBox.DataSource = displayRaces;
		RaceBox.DisplayMember = "RaceName";
		RaceBox.ValueMember = "RaceName";
		int num = displayRaces.IndexOf(charRace);
		RaceBox.SelectedIndex = ((num > 0) ? num : 0);
		RaceBox.EndUpdate();
	}

	private void addGuildBTN_Click(object sender, EventArgs e)
	{
		loading = true;
		string text = "";
		if (sender.Equals(addGuild))
		{
			text = guildlevels.Text;
			if (guildlevels.Text.IndexOf("/") != -1)
			{
				text = guildlevels.Text.Substring(0, guildlevels.Text.IndexOf("/"));
			}
		}
		else
		{
			text = "66";
		}
		if (isNumber(text, skillspell: false))
		{
			Guild guild = (Guild)displayGuilds[MainGuildBox.SelectedIndex];
			int num = int.Parse(text);
			if (num == 66)
			{
				num = ((guild.level != guild.maxLvls) ? guild.maxLvls : 0);
			}
			updateGuildInfo(guild, num);
			updateDisplay();
			if (num == 0)
			{
				updateSpellsTab();
				updateSkillsTab();
			}
			levelsTB.Text = cs.totalLevels.ToString();
		}
		else
		{
			MessageBox.Show("Please enter a valid NUMBER!", "Invalid Entry!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		loading = false;
	}

	private void guildlevels_GotFocus(object sender, EventArgs e)
	{
		Guild guild = (Guild)displayGuilds[MainGuildBox.SelectedIndex];
		guildlevels.Text = (guild.availLevels + guild.level).ToString();
	}

	private void guildlevels_LostFocus(object sender, EventArgs e)
	{
		Guild guild = (Guild)displayGuilds[MainGuildBox.SelectedIndex];
		TextBox textBox = guildlevels;
		textBox.Text = textBox.Text + "/" + (guild.level + guild.availLevels);
	}

	private void SkillsData_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (SkillsData.SelectedIndices.Count == 1 && !loading && tabController.SelectedTab == SkillsTab)
		{
			updateCostDisplays(skills: true);
			SkillSpell skillSpell = (SkillSpell)cs.availableSkills[SkillsData.SelectedIndex];
			SkillDescript.Text = skillSpell.Descript;
		}
		else
		{
			SkillCost1.Text = "";
			SkillCost2.Text = "";
			SkillDescript.Text = "";
		}
		SkAllTB.Text = $"{cs.skillsExp:#,0}";
		SkSelectedTB.Text = $"{cs.getExperience(new ArrayList(SkillsData.SelectedItems)):#,0}";
	}

	private void SpellsData_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (SpellsData.SelectedIndices.Count == 1 && !loading && tabController.SelectedTab == SpellsTab)
		{
			updateCostDisplays(skills: false);
			SkillSpell skillSpell = (SkillSpell)cs.availableSpells[SpellsData.SelectedIndex];
			SpellDescript.Text = skillSpell.Descript;
		}
		else
		{
			SpellCost1.Text = "";
			SpellCost2.Text = "";
			SpellDescript.Text = "";
		}
		SpAllTB.Text = $"{cs.spellsExp:#,0}";
		SpSelectedTB.Text = $"{cs.getExperience(new ArrayList(SpellsData.SelectedItems)):#,0}";
	}

	private void QPTB_TextChanged(object sender, EventArgs e)
	{
		if (isNumber(QPTB.Text, skillspell: false))
		{
			cs.qps = int.Parse(QPTB.Text);
			updateDisplay();
		}
		else
		{
			QPTB.Text = "0";
		}
	}

	private void freeLevelsTB_TextChanged(object sender, EventArgs e)
	{
		if (isNumber(freeLevelsTB.Text, skillspell: false))
		{
			cs.free = int.Parse(freeLevelsTB.Text);
			freeLevelsTB.Text = cs.free.ToString();
			levelsTB.Text = cs.totalLevels.ToString();
			updateDisplay();
		}
		else
		{
			freeLevelsTB.Text = "0";
		}
	}

	private void skills_keyDown(object sender, KeyEventArgs e)
	{
		if (e.Alt)
		{
			if (e.KeyCode == Keys.X)
			{
				SkillMBtn_Click(sender, null);
			}
			else if (e.KeyCode == Keys.S)
			{
				SkillSBtn_Click(sender, null);
			}
			else if (e.KeyCode == Keys.Z)
			{
				for (int i = 0; i < SkillsData.SelectedItems.Count; i++)
				{
					((SkillSpell)SkillsData.SelectedItems[i]).learned = 0;
				}
				cs.updateExperience();
				updateSkillsTab();
			}
		}
		else
		{
			_ = e.KeyCode.ToString() + ";";
		}
	}

	private void skillsDblClick(object sender, EventArgs e)
	{
		SkillSpell skillSpell = (SkillSpell)SkillsData.SelectedItem;
		if (skillSpell != null)
		{
			if (skillSpell.learned != skillSpell.scaledPercent)
			{
				skillSpell.learned = ((skillSpell.scaledPercent > 100) ? skillSpell.scaledPercent : 100);
			}
			else
			{
				skillSpell.learned = 0;
			}
		}
		cs.updateExperience();
		updateSkillsTab();
	}

	private void spells_keyDown(object sender, KeyEventArgs e)
	{
		if (!e.Alt)
		{
			return;
		}
		if (e.KeyCode == Keys.X)
		{
			SpellsMBtn_Click(sender, null);
		}
		else if (e.KeyCode == Keys.S)
		{
			SpellsSBtn_Click(sender, null);
		}
		else if (e.KeyCode == Keys.Z)
		{
			for (int i = 0; i < SpellsData.SelectedItems.Count; i++)
			{
				((SkillSpell)SpellsData.SelectedItems[i]).learned = 0;
			}
			cs.updateExperience();
			updateSpellsTab();
		}
	}

	private void spellsDblClick(object sender, EventArgs e)
	{
		SkillSpell skillSpell = (SkillSpell)SpellsData.SelectedItem;
		if (skillSpell != null)
		{
			if (skillSpell.learned != skillSpell.scaledPercent)
			{
				skillSpell.learned = ((skillSpell.scaledPercent > 100) ? skillSpell.scaledPercent : 100);
			}
			else
			{
				skillSpell.learned = 0;
			}
		}
		cs.updateExperience();
		updateSpellsTab();
	}

	private void guildInfo_Click(object sender, EventArgs e)
	{
		int index = MainGuildBox.IndexFromPoint(MainGuildBox.PointToClient(mousePoint));
		new GuildDisplay((Guild)displayGuilds[index]);
	}

	private void raceInfo_Click(object sender, EventArgs e)
	{
		int index = RaceBox.IndexFromPoint(RaceBox.PointToClient(mousePoint));
		new RaceDisplay((Race)displayRaces[index]);
	}

	private void SkillSBtn_Click(object sender, EventArgs e)
	{
		if (!isNumber(SkillPercTB.Text, skillspell: true))
		{
			MessageBox.Show("Must enter a multiple of five to train a skill or spell.", "Invalid percentage entered!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int learned = int.Parse(SkillPercTB.Text);
		for (int i = 0; i < SkillsData.SelectedItems.Count; i++)
		{
			((SkillSpell)SkillsData.SelectedItems[i]).learned = learned;
		}
		cs.updateExperience();
		updateSkillsTab();
	}

	private void SkillMBtn_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < SkillsData.SelectedItems.Count; i++)
		{
			SkillSpell skillSpell = (SkillSpell)SkillsData.SelectedItems[i];
			skillSpell.learned = ((skillSpell.scaledPercent > 100) ? skillSpell.scaledPercent : 100);
		}
		cs.updateExperience();
		updateSkillsTab();
	}

	private void SpellsSBtn_Click(object sender, EventArgs e)
	{
		if (!isNumber(SpellPercTB.Text, skillspell: true))
		{
			MessageBox.Show("Must enter a multiple of five to train a skill or spell.", "Invalid percentage entered!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int learned = int.Parse(SpellPercTB.Text);
		for (int i = 0; i < SpellsData.SelectedItems.Count; i++)
		{
			((SkillSpell)SpellsData.SelectedItems[i]).learned = learned;
		}
		cs.updateExperience();
		updateSpellsTab();
	}

	private void copySkillsBtn_Click(object sender, EventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		for (int i = 0; i < cs.availableSkills.Count; i++)
		{
			SkillSpell skillSpell = (SkillSpell)cs.availableSkills[i];
			int learned = skillSpell.learned;
			if (learned <= 0)
			{
				continue;
			}
			int num = learned / 5;
			if (num <= 0)
			{
				continue;
			}
			if (num <= 20)
			{
				if (!flag)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(num);
				stringBuilder.Append(" train ");
				stringBuilder.Append(skillSpell.SSName);
				flag = false;
				continue;
			}
			int num2 = num;
			while (num2 > 0)
			{
				if (!flag)
				{
					stringBuilder.Append(";");
				}
				int num3 = ((num2 > 20) ? 20 : num2);
				stringBuilder.Append(num3);
				stringBuilder.Append(" train ");
				stringBuilder.Append(skillSpell.SSName);
				num2 -= num3;
				flag = false;
			}
		}
		if (stringBuilder.Length > 0)
		{
			Clipboard.SetText(stringBuilder.ToString());
		}
	}

	private void copySpellsBtn_Click(object sender, EventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		for (int i = 0; i < cs.availableSpells.Count; i++)
		{
			SkillSpell skillSpell = (SkillSpell)cs.availableSpells[i];
			int learned = skillSpell.learned;
			if (learned <= 0)
			{
				continue;
			}
			int num = learned / 5;
			if (num <= 0)
			{
				continue;
			}
			if (num <= 20)
			{
				if (!flag)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(num);
				stringBuilder.Append(" study ");
				stringBuilder.Append(skillSpell.SSName);
				flag = false;
				continue;
			}
			int num2 = num;
			while (num2 > 0)
			{
				if (!flag)
				{
					stringBuilder.Append(";");
				}
				int num3 = ((num2 > 20) ? 20 : num2);
				stringBuilder.Append(num3);
				stringBuilder.Append(" study ");
				stringBuilder.Append(skillSpell.SSName);
				num2 -= num3;
				flag = false;
			}
		}
		if (stringBuilder.Length > 0)
		{
			Clipboard.SetText(stringBuilder.ToString());
		}
	}

	private void saveTrainStudyMenu_Click(object sender, EventArgs e)
	{
		string text = "";
		if (cs != null && cs.guilds != null && cs.guilds.Count > 0)
		{
			for (int i = 0; i < cs.guilds.Count; i++)
			{
				Guild guild = (Guild)cs.guilds[i];
				if (guild.rootGuild() && guild.level > 0)
				{
					if (text != "")
					{
						text += "_";
					}
					string text2 = guild.GuildName.Replace(" ", "_").ToLower();
					text += text2;
				}
			}
			text = ((!(text != "")) ? "trainstudy.txt" : (text + "_trainstudy.txt"));
		}
		else
		{
			text = "trainstudy.txt";
		}
		saveTrainStudy.FileName = text;
		saveTrainStudy.ShowDialog();
	}

	private void saveTrainStudy_FileOk(object sender, CancelEventArgs e)
	{
		if (!(saveTrainStudy.FileName != ""))
		{
			return;
		}
		StreamWriter streamWriter = new StreamWriter(saveTrainStudy.OpenFile());
		StringBuilder stringBuilder = new StringBuilder();
		
		// Create dictionaries to track which guild each skill/spell belongs to
		Hashtable skillToGuild = new Hashtable();
		Hashtable spellToGuild = new Hashtable();
		
		// Get all guilds including sub-guilds that have level > 0
		// Use a Hashtable keyed by GuildName to avoid duplicates
		Hashtable guildSet = new Hashtable();
		ArrayList allGuilds = new ArrayList();
		ArrayList guildsToCheck = new ArrayList();
		
		// Create a map of all active guilds by name for quick lookup
		Hashtable activeGuildsByName = new Hashtable();
		if (cs != null && cs.guilds != null)
		{
			for (int i = 0; i < cs.guilds.Count; i++)
			{
				Guild guild = (Guild)cs.guilds[i];
				if (guild.level > 0)
				{
					activeGuildsByName[guild.GuildName] = guild;
				}
			}
		}
		
		if (cs != null && cs.guilds != null)
		{
			// First, add all guilds from cs.guilds that have level > 0
			for (int i = 0; i < cs.guilds.Count; i++)
			{
				Guild guild = (Guild)cs.guilds[i];
				if (guild.level > 0 && !guildSet.ContainsKey(guild.GuildName))
				{
					guildSet.Add(guild.GuildName, guild);
					allGuilds.Add(guild);
					guildsToCheck.Add(guild);
				}
			}
			
			// Now iteratively check each guild's sub-guilds from completeGuilds
			// This ensures we find all sub-guild relationships, including deeply nested ones
			// We check BOTH completeGuilds AND the current guild's subs property to be thorough
			int checkIndex = 0;
			Hashtable processedSubs = new Hashtable(); // Track which sub-guilds we've already processed for this guild
			
			while (checkIndex < guildsToCheck.Count)
			{
				Guild currentGuild = (Guild)guildsToCheck[checkIndex];
				processedSubs.Clear();
				
				// Check completeGuilds first to get the authoritative sub-guild list
				if (completeGuilds != null)
				{
					for (int k = 0; k < completeGuilds.Count; k++)
					{
						Guild completeGuild = (Guild)completeGuilds[k];
						if (completeGuild.GuildName == currentGuild.GuildName && completeGuild.subs != null)
						{
							for (int j = 0; j < completeGuild.subs.Count; j++)
							{
								Guild subGuildFromComplete = (Guild)completeGuild.subs[j];
								string subGuildName = subGuildFromComplete.GuildName;
								
								// Skip if we've already processed this sub-guild
								if (processedSubs.ContainsKey(subGuildName))
								{
									continue;
								}
								processedSubs.Add(subGuildName, true);
								
								// Check if this sub-guild is active
								// Always check cs.guilds first to get the actual level
								if (!guildSet.ContainsKey(subGuildName))
								{
									bool foundInActive = false;
									// Check if this guild is actually in cs.guilds by name with level > 0
									for (int m = 0; m < cs.guilds.Count; m++)
									{
										Guild g = (Guild)cs.guilds[m];
										if (g.GuildName == subGuildName && g.level > 0)
										{
											foundInActive = true;
											guildSet.Add(subGuildName, g);
											allGuilds.Add(g);
											guildsToCheck.Add(g);
											break;
										}
									}
									// If not found in cs.guilds, check if it's in activeGuildsByName (should be same, but double-check)
									if (!foundInActive && activeGuildsByName.ContainsKey(subGuildName))
									{
										Guild activeSubGuild = (Guild)activeGuildsByName[subGuildName];
										guildSet.Add(subGuildName, activeSubGuild);
										allGuilds.Add(activeSubGuild);
										guildsToCheck.Add(activeSubGuild);
										foundInActive = true;
									}
									// If still not found but the sub-guild from completeGuilds has level > 0, add it
									// (This handles edge cases where sub-guilds might be tracked differently)
									if (!foundInActive && subGuildFromComplete.level > 0)
									{
										guildSet.Add(subGuildName, subGuildFromComplete);
										allGuilds.Add(subGuildFromComplete);
										guildsToCheck.Add(subGuildFromComplete);
									}
								}
							}
							break; // Found the guild, no need to continue
						}
					}
				}
				
				// Also check the current guild's subs property (in case it has different sub-guilds)
				if (currentGuild.subs != null)
				{
					for (int j = 0; j < currentGuild.subs.Count; j++)
					{
						Guild subGuildFromParent = (Guild)currentGuild.subs[j];
						string subGuildName = subGuildFromParent.GuildName;
						
						// Skip if we've already processed this sub-guild
						if (processedSubs.ContainsKey(subGuildName))
						{
							continue;
						}
						processedSubs.Add(subGuildName, true);
						
						// Check if this sub-guild is active
						// Always check cs.guilds first to get the actual level
						if (!guildSet.ContainsKey(subGuildName))
						{
							bool foundInActive = false;
							// Check if this guild is actually in cs.guilds by name with level > 0
							for (int m = 0; m < cs.guilds.Count; m++)
							{
								Guild g = (Guild)cs.guilds[m];
								if (g.GuildName == subGuildName && g.level > 0)
								{
									foundInActive = true;
									guildSet.Add(subGuildName, g);
									allGuilds.Add(g);
									guildsToCheck.Add(g);
									break;
								}
							}
							// If not found in cs.guilds, check if it's in activeGuildsByName (should be same, but double-check)
							if (!foundInActive && activeGuildsByName.ContainsKey(subGuildName))
							{
								Guild activeSubGuild = (Guild)activeGuildsByName[subGuildName];
								guildSet.Add(subGuildName, activeSubGuild);
								allGuilds.Add(activeSubGuild);
								guildsToCheck.Add(activeSubGuild);
								foundInActive = true;
							}
							// If still not found but the sub-guild has level > 0, add it
							if (!foundInActive && subGuildFromParent.level > 0)
							{
								guildSet.Add(subGuildName, subGuildFromParent);
								allGuilds.Add(subGuildFromParent);
								guildsToCheck.Add(subGuildFromParent);
							}
						}
					}
				}
				
				checkIndex++;
			}
		}
		
		// Map skills and spells to their guilds
		// Use the guilds from allGuilds (which includes all active guilds)
		// When multiple guilds can train/study the same skill/spell, assign it to the guild with the highest max percentage
		Hashtable skillMaxPercent = new Hashtable(); // Track max percentage for each skill
		Hashtable spellMaxPercent = new Hashtable(); // Track max percentage for each spell
		
		for (int k = 0; k < allGuilds.Count; k++)
		{
			Guild guild2 = (Guild)allGuilds[k];
			if (guild2.level > 0)
			{
				// Try to get the guild level - if it fails, the guild might not be loaded
				GuildLevel gL = guild2.getGL(guild2.level);
				if (gL != null)
				{
					// Map skills - check max percentage and assign to guild with highest
					IDictionaryEnumerator skillEnum = gL.getSkills().GetEnumerator();
					while (skillEnum.MoveNext())
					{
						string skillName = (string)skillEnum.Key;
						int maxPercent = (int)skillEnum.Value;
						
						if (!skillToGuild.ContainsKey(skillName))
						{
							// First time seeing this skill - map it to this guild
							skillToGuild.Add(skillName, guild2);
							skillMaxPercent.Add(skillName, maxPercent);
						}
						else
						{
							// Skill already mapped - check if this guild has a higher max percentage
							int currentMax = (int)skillMaxPercent[skillName];
							if (maxPercent > currentMax)
							{
								// This guild can train it higher - reassign
								skillToGuild[skillName] = guild2;
								skillMaxPercent[skillName] = maxPercent;
							}
						}
					}
					// Map spells - check max percentage and assign to guild with highest
					IDictionaryEnumerator spellEnum = gL.getSpells().GetEnumerator();
					while (spellEnum.MoveNext())
					{
						string spellName = (string)spellEnum.Key;
						int maxPercent = (int)spellEnum.Value;
						
						if (!spellToGuild.ContainsKey(spellName))
						{
							// First time seeing this spell - map it to this guild
							spellToGuild.Add(spellName, guild2);
							spellMaxPercent.Add(spellName, maxPercent);
						}
						else
						{
							// Spell already mapped - check if this guild has a higher max percentage
							int currentMax = (int)spellMaxPercent[spellName];
							if (maxPercent > currentMax)
							{
								// This guild can study it higher - reassign
								spellToGuild[spellName] = guild2;
								spellMaxPercent[spellName] = maxPercent;
							}
						}
					}
				}
			}
		}
		
		// Group skills and spells by guild
		Hashtable guildSkills = new Hashtable();
		Hashtable guildSpells = new Hashtable();
		
		// Group skills by guild
		for (int l = 0; l < cs.availableSkills.Count; l++)
		{
			SkillSpell skillSpell = (SkillSpell)cs.availableSkills[l];
			if (skillSpell.learned > 0 && skillToGuild.ContainsKey(skillSpell.SSName))
			{
				Guild guild3 = (Guild)skillToGuild[skillSpell.SSName];
				if (!guildSkills.ContainsKey(guild3))
				{
					guildSkills.Add(guild3, new ArrayList());
				}
				((ArrayList)guildSkills[guild3]).Add(skillSpell);
			}
		}
		
		// Group spells by guild
		for (int m = 0; m < cs.availableSpells.Count; m++)
		{
			SkillSpell skillSpell2 = (SkillSpell)cs.availableSpells[m];
			if (skillSpell2.learned > 0 && spellToGuild.ContainsKey(skillSpell2.SSName))
			{
				Guild guild4 = (Guild)spellToGuild[skillSpell2.SSName];
				if (!guildSpells.ContainsKey(guild4))
				{
					guildSpells.Add(guild4, new ArrayList());
				}
				((ArrayList)guildSpells[guild4]).Add(skillSpell2);
			}
		}
		
		// Generate commands grouped by guild
		for (int n = 0; n < allGuilds.Count; n++)
		{
			Guild guild5 = (Guild)allGuilds[n];
			if (guild5.level <= 0)
			{
				continue;
			}
			
			bool hasContent = false;
			StringBuilder guildTrainCommands = new StringBuilder();
			StringBuilder guildStudyCommands = new StringBuilder();
			bool trainFlag = true;
			bool studyFlag = true;
			
			// Generate train commands for this guild
			if (guildSkills.ContainsKey(guild5))
			{
				ArrayList skills = (ArrayList)guildSkills[guild5];
				for (int o = 0; o < skills.Count; o++)
				{
					SkillSpell skillSpell3 = (SkillSpell)skills[o];
					int learned = skillSpell3.learned;
					if (learned <= 0)
					{
						continue;
					}
					int num = learned / 5;
					if (num <= 0)
					{
						continue;
					}
					hasContent = true;
					if (num <= 20)
					{
						if (!trainFlag)
						{
							guildTrainCommands.Append(";");
						}
						guildTrainCommands.Append(num);
						guildTrainCommands.Append(" train ");
						guildTrainCommands.Append(skillSpell3.SSName);
						trainFlag = false;
					}
					else
					{
						int num2 = num;
						while (num2 > 0)
						{
							if (!trainFlag)
							{
								guildTrainCommands.Append(";");
							}
							int num3 = ((num2 > 20) ? 20 : num2);
							guildTrainCommands.Append(num3);
							guildTrainCommands.Append(" train ");
							guildTrainCommands.Append(skillSpell3.SSName);
							num2 -= num3;
							trainFlag = false;
						}
					}
				}
			}
			
			// Generate study commands for this guild
			if (guildSpells.ContainsKey(guild5))
			{
				ArrayList spells = (ArrayList)guildSpells[guild5];
				for (int p = 0; p < spells.Count; p++)
				{
					SkillSpell skillSpell4 = (SkillSpell)spells[p];
					int learned2 = skillSpell4.learned;
					if (learned2 <= 0)
					{
						continue;
					}
					int num4 = learned2 / 5;
					if (num4 <= 0)
					{
						continue;
					}
					hasContent = true;
					if (num4 <= 20)
					{
						if (!studyFlag)
						{
							guildStudyCommands.Append(";");
						}
						guildStudyCommands.Append(num4);
						guildStudyCommands.Append(" study ");
						guildStudyCommands.Append(skillSpell4.SSName);
						studyFlag = false;
					}
					else
					{
						int num5 = num4;
						while (num5 > 0)
						{
							if (!studyFlag)
							{
								guildStudyCommands.Append(";");
							}
							int num6 = ((num5 > 20) ? 20 : num5);
							guildStudyCommands.Append(num6);
							guildStudyCommands.Append(" study ");
							guildStudyCommands.Append(skillSpell4.SSName);
							num5 -= num6;
							studyFlag = false;
						}
					}
				}
			}
			
			// Write guild section if it has content
			if (hasContent)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
				}
				stringBuilder.Append(guild5.GuildName);
				stringBuilder.AppendLine(":");
				if (guildTrainCommands.Length > 0)
				{
					stringBuilder.AppendLine(guildTrainCommands.ToString());
				}
				if (guildStudyCommands.Length > 0)
				{
					stringBuilder.AppendLine(guildStudyCommands.ToString());
				}
			}
		}
		
		streamWriter.Write(stringBuilder.ToString());
		streamWriter.Close();
	}

	private void SpellsMBtn_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < SpellsData.SelectedItems.Count; i++)
		{
			SkillSpell skillSpell = (SkillSpell)SpellsData.SelectedItems[i];
			skillSpell.learned = ((skillSpell.scaledPercent > 100) ? skillSpell.scaledPercent : 100);
		}
		cs.updateExperience();
		updateSpellsTab();
	}

	private void statBtn_Click(object sender, EventArgs e)
	{
		if (isNumber(strStTB.Text, skillspell: false) && isNumber(intStTB.Text, skillspell: false) && isNumber(dexStTB.Text, skillspell: false) && isNumber(conStTB.Text, skillspell: false) && isNumber(wisStTB.Text, skillspell: false) && isNumber(chaStTB.Text, skillspell: false))
		{
			int[] trained = new int[6]
			{
				int.Parse(strStTB.Text),
				int.Parse(intStTB.Text),
				int.Parse(wisStTB.Text),
				int.Parse(conStTB.Text),
				int.Parse(dexStTB.Text),
				int.Parse(chaStTB.Text)
			};
			cs.trained = trained;
			updateDisplay();
		}
		else
		{
			MessageBox.Show("Somewhere you entered a non-valid entry.", "Illegal Entry!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public void addSubGuilds(Guild guild, bool priv, int delta)
	{
		ArrayList subs = guild.subs;
		if (guild.level > 0 && guild.subsAvailable() && subs != null)
		{
			for (int i = 0; i < subs.Count; i++)
			{
				Guild guild2 = (Guild)subs[i];
				if (!completeGuilds.Contains(guild2))
				{
					completeGuilds.Add(guild2);
					string path = (priv ? privatePath : dataPath);
					guild2.loadLevels(path, completeGuilds);
				}
			}
		}
		else if (subs != null && subs.Count != 0)
		{
			for (int j = 0; j < subs.Count; j++)
			{
				Guild guild3 = (Guild)subs[j];
				guild3.level = 0;
				completeGuilds.Remove(guild3);
				if (cs.guilds.Contains(guild3))
				{
					cs.guilds.Remove(guild3);
				}
			}
		}
		if (delta < 0)
		{
			cs.resetSkillsSpells(skills, spells);
		}
		else if (guild.level != 0)
		{
			cs.addSkillsSpells(guild, skills, spells);
		}
		completeGuilds = cs.sortGuilds(completeGuilds, trained: false);
		updateGuildRaceList();
		updateList(MainGuildBox, displayGuilds, "GuildString", "GuildString");
	}

	private bool isNumber(string test, bool skillspell)
	{
		Regex regex = new Regex("^[0-9]+$");
		if (skillspell)
		{
			if (regex.IsMatch(test) && test.Length < 4)
			{
				return int.Parse(test) % 5 == 0;
			}
			return false;
		}
		return regex.IsMatch(test);
	}

	public void updateList(ListBox list, ArrayList data, string vMember, string dMember)
	{
		int topIndex = list.TopIndex;
		int selectedIndex = ((list.SelectedIndex > data.Count) ? (data.Count - 1) : list.SelectedIndex);
		list.BeginUpdate();
		list.DataSource = new ArrayList();
		if (data != null && data.Count > 0)
		{
			list.DataSource = data;
			list.DisplayMember = dMember;
			list.ValueMember = vMember;
			list.TopIndex = topIndex;
			list.SelectedIndex = selectedIndex;
		}
		list.EndUpdate();
	}

	public void updateSkillsTab()
	{
		updateList(SkillsData, cs.availableSkills, "SS", "SSNamePercent");
		if (cs.availableSkills.Count == 0)
		{
			SkillCost1.Text = "";
			SkillCost2.Text = "";
			SkillDescript.Text = "";
		}
		SkAllTB.Text = $"{cs.skillsExp:#,0}";
		SkSelectedTB.Text = $"{cs.getExperience(new ArrayList(SkillsData.SelectedItems)):#,0}";
		populateExpBoxes();
	}

	public void updateSpellsTab()
	{
		updateList(SpellsData, cs.availableSpells, "SS", "SSNamePercent");
		if (cs.availableSpells.Count == 0)
		{
			SpellCost1.Text = "";
			SpellCost2.Text = "";
			SpellDescript.Text = "";
		}
		SpAllTB.Text = $"{cs.spellsExp:#,0}";
		SpSelectedTB.Text = $"{cs.getExperience(new ArrayList(SpellsData.SelectedItems)):#,0}";
		populateExpBoxes();
	}

	public void updateCostDisplays(bool skills)
	{
		int num;
		SkillSpell skillSpell;
		if (skills)
		{
			num = ((cs.charRace.skillMax + cs.skWish > 100) ? 100 : (cs.charRace.skillMax + cs.skWish));
			skillSpell = (SkillSpell)cs.availableSkills[SkillsData.SelectedIndex];
		}
		else
		{
			num = ((cs.charRace.spellMax + cs.spWish > 100) ? 100 : (cs.charRace.spellMax + cs.spWish));
			skillSpell = (SkillSpell)cs.availableSpells[SpellsData.SelectedIndex];
		}
		int[] costArray = skillSpell.costArray;
		string[] array = new string[22];
		int num2 = 0;
		for (int i = 0; i < 20; i++)
		{
			array[i + num2] = " ";
			string[] array3;
			nint num4;
			if (i == 0)
			{
				string[] array2 = (array3 = array);
				int num3 = i + num2;
				num4 = num3;
				array2[num3] = array3[num4] + "  ";
			}
			else if (i < 19)
			{
				string[] array4 = (array3 = array);
				int num5 = i + num2;
				num4 = num5;
				array4[num5] = array3[num4] + " ";
			}
			string[] array5 = (array3 = array);
			int num6 = i + num2;
			num4 = num6;
			array5[num6] = array3[num4] + (i + 1) * 5 + "%   ";
			for (int j = ((costArray[i] == 0) ? 1 : ((int)Math.Log10(costArray[i]))); j < 9; j++)
			{
				string[] array6 = (array3 = array);
				int num7 = i + num2;
				num4 = num7;
				array6[num7] = array3[num4] + " ";
			}
			string[] array7 = (array3 = array);
			int num8 = i + num2;
			num4 = num8;
			array7[num8] = array3[num4] + costArray[i] + "  ";
			int num9 = costArray[i] / 2250;
			for (int k = ((num9 != 0) ? ((int)Math.Log10(num9)) : 0); k < 7; k++)
			{
				string[] array8 = (array3 = array);
				int num10 = i + num2;
				num4 = num10;
				array8[num10] = array3[num4] + " ";
			}
			string[] array9 = (array3 = array);
			int num11 = i + num2;
			num4 = num11;
			array9[num11] = array3[num4] + num9;
			if ((i + 1) * 5 == skillSpell.scaledPercent)
			{
				num2++;
				array[i + num2] = "  -------- Char Max --------";
			}
			if ((i + 1) * 5 == num)
			{
				num2++;
				array[i + num2] = "  ------- Racial Max -------";
			}
		}
		string[] array10 = new string[13];
		string[] array11 = new string[13];
		array10[0] = "  %          Exp        Gold";
		array10[1] = "------------------------------";
		array11[0] = "  %          Exp        Gold";
		array11[1] = "------------------------------";
		for (int l = 0; l < 11; l++)
		{
			array10[l + 2] = array[l];
		}
		for (int m = 0; m < 11; m++)
		{
			array11[m + 2] = array[m + 11];
		}
		if (skills)
		{
			SkillCost1.Lines = array10;
			SkillCost2.Lines = array11;
		}
		else
		{
			SpellCost1.Lines = array10;
			SpellCost2.Lines = array11;
		}
	}

	public void updateResistances()
	{
		resistLbl.Text = "";
		int[] resistances = cs.resistances;
		if (resistances[0] != 0)
		{
			Label label = resistLbl;
			object obj = label.Text;
			label.Text = string.Concat(obj, "Acid: ", resistances[0], "\r\n");
		}
		if (resistances[1] != 0)
		{
			Label label2 = resistLbl;
			object obj2 = label2.Text;
			label2.Text = string.Concat(obj2, "Asphyxiation: ", resistances[1], "\r\n");
		}
		if (resistances[2] != 0)
		{
			Label label3 = resistLbl;
			object obj3 = label3.Text;
			label3.Text = string.Concat(obj3, "Cold: ", resistances[2], "\r\n");
		}
		if (resistances[3] != 0)
		{
			Label label4 = resistLbl;
			object obj4 = label4.Text;
			label4.Text = string.Concat(obj4, "Electric: ", resistances[3], "\r\n");
		}
		if (resistances[4] != 0)
		{
			Label label5 = resistLbl;
			object obj5 = label5.Text;
			label5.Text = string.Concat(obj5, "Fire: ", resistances[4], "\r\n");
		}
		if (resistances[5] != 0)
		{
			Label label6 = resistLbl;
			object obj6 = label6.Text;
			label6.Text = string.Concat(obj6, "Magical: ", resistances[5], "\r\n");
		}
		if (resistances[6] != 0)
		{
			Label label7 = resistLbl;
			object obj7 = label7.Text;
			label7.Text = string.Concat(obj7, "Physical: ", resistances[6], "\r\n");
		}
		if (resistances[7] != 0)
		{
			Label label8 = resistLbl;
			object obj8 = label8.Text;
			label8.Text = string.Concat(obj8, "Poison: ", resistances[7], "\r\n");
		}
		if (resistances[8] != 0)
		{
			Label label9 = resistLbl;
			object obj9 = label9.Text;
			label9.Text = string.Concat(obj9, "Psionic: ", resistances[8], "\r\n");
		}
		if (resistLbl.Text.Equals(""))
		{
			resistLbl.Text += "No resistances.";
		}
	}

	private void updateDisplay()
	{
		populateStatBoxes();
		raceTB.Lines = cs.charRace.ToStrings();
		if (displayGuilds.Count > 0)
		{
			Guild guild = (Guild)displayGuilds[MainGuildBox.SelectedIndex];
			guildlevels.Text = guild.level + "/" + (guild.availLevels + guild.level);
		}
		updateSkillsTab();
		updateSpellsTab();
		cs.updateExperience();
		populateExpBoxes();
		updateStats();
		qpNeededTB.Text = cs.qpsneeded.ToString();
		updateResistances();
	}

	public void populateExpBoxes()
	{
		SkillsEXP.Text = $"{cs.skillsExp:#,0}";
		SpellsEXP.Text = $"{cs.spellsExp:#,0}";
		RaceEXP.Text = $"{cs.RaceExp:#,0}";
		GuildExp.Text = $"{cs.GuildExp:#,0}";
		StatExp.Text = $"{cs.statExp:#,0}";
		TotalEXP.Text = $"{cs.totalExp:#,0}";
		GoldTB.Text = $"{(cs.skillsExp + cs.spellsExp) / 2250.0:#,0} gp";
	}

	public void populateStatBoxes()
	{
		int[] array = cs.charInfo();
		HPTB.Text = array[0].ToString();
		SPTB.Text = array[1].ToString();
		HPRTB.Text = array[2].ToString();
		SPRTB.Text = array[3].ToString();
		StrTB.Text = array[4].ToString();
		IntTB.Text = array[5].ToString();
		ConTB.Text = array[6].ToString();
		WisTB.Text = array[7].ToString();
		DexTB.Text = array[8].ToString();
		ChaTB.Text = array[9].ToString();
		sizeTB.Text = (cs.charRace.size + cs.statWishes / 15).ToString() ?? "";
		skMax.Text = (cs.charRace.skillMax + cs.skWish).ToString() ?? "";
		spMax.Text = (cs.charRace.spellMax + cs.spWish).ToString() ?? "";
	}

	public void updateStats()
	{
		int[] trained = cs.trained;
		strStTB.Text = trained[0].ToString();
		intStTB.Text = trained[1].ToString();
		wisStTB.Text = trained[2].ToString();
		conStTB.Text = trained[3].ToString();
		dexStTB.Text = trained[4].ToString();
		chaStTB.Text = trained[5].ToString();
	}

	private void lSkill_CheckedChanged(object sender, EventArgs e)
	{
		if (lSkill.Checked)
		{
			cs.skWish += 5;
			cs.spWish += 5;
			cs.lesserWishes++;
		}
		else
		{
			cs.skWish -= 5;
			cs.spWish -= 5;
			cs.lesserWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		RaceBox_SelectedIndexChanged(null, null);
	}

	private void gSkill_CheckedChanged(object sender, EventArgs e)
	{
		if (gSkill.Checked)
		{
			cs.skWish += 10;
			cs.spWish += 10;
			cs.greaterWishes++;
		}
		else
		{
			cs.skWish -= 10;
			cs.spWish -= 10;
			cs.greaterWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		RaceBox_SelectedIndexChanged(null, null);
	}

	private void lStats_CheckedChanged(object sender, EventArgs e)
	{
		if (lStats.Checked)
		{
			cs.statWishes += 15;
			cs.lesserWishes++;
			cs.LesserStatsWish = true;
		}
		else
		{
			cs.statWishes -= 15;
			cs.lesserWishes--;
			cs.LesserStatsWish = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gStats_CheckedChanged(object sender, EventArgs e)
	{
		if (gStats.Checked)
		{
			cs.statWishes += 30;
			cs.greaterWishes++;
			cs.SuperiorStatsWish = true;
		}
		else
		{
			cs.statWishes -= 30;
			cs.greaterWishes--;
			cs.SuperiorStatsWish = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lMag_CheckedChanged(object sender, EventArgs e)
	{
		if (lMag.Checked)
		{
			cs.lesserWishes++;
			cs.magWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.magWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gMag_CheckedChanged(object sender, EventArgs e)
	{
		if (gMag.Checked)
		{
			cs.greaterWishes++;
			cs.magWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.magWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lPhys_CheckedChanged(object sender, EventArgs e)
	{
		if (lPhys.Checked)
		{
			cs.lesserWishes++;
			cs.physWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.physWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gPhys_CheckedChanged(object sender, EventArgs e)
	{
		if (gPhys.Checked)
		{
			cs.greaterWishes++;
			cs.physWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.physWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lHaste_CheckedChanged(object sender, EventArgs e)
	{
		if (lHaste.Checked)
		{
			cs.lesserWishes++;
		}
		else
		{
			cs.lesserWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void lCriticalBlow_CheckedChanged(object sender, EventArgs e)
	{
		if (lCriticalBlow.Checked)
		{
			cs.lesserWishes++;
		}
		else
		{
			cs.lesserWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void thickSkin_CheckedChanged(object sender, EventArgs e)
	{
		cs.ThickSkin = thickSkin.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void trueSeeing_CheckedChanged(object sender, EventArgs e)
	{
		cs.TrueSeeing = trueSeeing.Checked;
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void gHaste_CheckedChanged(object sender, EventArgs e)
	{
		if (gHaste.Checked)
		{
			cs.greaterWishes++;
		}
		else
		{
			cs.greaterWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void gCriticalBlow_CheckedChanged(object sender, EventArgs e)
	{
		if (gCriticalBlow.Checked)
		{
			cs.greaterWishes++;
		}
		else
		{
			cs.greaterWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void ambidexterity_CheckedChanged(object sender, EventArgs e)
	{
		cs.Ambidexterity = ambidexterity.Checked;
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void elementalAttunement_CheckedChanged(object sender, EventArgs e)
	{
		cs.ElementalAttunement = elementalAttunement.Checked;
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void giantSize_CheckedChanged(object sender, EventArgs e)
	{
		cs.GiantSize = giantSize.Checked;
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void improvedStr_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedStr = improvedStr.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void improvedDex_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedDex = improvedDex.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void improvedCon_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedCon = improvedCon.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void improvedInt_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedInt = improvedInt.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void improvedWis_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedWis = improvedWis.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void improvedCha_CheckedChanged(object sender, EventArgs e)
	{
		cs.ImprovedCha = improvedCha.Checked;
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lucky_CheckedChanged(object sender, EventArgs e)
	{
		cs.Lucky = lucky.Checked;
		TpTB.Text = cs.taskpoints.ToString();
	}

	private void lBattleRegen_CheckedChanged(object sender, EventArgs e)
	{
		if (lBattleRegen.Checked)
		{
			cs.lesserWishes++;
			cs.BattleRegenWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.BattleRegenWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gBattleRegen_CheckedChanged(object sender, EventArgs e)
	{
		if (gBattleRegen.Checked)
		{
			cs.greaterWishes++;
			cs.BattleRegenWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.BattleRegenWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lEndurance_CheckedChanged(object sender, EventArgs e)
	{
		if (lEndurance.Checked)
		{
			cs.lesserWishes++;
			cs.EnduranceWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.EnduranceWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gEndurance_CheckedChanged(object sender, EventArgs e)
	{
		if (gEndurance.Checked)
		{
			cs.greaterWishes++;
			cs.EnduranceWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.EnduranceWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gReserves_CheckedChanged(object sender, EventArgs e)
	{
		if (gReserves.Checked)
		{
			cs.greaterWishes++;
			cs.ReservesWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.ReservesWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lReserves_CheckedChanged(object sender, EventArgs e)
	{
		if (lReserves.Checked)
		{
			cs.lesserWishes++;
			cs.ReservesWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.ReservesWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void gSpellDamage_CheckedChanged(object sender, EventArgs e)
	{
		if (gSpellDamage.Checked)
		{
			cs.greaterWishes++;
			cs.SpellDamageWishes += 2;
		}
		else
		{
			cs.greaterWishes--;
			cs.SpellDamageWishes -= 2;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void lSpellDamage_CheckedChanged(object sender, EventArgs e)
	{
		if (lSpellDamage.Checked)
		{
			cs.lesserWishes++;
			cs.SpellDamageWishes++;
		}
		else
		{
			cs.lesserWishes--;
			cs.SpellDamageWishes--;
		}
		TpTB.Text = cs.taskpoints.ToString();
		populateStatBoxes();
	}

	private void resistAcid_CheckedChanged(object sender, EventArgs e)
	{
		if (resistAcid.Checked)
		{
			cs.ResistAcid = true;
		}
		else
		{
			cs.ResistAcid = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistAsp_CheckedChanged(object sender, EventArgs e)
	{
		if (resistAsp.Checked)
		{
			cs.ResistAsp = true;
		}
		else
		{
			cs.ResistAsp = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistCold_CheckedChanged(object sender, EventArgs e)
	{
		if (resistCold.Checked)
		{
			cs.ResistCold = true;
		}
		else
		{
			cs.ResistCold = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistElec_CheckedChanged(object sender, EventArgs e)
	{
		if (resistElec.Checked)
		{
			cs.ResistElec = true;
		}
		else
		{
			cs.ResistElec = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistFire_CheckedChanged(object sender, EventArgs e)
	{
		if (resistFire.Checked)
		{
			cs.ResistFire = true;
		}
		else
		{
			cs.ResistFire = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistMag_CheckedChanged(object sender, EventArgs e)
	{
		if (resistMag.Checked)
		{
			cs.ResistMag = true;
		}
		else
		{
			cs.ResistMag = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistPois_CheckedChanged(object sender, EventArgs e)
	{
		if (resistPois.Checked)
		{
			cs.ResistPois = true;
		}
		else
		{
			cs.ResistPois = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	private void resistPsi_CheckedChanged(object sender, EventArgs e)
	{
		if (resistPsi.Checked)
		{
			cs.ResistPsi = true;
		}
		else
		{
			cs.ResistPsi = false;
		}
		TpTB.Text = cs.taskpoints.ToString();
		updateResistances();
	}

	public void writeDashes(StreamWriter bw)
	{
		bw.WriteLine("---------------------------------------------------");
	}

	private void saveCharacter_FileOk(object sender, CancelEventArgs e)
	{
		if (!(saveCharacter.FileName != ""))
		{
			return;
		}
		StreamWriter streamWriter = new StreamWriter(saveCharacter.OpenFile());
		writeDashes(streamWriter);
		streamWriter.WriteLine("RACE: " + cs.charRace.RaceName);
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("GUILDS");
		writeDashes(streamWriter);
		for (int i = 0; i < cs.guilds.Count; i++)
		{
			Guild guild = (Guild)cs.guilds[i];
			streamWriter.WriteLine(guild.SaveGuildString);
		}
		streamWriter.WriteLine("Free Levels: " + cs.free);
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("RESULTING CHARACTER");
		writeDashes(streamWriter);
		int[] array = cs.charInfo();
		streamWriter.WriteLine("Hpmax:\t\t" + array[0]);
		streamWriter.WriteLine("Spmax:\t\t" + array[1]);
		streamWriter.WriteLine("Hpregen:\t" + array[2]);
		streamWriter.WriteLine("Spregen:\t" + array[3]);
		streamWriter.WriteLine("SkillMax:\t" + cs.charRace.skillMax);
		streamWriter.WriteLine("SpellMax:\t" + cs.charRace.spellMax);
		streamWriter.WriteLine("Str:\t\t" + array[4]);
		streamWriter.WriteLine("Con:\t\t" + array[6]);
		streamWriter.WriteLine("Dex:\t\t" + array[8]);
		streamWriter.WriteLine("Int:\t\t" + array[5]);
		streamWriter.WriteLine("Wis:\t\t" + array[7]);
		streamWriter.WriteLine("Cha:\t\t" + array[9]);
		streamWriter.WriteLine("Size:\t\t" + cs.charRace.size);
		streamWriter.WriteLine("Exprate:\t" + cs.charRace.expRate);
		streamWriter.WriteLine("Tps:\t\t" + cs.taskpoints);
		streamWriter.WriteLine("Final Level:\t" + cs.totalLevels);
		streamWriter.WriteLine("Experience:\t" + $"{cs.totalExp:#,0}");
		streamWriter.WriteLine("Gold:\t\t" + $"{cs.gold:#,0}");
		streamWriter.WriteLine("Quest Points:\t" + cs.qps);
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("WISHES");
		writeDashes(streamWriter);
		if (lCriticalBlow.Checked)
		{
			streamWriter.WriteLine("Lesser critical blow");
		}
		if (lHaste.Checked)
		{
			streamWriter.WriteLine("Lesser haste");
		}
		if (lMag.Checked)
		{
			streamWriter.WriteLine("Lesser magical improvement");
		}
		if (lPhys.Checked)
		{
			streamWriter.WriteLine("Lesser Physical improvement");
		}
		if (lSkill.Checked)
		{
			streamWriter.WriteLine("Better knowledge");
		}
		if (lStats.Checked)
		{
			streamWriter.WriteLine("Better stats");
		}
		if (thickSkin.Checked)
		{
			streamWriter.WriteLine("Thick skin");
		}
		if (trueSeeing.Checked)
		{
			streamWriter.WriteLine("True Seeing");
		}
		if (gCriticalBlow.Checked)
		{
			streamWriter.WriteLine("Greater critical blow");
		}
		if (gHaste.Checked)
		{
			streamWriter.WriteLine("Greater haste");
		}
		if (gMag.Checked)
		{
			streamWriter.WriteLine("Greater magical improvement");
		}
		if (gPhys.Checked)
		{
			streamWriter.WriteLine("Greater physical improvement");
		}
		if (gSkill.Checked)
		{
			streamWriter.WriteLine("Superior knowledge");
		}
		if (gStats.Checked)
		{
			streamWriter.WriteLine("Superior stats");
		}
		if (lBattleRegen.Checked)
		{
			streamWriter.WriteLine("Improved battle regeneration");
		}
		if (gBattleRegen.Checked)
		{
			streamWriter.WriteLine("Superior battle regeneration");
		}
		if (lEndurance.Checked)
		{
			streamWriter.WriteLine("Improved endurance");
		}
		if (gEndurance.Checked)
		{
			streamWriter.WriteLine("Superior endurance");
		}
		if (lReserves.Checked)
		{
			streamWriter.WriteLine("Improved reserves");
		}
		if (gReserves.Checked)
		{
			streamWriter.WriteLine("Superior reserves");
		}
		if (lSpellDamage.Checked)
		{
			streamWriter.WriteLine("Improved spell damage");
		}
		if (gSpellDamage.Checked)
		{
			streamWriter.WriteLine("Superior spell damage");
		}
		if (ambidexterity.Checked)
		{
			streamWriter.WriteLine("Ambidexterity");
		}
		if (elementalAttunement.Checked)
		{
			streamWriter.WriteLine("Elemental attunement");
		}
		if (giantSize.Checked)
		{
			streamWriter.WriteLine("Giant size");
		}
		if (improvedStr.Checked)
		{
			streamWriter.WriteLine("Improved strength");
		}
		if (improvedDex.Checked)
		{
			streamWriter.WriteLine("Improved dexterity");
		}
		if (improvedCon.Checked)
		{
			streamWriter.WriteLine("Improved constitution");
		}
		if (improvedInt.Checked)
		{
			streamWriter.WriteLine("Improved intelligence");
		}
		if (improvedWis.Checked)
		{
			streamWriter.WriteLine("Improved wisdom");
		}
		if (improvedCha.Checked)
		{
			streamWriter.WriteLine("Improved charisma");
		}
		if (lucky.Checked)
		{
			streamWriter.WriteLine("Lucky");
		}
		if (resistAcid.Checked)
		{
			streamWriter.WriteLine("Resist acid");
		}
		if (resistAsp.Checked)
		{
			streamWriter.WriteLine("Resist asphyxiation");
		}
		if (resistCold.Checked)
		{
			streamWriter.WriteLine("Resist cold");
		}
		if (resistElec.Checked)
		{
			streamWriter.WriteLine("Resist electric");
		}
		if (resistFire.Checked)
		{
			streamWriter.WriteLine("Resist fire");
		}
		if (resistMag.Checked)
		{
			streamWriter.WriteLine("Resist magical");
		}
		if (resistPois.Checked)
		{
			streamWriter.WriteLine("Resist poison");
		}
		if (resistPsi.Checked)
		{
			streamWriter.WriteLine("Resist psionic");
		}
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("STATS");
		writeDashes(streamWriter);
		int[] trained = cs.trained;
		streamWriter.WriteLine("STR: " + trained[0]);
		streamWriter.WriteLine("INT: " + trained[1]);
		streamWriter.WriteLine("WIS: " + trained[2]);
		streamWriter.WriteLine("CON: " + trained[3]);
		streamWriter.WriteLine("DEX: " + trained[4]);
		streamWriter.WriteLine("CHA: " + trained[5]);
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("SKILLS");
		writeDashes(streamWriter);
		for (int j = 0; j < cs.availableSkills.Count; j++)
		{
			SkillSpell skillSpell = (SkillSpell)cs.availableSkills[j];
			if (skillSpell.learned > 0)
			{
				streamWriter.WriteLine(skillSpell.SaveString);
			}
		}
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.WriteLine("SPELLS");
		writeDashes(streamWriter);
		for (int k = 0; k < cs.availableSpells.Count; k++)
		{
			SkillSpell skillSpell2 = (SkillSpell)cs.availableSpells[k];
			if (skillSpell2.learned > 0)
			{
				streamWriter.WriteLine(skillSpell2.SaveString);
			}
		}
		writeDashes(streamWriter);
		streamWriter.WriteLine();
		streamWriter.Close();
	}

	private void loadCharacter_FileOk(object sender, CancelEventArgs e)
	{
		try
		{
			if (loadCharacter.FileName != "")
			{
				StreamReader streamReader = new StreamReader(loadCharacter.OpenFile());
				resetALL();
				string text = streamReader.ReadLine();
				while (!text.StartsWith("RACE"))
				{
					text = streamReader.ReadLine();
				}
				Race value = new Race(text.Substring(text.IndexOf(":") + 2, text.Length - text.IndexOf(":") - 2));
				RaceBox.SelectedIndex = completeRaces.IndexOf(value);
				while (!text.StartsWith("GUILDS"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				while (!text.StartsWith("-------"))
				{
					if (text.StartsWith("Free"))
					{
						string s = text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim();
						cs.free = int.Parse(s);
						freeLevelsTB.Text = cs.free.ToString();
						levelsTB.Text = cs.totalLevels.ToString();
					}
					else
					{
						string s2 = text.Substring(text.Length - 3, 3).Trim();
						string text2 = text.Substring(0, text.Length - 3).Trim();
						if (text2.StartsWith("-"))
						{
							text2 = text2.Substring(1, text2.Length - 1).Trim();
						}
						int num = int.Parse(s2);
						Guild guild = (Guild)completeGuilds[completeGuilds.IndexOf(new Guild(text2, priv: false, 0))];
						updateGuildInfo(guild, num);
						if (guild.level != num)
						{
							updateGuildInfo(guild, num);
						}
					}
					text = streamReader.ReadLine();
				}
				while (!text.StartsWith("RESULT"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				while (!text.StartsWith("Quest"))
				{
					text = streamReader.ReadLine();
				}
				int qps = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				cs.qps = qps;
				QPTB.Text = qps.ToString();
				while (!text.StartsWith("WISHES"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				while (!text.StartsWith("-----"))
				{
					if (text.StartsWith("Lesser critical blow"))
					{
						lCriticalBlow.Checked = true;
					}
					else if (text.StartsWith("Lesser haste"))
					{
						lHaste.Checked = true;
					}
					else if (text.StartsWith("Lesser magical improvement"))
					{
						lMag.Checked = true;
					}
					else if (text.StartsWith("Lesser Physical improvement"))
					{
						lPhys.Checked = true;
					}
					else if (text.StartsWith("Better techniques") || text.StartsWith("Better knowledge") || text.StartsWith("Better spellcasting"))
					{
						lSkill.Checked = true;
					}
					else if (text.StartsWith("Better stats"))
					{
						lStats.Checked = true;
					}
					else if (text.StartsWith("Thick skin"))
					{
						thickSkin.Checked = true;
					}
					else if (text.StartsWith("True Seeing"))
					{
						trueSeeing.Checked = true;
					}
					else if (text.StartsWith("Greater critical blow"))
					{
						gCriticalBlow.Checked = true;
					}
					else if (text.StartsWith("Greater haste"))
					{
						gHaste.Checked = true;
					}
					else if (text.StartsWith("Greater magical improvement"))
					{
						gMag.Checked = true;
					}
					else if (text.StartsWith("Greater physical improvement"))
					{
						gPhys.Checked = true;
					}
					else if (text.StartsWith("Superior techniques") || text.StartsWith("Superior knowledge") || text.StartsWith("Superior spellcasting"))
					{
						gSkill.Checked = true;
					}
					else if (text.StartsWith("Superior stats"))
					{
						gStats.Checked = true;
					}
					else if (text.StartsWith("Improved battle regeneration"))
					{
						lBattleRegen.Checked = true;
					}
					else if (text.StartsWith("Superior battle regeneration"))
					{
						gBattleRegen.Checked = true;
					}
					else if (text.StartsWith("Improved endurance"))
					{
						lEndurance.Checked = true;
					}
					else if (text.StartsWith("Superior endurance"))
					{
						gEndurance.Checked = true;
					}
					else if (text.StartsWith("Improved reserves"))
					{
						lReserves.Checked = true;
					}
					else if (text.StartsWith("Superior reserves"))
					{
						gReserves.Checked = true;
					}
					else if (text.StartsWith("Improved spell damage"))
					{
						lSpellDamage.Checked = true;
					}
					else if (text.StartsWith("Superior spell damage"))
					{
						gSpellDamage.Checked = true;
					}
					else if (text.StartsWith("Ambidexterity"))
					{
						ambidexterity.Checked = true;
					}
					else if (text.StartsWith("Elemental attunement"))
					{
						elementalAttunement.Checked = true;
					}
					else if (text.StartsWith("Giant size"))
					{
						giantSize.Checked = true;
					}
					else if (text.StartsWith("Improved strength"))
					{
						improvedStr.Checked = true;
					}
					else if (text.StartsWith("Improved dexterity"))
					{
						improvedDex.Checked = true;
					}
					else if (text.StartsWith("Improved constitution"))
					{
						improvedCon.Checked = true;
					}
					else if (text.StartsWith("Improved intelligence"))
					{
						improvedInt.Checked = true;
					}
					else if (text.StartsWith("Improved wisdom"))
					{
						improvedWis.Checked = true;
					}
					else if (text.StartsWith("Improved charisma"))
					{
						improvedCha.Checked = true;
					}
					else if (text.StartsWith("Lucky"))
					{
						lucky.Checked = true;
					}
					else if (text.StartsWith("Resist acid"))
					{
						resistAcid.Checked = true;
					}
					else if (text.StartsWith("Resist asphyxiation"))
					{
						resistAsp.Checked = true;
					}
					else if (text.StartsWith("Resist cold"))
					{
						resistCold.Checked = true;
					}
					else if (text.StartsWith("Resist electric"))
					{
						resistElec.Checked = true;
					}
					else if (text.StartsWith("Resist fire"))
					{
						resistFire.Checked = true;
					}
					else if (text.StartsWith("Resist magical"))
					{
						resistMag.Checked = true;
					}
					else if (text.StartsWith("Resist poison"))
					{
						resistPois.Checked = true;
					}
					else if (text.StartsWith("Resist psionic"))
					{
						resistPsi.Checked = true;
					}
					text = streamReader.ReadLine();
				}
				while (!text.StartsWith("STATS"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				int[] array = new int[6]
				{
					int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim()),
					0,
					0,
					0,
					0,
					0
				};
				text = streamReader.ReadLine();
				array[1] = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				text = streamReader.ReadLine();
				array[2] = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				text = streamReader.ReadLine();
				array[3] = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				text = streamReader.ReadLine();
				array[4] = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				text = streamReader.ReadLine();
				array[5] = int.Parse(text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim());
				cs.trained = array;
				while (!text.StartsWith("SKILLS"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				ArrayList availableSkills = cs.availableSkills;
				while (!text.StartsWith("-----"))
				{
					string name = text.Substring(0, text.IndexOf(":"));
					string s3 = text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim();
					((SkillSpell)availableSkills[availableSkills.IndexOf(new SkillSpell(name, 0))]).learned = int.Parse(s3);
					text = streamReader.ReadLine();
				}
				updateSkillsTab();
				while (!text.StartsWith("SPELLS"))
				{
					text = streamReader.ReadLine();
				}
				text = streamReader.ReadLine();
				text = streamReader.ReadLine();
				ArrayList availableSpells = cs.availableSpells;
				while (!text.StartsWith("-----"))
				{
					string name2 = text.Substring(0, text.IndexOf(":"));
					string s4 = text.Substring(text.IndexOf(":") + 1, text.Length - text.IndexOf(":") - 1).Trim();
					((SkillSpell)availableSpells[availableSpells.IndexOf(new SkillSpell(name2, 0))]).learned = int.Parse(s4);
					text = streamReader.ReadLine();
				}
				updateSpellsTab();
				cs.updateExperience();
				updateDisplay();
				streamReader.Close();
			}
			tabController.SelectedTab.Show();
		}
		catch (Exception)
		{
			MessageBox.Show("Something bad happened when you tried to load your character.  Please verify format of file!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			resetALL();
			tabController.SelectedTab.Show();
		}
	}

	public void writeXmlLeaf(XmlTextWriter q, string tag, string val)
	{
		q.WriteStartElement(tag);
		q.WriteString(val);
		q.WriteEndElement();
	}

	private void saveCharacterXML_FileOk(object sender, CancelEventArgs e)
	{
		if (!(saveCharacter.FileName != ""))
		{
			return;
		}
		XmlTextWriter xmlTextWriter = new XmlTextWriter(saveCharacter.OpenFile(), Encoding.Unicode);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("Character");
		writeXmlLeaf(xmlTextWriter, "Race", cs.charRace.RaceName);
		bool flag = false;
		xmlTextWriter.WriteStartElement("Guilds");
		for (int i = 0; i < cs.guilds.Count; i++)
		{
			Guild guild = (Guild)cs.guilds[i];
			if (guild.rootGuild() && flag)
			{
				xmlTextWriter.WriteEndElement();
			}
			string localName = (guild.rootGuild() ? "Guild" : "Subguild");
			xmlTextWriter.WriteStartElement(localName);
			writeXmlLeaf(xmlTextWriter, "Name", guild.GuildName);
			writeXmlLeaf(xmlTextWriter, "Levels", guild.level.ToString());
			flag = !guild.rootGuild();
			if (flag)
			{
				xmlTextWriter.WriteEndElement();
			}
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		int[] array = cs.charInfo();
		xmlTextWriter.WriteStartElement("Stats");
		writeXmlLeaf(xmlTextWriter, "HP_Max", array[0].ToString());
		writeXmlLeaf(xmlTextWriter, "SP_Max", array[1].ToString());
		writeXmlLeaf(xmlTextWriter, "HP_Regen", array[2].ToString());
		writeXmlLeaf(xmlTextWriter, "SP_Regen", array[3].ToString());
		writeXmlLeaf(xmlTextWriter, "Skill_Max", cs.charRace.skillMax.ToString());
		writeXmlLeaf(xmlTextWriter, "Spell_Max", cs.charRace.spellMax.ToString());
		writeXmlLeaf(xmlTextWriter, "Strength", array[4].ToString());
		writeXmlLeaf(xmlTextWriter, "Constitution", array[5].ToString());
		writeXmlLeaf(xmlTextWriter, "Dexterity", array[6].ToString());
		writeXmlLeaf(xmlTextWriter, "Intelligence", array[7].ToString());
		writeXmlLeaf(xmlTextWriter, "Wisdom", array[8].ToString());
		writeXmlLeaf(xmlTextWriter, "Charisma", array[9].ToString());
		writeXmlLeaf(xmlTextWriter, "Size", cs.charRace.size.ToString());
		writeXmlLeaf(xmlTextWriter, "Exp_Rate", cs.charRace.expRate.ToString());
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
		xmlTextWriter.Close();
	}

	private void loadCharacterXML_FileOk(object sender, CancelEventArgs e)
	{
	}

	private void save_Click(object sender, EventArgs e)
	{
		saveCharacter.ShowDialog();
	}

	private void load_Click(object sender, EventArgs e)
	{
		tabController.SelectedTab.Hide();
		loadCharacter.ShowDialog();
		tabController.SelectedTab.Show();
	}

	private void updateDataLogFile()
	{
		string path = dataPath + "\\dataUpdate";
		File.Delete(path);
		string[] files = Directory.GetFiles(dataPath);
		StreamWriter streamWriter = new StreamWriter(path);
		for (int i = 0; i < files.Length; i++)
		{
			int num = files[i].LastIndexOf("\\") + 1;
			string text = files[i].Substring(num, files[i].Length - num);
			streamWriter.WriteLine(text + "::" + File.GetLastWriteTime(files[i]).ToUniversalTime().ToString());
		}
		streamWriter.Close();
		if (Directory.Exists(privatePath))
		{
			string path2 = privatePath + "\\privateDataUpdate";
			File.Delete(path2);
			string[] files2 = Directory.GetFiles(privatePath, "*.chr");
			streamWriter = new StreamWriter(path2);
			for (int j = 0; j < files2.Length; j++)
			{
				int num2 = files2[j].LastIndexOf("\\") + 1;
				string text2 = files2[j].Substring(num2, files2[j].Length - num2);
				streamWriter.WriteLine(text2 + "::" + File.GetLastWriteTime(files2[j]).ToUniversalTime().ToString());
			}
			streamWriter.Close();
		}
		streamWriter = new StreamWriter(rootPath + "\\exeUpdate");
		streamWriter.WriteLine(Application.ProductVersion);
		streamWriter.Close();
		streamWriter = new StreamWriter(dataPath + "\\help_skill.chr");
		StreamWriter streamWriter2 = new StreamWriter(privatePath + "\\help_privateSkill.chr");
		skills.Sort();
		string text3 = "Skills: ";
		for (int k = 0; k < skills.Count; k++)
		{
			SkillSpell skillSpell = (SkillSpell)skills[k];
			if (skillSpell.raw != null)
			{
				if (!skillSpell.privateSS)
				{
					streamWriter.WriteLine(skillSpell.raw.Trim());
					writeDashes(streamWriter);
				}
				else
				{
					streamWriter2.WriteLine(skillSpell.raw.Trim());
					writeDashes(streamWriter2);
				}
			}
			else
			{
				text3 = text3 + "\r\n" + skillSpell.SSName;
			}
		}
		streamWriter.Close();
		streamWriter2.Close();
		streamWriter = new StreamWriter(dataPath + "\\help_spell.chr");
		streamWriter2 = new StreamWriter(privatePath + "\\help_privateSpell.chr");
		spells.Sort();
		string text4 = "Spells: ";
		for (int l = 0; l < spells.Count; l++)
		{
			SkillSpell skillSpell2 = (SkillSpell)spells[l];
			if (skillSpell2.raw != null)
			{
				if (!skillSpell2.privateSS)
				{
					streamWriter.WriteLine(skillSpell2.raw.Trim());
					writeDashes(streamWriter);
				}
				else
				{
					streamWriter2.WriteLine(skillSpell2.raw.Trim());
					writeDashes(streamWriter2);
				}
			}
			else
			{
				text4 = text4 + "\r\n" + skillSpell2.SSName;
			}
		}
		streamWriter.Close();
		streamWriter2.Close();
		streamWriter = new StreamWriter(rootPath + "\\missing.chr");
		streamWriter.WriteLine(text3);
		writeDashes(streamWriter);
		streamWriter.WriteLine(text4);
		streamWriter.Close();
	}

	private bool updateDataFolder(ProgressIndicator pi)
	{
		try
		{
			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			string[] files = Directory.GetFiles(dataPath);
			Hashtable hashtable = new Hashtable();
			for (int i = 0; i < files.Length; i++)
			{
				int num = files[i].LastIndexOf("\\") + 1;
				string key = files[i].Substring(num, files[i].Length - num);
				hashtable.Add(key, File.GetLastWriteTimeUtc(files[i]));
			}
			ArrayList arrayList = new ArrayList();
			pi.updateLbl("Grabbing information from online...");
			WebClient webClient = new WebClient();
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(new Uri("http://home.comcast.net/~thp1017/data/dataUpdate"));
			obj.Timeout = 5000;
			StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
			for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
			{
				arrayList.Add(text);
			}
			streamReader.Close();
			pi.updateLbl("Comparing files to see what needs updated...");
			Hashtable hashtable2 = new Hashtable();
			arrayList.Sort();
			for (int j = 0; j < arrayList.Count; j++)
			{
				string text2 = (string)arrayList[j];
				string key2 = text2.Substring(0, text2.IndexOf("::"));
				DateTime dateTime = DateTime.Parse(text2.Substring(text2.IndexOf("::") + 2, text2.Length - text2.IndexOf("::") - 2), new CultureInfo("en-US", useUserOverride: false));
				if (hashtable.ContainsKey(key2))
				{
					if (((DateTime)hashtable[key2]).ToUniversalTime().CompareTo((object)dateTime) < 0)
					{
						hashtable2.Add(key2, dateTime);
					}
				}
				else
				{
					hashtable2.Add(key2, dateTime);
				}
			}
			IDictionaryEnumerator enumerator = hashtable2.GetEnumerator();
			if (hashtable2.Count > 0 && MessageBox.Show("Really download updates?  This may overwrite any local changes you have made!", "Confirm Update", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return true;
			}
			if (hashtable2.Count > 0)
			{
				pi.initProgressBar(0, hashtable2.Count);
				pi.Focus();
				while (enumerator.MoveNext())
				{
					if (pi.userCancelled)
					{
						return true;
					}
					pi.updateLbl("Downloading file " + enumerator.Key);
					pi.updateProgressBar();
					string address = "http://home.comcast.net/~thp1017/data/" + enumerator.Key;
					string text3 = dataPath + enumerator.Key;
					webClient.DownloadFile(address, text3);
					File.SetLastWriteTimeUtc(text3, ((DateTime)enumerator.Value).ToLocalTime());
				}
				pi.updateLbl("Finishing up...");
				for (int k = 0; k < waitTime; k++)
				{
				}
			}
			else
			{
				pi.updateLbl("No files need updating.");
				for (int l = 0; l < waitTime; l++)
				{
				}
			}
			return false;
		}
		catch (Exception)
		{
			pi.updateLbl("Data update server unavailable.");
			return false;
		}
	}

	private ArrayList updatePrivateFolder(ProgressIndicator pi)
	{
		bool flag = false;
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		if (Directory.Exists(privatePath) && Directory.GetFiles(privatePath).Length != 0)
		{
			string[] files = Directory.GetFiles(privatePath);
			for (int i = 0; i < files.Length; i++)
			{
				int num = files[i].LastIndexOf("\\") + 1;
				string key = files[i].Substring(num, files[i].Length - num);
				hashtable2.Add(key, File.GetLastWriteTimeUtc(files[i]));
			}
		}
		if (passTB.Text.Length > 0 && hashtable2.Count > 0)
		{
			NetworkCredential credentials = new NetworkCredential("private", passTB.Text, null);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://home.comcast.net/~thp1017/private/"));
			try
			{
				httpWebRequest.Credentials = credentials;
				HttpWebResponse obj = (HttpWebResponse)httpWebRequest.GetResponse();
				flag = true;
				obj.Close();
			}
			catch (Exception)
			{
			}
		}
		if (flag)
		{
			pi.updateLbl("Checking for updates to 'private' files...");
			NetworkCredential credentials2 = new NetworkCredential("private", passTB.Text, null);
			WebClient webClient = new WebClient();
			webClient.Credentials = credentials2;
			try
			{
				ArrayList arrayList = new ArrayList();
				HttpWebRequest obj2 = (HttpWebRequest)WebRequest.Create(new Uri("http://home.comcast.net/~thp1017/private/privateDataUpdate"));
				obj2.Credentials = credentials2;
				StreamReader streamReader = new StreamReader(((HttpWebResponse)obj2.GetResponse()).GetResponseStream());
				for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
				{
					arrayList.Add(text);
				}
				streamReader.Close();
				pi.updateLbl("Comparing files to see what needs updated...");
				arrayList.Sort();
				for (int j = 0; j < arrayList.Count; j++)
				{
					string text2 = (string)arrayList[j];
					string key2 = text2.Substring(0, text2.IndexOf("::"));
					DateTime dateTime = DateTime.Parse(text2.Substring(text2.IndexOf("::") + 2, text2.Length - text2.IndexOf("::") - 2));
					if (hashtable2.ContainsKey(key2))
					{
						if (((DateTime)hashtable2[key2]).ToUniversalTime().CompareTo((object)dateTime) < 0)
						{
							hashtable.Add(key2, dateTime);
						}
					}
					else
					{
						hashtable.Add(key2, dateTime);
					}
				}
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				if (hashtable.Count > 0)
				{
					pi.initProgressBar(0, hashtable.Count);
					while (enumerator.MoveNext())
					{
						pi.updateLbl("Downloading file " + enumerator.Key);
						pi.updateProgressBar();
						string address = "http://home.comcast.net/~thp1017/private/" + enumerator.Key;
						string text3 = privatePath + enumerator.Key;
						webClient.DownloadFile(address, text3);
						File.SetLastWriteTimeUtc(text3, ((DateTime)enumerator.Value).ToLocalTime());
						for (int k = 0; k < waitTime / 5; k++)
						{
						}
					}
					pi.updateLbl("Finishing up...");
					for (int l = 0; l < waitTime; l++)
					{
					}
				}
				else
				{
					pi.updateLbl("No files need updating.");
					for (int m = 0; m < waitTime; m++)
					{
					}
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, "File Update Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				hashtable = new Hashtable();
			}
		}
		pi.updateLbl("Finishing up...");
		return new ArrayList(hashtable.Keys);
	}

	private bool checkExe()
	{
		try
		{
			if (checkGitHubVersionUpdate())
			{
				return true;
			}
			if (GetLastUpdateCheckTime() != DateTime.MinValue)
			{
				return checkGitHubFileUpdates();
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool checkGitHubVersionUpdate()
	{
		try
		{
			WebClient obj = new WebClient
			{
				Headers = { { "User-Agent", "zCreator-Enhanced" } }
			};
			string address = "https://api.github.com/repos/Antiflower/Zcreator-Enhanced/releases/latest";
			string text = obj.DownloadString(address);
			if (text.Contains("\"message\":") && text.Contains("Not Found"))
			{
				return false;
			}
			int num = text.IndexOf("\"tag_name\":\"") + 12;
			if (num > 11)
			{
				int num2 = text.IndexOf("\"", num);
				if (num2 > num)
				{
					string text2 = text.Substring(num, num2 - num);
					string fileVersion = GetFileVersion();
					text2 = text2.TrimStart('v', 'V').Trim();
					fileVersion = NormalizeVersion(fileVersion);
					text2 = NormalizeVersion(text2);
					return !text2.Equals(fileVersion);
				}
			}
			return false;
		}
		catch (WebException ex)
		{
			if (ex.Response is HttpWebResponse httpWebResponse)
			{
				_ = httpWebResponse.StatusCode;
				_ = 404;
				return false;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private string NormalizeVersion(string version)
	{
		version = version.TrimStart('v', 'V').Trim();
		string[] array = version.Split('.');
		if (array.Length == 3)
		{
			version += ".0";
		}
		else if (array.Length == 2)
		{
			version += ".0.0";
		}
		return version;
	}

	private bool checkGitHubFileUpdates()
	{
		try
		{
			DateTime lastUpdateCheckTime = GetLastUpdateCheckTime();
			WebClient obj = new WebClient
			{
				Headers = { { "User-Agent", "zCreator-Enhanced" } }
			};
			string address = "https://api.github.com/repos/Antiflower/Zcreator-Enhanced/commits?sha=main&per_page=1";
			string text = obj.DownloadString(address);
			int num = text.IndexOf("\"date\":\"") + 8;
			if (num > 7)
			{
				int num2 = text.IndexOf("\"", num);
				if (DateTime.Parse(text.Substring(num, num2 - num), null, DateTimeStyles.RoundtripKind) > lastUpdateCheckTime)
				{
					return true;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private DateTime GetLastUpdateCheckTime()
	{
		string path = Path.Combine(rootPath, "lastUpdateCheck.txt");
		if (File.Exists(path))
		{
			try
			{
				string text = File.ReadAllText(path).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					return DateTime.Parse(text, null, DateTimeStyles.RoundtripKind);
				}
			}
			catch
			{
			}
		}
		return DateTime.MinValue;
	}

	private void SaveLastUpdateCheckTime()
	{
		File.WriteAllText(Path.Combine(rootPath, "lastUpdateCheck.txt"), DateTime.UtcNow.ToString("o"));
	}

	public static void updateExe()
	{
		updateExeFromGitHub();
	}

	private static void updateExeFromGitHub()
	{
		WebClient webClient = new WebClient();
		webClient.Headers.Add("User-Agent", "zCreator-Enhanced");
		string address = "https://github.com/Antiflower/Zcreator-Enhanced/raw/main/Zcreator%20Updated/zCreator_updated.exe";
		string executablePath = Application.ExecutablePath;
		string directoryName = Path.GetDirectoryName(executablePath);
		string text = Path.Combine(directoryName, "zCreator_updated.exe");
		string text2 = Path.Combine(Path.GetTempPath(), "zCreator_updated_temp.exe");
		webClient.DownloadFile(address, text2);
		try
		{
			if (text.Equals(executablePath, StringComparison.OrdinalIgnoreCase))
			{
				string text3 = Path.Combine(directoryName, "update_zcreator.bat");
				using (StreamWriter streamWriter = new StreamWriter(text3))
				{
					streamWriter.WriteLine("@echo off");
					streamWriter.WriteLine("timeout /t 2 /nobreak >nul");
					streamWriter.WriteLine("del \"" + text + "\"");
					streamWriter.WriteLine("move \"" + text2 + "\" \"" + text + "\"");
					streamWriter.WriteLine("del \"%~f0\"");
				}
				Process.Start(new ProcessStartInfo
				{
					FileName = text3,
					UseShellExecute = true,
					WindowStyle = ProcessWindowStyle.Hidden
				});
				MessageBox.Show("Update will be installed when you close the application.\n\nPlease restart zCreator_updated.exe after closing.", "Update Ready", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				File.Copy(text2, text, overwrite: true);
				File.Delete(text2);
				MessageBox.Show("Update installed successfully!\n\nPlease restart the application to use the new version.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception)
		{
			try
			{
				string text4 = Path.Combine(directoryName, "update_zcreator.bat");
				using (StreamWriter streamWriter2 = new StreamWriter(text4))
				{
					streamWriter2.WriteLine("@echo off");
					streamWriter2.WriteLine("timeout /t 2 /nobreak >nul");
					streamWriter2.WriteLine("del \"" + text + "\"");
					streamWriter2.WriteLine("move \"" + text2 + "\" \"" + text + "\"");
					streamWriter2.WriteLine("del \"%~f0\"");
				}
				Process.Start(new ProcessStartInfo
				{
					FileName = text4,
					UseShellExecute = true,
					WindowStyle = ProcessWindowStyle.Hidden
				});
				MessageBox.Show("Update will be installed when you close the application.\n\nPlease restart zCreator_updated.exe after closing.", "Update Ready", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
				string text5 = Path.Combine(directoryName, "zCreator_updated_new.exe");
				File.Move(text2, text5);
				MessageBox.Show("Update downloaded to:\n" + text5 + "\n\nPlease close this application and replace zCreator_updated.exe with the new file.", "Update Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void checkUpdates_Click(object sender, EventArgs e)
	{
		if (passTB.Text.Equals("update"))
		{
			updateDataLogFile();
			return;
		}
		try
		{
			ProgressIndicator progressIndicator = new ProgressIndicator();
			progressIndicator.updateLbl("Checking GitHub for updates...");
			progressIndicator.Refresh();
			bool flag = checkExe();
			ArrayList arrayList = updateGitHubDataFiles(progressIndicator);
			progressIndicator.Close();
			if (flag || (arrayList != null && arrayList.Count > 0))
			{
				string text = "Updates are available on GitHub!\n\n";
				if (flag)
				{
					text += "• New executable version available\n";
				}
				if (arrayList != null && arrayList.Count > 0)
				{
					text = text + "• " + arrayList.Count + " data file(s) updated\n";
				}
				text += "\nWould you like to download the updates now?";
				if (MessageBox.Show(text, "Updates Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					downloadGitHubUpdates(flag, arrayList);
					SaveLastUpdateCheckTime();
					MessageBox.Show("Updates downloaded successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("You can download updates from:\nhttps://github.com/Antiflower/Zcreator-Enhanced", "Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else
			{
				SaveLastUpdateCheckTime();
				MessageBox.Show("You are using the latest version of zCreator!\n\nVersion: " + GetFileVersion() + "\n\nFor future updates, check:\nhttps://github.com/Antiflower/Zcreator-Enhanced", "Up to Date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Unable to check for updates: " + ex.Message + "\n\nPlease check manually at:\nhttps://github.com/Antiflower/Zcreator-Enhanced", "Update Check Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private ArrayList updateGitHubDataFiles(ProgressIndicator pi)
	{
		try
		{
			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			pi.updateLbl("Checking data files on GitHub...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent", "zCreator-Enhanced");
			string address = "https://api.github.com/repos/Antiflower/Zcreator-Enhanced/contents/data";
			string text = webClient.DownloadString(address);
			ArrayList arrayList = new ArrayList();
			DateTime lastUpdateCheckTime = GetLastUpdateCheckTime();
			int startIndex = 0;
			while (true)
			{
				int num = text.IndexOf("\"name\":\"", startIndex);
				if (num == -1)
				{
					break;
				}
				int num2 = num + 8;
				int num3 = text.IndexOf("\"", num2);
				if (num3 == -1)
				{
					break;
				}
				string text2 = text.Substring(num2, num3 - num2);
				if (text2.EndsWith(".chr") || text2.EndsWith(".txt"))
				{
					string address2 = "https://api.github.com/repos/Antiflower/Zcreator-Enhanced/commits?path=data/" + text2 + "&per_page=1";
					try
					{
						string text3 = webClient.DownloadString(address2);
						int num4 = text3.IndexOf("\"date\":\"");
						if (num4 > -1)
						{
							int num5 = num4 + 8;
							int num6 = text3.IndexOf("\"", num5);
							if (num6 > num5)
							{
								DateTime dateTime = DateTime.Parse(text3.Substring(num5, num6 - num5), null, DateTimeStyles.RoundtripKind);
								if (!File.Exists(Path.Combine(dataPath, text2)) || dateTime > lastUpdateCheckTime)
								{
									arrayList.Add(text2);
								}
							}
						}
					}
					catch
					{
						if (!File.Exists(Path.Combine(dataPath, text2)))
						{
							arrayList.Add(text2);
						}
					}
				}
				startIndex = num3;
			}
			return arrayList;
		}
		catch
		{
			return new ArrayList();
		}
	}

	private void downloadGitHubUpdates(bool downloadExe, ArrayList dataFiles)
	{
		ProgressIndicator progressIndicator = new ProgressIndicator();
		WebClient webClient = new WebClient();
		webClient.Headers.Add("User-Agent", "zCreator-Enhanced");
		int max = (downloadExe ? 1 : 0) + (dataFiles?.Count ?? 0);
		progressIndicator.initProgressBar(0, max);
		progressIndicator.Refresh();
		int num = 0;
		if (downloadExe)
		{
			progressIndicator.updateLbl("Downloading executable...");
			progressIndicator.updateProgressBar();
			updateExeFromGitHub();
			num++;
		}
		if (dataFiles != null && dataFiles.Count > 0)
		{
			foreach (string dataFile in dataFiles)
			{
				progressIndicator.updateLbl("Downloading " + dataFile + "...");
				progressIndicator.updateProgressBar();
				string address = "https://raw.githubusercontent.com/Antiflower/Zcreator-Enhanced/main/data/" + dataFile;
				string fileName = Path.Combine(dataPath, dataFile);
				webClient.DownloadFile(address, fileName);
				num++;
			}
		}
		progressIndicator.Close();
	}
}
