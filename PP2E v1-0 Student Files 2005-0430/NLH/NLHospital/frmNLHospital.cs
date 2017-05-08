using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NLHBaseWindow;
using NLHospitalLibrary;


namespace NLHospital
{

    /// <summary>
    /// Summary description for frmNLHospital.
    /// </summary>
    /// 
    public class frmNLHospital : NLHBase
    {

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPassword;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        static int cnt = 0;
        Admissions admission = new Admissions();
        Users oUsers = new Users();


        public frmNLHospital()
        {
            //
            // Required for Windows Form Designer support
            //
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNLHospital));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnLogin.Location = new System.Drawing.Point(107, 216);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 38);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExit.Location = new System.Drawing.Point(198, 216);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtUserID.Location = new System.Drawing.Point(107, 120);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(161, 26);
            this.txtUserID.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtPassword.Location = new System.Drawing.Point(107, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(161, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Northern Lights Hospital";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblUserID.Location = new System.Drawing.Point(34, 123);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(67, 23);
            this.lblUserID.TabIndex = 5;
            this.lblUserID.Text = "User ID Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblPassword.Location = new System.Drawing.Point(10, 163);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(91, 23);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // frmNLHospital
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(294, 266);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNLHospital";
            this.Text = "NLHospital";
            this.Load += new System.EventHandler(this.frmNLHospital_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new frmNLHospital());
        }
        private void frmNLHospital_Load(object sender, System.EventArgs e)
        {
            txtUserID.Focus();
        }
        private void label1_Click(object sender, System.EventArgs e)
        {}
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Exit Northern Lights Hospital application?", "",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string strUser;
            string UserGroup = "";
            string strPass;
            string sMsg = "";

            strUser = txtUserID.Text;
            strPass = txtPassword.Text;

            DataSet o_Find = new DataSet();
            
            try
            {
                o_Find = oUsers.FindData(strUser, strPass);

                sMsg = "Welcome " + o_Find.Tables["Login"].Rows[0][2].ToString();
                //switch (strUser)

                UserGroup = (o_Find.Tables["Login"].Rows[0][2]).ToString();
                CurrentUser currentUser = new CurrentUser(strUser, UserGroup);

                frmMenu menuForm = new frmMenu(currentUser);
                //menuForm.oCurrent.UserName = strUser;
                menuForm.Visible = true;
                menuForm.Activate();
                menuForm.SelectUser();
                this.Hide();
            }
            catch
            {
                if (cnt == 0)
                {
                    sMsg = "User not in database. Please try again.";
                    MessageBox.Show(sMsg, "NHL Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                if (cnt == 1)
                {
                    sMsg = "User not in database. One try left.";
                    MessageBox.Show(sMsg, "NHL Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                    
                if (cnt == 2)
                {
                    sMsg = "Application is closing. Please contact your supervisor.";
                    MessageBox.Show(sMsg, "NHL Hospital", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }
            finally
            {
                cnt++;
                txtUserID.Text = "";
                txtPassword.Text = "";
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
