using System;
using System.Data;
using System.Data.SqlClient;
using NLHospitalLibrary.Properties;


namespace NLHospitalLibrary
{
    /// <summary>
    /// Summary description for Users.
    /// </summary>
    public class Users
    {
        public SqlConnection m_oCn;

        public SqlDataAdapter m_oDA;
        // private string m_sClassName = "Users";
        public string sSQL;

        public Users()
        {
            // TODO: Add constructor logic here
            //SqlCommand oSelCmd = m_oCn.CreateCommand();
            //sSQL = "SELECT UserName, Password FROM Login ";
            //oSelCmd = null;
            //oSelCmd = new SqlCommand(sSQL, m_oCn);
            //oSelCmd.CommandType = CommandType.Text;
            //m_oDA = new SqlDataAdapter();
            //m_oDA.SelectCommand = oSelCmd;
            //m_oCn = null;
        }

        public DataSet FindData(string ID, string pass)
        {
            InitializeConnection(); //1 - Criar Conexao

            m_oCn.Open(); // 2 - Abrir Conexao

            SqlCommand oSelCmd = m_oCn.CreateCommand(); // 3 - Criar Comando
                                                        //sSQL = "SELECT UserId, Password, UserGroup FROM Login";
            sSQL = "SELECT * FROM Login";
            // oSelCmd = null;

            oSelCmd.CommandType = CommandType.Text;
            oSelCmd = new SqlCommand(sSQL, m_oCn); // 4 - preencehr comando
            oSelCmd.CommandTimeout = 7200;

            m_oDA = new SqlDataAdapter(oSelCmd); //5 – Criar Adaptador
            m_oDA.SelectCommand = oSelCmd;
            //m_oCn = null;

            DataSet thisDataSet = new DataSet(); // 6 criar data table
            DataSet foundDataSet = new DataSet();


            try
            {
                m_oDA.Fill(thisDataSet, "Login");

                for (int n = 0; n < thisDataSet.Tables["Login"].Rows.Count; n++)
                {
                    if (thisDataSet.Tables["Login"].Rows[n][0].ToString() == ID)
                    {
                        if (thisDataSet.Tables["Login"].Rows[n][1].ToString() == pass)
                        {
                            m_oDA.Fill(foundDataSet, n, 1, "Login");
                            //break;
                        }
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

        private void InitializeConnection()
        {
            m_oCn = new SqlConnection(Settings.Default.ConnectionString);
        }
    }
}
