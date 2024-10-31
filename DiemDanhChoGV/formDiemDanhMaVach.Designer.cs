namespace DiemDanhChoGV
{
    partial class formDiemDanhMaVach
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbCamera = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblChonCamera = new System.Windows.Forms.Label();
            this.txtMaSinhVien = new System.Windows.Forms.TextBox();
            this.lblMaSoSinhVien = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ptbCamera = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxThongBao = new System.Windows.Forms.RichTextBox();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.checkBoxTuDongVang = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiemDanh)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxTuDongVang);
            this.panel1.Controls.Add(this.btnDiemDanh);
            this.panel1.Controls.Add(this.richTextBoxThongBao);
            this.panel1.Controls.Add(this.cbbCamera);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lblChonCamera);
            this.panel1.Controls.Add(this.txtMaSinhVien);
            this.panel1.Controls.Add(this.lblMaSoSinhVien);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(757, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 553);
            this.panel1.TabIndex = 0;
            // 
            // cbbCamera
            // 
            this.cbbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCamera.FormattingEnabled = true;
            this.cbbCamera.Location = new System.Drawing.Point(9, 34);
            this.cbbCamera.Name = "cbbCamera";
            this.cbbCamera.Size = new System.Drawing.Size(253, 28);
            this.cbbCamera.TabIndex = 44;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Gray;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(9, 121);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStop.Size = new System.Drawing.Size(115, 50);
            this.btnStop.TabIndex = 43;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(9, 67);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStart.Size = new System.Drawing.Size(115, 50);
            this.btnStart.TabIndex = 42;
            this.btnStart.Text = "Start";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblChonCamera
            // 
            this.lblChonCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChonCamera.AutoSize = true;
            this.lblChonCamera.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChonCamera.Location = new System.Drawing.Point(9, 12);
            this.lblChonCamera.Name = "lblChonCamera";
            this.lblChonCamera.Size = new System.Drawing.Size(98, 19);
            this.lblChonCamera.TabIndex = 40;
            this.lblChonCamera.Text = "Chọn camera";
            // 
            // txtMaSinhVien
            // 
            this.txtMaSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMaSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaSinhVien.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSinhVien.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtMaSinhVien.Location = new System.Drawing.Point(9, 199);
            this.txtMaSinhVien.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtMaSinhVien.Name = "txtMaSinhVien";
            this.txtMaSinhVien.Size = new System.Drawing.Size(253, 32);
            this.txtMaSinhVien.TabIndex = 38;
            this.txtMaSinhVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSinhVien_KeyDown);
            // 
            // lblMaSoSinhVien
            // 
            this.lblMaSoSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaSoSinhVien.AutoSize = true;
            this.lblMaSoSinhVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSoSinhVien.Location = new System.Drawing.Point(9, 173);
            this.lblMaSoSinhVien.Name = "lblMaSoSinhVien";
            this.lblMaSoSinhVien.Size = new System.Drawing.Size(115, 19);
            this.lblMaSoSinhVien.TabIndex = 39;
            this.lblMaSoSinhVien.Text = "Mã số sinh viên";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(79, 492);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLuu.Size = new System.Drawing.Size(183, 50);
            this.btnLuu.TabIndex = 35;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuuDiemDanh_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvDiemDanh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 553);
            this.panel2.TabIndex = 1;
            // 
            // dtgvDiemDanh
            // 
            this.dtgvDiemDanh.AllowUserToAddRows = false;
            this.dtgvDiemDanh.AllowUserToDeleteRows = false;
            this.dtgvDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDiemDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDiemDanh.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgvDiemDanh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDiemDanh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDiemDanh.ColumnHeadersHeight = 30;
            this.dtgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvDiemDanh.EnableHeadersVisualStyles = false;
            this.dtgvDiemDanh.Location = new System.Drawing.Point(3, 13);
            this.dtgvDiemDanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvDiemDanh.Name = "dtgvDiemDanh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDiemDanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvDiemDanh.RowHeadersVisible = false;
            this.dtgvDiemDanh.RowHeadersWidth = 51;
            this.dtgvDiemDanh.RowTemplate.Height = 24;
            this.dtgvDiemDanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgvDiemDanh.Size = new System.Drawing.Size(280, 527);
            this.dtgvDiemDanh.TabIndex = 43;
            this.dtgvDiemDanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDiemDanh_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ptbCamera);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(299, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(458, 553);
            this.panel3.TabIndex = 2;
            // 
            // ptbCamera
            // 
            this.ptbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbCamera.Location = new System.Drawing.Point(31, 87);
            this.ptbCamera.Name = "ptbCamera";
            this.ptbCamera.Size = new System.Drawing.Size(400, 400);
            this.ptbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbCamera.TabIndex = 0;
            this.ptbCamera.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // richTextBoxThongBao
            // 
            this.richTextBoxThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxThongBao.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxThongBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxThongBao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxThongBao.Location = new System.Drawing.Point(13, 281);
            this.richTextBoxThongBao.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.richTextBoxThongBao.Name = "richTextBoxThongBao";
            this.richTextBoxThongBao.ReadOnly = true;
            this.richTextBoxThongBao.Size = new System.Drawing.Size(233, 97);
            this.richTextBoxThongBao.TabIndex = 45;
            this.richTextBoxThongBao.Text = ".....................................";
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiemDanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnDiemDanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDiemDanh.FlatAppearance.BorderSize = 0;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanh.ForeColor = System.Drawing.Color.White;
            this.btnDiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Location = new System.Drawing.Point(9, 240);
            this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDiemDanh.Size = new System.Drawing.Size(94, 34);
            this.btnDiemDanh.TabIndex = 46;
            this.btnDiemDanh.Text = "Điểm danh";
            this.btnDiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemDanh.UseVisualStyleBackColor = false;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
            // 
            // checkBoxTuDongVang
            // 
            this.checkBoxTuDongVang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTuDongVang.Checked = true;
            this.checkBoxTuDongVang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTuDongVang.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTuDongVang.Location = new System.Drawing.Point(13, 420);
            this.checkBoxTuDongVang.Name = "checkBoxTuDongVang";
            this.checkBoxTuDongVang.Size = new System.Drawing.Size(249, 67);
            this.checkBoxTuDongVang.TabIndex = 47;
            this.checkBoxTuDongVang.Text = "Tự động đánh vắng sinh viên không điểm danh";
            this.checkBoxTuDongVang.UseVisualStyleBackColor = true;
            // 
            // formDiemDanhMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 553);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "formDiemDanhMaVach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm danh mã vạch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formDiemDanhMaVach_FormClosing);
            this.Load += new System.EventHandler(this.formDiemDanhMaVach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiemDanh)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvDiemDanh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblChonCamera;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.Label lblMaSoSinhVien;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox ptbCamera;
        private System.Windows.Forms.ComboBox cbbCamera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDiemDanh;
        private System.Windows.Forms.RichTextBox richTextBoxThongBao;
        private System.Windows.Forms.CheckBox checkBoxTuDongVang;
    }
}