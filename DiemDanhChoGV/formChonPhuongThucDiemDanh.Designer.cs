namespace DiemDanhChoGV
{
    partial class formChonPhuongThucDiemDanh
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
            this.btnDiemDanhThuCong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDiemDanhThuCong
            // 
            this.btnDiemDanhThuCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiemDanhThuCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnDiemDanhThuCong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDiemDanhThuCong.FlatAppearance.BorderSize = 0;
            this.btnDiemDanhThuCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanhThuCong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanhThuCong.ForeColor = System.Drawing.Color.White;
            this.btnDiemDanhThuCong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanhThuCong.Location = new System.Drawing.Point(44, 56);
            this.btnDiemDanhThuCong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiemDanhThuCong.Name = "btnDiemDanhThuCong";
            this.btnDiemDanhThuCong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDiemDanhThuCong.Size = new System.Drawing.Size(160, 50);
            this.btnDiemDanhThuCong.TabIndex = 33;
            this.btnDiemDanhThuCong.Text = "Thủ công";
            this.btnDiemDanhThuCong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemDanhThuCong.UseVisualStyleBackColor = false;
            this.btnDiemDanhThuCong.Click += new System.EventHandler(this.btnDiemDanhThuCong_Click);
            // 
            // formChonPhuongThucDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 169);
            this.Controls.Add(this.btnDiemDanhThuCong);
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.MaximumSize = new System.Drawing.Size(626, 216);
            this.Name = "formChonPhuongThucDiemDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phương thức điểm danh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiemDanhThuCong;
    }
}