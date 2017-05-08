using System;
using System.Collections.Generic;
using System.Text;
using NLHospitalLibrary.Properties;
using System.Data;
using System.Data.SqlClient;


namespace NLHospitalLibrary
{
    public class Bill
    {
        public int bBill_Id { get; set; }
        public int bAdmissionID { get; set; }//key
        public int bStayLength { get; set; }
        public decimal TV_DalyRate { get; set; }
        public decimal Phone_DR { get; set; }
        public decimal SemiPrivateRoom_DR { get; set; }
        public decimal PrivateRoom_DR { get; set; }
        public decimal StandardRoom { get; set; }
        public decimal dailyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string accommodationType { get; set; }
        public void RecordBill(Admissions adms)
        {
            //tv
            TotalAmount = 0;
            TV_DalyRate = 0;
            Phone_DR = 0;
            PrivateRoom_DR = 571;
            SemiPrivateRoom_DR = 267;
            StandardRoom = 125;

            if (adms.admtv == true)
            {
                TV_DalyRate = 42.50m;
                dailyRate += TV_DalyRate;
            }
            if (adms.admPhone == true)
            {
                Phone_DR = 7.50m;
                dailyRate += Phone_DR;
            }
            if (accommodationType == "PRIVATE")
            {
                dailyRate += PrivateRoom_DR;
                SemiPrivateRoom_DR = 0;
            }
            if (accommodationType == "SE PRIVATE")
            {
                dailyRate += SemiPrivateRoom_DR;
                PrivateRoom_DR = 0;
            }
            if (accommodationType != "PRIVATE" && accommodationType != "SE PRIVATE")
            {
                dailyRate += StandardRoom;
                PrivateRoom_DR = 0;
                SemiPrivateRoom_DR = 0;
            }

            TotalAmount = bStayLength * dailyRate;

            try
            {
                SqlConnection o_mcOn = new SqlConnection(Settings.Default.ConnectionString);
                o_mcOn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_openBill";
                cmd.Connection = o_mcOn;

                cmd.Parameters.Add(new SqlParameter("@AdmissionID", Convert.ToInt32(bAdmissionID)));
                cmd.Parameters.Add(new SqlParameter("@StayLength", Convert.ToInt32(bStayLength)));
                cmd.Parameters.Add(new SqlParameter("@TV_DalyRate", Convert.ToDecimal(TV_DalyRate)));
                cmd.Parameters.Add(new SqlParameter("@Phone_DR", Convert.ToDecimal(Phone_DR)));// phone daily rate
                cmd.Parameters.Add(new SqlParameter("@SemiPrivateRoom_DR", Convert.ToDecimal(SemiPrivateRoom_DR)));
                cmd.Parameters.Add(new SqlParameter("@PrivateRoom_DR", Convert.ToDecimal(PrivateRoom_DR)));
                cmd.Parameters.Add(new SqlParameter("@TotalAmount", Convert.ToDecimal(TotalAmount)));
                cmd.Parameters.Add(new SqlParameter("@StandardRoom", Convert.ToDecimal(StandardRoom)));


                cmd.ExecuteScalar();
                o_mcOn.Close();
                o_mcOn = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataSet FindBill(string admissionId)
        {

            SqlConnection myCon = new SqlConnection(Settings.Default.ConnectionString);
            myCon.Open();

            DataSet thisdataset = new DataSet();
            DataSet foundDataset = new DataSet();

            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myCon;
            myCmd.CommandType = CommandType.Text;
            myCmd.CommandText = "SELECT Bill_Id,AdmissionID,StayLength,TV_DalyRate,Phone_DR,SemiPrivateRoom_DR,PrivateRoom_DR,StandardRoom,TotalAmount FROM Bills";

            SqlDataAdapter myAdapt = new SqlDataAdapter(myCmd);

            myAdapt.Fill(thisdataset, "Bills");

            for (int i = 0; i < thisdataset.Tables["Bills"].Rows.Count; i++)
            {
                if (thisdataset.Tables["Bills"].Rows[i]["AdmissionID"].ToString() == admissionId)
                {
                    myAdapt.Fill(foundDataset, i, 1, "Bills");
                }
            }
            myCon.Close();
            return foundDataset;

        }
        public bool getBillInfo(string admiD)
        {
            bool billvalid = true;
            try
            {
                DataSet bdset = new DataSet();
                bdset = FindBill(admiD);
                bBill_Id = Convert.ToInt32(bdset.Tables["Bills"].Rows[0]["Bill_Id"]);
                bAdmissionID = Convert.ToInt32(bdset.Tables["Bills"].Rows[0]["AdmissionID"]);
                bStayLength = Convert.ToInt32(bdset.Tables["Bills"].Rows[0]["StayLength"]);
                TV_DalyRate = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["TV_DalyRate"]);
                Phone_DR = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["Phone_DR"]);
                SemiPrivateRoom_DR = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["SemiPrivateRoom_DR"]);
                PrivateRoom_DR = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["PrivateRoom_DR"]);
                StandardRoom = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["StandardRoom"]);
                StandardRoom = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["StandardRoom"]);
                dailyRate = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["TotalAmount"]) / bStayLength;
                TotalAmount = Convert.ToDecimal(bdset.Tables["Bills"].Rows[0]["TotalAmount"]);
                //accommodationType = 
            }
            catch
            {
                billvalid = false;
            }
            return billvalid;
        }
    }
}
