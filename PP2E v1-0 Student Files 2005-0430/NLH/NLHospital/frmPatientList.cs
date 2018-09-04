using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace NLHospital
{
	/// <summary>
	/// Summary description for PatientList.
	/// </summary>
	public class PatientList : System.Windows.Forms.Form
	{
		public Patients thisReport = new Patients();
		private System.Windows.Forms.Button btnQuit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPatients;

		DataSet m_oDS = new DataSet();


		public PatientList()
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
			this.crvPatients = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.btnQuit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// crvPatients
			// 
			this.crvPatients.ActiveViewIndex = -1;
			this.crvPatients.Name = "crvPatients";
			this.crvPatients.ReportSource = null;
			this.crvPatients.Size = new System.Drawing.Size(288, 224);
			this.crvPatients.TabIndex = 0;
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(208, 240);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "QUIT";
			// 
			// PatientList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnQuit,
																		  this.crvPatients});
			this.Name = "PatientList";
			this.Text = "PatientList";
			this.Load += new System.EventHandler(this.PatientList_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void PatientList_Load(object sender, System.EventArgs e)
		{
//			GetPatientData();
		}

/*		private void GetPatientData()
		{
			Patients oPatient = new Patients();
			m_oDS = oPatient.GetData();
			thisReport.SetDataSource(m_oDS);

			crvPatients.ReportSource = thisReport;
		}*/
	}
}
