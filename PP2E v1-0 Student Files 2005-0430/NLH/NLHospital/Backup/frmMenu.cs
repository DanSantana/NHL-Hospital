using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NLHospitalLibrary;
using NLHBaseWindow;


namespace NLHospital
{
	/// <summary>
	/// Summary description for frmMenu.
	/// </summary>
	public class frmMenu : NLHBase
	{
		private System.Windows.Forms.Label lblAdministrator;
		private System.Windows.Forms.Button btnDoctors;
		private System.Windows.Forms.Label lblAdmin;
		private System.Windows.Forms.Panel pnlAdministrator;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnDischarge;
		private System.Windows.Forms.Button btnSurgery;
		private System.Windows.Forms.Label lblNurses;
		private System.Windows.Forms.Button btnForSurgery;
		private System.Windows.Forms.Button btnBilling;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Panel pnlDoctors;
		private System.Windows.Forms.Panel pnlNurses;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPatientID;
		private System.Windows.Forms.Label label1;

		public CurrentUser oCurrent = new CurrentUser();

		public frmMenu()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlAdministrator = new System.Windows.Forms.Panel();
			this.btnBilling = new System.Windows.Forms.Button();
			this.lblAdmin = new System.Windows.Forms.Label();
			this.btnDoctors = new System.Windows.Forms.Button();
			this.lblAdministrator = new System.Windows.Forms.Label();
			this.pnlDoctors = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPatientID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSurgery = new System.Windows.Forms.Button();
			this.btnDischarge = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlNurses = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.btnForSurgery = new System.Windows.Forms.Button();
			this.lblNurses = new System.Windows.Forms.Label();
			this.btnQuit = new System.Windows.Forms.Button();
			this.pnlAdministrator.SuspendLayout();
			this.pnlDoctors.SuspendLayout();
			this.pnlNurses.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlAdministrator
			// 
			this.pnlAdministrator.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.btnBilling,
																						   this.lblAdmin,
																						   this.btnDoctors,
																						   this.lblAdministrator});
			this.pnlAdministrator.Location = new System.Drawing.Point(16, 8);
			this.pnlAdministrator.Name = "pnlAdministrator";
			this.pnlAdministrator.Size = new System.Drawing.Size(320, 120);
			this.pnlAdministrator.TabIndex = 0;
			this.pnlAdministrator.Visible = false;
			// 
			// btnBilling
			// 
			this.btnBilling.Location = new System.Drawing.Point(160, 80);
			this.btnBilling.Name = "btnBilling";
			this.btnBilling.Size = new System.Drawing.Size(136, 23);
			this.btnBilling.TabIndex = 5;
			this.btnBilling.Text = "Bill Patient";
			this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
			// 
			// lblAdmin
			// 
			this.lblAdmin.AutoSize = true;
			this.lblAdmin.Location = new System.Drawing.Point(16, 32);
			this.lblAdmin.Name = "lblAdmin";
			this.lblAdmin.Size = new System.Drawing.Size(175, 13);
			this.lblAdmin.TabIndex = 4;
			this.lblAdmin.Text = "Please select one of the following:";
			// 
			// btnDoctors
			// 
			this.btnDoctors.Location = new System.Drawing.Point(8, 80);
			this.btnDoctors.Name = "btnDoctors";
			this.btnDoctors.Size = new System.Drawing.Size(136, 23);
			this.btnDoctors.TabIndex = 1;
			this.btnDoctors.Text = "Manage Doctors";
			this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
			// 
			// lblAdministrator
			// 
			this.lblAdministrator.AutoSize = true;
			this.lblAdministrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAdministrator.Location = new System.Drawing.Point(16, 8);
			this.lblAdministrator.Name = "lblAdministrator";
			this.lblAdministrator.Size = new System.Drawing.Size(96, 16);
			this.lblAdministrator.TabIndex = 0;
			this.lblAdministrator.Text = "Administration";
			// 
			// pnlDoctors
			// 
			this.pnlDoctors.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label1,
																					 this.txtPatientID,
																					 this.label3,
																					 this.btnSurgery,
																					 this.btnDischarge,
																					 this.label2});
			this.pnlDoctors.Location = new System.Drawing.Point(344, 8);
			this.pnlDoctors.Name = "pnlDoctors";
			this.pnlDoctors.Size = new System.Drawing.Size(320, 120);
			this.pnlDoctors.TabIndex = 2;
			this.pnlDoctors.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Patient ID:";
			// 
			// txtPatientID
			// 
			this.txtPatientID.Location = new System.Drawing.Point(80, 56);
			this.txtPatientID.Name = "txtPatientID";
			this.txtPatientID.Size = new System.Drawing.Size(72, 20);
			this.txtPatientID.TabIndex = 6;
			this.txtPatientID.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Please elect one of the following:";
			// 
			// btnSurgery
			// 
			this.btnSurgery.Location = new System.Drawing.Point(168, 80);
			this.btnSurgery.Name = "btnSurgery";
			this.btnSurgery.Size = new System.Drawing.Size(136, 23);
			this.btnSurgery.TabIndex = 2;
			this.btnSurgery.Text = "Surgery Report";
			// 
			// btnDischarge
			// 
			this.btnDischarge.Location = new System.Drawing.Point(16, 80);
			this.btnDischarge.Name = "btnDischarge";
			this.btnDischarge.Size = new System.Drawing.Size(136, 23);
			this.btnDischarge.TabIndex = 1;
			this.btnDischarge.Text = "Discharge Patient";
			this.btnDischarge.Click += new System.EventHandler(this.btnDischarge_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Doctors";
			// 
			// pnlNurses
			// 
			this.pnlNurses.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label4,
																					this.button1,
																					this.btnForSurgery,
																					this.lblNurses});
			this.pnlNurses.Location = new System.Drawing.Point(16, 136);
			this.pnlNurses.Name = "pnlNurses";
			this.pnlNurses.Size = new System.Drawing.Size(320, 120);
			this.pnlNurses.TabIndex = 3;
			this.pnlNurses.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Select one of the following:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Patient List";
			// 
			// btnForSurgery
			// 
			this.btnForSurgery.Location = new System.Drawing.Point(168, 80);
			this.btnForSurgery.Name = "btnForSurgery";
			this.btnForSurgery.Size = new System.Drawing.Size(136, 23);
			this.btnForSurgery.TabIndex = 1;
			this.btnForSurgery.Text = "Surgery Report";
			// 
			// lblNurses
			// 
			this.lblNurses.AutoSize = true;
			this.lblNurses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNurses.Location = new System.Drawing.Point(32, 8);
			this.lblNurses.Name = "lblNurses";
			this.lblNurses.Size = new System.Drawing.Size(50, 16);
			this.lblNurses.TabIndex = 0;
			this.lblNurses.Text = "Nurses";
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(216, 320);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.TabIndex = 4;
			this.btnQuit.Text = "Quit";
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// frmMenu
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 470);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnQuit,
																		  this.pnlDoctors,
																		  this.pnlAdministrator,
																		  this.pnlNurses});
			this.Name = "frmMenu";
			this.Text = "Menu";
			this.Load += new System.EventHandler(this.frmMenu_Load);
			this.pnlAdministrator.ResumeLayout(false);
			this.pnlDoctors.ResumeLayout(false);
			this.pnlNurses.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnDoctors_Click(object sender, System.EventArgs e)
		{
			frmDoctors doctorsForm = new frmDoctors ();
			doctorsForm.Visible = true;
			doctorsForm.Activate();
		}

		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			Application.Exit ();
		}

		private void frmMenu_Load(object sender, System.EventArgs e)
		{
		}

		public void SelectUser()
		{
			switch (oCurrent.UserName )
			{
				case "Admin":
					pnlAdministrator.Visible = true;
					break;
				case "Doctor":
					pnlDoctors.Visible = true;
					break;
				case "Nurse":
					pnlNurses.Visible = true;
					break;
			}
			
		}

		private void btnDischarge_Click(object sender, System.EventArgs e)
		{


		}

		private void btnBilling_Click(object sender, System.EventArgs e)
		{
			frmBillPatient billForm = new frmBillPatient ();
			billForm.Visible = true;
			billForm.Activate();
		}

	}
}
