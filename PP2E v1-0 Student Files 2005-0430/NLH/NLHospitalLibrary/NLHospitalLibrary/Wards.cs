using System;
using System.Data ;
using System.Data .SqlClient ;

namespace NLHospitalLibrary
{
	/// <summary>
	/// Summary description for Wards.
	/// </summary>
	public class Wards
	{
		private DataSet m_oDS ; 
		private SqlConnection m_oCn ;    
		private SqlDataAdapter m_oDA;
		private string m_sClassName = "Wards";
		private string sSQL;

		public Wards()
		{
			//
			// TODO: Add constructor logic here
			//
			SqlCommand oSelCmd;

			InitializeConnection();

			sSQL = "SELECT WardName " +
				" FROM	Ward " ;
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
			m_oCn = new SqlConnection(
				@"Data Source=(local);Integrated Security=SSPI;" 
				+ "Initial Catalog=NLHospital");
		}

	}
}
