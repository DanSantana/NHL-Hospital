using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NLHospitalLibrary;
using System.Data.SqlClient;
using NLHBaseWindow;
using NLHospital.Properties;

namespace NLHospital
{
    public partial class frmAdmissions : NLHBase
    {
        frmMenu mymenu;

        Beds oBed = new Beds();
        Bill oBill = new Bill();
        Admissions oAdmission = new Admissions();
       
        string NewAdmissionID = "";
        SqlConnection sqlcon;
        SqlDataAdapter sqlAdpt;
        SqlCommand sqlCmd;

        // variables to insert new admission
        string PatientID;
        //string BedNumber;
        //bool SurgeryScheduled = false;
        //DateTime AdmitDate;
        //DateTime SurgeryDate;
        //DateTime DischargeDate;
        string DoctorID;

        // variable to feed bill
        //string AdmissionID;
        double StayLength;
        //decimal TV_DalyRate;
        //bool Phone_DR;
        //bool SemiPrivateBed;
        //bool PrivateBed;
        //bool standardBed;
        //decimal TotalAmount;

        bool SavedAdmissionRecord = false;

        string obedWar;
        string obedType;

        public frmAdmissions(frmMenu MYMENU)
        {
            InitializeComponent();
            mymenu = MYMENU;
        }

        private void frmAdmissions_Load(object sender, EventArgs e)
        {
            groupbxAdmissiondata.Enabled = false;
            groupbxAccomodation.Enabled = false;
            btSave.Enabled = false;
            rdbt_Not.Checked = true;
            dtpAdmissionDate.Value = DateTime.Today.Date;
            dtpSurgeryDate.Value = DateTime.Today.Date;
            dtpDischargedDate.Value = DateTime.Today.AddDays(+1);

            TimeSpan StayDays = Convert.ToDateTime(dtpDischargedDate.Text) - Convert.ToDateTime(dtpAdmissionDate.Text);
            StayLength = StayDays.Days;
            txbStayLength.Text = StayLength.ToString();

            loadcombos();
            cbbxBedType.SelectedIndex = 0;
            cbbxWardName.SelectedIndex = 0;
            obedType = "STANDARD";
            obedWar = "OBS";
            btfindbed.Enabled = false;
            btfindbed.Visible = false;
            txbBedNumbers.Enabled = false;
        }
        private void loadcombos()
        {
            cbbxBedType.Items.Add("STANDARD");
            cbbxBedType.Items.Add("SE PRIVATE");
            cbbxBedType.Items.Add("PRIVATE");

            cbbxWardName.Items.Add("OBSERVATION");
            cbbxWardName.Items.Add("CARDIOLOGY");
            cbbxWardName.Items.Add("PEDIATRICS");
            cbbxWardName.Items.Add("EMERGENCY");
        }

