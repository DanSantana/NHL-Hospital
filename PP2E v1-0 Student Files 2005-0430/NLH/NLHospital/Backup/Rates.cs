using System;
using System.Data ;
using System.Data .SqlClient ;

namespace NLHospitalLibrary
{
	/// <summary>
	/// Summary description for Rates.
	/// </summary>
	public class Rates
	{
		private DataSet m_oDS ; 
		private SqlConnection m_oCn ;    
		private SqlDataAdapter m_oDA;
		private string m_sClassName = "Extras_Rates";
		private string sSQL;

		public decimal TVRate;
		public decimal PhoneRate;
		public decimal SemiRate;
		public decimal PrivateRate;

		public Rates()
		{
			//
			// TODO: Add constructor logic here
			//
			SqlCommand oSelCmd;

			InitializeConnection();

			sSQL = "SELECT Extras_Name, DailyCost FROM Extras_Rates " ;
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


		public void GetRates ()
		{
			DataSet thisDataSet = new DataSet();

			thisDataSet = this.GetData();

			for (int n = 0; n < thisDataSet.Tables["Extras_Rates"].Rows.Count ; n++)
			{
				
				if (thisDataSet.Tables ["Extras_Rates"].Rows[n]["Extras_Name"].ToString () == "TV")
				{
					TVRate = Convert.ToDecimal (thisDataSet.Tables ["Extras_Rates"].Rows[n]["DailyCost"]);
				}

				if (thisDataSet.Tables ["Extras_Rates"].Rows[n]["Extras_Name"].ToString () == "Phone")
				{
					PhoneRate = Convert.ToDecimal (thisDataSet.Tables ["Extras_Rates"].Rows[n]["DailyCost"]);
				}

				if (thisDataSet.Tables ["Extras_Rates"].Rows[n]["ExtrasName"].ToString () == "Semi")
				{
					SemiRate = Convert.ToDecimal (thisDataSet.Tables ["Extras_Rates"].Rows[n]["DailyCost"]);
				}

				if (thisDataSet.Tables ["Extras_Rates"].Rows[n]["Extras_Name"].ToString () == "Private")
				{
					PrivateRate = thisDataSet.Tables ["Extras_Rates"].Rows[n]["DailyCost"];
				}
			}

		}
	}
}
