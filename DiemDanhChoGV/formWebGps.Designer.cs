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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDuongLinkWebgps = new System.Windows.Forms.Label();
            this.grbLink = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
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
            this.grbLink.Location = new System.Drawing.Point(31, 12);
            this.grbLink.Name = "grbLink";
            this.grbLink.Size = new System.Drawing.Size(556, 93);
            this.grbLink.TabIndex = 1;
            this.grbLink.TabStop = false;
            this.grbLink.Text = "link Web ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 22);
            this.textBox1.TabIndex = 44;
            this.textBox1.Text = "https://dat9999999.github.io/DiemDanhGPS/";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDiemDanh.ColumnHeadersHeight = 30;
            this.dtgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvDiemDanh.EnableHeadersVisualStyles = false;
            this.dtgvDiemDanh.Location = new System.Drawing.Point(31, 112);
            this.dtgvDiemDanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvDiemDanh.Name = "dtgvDiemDanh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvDiemDanh.RowHeadersWidth = 51;
            this.dtgvDiemDanh.RowTemplate.Height = 24;
            this.dtgvDiemDanh.Size = new System.Drawing.Size(556, 557);
            this.dtgvDiemDanh.TabIndex = 43;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(457, 698);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLuu.Size = new System.Drawing.Size(130, 50);
            this.btnLuu.TabIndex = 44;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // formWebGps
            // 
            this.ClientSize = new System.Drawing.Size(636, 759);
            this.Controls.Add(this.btnLuu);
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
        private System.Windows.Forms.Button btnLuu;
    }
}