        private void btNewAdmission_Click(object sender, EventArgs e)
        {
            groupbxAdmissiondata.Enabled = true;
            groupbxAccomodation.Enabled = true;
            btSave.Enabled = true;
            btNewAdmission.Visible = false;
            btLoadAdmission.Visible = false;
            //ConnectAdmission();
            //FeelNewAdmission();
        }
        public void FeelNewAdmission()
        {
            txbAdmissionID.Text = NewAdmissionID;
        }
        public void ConnectAdmission()
        {
            // Connection
            // 1 Creat Connection
            sqlcon = new SqlConnection(Settings.Default.StringConnection);
            // 2 open
            sqlcon.Open();
            // Command
            // 3 Criar Comand
            sqlCmd = sqlcon.CreateCommand();
            // 4 Definir texto          
            sqlCmd.CommandType = CommandType.Text;
            // 5 preencher comando
            sqlCmd = new SqlCommand("select AdmissionID from AdmissionRecords", sqlcon);
            // 6 tempo de comando em execucao
            sqlCmd.CommandTimeout = 7200;
            // Adaptador
            // 7 criar Adaptador inserindo o comando
            sqlAdpt = new SqlDataAdapter(sqlCmd);
            // 8 Selecionar o comando
            sqlAdpt.SelectCommand = sqlCmd;
            // 9 criar dataset
            DataSet admiss = new DataSet();
            DataSet foundmiss = new DataSet();
            // 10 preencher dataset
            try
            {
                sqlAdpt.Fill(admiss, "AdmRec");
                if (admiss.Tables["AdmissionRecords"].Rows.Count == 0)
                {
                    NewAdmissionID = "1";
                }
                else
                {
                    int tablesize = admiss.Tables["AdmissionRecords"].Rows.Count;
                    NewAdmissionID = (tablesize + 1).ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void txbPatientName_TextChanged(object sender, EventArgs e)
        {
        }

        private void rdbt_Not_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void MtxbischargedDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            if (SavedAdmissionRecord == true)
            {
                this.Close();
                mymenu.Show();
            }
            else
            {
               DialogResult Result =  MessageBox.Show("If you quit now all data in the form will be missed", "Leave without save admission", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Result==DialogResult.OK)
                {
                    this.Close();
                    mymenu.Show();
                }
            }
        }

        private void MtxbPatientID_Leave(object sender, EventArgs e)
        {
            Patients oPatient = new Patients();
            Doctors oDoctor = new Doctors();
            bool pValidation = true;
            PatientID = MtxbPatientID.Text;
            pValidation = oPatient.GetPatientInfo(PatientID);
            if (pValidation == false)
            {
                MessageBox.Show("Sorry, There is not Patient registered with this health insurance number", "Pacient not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtxbPatientID.Clear();
                MtxbPatientID.Focus();
            }
            else
            {
                oPatient.GetPatientInfo(PatientID);
                try
                {
                    oPatient.GetPatientInfo(PatientID);
                    // fill out name automatic
                    txbPatientName.Text = oPatient.pFirst + " " + oPatient.pLast;
                    // fill out Next of kin
                    txbPatientNextOfKin.Text = oPatient.pNextofk;
                    // fill ou doctor
                    txbDoctorID.Text = oPatient.pDoctor;
                    DoctorID = txbDoctorID.Text;
                    oDoctor.GetDoctorInfo(DoctorID);
                    txbDoctorName.Text = oDoctor.oFirstName.ToString() + " " + oDoctor.oLastName.ToString();
                    txbDocSpecialTy.Text = oDoctor.oSpeciality.ToString();

                    btfindbed.Enabled = true;
                    btfindbed.Visible = true;
                    txbBedNumbers.Enabled = true;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void MtxbPatientID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void MtxbPatientID_Click(object sender, EventArgs e)
        {
            MtxbPatientID.SelectionStart = MtxbPatientID.Text.Length + 1;
        }

        private void txbDoctorID_TextChanged(object sender, EventArgs e)
        {
        }

        private void txbDocSpecialTy_TextChanged(object sender, EventArgs e)
        {
        }

        private void txbDoctorName_TextChanged(object sender, EventArgs e)
        {
        }
        private void dtpDischargedDate_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan StayDays = Convert.ToDateTime(dtpDischargedDate.Text) - Convert.ToDateTime(dtpAdmissionDate.Text);
            StayLength = StayDays.Days;
            txbStayLength.Text = StayLength.ToString();
        }

        private void cbbxBedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            obedType = "";
            obedType = cbbxBedType.SelectedItem.ToString().Trim();
        }
        private void cbbxWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            obedWar = "";
            switch (cbbxWardName.SelectedItem.ToString().Trim())
            {
                case "OBSERVATION":
                    obedWar = "OBS";
                    break;
                case "CARDIOLOGY":
                    obedWar = "CARD";
                    break;
                case "PEDIATRICS":
                    obedWar = "PED";
                    break;
                case "EMERGENCY":
                    obedWar = "EMER";
                    break;
            }
        }
        private void loadbeds()
        {
            bool valid = oBed.getAvailabelBed(obedType, obedWar);
            if (valid == false)
            {
                MessageBox.Show("Sorry, there is not " + obedType + " accomodation available in the " + cbbxWardName.SelectedItem.ToString() + " ward.", "Unavailable bed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                oBed.getAvailabelBed(obedType, obedWar);
                txbBedNumbers.Text = oBed.bNumber.ToString();
            }
        }

        private void tsbBedNumbers_TextChanged(object sender, EventArgs e)
        {
        }

        private void btfindbed_Click(object sender, EventArgs e)
        {
            loadbeds();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            bool saveok = saveRecords();

            if (saveok == false)
            {
                this.Close();
                mymenu.Show();
            }
            else
            {
                oBed.setbedBusy();
                groupbxAdmissiondata.Enabled = false;
                groupbxAccomodation.Enabled = false;
                OpenBill();
            }
        }
        private void OpenBill()
        {
            oBill.bAdmissionID = oAdmission.AdmissionID;
            oBill.bStayLength = Convert.ToInt32(txbStayLength.Text);
            oBill.accommodationType = cbbxBedType.Text;
            oBill.RecordBill(oAdmission);
        }

        private bool saveRecords()
        {
            bool saveallowed = true;
            string msge;

            // variables to insert new admission
            // PatientID;
            oAdmission.admPatientID = MtxbPatientID.Text;
            // BedNumber;
            oAdmission.admBedNo = txbBedNumbers.Text;
            // SurgeryScheduled
            if (rdrbt_yes.Checked==true)
            {
                oAdmission.admSurgerySchedule = true;
            }
            if (rdbt_Not.Checked==true)
            {
                oAdmission.admSurgerySchedule = false;
            }
            // AdmitDate;
            oAdmission.admissionDate = Convert.ToDateTime(dtpAdmissionDate.Text);
            // SurgeryDate;
            oAdmission.admSurgeryDate = Convert.ToDateTime(dtpSurgeryDate.Text);
            // DischargeDate;
            oAdmission.admpatientDischargedDate = Convert.ToDateTime(dtpDischargedDate.Text);
            //DoctorID;
            oAdmission.admDoctorID = txbDoctorID.Text;
            // TV
            if (cbxTV.Checked==true)
            {
                oAdmission.admtv = true;                
            }
            // Phone
            if (cbxPhone.Checked==true)
            {
                oAdmission.admPhone = true;
            }

            msge = oAdmission.insertNewAdmission();

            if (msge == "There is a Admission Open for this Patient, Please Close before progress a New Admission")
            {
                MessageBox.Show("Sorry" + msge, "Admission Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveallowed = false;
            }

            if (msge == "Invalid")
            {
                MessageBox.Show("Sorry" + msge, "Admission Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveallowed = false;
            }
            if (msge != "Invalid" && msge != "There is a Admission Open for this Patient, Please Close before progress a New Admission")
            {
                MessageBox.Show(" Transaction Sucessfully Progressed New Admission Number: " + msge, "Admission Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbAdmissionID.Text = msge;
                oAdmission.AdmissionID = Convert.ToInt32(msge);
                SavedAdmissionRecord = true;
                btSave.Hide();
            }
            return saveallowed;
        }

        private void btLoadAdmission_Click(object sender, EventArgs e)
        {
            txbAdmissionID.Enabled = true;
        }

        private void txbAdmissionID_Leave(object sender, EventArgs e)
        {
            groupbxAdmissiondata.Enabled = true;
            groupbxAccomodation.Enabled = true;
        }
    }
}
