using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CharCreator;

public class RaceDisplay : Form
{
	private Label label2;

	private Container components;

	public RaceDisplay(Race r)
	{
		InitializeComponent();
		displayDescription(r.descript);
		base.Visible = true;
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
		this.label2 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.label2.Font = new System.Drawing.Font("Courier New", 10f);
		this.label2.Location = new System.Drawing.Point(16, 16);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(600, 240);
		this.label2.TabIndex = 1;
		this.label2.Text = "No Racial Information Available";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.WhiteSmoke;
		base.ClientSize = new System.Drawing.Size(624, 269);
		base.Controls.Add(this.label2);
		base.Name = "RaceDisplay";
		this.Text = "RaceDisplay";
		base.ResumeLayout(false);
	}

	public void displayDescription(string descript)
	{
		if (descript != null && descript.Length > 0)
		{
			int num = 0;
			int num2 = 0;
			string text = descript;
			int num3 = text.IndexOf("\r");
			while (num3 != -1)
			{
				num++;
				text = text.Substring(num3 + 1, text.Length - num3 - 1);
				num3 = text.IndexOf("\r");
				num2 = Math.Max(num2, num3);
			}
			double num4 = 0.0;
			num4 = ((num >= 25) ? ((1.0 - (double)num / 750.0) * (double)(label2.Font.Height + 2)) : ((double)(label2.Font.Height + (6 - num / 5))));
			base.Width = num2 * 9;
			base.Height = (int)(num4 * (double)num);
			label2.Width = num2 * 9 - 32;
			label2.Height = (int)(num4 * (double)num) - 56;
			label2.Text = descript;
		}
	}
}
