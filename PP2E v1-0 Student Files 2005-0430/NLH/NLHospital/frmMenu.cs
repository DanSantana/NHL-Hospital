using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NLHospitalLibrary;
using NLHBaseWindow;
using System.Data.SqlClient;
using System.Data;


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
        private Label LbAdmission;
        private Button btAdmission;
        private Button btNewPatient;
        private Label label5;
        private Panel plAdmission;
        public CurrentUser currentUser;

        public frmMenu(CurrentUser OCURRENT)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            currentUser = OCURRENT;
            SelectUser();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
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
            this.LbAdmission = new System.Windows.Forms.Label();
            this.btAdmission = new System.Windows.Forms.Button();
            this.btNewPatient = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.plAdmission = new System.Windows.Forms.Panel();
            this.pnlAdministrator.SuspendLayout();
            this.pnlDoctors.SuspendLayout();
            this.pnlNurses.SuspendLayout();
            this.plAdmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdministrator
            // 
            this.pnlAdministrator.Controls.Add(this.btnBilling);
            this.pnlAdministrator.Controls.Add(this.lblAdmin);
            this.pnlAdministrator.Controls.Add(this.btnDoctors);
            this.pnlAdministrator.Controls.Add(this.lblAdministrator);
            this.pnlAdministrator.Location = new System.Drawing.Point(16, 8);
            this.pnlAdministrator.Name = "pnlAdministrator";
            this.pnlAdministrator.Size = new System.Drawing.Size(320, 120);
            this.pnlAdministrator.TabIndex = 1;
            // 
            // btnBilling
            // 
            this.btnBilling.Location = new System.Drawing.Point(160, 80);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(136, 29);
            this.btnBilling.TabIndex = 1;
            this.btnBilling.Text = "Bill Patient";
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(16, 32);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(168, 13);
            this.lblAdmin.TabIndex = 2;
            this.lblAdmin.Text = "Please select one of the following:";
            // 
            // btnDoctors
            // 
            this.btnDoctors.Location = new System.Drawing.Point(8, 80);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(136, 29);
            this.btnDoctors.TabIndex = 0;
            this.btnDoctors.Text = "Manage Doctors";
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // lblAdministrator
            // 
            this.lblAdministrator.AutoSize = true;
            this.lblAdministrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrator.Location = new System.Drawing.Point(16, 8);
            this.lblAdministrator.Name = "lblAdministrator";
            this.lblAdministrator.Size = new System.Drawing.Size(111, 17);
            this.lblAdministrator.TabIndex = 3;
            this.lblAdministrator.Text = "Administration";
            // 
            // pnlDoctors
            // 
            this.pnlDoctors.Controls.Add(this.label1);
            this.pnlDoctors.Controls.Add(this.txtPatientID);
            this.pnlDoctors.Controls.Add(this.label3);
            this.pnlDoctors.Controls.Add(this.btnSurgery);
            this.pnlDoctors.Controls.Add(this.btnDischarge);
            this.pnlDoctors.Controls.Add(this.label2);
            this.pnlDoctors.Location = new System.Drawing.Point(344, 8);
            this.pnlDoctors.Name = "pnlDoctors";
            this.pnlDoctors.Size = new System.Drawing.Size(320, 120);
            this.pnlDoctors.TabIndex = 0;
            this.pnlDoctors.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDoctors_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient ID:";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(80, 53);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(104, 20);
            this.txtPatientID.TabIndex = 0;
            this.txtPatientID.TextChanged += new System.EventHandler(this.txtPatientID_TextChanged);
            this.txtPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please select one of the following:";
            // 
            // btnSurgery
            // 
            this.btnSurgery.Location = new System.Drawing.Point(168, 80);
            this.btnSurgery.Name = "btnSurgery";
            this.btnSurgery.Size = new System.Drawing.Size(136, 29);
            this.btnSurgery.TabIndex = 2;
            this.btnSurgery.Text = "Surgery Report";
            this.btnSurgery.Click += new System.EventHandler(this.btnSurgery_Click);
            // 
            // btnDischarge
            // 
            this.btnDischarge.Location = new System.Drawing.Point(16, 80);
            this.btnDischarge.Name = "btnDischarge";
            this.btnDischarge.Size = new System.Drawing.Size(136, 29);
            this.btnDischarge.TabIndex = 1;
            this.btnDischarge.Text = "Discharge Patient";
            this.btnDischarge.Click += new System.EventHandler(this.btnDischarge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Doctors";
            // 
            // pnlNurses
            // 
            this.pnlNurses.Controls.Add(this.label4);
            this.pnlNurses.Controls.Add(this.button1);
            this.pnlNurses.Controls.Add(this.btnForSurgery);
            this.pnlNurses.Controls.Add(this.lblNurses);
            this.pnlNurses.Location = new System.Drawing.Point(16, 147);
            this.pnlNurses.Name = "pnlNurses";
            this.pnlNurses.Size = new System.Drawing.Size(320, 120);
            this.pnlNurses.TabIndex = 2;
            this.pnlNurses.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNurses_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Select one of the following:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Patient List";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnForSurgery
            // 
            this.btnForSurgery.Location = new System.Drawing.Point(168, 80);
            this.btnForSurgery.Name = "btnForSurgery";
            this.btnForSurgery.Size = new System.Drawing.Size(136, 29);
            this.btnForSurgery.TabIndex = 0;
            this.btnForSurgery.Text = "Surgery Report";
            this.btnForSurgery.Click += new System.EventHandler(this.btnForSurgery_Click);
            // 
            // lblNurses
            // 
            this.lblNurses.AutoSize = true;
            this.lblNurses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurses.Location = new System.Drawing.Point(16, 15);
            this.lblNurses.Name = "lblNurses";
            this.lblNurses.Size = new System.Drawing.Size(59, 17);
            this.lblNurses.TabIndex = 3;
            this.lblNurses.Text = "Nurses";
            this.lblNurses.Click += new System.EventHandler(this.lblNurses_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(581, 276);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(83, 30);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // LbAdmission
            // 
            this.LbAdmission.AutoSize = true;
            this.LbAdmission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAdmission.Location = new System.Drawing.Point(13, 15);
            this.LbAdmission.Name = "LbAdmission";
            this.LbAdmission.Size = new System.Drawing.Size(81, 17);
            this.LbAdmission.TabIndex = 3;
            this.LbAdmission.Text = "Admission";
            // 
            // btAdmission
            // 
            this.btAdmission.Location = new System.Drawing.Point(13, 80);
            this.btAdmission.Name = "btAdmission";
            this.btAdmission.Size = new System.Drawing.Size(136, 29);
            this.btAdmission.TabIndex = 1;
            this.btAdmission.Text = "Admission";
            this.btAdmission.UseVisualStyleBackColor = false;
            this.btAdmission.Click += new System.EventHandler(this.btAdmission_Click);
            // 
            // btNewPatient
            // 
            this.btNewPatient.Location = new System.Drawing.Point(165, 80);
            this.btNewPatient.Name = "btNewPatient";
            this.btNewPatient.Size = new System.Drawing.Size(136, 29);
            this.btNewPatient.TabIndex = 0;
            this.btNewPatient.Text = "Patient Management";
            this.btNewPatient.UseVisualStyleBackColor = false;
            this.btNewPatient.Click += new System.EventHandler(this.btNewPatient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Select one of the following:";
            // 
            // plAdmission
            // 
            this.plAdmission.Controls.Add(this.LbAdmission);
            this.plAdmission.Controls.Add(this.label5);
            this.plAdmission.Controls.Add(this.btAdmission);
            this.plAdmission.Controls.Add(this.btNewPatient);
            this.plAdmission.Location = new System.Drawing.Point(344, 147);
            this.plAdmission.Name = "plAdmission";
            this.plAdmission.Size = new System.Drawing.Size(320, 119);
            this.plAdmission.TabIndex = 3;
            // 
            // frmMenu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 316);
            this.Controls.Add(this.plAdmission);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.pnlDoctors);
            this.Controls.Add(this.pnlAdministrator);
            this.Controls.Add(this.pnlNurses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlAdministrator.ResumeLayout(false);
            this.pnlAdministrator.PerformLayout();
            this.pnlDoctors.ResumeLayout(false);
            this.pnlDoctors.PerformLayout();
            this.pnlNurses.ResumeLayout(false);
            this.pnlNurses.PerformLayout();
            this.plAdmission.ResumeLayout(false);
            this.plAdmission.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private void btnDoctors_Click(object sender, System.EventArgs e)
        {
            frmDoctors doctorsForm = new frmDoctors(this);
            doctorsForm.Visible = true;
            doctorsForm.Activate();
            this.Hide();
        }
        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        private void frmMenu_Load(object sender, System.EventArgs e)
        {
            this.Text = "....   Welcome " + currentUser.userGroup.ToString();
        }
        public void SelectUser()
        {
            switch (currentUser.userGroup.ToString())
            {
                case "Admin":
                    plAdmission.Enabled = false;
                    pnlDoctors.Enabled = false;
                    pnlNurses.Enabled = false;
                    break;
                case "Doctor":
                    pnlAdministrator.Enabled = false;
                    pnlNurses.Enabled = false;
                    plAdmission.Enabled = false;
                    txtPatientID.Focus();
                    break;
                case "Nurse":
                    plAdmission.Enabled = false;
                    pnlDoctors.Enabled = false;
                    pnlAdministrator.Enabled = false;
                    break;
                case "Admission":
                    pnlNurses.Enabled = false;
                    pnlDoctors.Enabled = false;
                    pnlAdministrator.Enabled = false;
                    break;
            }
        }
        private void btnDischarge_Click(object sender, System.EventArgs e)
        {
            string patientID = txtPatientID.Text;
            string sMsg = "";
            Admissions oadms = new Admissions();
            sMsg = (oadms.DischargePatient(patientID)).ToString();
            MessageBox.Show(sMsg, "Discharging Patient",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            txtPatientID.Clear();
            txtPatientID.Focus();
        }
        private void btnBilling_Click(object sender, System.EventArgs e)
        {
            frmBillPatient billForm = new frmBillPatient(this);
            billForm.Visible = true;
            billForm.Activate();
            this.Hide();
        }
        private void btnSurgery_Click(object sender, EventArgs e)
        {
            DataSet pList = new DataSet();
            Admissions adms = new Admissions();
            pList = adms.ListSurgery();

            if (pList.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Was not Pssible Progress the List the patients, Please try again later", "Patient List Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmReport pReport = new frmReport(pList, this);
                pReport.Show();
                pReport.Activate();
                this.Hide();
            }
            
        }
        private void pnlDoctors_Paint(object sender, PaintEventArgs e)
        { }
        private void btAdmission_Click(object sender, EventArgs e)
        {
            frmAdmissions Admission = new frmAdmissions(this);
            Admission.Show();
            Admission.Activate();
            this.Hide();
        }
        private void btNewPatient_Click(object sender, EventArgs e)
        {
            frmPatients frmPatient = new frmPatients(this);
            frmPatient.Show();
            frmPatient.Activate();
            this.Hide();
        }
        private void pnlNurses_Paint(object sender, PaintEventArgs e)
        { }
        private void lblNurses_Click(object sender, EventArgs e)
        { }
        private void txtPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDischarge.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                btnDischarge.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet pList = new DataSet();
            Admissions adms = new Admissions();
            pList = adms.ListPatients();

            if (pList.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Was not Pssible Progress the List the patients, Please try again later","Patient List Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmReport pReport = new frmReport(pList,this);
                pReport.Show();
                pReport.Activate();
                this.Hide();
            }
        }
        private void btnForSurgery_Click(object sender, EventArgs e)
        {
            DataSet pList = new DataSet();
            Admissions adms = new Admissions();
            pList = adms.ListSurgery();
            if (pList.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Was not Pssible Progress the List the patients, Please try again later", "Patient List Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }       
            else
            {
                frmReport pReport = new frmReport(pList, this);
                pReport.Show();
                pReport.Activate();
                this.Hide();
            }
        }
    }
}
