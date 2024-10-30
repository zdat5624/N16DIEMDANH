namespace XuLyGPS
{
    partial class formWebGps
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDuongLinkWebgps = new System.Windows.Forms.Label();
            this.grbLink = new System.Windows.Forms.GroupBox();
            this.dtgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiemDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDuongLinkWebgps
            // 
            this.lblDuongLinkWebgps.AutoSize = true;
            this.lblDuongLinkWebgps.Location = new System.Drawing.Point(16, 40);
            this.lblDuongLinkWebgps.Name = "lblDuongLinkWebgps";
            this.lblDuongLinkWebgps.Size = new System.Drawing.Size(124, 16);
            this.lblDuongLinkWebgps.TabIndex = 0;
            this.lblDuongLinkWebgps.Text = "link web điểm danh:";
            // 
            // grbLink
            // 
            this.grbLink.Controls.Add(this.textBox1);
            this.grbLink.Controls.Add(this.lblDuongLinkWebgps);
            this.grbLink.Location = new System.Drawing.Point(43, 12);
            this.grbLink.Name = "grbLink";
            this.grbLink.Size = new System.Drawing.Size(556, 93);
            this.grbLink.TabIndex = 1;
            this.grbLink.TabStop = false;
            this.grbLink.Text = "link Web ";
            // 
            // dtgvDiemDanh
            // 
            this.dtgvDiemDanh.AllowUserToAddRows = false;
            this.dtgvDiemDanh.AllowUserToDeleteRows = false;
            this.dtgvDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtgvDiemDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDiemDanh.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgvDiemDanh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDiemDanh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvDiemDanh.ColumnHeadersHeight = 30;
            this.dtgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvDiemDanh.EnableHeadersVisualStyles = false;
            this.dtgvDiemDanh.Location = new System.Drawing.Point(43, 112);
            this.dtgvDiemDanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvDiemDanh.Name = "dtgvDiemDanh";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvDiemDanh.RowHeadersWidth = 51;
            this.dtgvDiemDanh.RowTemplate.Height = 24;
            this.dtgvDiemDanh.Size = new System.Drawing.Size(556, 705);
            this.dtgvDiemDanh.TabIndex = 43;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 22);
            this.textBox1.TabIndex = 44;
            this.textBox1.Text = "https://dat9999999.github.io/DiemDanhGPS/";
            // 
            // formWebGps
            // 
            this.ClientSize = new System.Drawing.Size(661, 759);
            this.Controls.Add(this.dtgvDiemDanh);
            this.Controls.Add(this.grbLink);
            this.Name = "formWebGps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm danh ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formWebGps_FormClosed);
            this.Load += new System.EventHandler(this.formWebGps_Load);
            this.grbLink.ResumeLayout(false);
            this.grbLink.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiemDanh)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label lblDuongLinkWebgps;
        private System.Windows.Forms.GroupBox grbLink;
        private System.Windows.Forms.DataGridView dtgvDiemDanh;
        private System.Windows.Forms.TextBox textBox1;
    }
}
