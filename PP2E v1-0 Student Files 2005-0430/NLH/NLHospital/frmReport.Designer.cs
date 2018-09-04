namespace NLHospital
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.dgInfo = new System.Windows.Forms.DataGridView();
            this.cbbxFilter = new System.Windows.Forms.ComboBox();
            this.btquit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgInfo
            // 
            this.dgInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfo.Location = new System.Drawing.Point(36, 87);
            this.dgInfo.Name = "dgInfo";
            this.dgInfo.Size = new System.Drawing.Size(656, 357);
            this.dgInfo.TabIndex = 0;
            // 
            // cbbxFilter
            // 
            this.cbbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cbbxFilter.FormattingEnabled = true;
            this.cbbxFilter.Location = new System.Drawing.Point(209, 47);
            this.cbbxFilter.Name = "cbbxFilter";
            this.cbbxFilter.Size = new System.Drawing.Size(158, 28);
            this.cbbxFilter.TabIndex = 1;
            this.cbbxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btquit
            // 
            this.btquit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btquit.Location = new System.Drawing.Point(618, 465);
            this.btquit.Name = "btquit";
            this.btquit.Size = new System.Drawing.Size(90, 36);
            this.btquit.TabIndex = 2;
            this.btquit.Text = "Quit";
            this.btquit.UseVisualStyleBackColor = true;
            this.btquit.Click += new System.EventHandler(this.btquit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By Ward Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient Report List";
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btPrint.Location = new System.Drawing.Point(524, 465);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 36);
            this.btPrint.TabIndex = 4;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 523);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btquit);
            this.Controls.Add(this.cbbxFilter);
            this.Controls.Add(this.dgInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.Text = "Report and List  |   Northern Lights Hospital";
            this.Load += new System.EventHandler(this.frmbeds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInfo;
        private System.Windows.Forms.ComboBox cbbxFilter;
        private System.Windows.Forms.Button btquit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}