using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NLHBaseWindow;
using NLHospitalLibrary;

namespace NLHospital
{
    public partial class frmPatients : NLHBase
    {
        frmMenu mymenu;
        string HealthNumber = "";
        bool patientOk = false;
        bool validFields = false;


        public string pLast;
        public string pFirst;
        public DateTime pDateBirth;
        public string pAddress;
        public string pCity;
        public string pProv;
        public string pPost;
        public string pPhone;
        public string pInsPlanCompany;
        public string pInsurancPlanNo;
        public string pNextofk;
        public string NtfKinRelationship;
        public string pDoctor;

        public frmPatients(frmMenu MYMENU)
        {
            InitializeComponent();
            mymenu = MYMENU;

        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            LoadcbbxRelationShip();
            LoadcbbxInsuranceCompany();
            cbbxInsuranceCompany.SelectedIndex = -1;
            cbbxInsuranceCompany.SelectedIndex = -1;
        }
        private void LoadcbbxInsuranceCompany()
        {
            cbbxInsuranceCompany.Items.Add("Blue Cross");
            cbbxInsuranceCompany.Items.Add("Alians");
            cbbxInsuranceCompany.Items.Add("United Health Care");
            cbbxInsuranceCompany.Items.Add("Aetna");
            cbbxInsuranceCompany.Items.Add("Humana");
            cbbxInsuranceCompany.Items.Add("Kaiser Permanente");
            cbbxInsuranceCompany.Items.Add("CIGNA");
            cbbxInsuranceCompany.Items.Add("Molina Healthcare");
            cbbxInsuranceCompany.Items.Add("Celtic Healthcare");
            cbbxInsuranceCompany.Items.Add("Assurant Health");
            cbbxInsuranceCompany.Items.Add("WellCare");
            cbbxInsuranceCompany.Items.Add("Altius");
        }
        private void LoadcbbxRelationShip()
        {
            cbbxRelationShip.Items.Add("Friend");
            cbbxRelationShip.Items.Add("Son");
            cbbxRelationShip.Items.Add("Parent");
            cbbxRelationShip.Items.Add("Spouse");
            cbbxRelationShip.Items.Add("Other");
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            mymenu.Show();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            Patients oPatient = new Patients();
            Doctors oDoct = new Doctors();
            HealthNumber = txbHealthNumber.Text;
            patientOk = oPatient.GetPatientInfo(HealthNumber);
            if (patientOk == false)
            {
                MessageBox.Show("Sorry! \n\n The Health Insurance Number " + HealthNumber + "was Not found!", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearFields();
            }
            if (patientOk != false)
            {
                oDoct.GetDoctorInfo(oPatient.pDoctor);

                //txbHealthNumber.Text = oPatient.;
                txbFirstName.Text = oPatient.pFirst.ToString();
                txbLastName.Text = oPatient.pLast.ToString();
                txbDateOfBirth.Text = oPatient.pDateBirth.ToString();

                txbPhone.Text = oPatient.pPhone.ToString();
                txbDoctorId.Text = oPatient.pDoctor.ToString();
                txbDoctorName.Text = oDoct.oFirstName.ToString() + " " + oDoct.oLastName.ToString();
                txbSpeciality.Text = oDoct.oSpeciality.ToString();

                txbAddress.Text = oPatient.pAddress.ToString();
                txbCity.Text = oPatient.pCity.ToString();
                txbProvince.Text = oPatient.pProv.ToString();
                txbPostalCode.Text = oPatient.pPost.ToString();
                txbNextOfKin.Text = oPatient.pNextofk.ToString();
                txbInsuranceNo.Text = oPatient.pInsurancPlanNo.ToString();
                cbbxRelationShip.Text = oPatient.NtfKinRelationship.ToString();
                cbbxInsuranceCompany.Text = oPatient.pInsPlanCompany.ToString();
            }
        }
        public void clearFields()
        {
            txbHealthNumber.Clear();
            txbFirstName.Clear();
            txbLastName.Clear();
            txbDateOfBirth.SendToBack();
            txbPhone.Clear();
            txbDoctorId.Clear();
            txbDoctorName.Clear();
            txbSpeciality.Clear();

            txbAddress.Clear();
            txbCity.Clear();
            txbProvince.Clear();
            txbPostalCode.Clear();

            txbNextOfKin.Clear();
            txbInsuranceNo.Clear();
            cbbxRelationShip.SelectedIndex = -1;
            cbbxInsuranceCompany.SelectedIndex = -1;

            HealthNumber = "";
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string sMsg = "";
            HealthNumber = txbHealthNumber.Text;
            pFirst = txbFirstName.Text;
            pLast = txbLastName.Text;
            pDateBirth = Convert.ToDateTime(txbDateOfBirth.Text);
            pPhone = txbPhone.Text;
            pDoctor = txbDoctorId.Text;
            pAddress = txbAddress.Text;
            pCity = txbCity.Text;
            pProv = txbProvince.Text;
            pPost = txbPostalCode.Text;
            pNextofk = txbNextOfKin.Text;
            pInsurancPlanNo = txbInsuranceNo.Text;
            pInsPlanCompany = cbbxInsuranceCompany.Text;
            NtfKinRelationship = cbbxRelationShip.Text;

            if (HealthNumber == null || pLast == null || pLast == null || pPhone == null || pDoctor == null || pAddress == null || pCity == null || pProv == null || pPost == null)
            {
                sMsg = "PLease fill out all fields before progress this transaction!";
            }
            else if (pNextofk == null || pInsurancPlanNo == null || pInsPlanCompany == null || NtfKinRelationship == null || txbDoctorName.Text == null)
            {
                sMsg = "PLease fill out all fields before progress this transaction!";
            }
            else
            {
                Patients pPatient = new Patients();
                sMsg = pPatient.UpdateData(HealthNumber, pLast, pFirst, pDateBirth, pAddress, pCity, pProv, pPost, pPhone, pInsPlanCompany, pInsurancPlanNo, pNextofk, NtfKinRelationship, pDoctor).ToString();
                if (sMsg.ToString() == "Patient Successfully updated!")
                {
                    clearFields();
                }
            }

            MessageBox.Show(sMsg.ToString(), "Update Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string sMsg = "";
            HealthNumber = txbHealthNumber.Text;
            pFirst = txbFirstName.Text;
            pLast = txbLastName.Text;
            pDateBirth = Convert.ToDateTime(txbDateOfBirth.Text);
            pPhone = txbPhone.Text;
            pDoctor = txbDoctorId.Text;
            pAddress = txbAddress.Text;
            pCity = txbCity.Text;
            pProv = txbProvince.Text;
            pPost = txbPostalCode.Text;
            pNextofk = txbNextOfKin.Text;
            pInsurancPlanNo = txbInsuranceNo.Text;
            pInsPlanCompany = cbbxInsuranceCompany.Text;
            NtfKinRelationship = cbbxRelationShip.Text;

            if (HealthNumber == null || pLast == null || pLast == null || pPhone == null || pDoctor == null || pAddress == null || pCity == null || pProv == null || pPost == null)
            {
                sMsg = "PLease fill out all fields before progress this transaction!";
            }
            else if (pNextofk == null || pInsurancPlanNo == null || pInsPlanCompany == null || NtfKinRelationship == null || txbDoctorName.Text == null)
            {
                sMsg = "PLease fill out all fields before progress this transaction!";
            }
            else
            {
                Patients pPatient = new Patients();
                sMsg = pPatient.AddData(HealthNumber, pLast, pFirst, pDateBirth, pAddress, pCity, pProv, pPost, pPhone, pInsPlanCompany, pInsurancPlanNo, pNextofk, NtfKinRelationship, pDoctor).ToString();
                if (sMsg.ToString() == "Patient Record Was Added!")
                {
                    clearFields();
                }
            }
            MessageBox.Show(sMsg.ToString(), "Update Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txbDoctorId_TextChanged(object sender, EventArgs e)
        {
        }

        private void txbDoctorId_Leave(object sender, EventArgs e)
        {
            string doctorid = txbDoctorId.Text.ToString().Trim();
            Doctors odoct = new Doctors();
            odoct.GetDoctorInfo(doctorid);
            txbDoctorName.Text = odoct.oFirstName.ToString() + " " + odoct.oLastName.ToString();
            txbSpeciality.Text = odoct.oSpeciality.ToString();
        }
    }
}

