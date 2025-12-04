using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CharCreator;

public class ProgressIndicator : Form
{
	public bool userCancelled;

	private Container components;

	private Label label3;

	private Label label1;

	private Label percentLbl;

	private Label taskLbl;

	private ProgressBar downloadBar;

	private Color BarColor = Color.Blue;

	public ProgressIndicator()
	{
		InitializeComponent();
		taskLbl.Text = "Starting update...";
		base.Visible = true;
		percentLbl.Text = "Download is 0% Complete.";
		downloadBar.Visible = true;
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
		this.downloadBar = new System.Windows.Forms.ProgressBar();
		this.label3 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.percentLbl = new System.Windows.Forms.Label();
		this.taskLbl = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.downloadBar.Location = new System.Drawing.Point(32, 120);
		this.downloadBar.Name = "downloadBar";
		this.downloadBar.Size = new System.Drawing.Size(344, 23);
		this.downloadBar.TabIndex = 2;
		this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(8, 72);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(160, 23);
		this.label3.TabIndex = 3;
		this.label3.Text = "Update Progress";
		this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(8, 16);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(104, 23);
		this.label1.TabIndex = 4;
		this.label1.Text = "Current Task";
		this.percentLbl.Font = new System.Drawing.Font("Comic Sans MS", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.percentLbl.Location = new System.Drawing.Point(32, 96);
		this.percentLbl.Name = "percentLbl";
		this.percentLbl.Size = new System.Drawing.Size(344, 24);
		this.percentLbl.TabIndex = 6;
		this.percentLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
		this.taskLbl.Font = new System.Drawing.Font("Comic Sans MS", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.taskLbl.Location = new System.Drawing.Point(24, 40);
		this.taskLbl.Name = "taskLbl";
		this.taskLbl.Size = new System.Drawing.Size(352, 24);
		this.taskLbl.TabIndex = 7;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		base.CausesValidation = false;
		base.ClientSize = new System.Drawing.Size(400, 157);
		base.Controls.Add(this.taskLbl);
		base.Controls.Add(this.percentLbl);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.downloadBar);
		base.Name = "ProgressIndicator";
		this.Text = "Update Progress";
		base.ResumeLayout(false);
	}

	public void updateLbl(string task)
	{
		taskLbl.Text = task;
		Refresh();
	}

	public void initProgressBar(int min, int max)
	{
		downloadBar.Minimum = min;
		downloadBar.Maximum = max;
		downloadBar.Step = 1;
		downloadBar.Value = min;
		Refresh();
	}

	public void updateProgressBar()
	{
		double num = ((downloadBar.Minimum == downloadBar.Maximum) ? 1.0 : ((double)(downloadBar.Value + 1 - downloadBar.Minimum) / (double)(downloadBar.Maximum - downloadBar.Minimum)));
		double num2 = Math.Round(100.0 * num, 0);
		percentLbl.Text = "Download is " + num2 + "% Complete.";
		downloadBar.PerformStep();
		Refresh();
	}

	private void cancel_Click(object sender, EventArgs e)
	{
		userCancelled = true;
	}
}
