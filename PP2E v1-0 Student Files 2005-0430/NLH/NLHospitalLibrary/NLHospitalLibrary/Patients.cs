using System;
using System.Data;
using System.Data.SqlClient;
using NLHospitalLibrary.Properties;
using System.Windows.Forms;

namespace NLHospitalLibrary
{
    /// <summary>
    /// Summary description for Patients.
    /// </summary>
    public class Patients
    {
        private DataSet m_oDS;
        private SqlConnection m_oCn;
        private SqlDataAdapter m_oDA;
        private string m_sClassName = "Patients";
        private string sSQL;

        public string pInsNum { get; set; }
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



        public Patients()
        {
            //
            // TODO: Add constructor logic here
            SqlCommand oSelCmd;
            SqlCommand oInsCmd;
            SqlCommand oUpdCmd;

            InitializeConnection();

            sSQL = "SELECT HealthNumber, LastName, FirstName, DateOfBirth, " +
                " Address, City, Province, PostalCode, Phone, InsuranceCompany, InsuranceNumber, " +
                " NextOfKin, NextOfKinRelationship, Doctor " +
                " FROM	Patients " +
                " ORDER BY HealthNumber  ";
            oSelCmd = null;
            oSelCmd = new SqlCommand(sSQL, m_oCn);
            oSelCmd.CommandType = CommandType.Text;

            sSQL = "UPDATE Patients " +
                " SET LastName = @LastName, FirstName = @FirstName, " +
                " DateOfBirth = @DateOfBirth, Address = @Address, City = @City, Province = @Province, " +
                " PostalCode = @PostalCode, Phone = @Phone, InsuranceCompany = @InsuranceCompany, " +
                " InsuranceNumber = @InsuranceNumber, NextOfKin = @NextOfKin, " +
                " NextOfKinRelationship = @NextOfKinRelationship, Doctor = @Doctor" +
                " WHERE HealthNumber  = @HealthNumber  ";
            oUpdCmd = null;
            oUpdCmd = new SqlCommand(sSQL, m_oCn);
            oUpdCmd.CommandType = CommandType.Text;
            oUpdCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30, "LastName"));
            oUpdCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30, "FirstName"));
            oUpdCmd.Parameters.Add(new SqlParameter("@HealthNumber", SqlDbType.NVarChar, 15, "HealthNumber"));
            oUpdCmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime, 8, "DateOfBirth"));
            oUpdCmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50, "Address"));
            oUpdCmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30, "City"));
            oUpdCmd.Parameters.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 15, "Province"));
            oUpdCmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode"));
            oUpdCmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 14, "Phone"));
            oUpdCmd.Parameters.Add(new SqlParameter("@InsuranceCompany", SqlDbType.NVarChar, 30, "InsuranceCompany"));
            oUpdCmd.Parameters.Add(new SqlParameter("@InsuranceNumber", SqlDbType.NVarChar, 15, "InsuranceNumber"));
            oUpdCmd.Parameters.Add(new SqlParameter("@NextOfKin", SqlDbType.NVarChar, 30, "NextOfKin"));
            oUpdCmd.Parameters.Add(new SqlParameter("@NextOfKinRelationship", SqlDbType.NVarChar, 10, "NextOfKinRelationship"));
            oUpdCmd.Parameters.Add(new SqlParameter("@Doctor", SqlDbType.NVarChar, 4, "Doctor"));

            sSQL = "INSERT INTO Patients " +
                " (LastName, FirstName, HealthNumber, " +
                " DateOfBirth, Address, City, Province, " +
                " PostalCode, Phone, InsuranceCompany, " +
                " InsuranceNumber, NextOfKin , NextOfKinRelationship, Doctor)" +
                " VALUES (@LastName, @FirstName, @HealthNumber, " +
                " @DateOfBirth, @Address, @City, @Province, " +
                " @PostalCode, @Phone, @InsuranceCompany, " +
                " @InsuranceNumber, @NextOfKin , @NextOfKinRelationship, @Doctor)";
            oInsCmd = null;
            oInsCmd = new SqlCommand(sSQL, m_oCn);
            oInsCmd.CommandType = CommandType.Text;
            oInsCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30, "LastName"));
            oInsCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30, "FirstName"));
            oInsCmd.Parameters.Add(new SqlParameter("@HealthNumber", SqlDbType.NVarChar, 15, "HealthNumber"));
            oInsCmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime, 8, "DateOfBirth"));
            oInsCmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50, "Address"));
            oInsCmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30, "City"));
            oInsCmd.Parameters.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 15, "Province"));
            oInsCmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode"));
            oInsCmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 14, "Phone"));
            oInsCmd.Parameters.Add(new SqlParameter("@InsuranceCompany", SqlDbType.NVarChar, 30, "InsuranceCompany"));
            oInsCmd.Parameters.Add(new SqlParameter("@InsuranceNumber", SqlDbType.NVarChar, 15, "InsuranceNumber"));
            oInsCmd.Parameters.Add(new SqlParameter("@NextOfKin", SqlDbType.NVarChar, 30, "NextOfKin"));
            oInsCmd.Parameters.Add(new SqlParameter("@NextOfKinRelationship", SqlDbType.NVarChar, 10, "NextOfKinRelationship"));
            oInsCmd.Parameters.Add(new SqlParameter("@Doctor", SqlDbType.NVarChar, 4, "Doctor"));

            m_oDA = new SqlDataAdapter();
            m_oDA.SelectCommand = oSelCmd;
            m_oDA.UpdateCommand = oUpdCmd;
            m_oDA.InsertCommand = oInsCmd;

            m_oCn = null;

        }

        public string AddData(string ID, string LN, string FN, DateTime birth,
            string address, string city, string prov, string post, string phone,
            string insCo, string insNum, string kin, string kinRel, string doc)
        {
            string sMsg = "";

            try
            {
                InitializeConnection();
                m_oCn.Open();
                DataSet thisDataSet = new DataSet();
                m_oDA.Fill(thisDataSet, m_sClassName);

                DataColumn[] keys = new DataColumn[1];
                keys[0] = thisDataSet.Tables["Patients"].Columns["HealthNumber"];
                thisDataSet.Tables["Patients"].PrimaryKey = keys;
                DataRow findRow = thisDataSet.Tables["Patients"].Rows.Find(ID);

                if (findRow == null)
                {
                    DataRow thisRow = thisDataSet.Tables["Patients"].NewRow();
                    thisRow["HealthNumber"] = ID;
                    thisRow["LastName"] = LN;
                    thisRow["FirstName"] = FN;
                    thisRow["DateOfBirth"] = Convert.ToDateTime(birth);
                    thisRow["Address"] = address;
                    thisRow["City"] = city;
                    thisRow["Province"] = prov;
                    thisRow["PostalCode"] = post;
                    thisRow["Phone"] = phone;
                    thisRow["InsuranceCompany"] = insCo;
                    thisRow["InsuranceNumber"] = insNum;
                    thisRow["NextOfKin"] = kin;
                    thisRow["NextOfKinRelationship"] = kinRel;
                    thisRow["Doctor"] = doc;
                    thisDataSet.Tables["Patients"].Rows.Add(thisRow);
                    if ((findRow = thisDataSet.Tables["Patients"].Rows.Find(ID)) != null)
                    {
                        sMsg = "Patient Record Was Added!";
                    }
                }
                else
                {
                    sMsg = " Patient " + " already present in database.";
                }

                m_oDA.Update(thisDataSet, m_sClassName);

            }
            catch (Exception e)
            {
                sMsg = "Record was not added" + e.Message.ToString();
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return sMsg;

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
                for (int n = 0; n < thisDataSet.Tables["Patients"].Rows.Count; n++)
                {
                    if (thisDataSet.Tables["Patients"].Rows[n]["HealthNumber"].ToString() == ID)
                    {
                        m_oDA.Fill(foundDataSet, n, 1, m_sClassName);
                    }
                }
            }
            catch (Exception e)
            {
                if (foundDataSet.Tables["Patients"].Rows.Count < 1)
                {
                    MessageBox.Show("There is not Patient availabel with this HealthNumber");
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return foundDataSet;
        }

        public string UpdateData(string ID, string LN, string FN, DateTime birth,
            string address, string city, string prov, string post, string phone,
            string insCo, string insNum, string kin, string kinRel, string doc)
        {
            string sMsg = "Patient Successfully updated!";
            DateTime dob = Convert.ToDateTime(birth);
            try
            {
                InitializeConnection();
                m_oCn.Open();
                DataSet thisDataSet = new DataSet();
                m_oDA.Fill(thisDataSet, m_sClassName);

                thisDataSet.Tables["Patients"].Rows[0]["HealthNumber"] = ID;
                thisDataSet.Tables["Patients"].Rows[0]["LastName"] = LN;
                thisDataSet.Tables["Patients"].Rows[0]["FirstName"] = FN;
                thisDataSet.Tables["Patients"].Rows[0]["DateOfBirth"] = dob;
                thisDataSet.Tables["Patients"].Rows[0]["Address"] = address;
                thisDataSet.Tables["Patients"].Rows[0]["City"] = city;
                thisDataSet.Tables["Patients"].Rows[0]["Province"] = prov;
                thisDataSet.Tables["Patients"].Rows[0]["PostalCode"] = post;
                thisDataSet.Tables["Patients"].Rows[0]["Phone"] = phone;
                thisDataSet.Tables["Patients"].Rows[0]["InsuranceCompany"] = insCo;
                thisDataSet.Tables["Patients"].Rows[0]["InsuranceNumber"] = insNum;
                thisDataSet.Tables["Patients"].Rows[0]["NextOfKin"] = kin;
                thisDataSet.Tables["Patients"].Rows[0]["NextOfKinRelationship"] = kinRel;
                thisDataSet.Tables["Patients"].Rows[0]["Doctor"] = doc;
                m_oDA.Update(thisDataSet, m_sClassName);

            }
            catch (Exception e)
            {
                sMsg = "Record was not updated" + e.Message.ToString();
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return sMsg;
        }


        public string SaveData(DataSet oDS)
        {
            string sMsg;
            long lRecsAffected;
            SqlTransaction oTran = null;

            try
            {
                InitializeConnection();
                m_oCn.Open();
                oTran = m_oCn.BeginTransaction();
                lRecsAffected = m_oDA.Update(oDS, m_sClassName);
                oTran.Commit();
                sMsg = lRecsAffected + " Patient Records Were Updated";
            }
            catch (Exception e)
            {
                oTran.Rollback();
                sMsg = "Records were not updated" + e.Message.ToString();
            }
            finally
            {
                oTran = null;
                m_oCn.Close();
                m_oCn = null;
            }
            return sMsg;
        }

        private void InitializeConnection()
        {
            m_oCn = new SqlConnection(Settings.Default.ConnectionString);
        }

        public bool GetPatientInfo(string pID)
        {
            bool pvalid = true;
            try
            {
                DataSet pDataSet = new DataSet();
                pDataSet = FindData(pID);
                pInsNum = pDataSet.Tables["Patients"].Rows[0]["HealthNumber"].ToString();
                pLast = pDataSet.Tables["Patients"].Rows[0]["LastName"].ToString();
                pFirst = pDataSet.Tables["Patients"].Rows[0]["FirstName"].ToString();
                pDateBirth = Convert.ToDateTime(pDataSet.Tables["Patients"].Rows[0]["DateOfBirth"]);

                pAddress = pDataSet.Tables["Patients"].Rows[0]["Address"].ToString();
                pCity = pDataSet.Tables["Patients"].Rows[0]["City"].ToString();
                pProv = pDataSet.Tables["Patients"].Rows[0]["Province"].ToString();
                pPost = pDataSet.Tables["Patients"].Rows[0]["PostalCode"].ToString();
                pPhone = pDataSet.Tables["Patients"].Rows[0]["Phone"].ToString();
                pInsPlanCompany = pDataSet.Tables["Patients"].Rows[0]["InsuranceCompany"].ToString();
                pInsurancPlanNo = pDataSet.Tables["Patients"].Rows[0]["InsuranceNumber"].ToString();
                pNextofk = pDataSet.Tables["Patients"].Rows[0]["NextOfKin"].ToString();
                NtfKinRelationship = pDataSet.Tables["Patients"].Rows[0]["NextOfKinRelationship"].ToString();
                pDoctor = pDataSet.Tables["Patients"].Rows[0]["Doctor"].ToString();
            }
            catch
            {
                pvalid = false;
            }
            return pvalid;
        }
    }
}
