using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NLHospitalLibrary;
using System.Data.SqlClient;
using NLHBaseWindow;
using NLHospital.Properties;
using System.Drawing.Printing;
using System.Data.OleDb;

namespace NLHospital
{
    public partial class frmReport : NLHBase
    {
        DataSet pList;
        frmMenu mymenu;
        public frmReport(DataSet PLIST,frmMenu MYMENU)
        {
            InitializeComponent();
            pList = PLIST;
            mymenu = MYMENU;
        }
        private void frmbeds_Load(object sender, EventArgs e)
        {
            dgInfo.ClearSelection();
            dgInfo.DataSource = pList.Tables[0];
            dgInfo.Refresh();
            dgInfo.ReadOnly = true;
            dgInfo.Sort(dgInfo.Columns[5], ListSortDirection.Ascending);


            Loadwards();
        }

        private void Loadwards()
        {
            cbbxFilter.Items.Add("ALL");
            cbbxFilter.Items.Add("OBSERVATION");
            cbbxFilter.Items.Add("CARDIOLOGY");
            cbbxFilter.Items.Add("PEDIATRICS");
            cbbxFilter.Items.Add("EMERGENCY");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ward = cbbxFilter.SelectedItem.ToString().Trim();
            string wardalias = "ALL";

            switch (ward)
          {
                case "OBSERVATION":
                    wardalias = "WardName = 'OBS'";
                    break;
                case "CARDIOLOGY":
                    wardalias = "WardName = 'CARD'";
                    break;
                case "PEDIATRICS":
                    wardalias = "WardName = 'PED'";
                    break;
                case "EMERGENCY":
                    wardalias = "WardName = 'EMER'";
                    break;
                case "All":
                    wardalias = "ALL";
                    break;
            }

            if (ward == "ALL")
            {
                dgInfo.ClearSelection();
                dgInfo.DataSource = pList.Tables[0];
                dgInfo.Refresh();
                dgInfo.ReadOnly = true;
                dgInfo.Sort(dgInfo.Columns[5], ListSortDirection.Ascending);
            }
            else
            {
                DataView dv = new DataView(pList.Tables[0]);
                dv.RowFilter = wardalias;
                dgInfo.DataSource = dv;
            }
        }

        private void btquit_Click(object sender, EventArgs e)
        {
            this.Close();
            mymenu.Show();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();

        }
        public void printodc(object sender, EventArgs e)
        {

            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgInfo.Width, this.dgInfo.Height);
            dgInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.dgInfo.Width, this.dgInfo.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
