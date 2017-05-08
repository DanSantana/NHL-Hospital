using System;
using System.Data;
using System.Data.SqlClient;
using NLHospitalLibrary.Properties;
using System.Windows.Forms;

namespace NLHospitalLibrary
{
    /// <summary>
    /// Summary description for Beds.
    /// </summary>
    public class Beds
    {
        private DataSet m_oDS;
        private SqlConnection m_oCn;
        private SqlDataAdapter m_oDA;
        private string m_sClassName = "Beds";
        private string sSQL;
        public string bWard { get; set; }
        public string bNumber { get; set; }
        public string bType { get; set; }
        public bool bOccuppied { get; set; }


        public Beds()
        {
            SqlCommand oSelCmd;
            InitializeConnection();

            sSQL = "SELECT BedNumber, BedType, Occupied, WardName " +
                " FROM	Beds where beds.Occupied = 0" +
                " ORDER BY BedNumber ";
            oSelCmd = null;
            oSelCmd = new SqlCommand(sSQL, m_oCn);
            oSelCmd.CommandType = CommandType.Text;

            m_oDA = new SqlDataAdapter();
            m_oDA.SelectCommand = oSelCmd;
            m_oCn = null;
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

        public string GetBed(string ward)
        {
            string bednumber = "none available";
            string tempbed;
            bool occupied = true;

            DataSet thisDataSet = new DataSet();
            m_oDA.Fill(thisDataSet, m_sClassName);

            for (int n = 0; n < thisDataSet.Tables["Beds"].Rows.Count; n++)
            {
                tempbed = thisDataSet.Tables["Beds"].Rows[n]["BedNumber"].ToString();
                if (tempbed.StartsWith(ward))
                {
                    occupied = Convert.ToBoolean(thisDataSet.Tables["Beds"].Rows[n]["Occupied"]);
                }
            }
            return bednumber;
        }

        public DataSet FindAvailableBeds(string bedType, string bward)
        {

            InitializeConnection();
            m_oCn.Open();
            DataSet datasetBed = new DataSet();
            DataSet datasetBedAv = new DataSet();
            try
            {
                m_oDA.Fill(datasetBed, m_sClassName);
                for (int n = 0; n < datasetBed.Tables["Beds"].Rows.Count; n++)
                {
                    if (datasetBed.Tables["Beds"].Rows[n]["BedType"].ToString() == bedType.ToString())
                    {
                        if (datasetBed.Tables["Beds"].Rows[n]["WardName"].ToString() == bward.ToString())
                        {
                            m_oDA.Fill(datasetBedAv, n, 1, m_sClassName);
                        }
                    }
                }
            }
            catch
            {
                if (datasetBedAv.Tables["Beds"].Rows.Count == 0)
                {
                    MessageBox.Show("There in Not Beds availabel");
                }
            }
            finally
            {
                m_oCn.Close();
                m_oCn = null;
            }
            return datasetBedAv;
        }

        public bool getAvailabelBed(string bedType, string bward)
        {
            bool valid = true;
            try
            {
                DataSet bedsAv = new DataSet();
                bedsAv = FindAvailableBeds(bedType, bward);
                bNumber = bedsAv.Tables["Beds"].Rows[0]["BedNumber"].ToString();
                bWard = bedsAv.Tables["Beds"].Rows[0]["WardName"].ToString();
                bOccuppied = Convert.ToBoolean(bedsAv.Tables["Beds"].Rows[0]["Occupied"]);
                bType = bedsAv.Tables["Beds"].Rows[0]["BedType"].ToString();
            }
            catch
            {
                valid = false;
            }
            return valid;
        }

        public void setbedBusy()
        {
            bOccuppied = true;
            InitializeConnection();
            try
            {
                m_oCn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BedsSetBusy";
                cmd.Connection = m_oCn;
                cmd.Parameters.Add(new SqlParameter("@BedNumber",bNumber.ToString()));
                cmd.ExecuteScalar();
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
        }

        public void bedsetFree()
        {
            bOccuppied = false;
            bOccuppied = true;
            InitializeConnection();
            try
            {
                m_oCn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BedsSetFree";
                cmd.Connection = m_oCn;
                cmd.Parameters.Add(new SqlParameter("@BedNumber", bNumber.ToString()));
                cmd.ExecuteScalar();
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
        }
    }
}
