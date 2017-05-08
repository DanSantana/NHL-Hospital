using System;
using System.Data;
using System.Data.SqlClient;
using NLHospitalLibrary.Properties;

namespace NLHospitalLibrary
{
    /// <summary>
    /// Summary description for Admissions.
    /// </summary>
    /// 

    public class Admissions
    {
        public DataSet m_oDS;
        public SqlConnection m_oCn;
        public SqlDataAdapter m_oDA;
        public string m_sClassName = "AdmissionRecords";
        public string sSQL;
        // admission atributes

        public int AdmissionID { get; set; }
        public string admPatientID { get; set; }
        public string admBedNo { get; set; }
        public bool admSurgerySchedule { get; set; }
        public DateTime admSurgeryDate { get; set; }
        public DateTime admissionDate { get; set; }
        public DateTime admpatientDischargedDate { get; set; }
        public string admDoctorID { get; set; }
        public bool admtv { get; set; }
        public bool admPhone { get; set; }
        public bool admsDischarged { get; set; }

        //class instances

        //Patients admPatient = new Patients();
        //Beds admBed = new Beds();
        //Doctors admDoct = new Doctors();
        public Admissions()
        {
            //
            // TODO: Add constructor logic here
            //
            SqlCommand oSelCmd;
            InitializeConnection();

            sSQL = "SELECT AdmissionID, PatientID, BedNumber, " +
                " SurgeryScheduled, SurgeryDate, AdmitDate, DischargeDate,Discharged,DoctorID,TV,Phone,Discharged" +
                " FROM	AdmissionRecords " +
                " ORDER BY AdmissionID ";
            oSelCmd = null;
            oSelCmd = new SqlCommand(sSQL, m_oCn);
            oSelCmd.CommandType = CommandType.Text;
            m_oDA = new SqlDataAdapter();
            m_oDA.SelectCommand = oSelCmd;
            m_oCn = null;
        }
        public DataSet FindData(string ID)
        {
            InitializeConnection();
            m_oCn.Open();
            DataSet thisDataSet = new DataSet();
            DataSet foundDataSet = new DataSet();
            try
            {
                m_oDA.Fill(thisDataSet, m_sClassName);
                for (int n = 0; n < thisDataSet.Tables["AdmissionRecords"].Rows.Count; n++)
                {
                    if (thisDataSet.Tables["AdmissionRecords"].Rows[n]["AdmissionID"].ToString() == ID && Convert.ToBoolean(thisDataSet.Tables["AdmissionRecords"].Rows[n]["Discharged"]) == false)
                    {
                        m_oDA.Fill(foundDataSet, n, 1, m_sClassName);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return foundDataSet;
        }
        public DataSet GetData()
        {
            m_oDS = new DataSet();
            m_oDA.Fill(m_oDS, m_sClassName);
            return m_oDS;
        }
        private void InitializeConnection()
        {
            m_oCn = new SqlConnection(Settings.Default.ConnectionString);
        }
        public void SetPatientDischarge(string ID)
        {
            InitializeConnection();
            m_oCn.Open();
            DataSet thisDataSet = new DataSet();
            try
            {
                m_oDA.Fill(thisDataSet, m_sClassName);
                for (int n = 0; n < thisDataSet.Tables["AdmissionRecords"].Rows.Count; n++)
                {
                    if (thisDataSet.Tables["AdmissionRecords"].Rows[n]["PatientID"].ToString() == ID)
                    {
                        thisDataSet.Tables["AdmissionRecords"].Rows[n]["DischargeDate"] = DateTime.Today.Date;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
        }
        public int GetDays(string ID)
        {
            int days;
            DateTime dis = new DateTime();
            DateTime ad = new DateTime();
            DataSet thisDataSet = new DataSet();
            thisDataSet = this.FindData(ID);
            ad = Convert.ToDateTime(thisDataSet.Tables["Admissions"].Rows[0]["AdmitDate"]);
            dis = Convert.ToDateTime(thisDataSet.Tables["Admissions"].Rows[0]["DischargeDate"]);
            days = dis.Day - ad.Day;
            return days;
        }
        public string insertNewAdmission()
        {
            bool existadmission = patientDischarged(admPatientID);
            string procedureOk = "";
            admsDischarged = false;
            if (existadmission == true)
            {
                procedureOk = "There is a Admission Open for this Patient, Please Close before progress a New Admission";
            }
            else
            {
                try
                {
                    InitializeConnection();
                    m_oCn.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "usp_AddAdmissionRecord";
                    sqlcmd.Connection = m_oCn;
                    sqlcmd.Parameters.Add(new SqlParameter("@PatientID", admPatientID.ToString()));
                    sqlcmd.Parameters.Add(new SqlParameter("@BedNumber", admBedNo.ToString()));
                    sqlcmd.Parameters.Add(new SqlParameter("@SurgeryScheduled", Convert.ToBoolean(admSurgerySchedule)));
                    sqlcmd.Parameters.Add(new SqlParameter("@AdmitDate", Convert.ToDateTime(admissionDate)));
                    sqlcmd.Parameters.Add(new SqlParameter("@SurgeryDate", Convert.ToDateTime(admSurgeryDate)));
                    sqlcmd.Parameters.Add(new SqlParameter("@DischargeDate", Convert.ToDateTime(admpatientDischargedDate)));
                    sqlcmd.Parameters.Add(new SqlParameter("@DoctorID", admDoctorID.ToString()));
                    sqlcmd.Parameters.Add(new SqlParameter("@TV", Convert.ToBoolean(admtv)));
                    sqlcmd.Parameters.Add(new SqlParameter("@Phone", admPhone.ToString()));
                    sqlcmd.Parameters.Add(new SqlParameter("@Discharged", Convert.ToBoolean(admsDischarged)));

                    procedureOk = sqlcmd.ExecuteScalar().ToString();
                }
                catch (Exception E)
                {
                    procedureOk = "Invalid" + E.ToString();
                }
                finally
                {
                    m_oCn.Close();
                    m_oCn = null;
                }
            }
            return procedureOk;
        }
        public bool patientDischarged(string pId)
        {
            SqlConnection newcon = new SqlConnection(Settings.Default.ConnectionString);
            newcon.Open();
            bool admissionExist = false;
            DataSet thisdataset = new DataSet();
            DataSet founddataset = new DataSet();
            m_oDA.Fill(thisdataset, m_sClassName);
            for (int i = 0; i < thisdataset.Tables["AdmissionRecords"].Rows.Count; i++)
            {
                if (thisdataset.Tables["AdmissionRecords"].Rows[i]["PatientID"].ToString() == pId && Convert.ToBoolean(thisdataset.Tables["AdmissionRecords"].Rows[i]["Discharged"]) == false)
                {
                    admissionExist = true;
                }
            }
            return admissionExist;
        }
        public bool GetAdmissionInfo(string admiD)
        {
            bool adminValid = true;
            try
            {
                DataSet admset = new DataSet();
                admset = FindData(admiD);
                AdmissionID = Convert.ToInt32(admset.Tables["AdmissionRecords"].Rows[0]["AdmissionID"]);
                admPatientID = admset.Tables["AdmissionRecords"].Rows[0]["PatientID"].ToString();
                admBedNo = admset.Tables["AdmissionRecords"].Rows[0]["BedNumber"].ToString();
                admSurgerySchedule = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["SurgeryScheduled"]);
                admSurgeryDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["SurgeryDate"]);
                admissionDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["AdmitDate"]);
                admpatientDischargedDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["DischargeDate"]);
                admtv = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["TV"]);
                admPhone = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["Phone"]);
                admsDischarged = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["Discharged"]);
                admDoctorID = Convert.ToString(admset.Tables["AdmissionRecords"].Rows[0]["DoctorID"]);
            }
            catch
            {
                adminValid = false;
            }
            return adminValid;
        }
        public bool GetAdmInfoByPatient(string patientID)
        {
            bool adminValid = true;
            try
            {
                DataSet admset = new DataSet();
                admset = FindAdmsByPatientID(patientID);
                AdmissionID = Convert.ToInt32(admset.Tables["AdmissionRecords"].Rows[0]["AdmissionID"]);
                admPatientID = admset.Tables["AdmissionRecords"].Rows[0]["PatientID"].ToString();
                admBedNo = admset.Tables["AdmissionRecords"].Rows[0]["BedNumber"].ToString();
                admSurgerySchedule = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["SurgeryScheduled"]);
                admSurgeryDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["SurgeryDate"]);
                admissionDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["AdmitDate"]);
                admpatientDischargedDate = Convert.ToDateTime(admset.Tables["AdmissionRecords"].Rows[0]["DischargeDate"]);
                admtv = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["TV"]);
                admPhone = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["Phone"]);
                admsDischarged = Convert.ToBoolean(admset.Tables["AdmissionRecords"].Rows[0]["Discharged"]);
                admDoctorID = Convert.ToString(admset.Tables["AdmissionRecords"].Rows[0]["DoctorID"]);
            }
            catch
            {
                adminValid = false;
            }
            return adminValid;
        }
        public DataSet FindAdmsByPatientID(string patientID)
        {
            InitializeConnection();
            m_oCn.Open();
            DataSet thisDataSet = new DataSet();
            DataSet foundDataSet = new DataSet();
            try
            {
                m_oDA.Fill(thisDataSet, m_sClassName);
                for (int n = 0; n < thisDataSet.Tables["AdmissionRecords"].Rows.Count; n++)
                {
                    if (thisDataSet.Tables["AdmissionRecords"].Rows[n]["PatientID"].ToString() == patientID && Convert.ToBoolean(thisDataSet.Tables["AdmissionRecords"].Rows[n]["Discharged"]) == false)
                    {
                        m_oDA.Fill(foundDataSet, n, 1, m_sClassName);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return foundDataSet;
        }
        public string DischargePatient(string patientID)
        {
            string sMsg = "";
            bool validPadmission = false;
            validPadmission = GetAdmInfoByPatient(patientID);

            if (validPadmission == false)
            {
                sMsg = "The patient Health Insurance: " + patientID + " Was not Found, please verify and try again!";
            }
            else
            {
                SqlConnection con = new SqlConnection(Settings.Default.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PatientDischarge";
                cmd.Parameters.Add(new SqlParameter("@PatientID", patientID));
                sMsg = "The patient Health Insurance: " + cmd.ExecuteScalar().ToString() + " Was Successfully Discharged!";
                con.Close();
            }
            return sMsg;
        }


        public DataSet listAdmissions()
        {
            DataSet alladmissions = new DataSet();
            m_oCn.Open();
            m_oDA.Fill(alladmissions, "AdmissionList");
            return alladmissions;
        }


        public DataSet ListPatients()
        {
            DataSet PatientList = new DataSet();
            InitializeConnection();
            m_oCn.Open();
            try
            {
                SqlCommand pListCmd = new SqlCommand();
                pListCmd.CommandType = CommandType.StoredProcedure;
                pListCmd.CommandText = "usp_ListPatient";
                pListCmd.Connection = m_oCn;
                SqlDataAdapter pListAdpter = new SqlDataAdapter();
                pListAdpter.SelectCommand = pListCmd;
                pListAdpter.Fill(PatientList, "pList");
                pListCmd.ExecuteScalar();
                
            }
            catch (Exception e )
            {
                throw new Exception(e.Message);
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }           

            return PatientList;
        }
        public DataSet ListSurgery()
        {

            DataSet PatientList = new DataSet();
            InitializeConnection();
            m_oCn.Open();
            try
            {
                SqlCommand pListCmd = new SqlCommand();
                pListCmd.CommandType = CommandType.StoredProcedure;
                pListCmd.CommandText = "usp_ListSurgery";
                pListCmd.Connection = m_oCn;
                SqlDataAdapter pListAdpter = new SqlDataAdapter();
                pListAdpter.SelectCommand = pListCmd;
                pListAdpter.Fill(PatientList, "pList");
                pListCmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return PatientList;
        }
    }
}


