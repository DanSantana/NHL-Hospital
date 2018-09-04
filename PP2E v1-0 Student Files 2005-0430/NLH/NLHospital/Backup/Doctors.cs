using System;
using System.Data ;
using System.Data.SqlClient ;


namespace NLHospitalLibrary
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Doctors
	{
		private DataSet m_oDS ; 
		private SqlConnection m_oCn ;    
		private SqlDataAdapter m_oDA;
		private string m_sClassName = "Doctors";
		private string sSQL;

		public Doctors()
		{
			//
			// TODO: Add constructor logic here
			SqlCommand oSelCmd;
			SqlCommand oInsCmd;
			SqlCommand oUpdCmd;
			SqlCommand oDelCmd;

			InitializeConnection();

			sSQL = "SELECT DoctorID, LastName, FirstName, Specialty " +
				" FROM	Doctors " +
				" ORDER BY DoctorID ";
			oSelCmd = null;
			oSelCmd = new SqlCommand(sSQL, m_oCn);
			oSelCmd.CommandType = CommandType.Text;

			sSQL = "UPDATE Doctors " +
				" SET LastName = @LastName, FirstName = @FirstName, Specialty = @Specialty " +
				" WHERE DoctorID = @DoctorID ";
			oUpdCmd = null;
			oUpdCmd = new SqlCommand(sSQL, m_oCn);
			oUpdCmd.CommandType = CommandType.Text;
			oUpdCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30, "LastName"));
			oUpdCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30, "FirstName"));
			oUpdCmd.Parameters.Add(new SqlParameter("@Specialty", SqlDbType.NVarChar, 20, "Specialty"));
			oUpdCmd.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.NChar, 4, "DoctorID"));

			sSQL = "INSERT INTO Doctors " +
				" (LastName, FirstName, Specialty, DoctorID)" +
				" VALUES (@LastName, @FirstName, @Specialty, @DoctorID)";
			oInsCmd = null;
			oInsCmd = new SqlCommand(sSQL, m_oCn);
			oInsCmd.CommandType = CommandType.Text;
			oInsCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30, "LastName"));
			oInsCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30, "FirstName"));
			oInsCmd.Parameters.Add(new SqlParameter("@Specialty", SqlDbType.NVarChar, 20, "Specialty"));
			oInsCmd.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.NChar, 4, "DoctorID"));

			sSQL = "DELETE Doctors " +
				" WHERE DoctorID = @DoctorID ";
			oDelCmd = null;
			oDelCmd = new SqlCommand(sSQL, m_oCn);
			oDelCmd.CommandType = CommandType.Text;
			oDelCmd.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.NChar, 4, "DoctorID"));

			m_oDA = new SqlDataAdapter();
			m_oDA.SelectCommand = oSelCmd;
			m_oDA.UpdateCommand = oUpdCmd;
			m_oDA.DeleteCommand = oDelCmd;
			m_oDA.InsertCommand = oInsCmd;

			m_oCn = null;

		}

		public string AddData(string ID, string LN, string FN, string spec)
		{
			string sMsg = "";

			try
			{
				InitializeConnection();
				m_oCn.Open();
				DataSet thisDataSet = new DataSet();
				m_oDA.Fill (thisDataSet, "Doctors");

				DataColumn[] keys = new DataColumn [1];
				keys[0] = thisDataSet.Tables ["Doctors"].Columns["DoctorID"];
				thisDataSet.Tables ["Doctors"].PrimaryKey = keys;
				DataRow findRow = thisDataSet.Tables ["Doctors"].Rows.Find (ID);

				if (findRow == null)
				{
					DataRow thisRow = thisDataSet.Tables["Doctors"].NewRow();
					thisRow["DoctorID"] = ID;
					thisRow["LastName"] = LN;
					thisRow["FirstName"] = FN;
					thisRow["Specialty"] = spec;
					thisDataSet.Tables["Doctors"].Rows.Add(thisRow);
					if ((findRow = thisDataSet.Tables ["Doctors"].Rows.Find (ID)) != null)
					{
						sMsg = " Doctor Record Was Added";
					}					
				}
				else
				{
					sMsg = " Doctor " + ID + " already present in database.";
				}

				m_oDA.Update (thisDataSet, "Doctors");

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
				m_oDA.Fill (thisDataSet, "Doctors");
				for (int n = 0; n < thisDataSet.Tables["Doctors"].Rows.Count ; n++)
				{
					if (thisDataSet.Tables["Doctors"].Rows[n]["DoctorID"].ToString () == ID)
					{
						m_oDA.Fill(foundDataSet,n,1,"Doctors");							
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

		public string UpdateData(string ID, string LN, string FN, string spec)
		{
			string sMsg = "";

			try
			{
				InitializeConnection();
				m_oCn.Open();
				DataSet thisDataSet = new DataSet();
				m_oDA.Fill (thisDataSet, "Doctors");

				thisDataSet.Tables["Doctors"].Rows[0]["DoctorID"] = ID;
				thisDataSet.Tables["Doctors"].Rows[0]["LastName"] = LN;
				thisDataSet.Tables["Doctors"].Rows[0]["FirstName"] = FN;
				thisDataSet.Tables["Doctors"].Rows[0]["Specialty"] = spec;
				m_oDA.Update (thisDataSet, "Doctors");

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

		public string DeleteData(string ID)
		{
			string sMsg = "";

			try
			{
				InitializeConnection();
				m_oCn.Open();
				DataSet thisDataSet = new DataSet();
				m_oDA.Fill (thisDataSet, "Doctors");

				DataColumn[] keys = new DataColumn [1];
				keys[0] = thisDataSet.Tables ["Doctors"].Columns["DoctorID"];
				thisDataSet.Tables ["Doctors"].PrimaryKey = keys;
				DataRow findRow = thisDataSet.Tables ["Doctors"].Rows.Find (ID);

				if (findRow == null)
				{
					sMsg = " Doctor " + ID + " not present in database.";
				}
				else
				{
					findRow.Delete();
					m_oDA.Update (thisDataSet, "Doctors");
					sMsg = " Doctor " + ID + " deleted from database.";
				}

			}
			catch (Exception e)
			{
				sMsg = "Record was not deleted" + e.Message.ToString();
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
				sMsg = lRecsAffected + " Doctor Records Were Updated";
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
	}
}
