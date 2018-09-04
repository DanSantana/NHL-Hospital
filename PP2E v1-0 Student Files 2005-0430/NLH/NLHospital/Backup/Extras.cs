using System;
using System.Data ;
using System.Data.SqlClient ;

namespace NLHospitalLibrary
{
	/// <summary>
	/// Summary description for Extras.
	/// </summary>
	public class Extras
	{
		private DataSet m_oDS ; 
		private SqlConnection m_oCn ;    
		private SqlDataAdapter m_oDA;
		private string m_sClassName = "Extras";
		private string sSQL;

		public Extras()
		{
			//
			// TODO: Add constructor logic here
			//
			SqlCommand oSelCmd;
			SqlCommand oInsCmd;
			SqlCommand oUpdCmd;

			InitializeConnection();

			sSQL = "SELECT PatientID, AdmissionRecordID, TV, Phone, " +
				" SemiPrivate, Private FROM Extras " ;
			oSelCmd = null;
			oSelCmd = new SqlCommand(sSQL, m_oCn);
			oSelCmd.CommandType = CommandType.Text;

			sSQL = "UPDATE Extras " +
				" SET AdmissionRecordID = @AdmissionRecordID, PatientID = @PatientID, " +
				" TV = @TV, Phone = @Phone, SemiPrivate = @SemiPrivate, Private = @Private " +
				" WHERE AdmissionRecordID = @AdmissionRecordID ";
			oUpdCmd = null;
			oUpdCmd = new SqlCommand(sSQL, m_oCn);
			oUpdCmd.CommandType = CommandType.Text;
			oUpdCmd.Parameters.Add(new SqlParameter("@AdmissionRecordID", SqlDbType.NChar, 4, "AdmissionRecordID"));
			oUpdCmd.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.NVarChar, 15, "PatientID"));
			oUpdCmd.Parameters.Add(new SqlParameter("@TV", SqlDbType.Bit, 1, "TV"));
			oUpdCmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.Bit, 1, "Phone"));
			oUpdCmd.Parameters.Add(new SqlParameter("@SemiPrivate", SqlDbType.Bit,1, "SemiPrivate"));
			oUpdCmd.Parameters.Add(new SqlParameter("@Private", SqlDbType.Bit, 1, "Private"));
			
			sSQL = "INSERT INTO Extras " +
				" (AdmissionRecordID, PatientID, TV, " +
				" Phone, SemiPrivate, Private )" +
				" VALUES (@AdmissionRecordID, @PatientID, @TV, " +
				" @Phone, @SemiPrivate, @Private)";
			oInsCmd = null;
			oInsCmd = new SqlCommand(sSQL, m_oCn);
			oInsCmd.CommandType = CommandType.Text;
			oInsCmd.Parameters.Add(new SqlParameter("@AdmissionRecordID", SqlDbType.NChar, 4, "AdmissionRecordID"));
			oInsCmd.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.NVarChar, 15, "PatientID"));
			oInsCmd.Parameters.Add(new SqlParameter("@TV", SqlDbType.Bit, 1, "TV"));
			oInsCmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.Bit, 1, "Phone"));
			oInsCmd.Parameters.Add(new SqlParameter("@SemiPrivate", SqlDbType.Bit,1, "SemiPrivate"));
			oInsCmd.Parameters.Add(new SqlParameter("@Private", SqlDbType.Bit, 1, "Private"));


			m_oDA = new SqlDataAdapter();
			m_oDA.SelectCommand = oSelCmd;
			m_oDA.UpdateCommand = oUpdCmd;
			m_oDA.InsertCommand = oInsCmd;

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
			m_oCn = new SqlConnection(
				@"Data Source=(local);Integrated Security=SSPI;" 
				+ "Initial Catalog=NLHospital");
		}

		public string AddData(string aID, string pID, bool tv, 
			bool phone, bool semi, bool priv)
		{
			string sMsg = "";

			try
			{
				InitializeConnection();
				m_oCn.Open();
				DataSet thisDataSet = new DataSet();
				m_oDA.Fill (thisDataSet, m_sClassName);

				DataColumn[] keys = new DataColumn [1];
				keys[0] = thisDataSet.Tables ["Extras"].Columns["AdmissionID"];
				thisDataSet.Tables ["Extras"].PrimaryKey = keys;
				DataRow findRow = thisDataSet.Tables ["Extras"].Rows.Find (aID);

				if (findRow == null)
				{
					DataRow thisRow = thisDataSet.Tables["Extras"].NewRow();
					thisRow["AdmissionRecordID"] = aID;
					thisRow["PatientID"] = pID;
					thisRow["TV"] = tv;
					thisRow["Phone"] = phone;
					thisRow["SemiPrivate"] = semi;
					thisRow["Private"] = priv;
					thisDataSet.Tables["Extras"].Rows.Add(thisRow);
					if ((findRow = thisDataSet.Tables ["Extras"].Rows.Find (aID)) != null)
					{
						sMsg = " Extras Record Was Added";
					}					
				}
				else
				{
					sMsg = " Extras " + aID + " already present in database.";
				}

				m_oDA.Update (thisDataSet, m_sClassName);

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
				m_oDA.Fill (thisDataSet, m_sClassName);
				for (int n = 0; n < thisDataSet.Tables["Extras"].Rows.Count ; n++)
				{
					if (thisDataSet.Tables["Extras"].Rows[n]["AdmissionRecordID"].ToString () == ID)
					{
						m_oDA.Fill(foundDataSet,n,1,"Extras");							
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
			return foundDataSet;
		}
	}
}
