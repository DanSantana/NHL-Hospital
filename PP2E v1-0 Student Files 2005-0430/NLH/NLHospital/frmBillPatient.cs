using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NLHospitalLibrary;
using NLHBaseWindow;
using NLHospital.Properties;




namespace NLHospital
{
    /// <summary>
    /// Summary description for BillPatient.
    /// </summary>
    public class frmBillPatient : NLHBase
    {
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblRTV;
        private System.Windows.Forms.Label lblTotalTV;
        private System.Windows.Forms.Label lblTotalPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalSemi;
        private System.Windows.Forms.Label lblPRate;
        private System.Windows.Forms.Label lblTotalPrivate;
        private System.Windows.Forms.Label lblRSemi;
        private Label label9;
        private Label lbstandardDR;
        private Label lbstDRgrandtot;
        private Label lbGrandTotalSupper;
        private Label label11;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        frmMenu mymenu;

        public frmBillPatient( frmMenu MYMENU)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            mymenu = MYMENU;



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillPatient));
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRTV = new System.Windows.Forms.Label();
            this.lblTotalTV = new System.Windows.Forms.Label();
            this.lblRPhone = new System.Windows.Forms.Label();
            this.lblTotalPhone = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRSemi = new System.Windows.Forms.Label();
            this.lblTotalSemi = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPRate = new System.Windows.Forms.Label();
            this.lblTotalPrivate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbstandardDR = new System.Windows.Forms.Label();
            this.lbstDRgrandtot = new System.Windows.Forms.Label();
            this.lbGrandTotalSupper = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(24, 48);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(81, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Health Number:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(24, 72);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(43, 13);
            this.lbl3.TabIndex = 1;
            this.lbl3.Text = "Patient:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(431, 48);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(31, 13);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Days";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Length of stay:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Daily Rate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chargeable:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "TV";
            // 
            // lblRTV
            // 
            this.lblRTV.AutoSize = true;
            this.lblRTV.Location = new System.Drawing.Point(248, 136);
            this.lblRTV.Name = "lblRTV";
            this.lblRTV.Size = new System.Drawing.Size(35, 13);
            this.lblRTV.TabIndex = 8;
            this.lblRTV.Text = "label2";
            this.lblRTV.Visible = false;
            this.lblRTV.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTotalTV
            // 
            this.lblTotalTV.AutoSize = true;
            this.lblTotalTV.Location = new System.Drawing.Point(392, 136);
            this.lblTotalTV.Name = "lblTotalTV";
            this.lblTotalTV.Size = new System.Drawing.Size(35, 13);
            this.lblTotalTV.TabIndex = 9;
            this.lblTotalTV.Text = "label3";
            this.lblTotalTV.Visible = false;
            // 
            // lblRPhone
            // 
            this.lblRPhone.AutoSize = true;
            this.lblRPhone.Location = new System.Drawing.Point(248, 160);
            this.lblRPhone.Name = "lblRPhone";
            this.lblRPhone.Size = new System.Drawing.Size(35, 13);
            this.lblRPhone.TabIndex = 10;
            this.lblRPhone.Text = "label8";
            this.lblRPhone.Visible = false;
            // 
            // lblTotalPhone
            // 
            this.lblTotalPhone.AutoSize = true;
            this.lblTotalPhone.Location = new System.Drawing.Point(392, 160);
            this.lblTotalPhone.Name = "lblTotalPhone";
            this.lblTotalPhone.Size = new System.Drawing.Size(35, 13);
            this.lblTotalPhone.TabIndex = 11;
            this.lblTotalPhone.Text = "label9";
            this.lblTotalPhone.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Semi-Private Room";
            // 
            // lblRSemi
            // 
            this.lblRSemi.AutoSize = true;
            this.lblRSemi.Location = new System.Drawing.Point(248, 184);
            this.lblRSemi.Name = "lblRSemi";
            this.lblRSemi.Size = new System.Drawing.Size(41, 13);
            this.lblRSemi.TabIndex = 13;
            this.lblRSemi.Text = "label11";
            this.lblRSemi.Visible = false;
            // 
            // lblTotalSemi
            // 
            this.lblTotalSemi.AutoSize = true;
            this.lblTotalSemi.Location = new System.Drawing.Point(392, 184);
            this.lblTotalSemi.Name = "lblTotalSemi";
            this.lblTotalSemi.Size = new System.Drawing.Size(41, 13);
            this.lblTotalSemi.TabIndex = 14;
            this.lblTotalSemi.Text = "label12";
            this.lblTotalSemi.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(112, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total now due:";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(320, 304);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(408, 304);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 19;
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Admission ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(104, 8);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(176, 20);
            this.txtID.TabIndex = 20;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(312, 8);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(160, 23);
            this.btnRetrieve.TabIndex = 22;
            this.btnRetrieve.Text = "Retrieve Patient Information";
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(120, 48);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(35, 13);
            this.lblHealth.TabIndex = 24;
            this.lblHealth.Text = "label9";
            this.lblHealth.Visible = false;
            this.lblHealth.Click += new System.EventHandler(this.lblHealth_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(384, 48);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(41, 13);
            this.lblDays.TabIndex = 25;
            this.lblDays.Text = "label11";
            this.lblDays.Visible = false;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(80, 72);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(41, 13);
            this.lblPatient.TabIndex = 26;
            this.lblPatient.Text = "label12";
            this.lblPatient.Visible = false;
            this.lblPatient.Click += new System.EventHandler(this.lblPatient_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Private Room";
            // 
            // lblPRate
            // 
            this.lblPRate.AutoSize = true;
            this.lblPRate.Location = new System.Drawing.Point(248, 208);
            this.lblPRate.Name = "lblPRate";
            this.lblPRate.Size = new System.Drawing.Size(35, 13);
            this.lblPRate.TabIndex = 28;
            this.lblPRate.Text = "label9";
            this.lblPRate.Visible = false;
            // 
            // lblTotalPrivate
            // 
            this.lblTotalPrivate.AutoSize = true;
            this.lblTotalPrivate.Location = new System.Drawing.Point(392, 208);
            this.lblTotalPrivate.Name = "lblTotalPrivate";
            this.lblTotalPrivate.Size = new System.Drawing.Size(41, 13);
            this.lblTotalPrivate.TabIndex = 29;
            this.lblTotalPrivate.Text = "label11";
            this.lblTotalPrivate.Visible = false;
            this.lblTotalPrivate.Click += new System.EventHandler(this.label11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Standard Room";
            // 
            // lbstandardDR
            // 
            this.lbstandardDR.AutoSize = true;
            this.lbstandardDR.Location = new System.Drawing.Point(248, 233);
            this.lbstandardDR.Name = "lbstandardDR";
            this.lbstandardDR.Size = new System.Drawing.Size(35, 13);
            this.lbstandardDR.TabIndex = 28;
            this.lbstandardDR.Text = "label9";
            this.lbstandardDR.Visible = false;
            // 
            // lbstDRgrandtot
            // 
            this.lbstDRgrandtot.AutoSize = true;
            this.lbstDRgrandtot.Location = new System.Drawing.Point(392, 233);
            this.lbstDRgrandtot.Name = "lbstDRgrandtot";
            this.lbstDRgrandtot.Size = new System.Drawing.Size(41, 13);
            this.lbstDRgrandtot.TabIndex = 29;
            this.lbstDRgrandtot.Text = "label11";
            this.lbstDRgrandtot.Visible = false;
            this.lbstDRgrandtot.Click += new System.EventHandler(this.label11_Click);
            // 
            // lbGrandTotalSupper
            // 
            this.lbGrandTotalSupper.AutoSize = true;
            this.lbGrandTotalSupper.Location = new System.Drawing.Point(392, 271);
            this.lbGrandTotalSupper.Name = "lbGrandTotalSupper";
            this.lbGrandTotalSupper.Size = new System.Drawing.Size(41, 13);
            this.lbGrandTotalSupper.TabIndex = 29;
            this.lbGrandTotalSupper.Text = "label11";
            this.lbGrandTotalSupper.Visible = false;
            this.lbGrandTotalSupper.Click += new System.EventHandler(this.label11_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            this.label11.ForeColor = System.Drawing.Color.SlateGray;
            this.label11.Location = new System.Drawing.Point(6, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(494, 7);
            this.label11.TabIndex = 30;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // frmBillPatient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(512, 342);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbGrandTotalSupper);
            this.Controls.Add(this.lbstDRgrandtot);
            this.Controls.Add(this.lbstandardDR);
            this.Controls.Add(this.lblTotalPrivate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTotalSemi);
            this.Controls.Add(this.lblRSemi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotalPhone);
            this.Controls.Add(this.lblRPhone);
            this.Controls.Add(this.lblTotalTV);
            this.Controls.Add(this.lblRTV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillPatient";
            this.Text = "BillPatient";
            this.Load += new System.EventHandler(this.frmBillPatient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void label6_Click(object sender, System.EventArgs e)
        {

        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            this.Close();
            mymenu.Show();

        }


        private void btnRetrieve_Click(object sender, System.EventArgs e)
        {

            //int days = 0;
            decimal grandTotal = 0.0M;
            //Extras oExtras = new Extras();
            //Rates oRates = new Rates();
            //eDataSet = oExtras.FindData(ID);
            //oRates.GetRates();
            //pID = eDataSet.Tables["Extras"].Rows[0]["PatientID"].ToString();
            //DataSet eDataSet = new DataSet();

            string AdmissionID = txtID.Text;
            string pID;
            Bill oBill = new Bill();
            Patients oPatients = new Patients();
            Admissions oAdmissions = new Admissions();
            DataSet bdataset = new DataSet();
            DataSet pDataSet = new DataSet();
            //DataSet admsdataset = new DataSet();
            bool admOk = false;
            bool patientOk = false;
            bool billOk = false;

            if (AdmissionID == "" || AdmissionID == null)
            {
                MessageBox.Show("Sorry this Admission Id was not found", "Admission Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    billOk = oBill.getBillInfo(AdmissionID);
                    admOk = oAdmissions.GetAdmissionInfo(AdmissionID);

                    pID = oAdmissions.admPatientID.ToString();
                    patientOk = oPatients.GetPatientInfo(pID);

                    lblHealth.Text = oAdmissions.admPatientID.ToString();
                    lblHealth.Visible = true;

                    lblPatient.Text = oPatients.pFirst + " " + oPatients.pLast;
                    lblPatient.Visible = true;

                    lblDays.Text = (oBill.bStayLength).ToString();
                    lblDays.Visible = true;
                    int days = Convert.ToInt32(oBill.bStayLength);

                    decimal RTV = (Convert.ToInt32(oBill.TV_DalyRate));
                    lblRTV.Text = RTV.ToString();
                    lblRTV.Visible = true;
                    lblTotalTV.Text = (Convert.ToDecimal(oBill.TV_DalyRate * oBill.bStayLength)).ToString();
                    lblTotalTV.Visible = true;

                    decimal RTphone = (Convert.ToInt32(oBill.Phone_DR));
                    lblRPhone.Text = RTphone.ToString();
                    lblRPhone.Visible = true;
                    lblTotalPhone.Text = (Convert.ToDecimal(oBill.Phone_DR * oBill.bStayLength)).ToString();
                    lblTotalPhone.Visible = true;

                    lblRSemi.Text = (Convert.ToDecimal(oBill.SemiPrivateRoom_DR).ToString());
                    lblRSemi.Visible = true;
                    lblTotalSemi.Text = (Convert.ToDecimal(oBill.SemiPrivateRoom_DR * oBill.bStayLength)).ToString();
                    lblTotalSemi.Visible = true;

                    lblPRate.Text = (Convert.ToDecimal(oBill.PrivateRoom_DR)).ToString();
                    lblPRate.Visible = true;

                    lblTotalPrivate.Text = (Convert.ToDecimal(oBill.PrivateRoom_DR * oBill.bStayLength)).ToString();
                    lblTotalPrivate.Visible = true;

                    lbstandardDR.Text = (Convert.ToDecimal(oBill.StandardRoom)).ToString();
                    lbstandardDR.Visible = true;

                    lbstDRgrandtot.Text = (Convert.ToDecimal(oBill.StandardRoom * oBill.bStayLength)).ToString();
                    lbstDRgrandtot.Visible = true;

                    lbGrandTotalSupper.Text = (Convert.ToDecimal(oBill.TotalAmount)).ToString();
                    lbGrandTotalSupper.Visible = true;
                }
                catch (Exception ex)
                {
                    if (admOk == false)
                    {
                        MessageBox.Show("Sorry this Admission Id was not found", "Admission Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        throw new Exception(ex.Message);
                }
            }
        }

        private void lblPatient_Click(object sender, System.EventArgs e)
        {

        }

        private void label11_Click(object sender, System.EventArgs e)
        {

        }

        private void frmBillPatient_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {





        }

        private void lblHealth_Click(object sender, EventArgs e)
        {

        }

        private void lblGrandTotal_Click(object sender, EventArgs e)
        {

        }


    }
}
