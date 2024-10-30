namespace DiemDanhChoGV
{
    partial class formChonBuoiDiemDanh
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
            this.flpChonBuoiDiemDanh = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpChonBuoiDiemDanh
            // 
            this.flpChonBuoiDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpChonBuoiDiemDanh.Location = new System.Drawing.Point(12, 12);
            this.flpChonBuoiDiemDanh.Name = "flpChonBuoiDiemDanh";
            this.flpChonBuoiDiemDanh.Size = new System.Drawing.Size(405, 568);
            this.flpChonBuoiDiemDanh.TabIndex = 0;
            this.flpChonBuoiDiemDanh.Paint += new System.Windows.Forms.PaintEventHandler(this.flpChonBuoiDiemDanh_Paint);
            // 
            // formChonBuoiDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 592);
            this.Controls.Add(this.flpChonBuoiDiemDanh);
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Name = "formChonBuoiDiemDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn buổi điểm danh";
            this.Load += new System.EventHandler(this.formChonBuoiDiemDanh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpChonBuoiDiemDanh;
    }
}