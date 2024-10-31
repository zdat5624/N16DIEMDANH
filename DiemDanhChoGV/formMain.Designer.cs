namespace DiemDanhChoGV
{
    partial class formMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLopHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.themToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThemLopHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsThemMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.xuatFileExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsXuatFileExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.lvDanhSachLop = new System.Windows.Forms.ListView();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dtgvLopHoc = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnThemSinhVien = new System.Windows.Forms.Button();
            this.btnXoaLop = new System.Windows.Forms.Button();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLopHoc)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.themToolStripMenuItem,
            this.xuatFileExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLopHoc,
            this.tsMonHoc});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 26);
            this.toolStripMenuItem1.Text = "Quản lý";
            // 
            // tsLopHoc
            // 
            this.tsLopHoc.Name = "tsLopHoc";
            this.tsLopHoc.Size = new System.Drawing.Size(150, 26);
            this.tsLopHoc.Text = "Lớp học";
            this.tsLopHoc.Click += new System.EventHandler(this.tsLopHoc_Click);
            // 
            // tsMonHoc
            // 
            this.tsMonHoc.Name = "tsMonHoc";
            this.tsMonHoc.Size = new System.Drawing.Size(150, 26);
            this.tsMonHoc.Text = "Môn học";
            this.tsMonHoc.Click += new System.EventHandler(this.tsMonHoc_Click);
            // 
            // themToolStripMenuItem
            // 
            this.themToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsThemLopHoc,
            this.tsThemMonHoc});
            this.themToolStripMenuItem.Name = "themToolStripMenuItem";
            this.themToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.themToolStripMenuItem.Text = "Thêm";
            // 
            // tsThemLopHoc
            // 
            this.tsThemLopHoc.Name = "tsThemLopHoc";
            this.tsThemLopHoc.Size = new System.Drawing.Size(191, 26);
            this.tsThemLopHoc.Text = "Thêm lớp học";
            this.tsThemLopHoc.Click += new System.EventHandler(this.tsThemLopHoc_Click);
            // 
            // tsThemMonHoc
            // 
            this.tsThemMonHoc.Name = "tsThemMonHoc";
            this.tsThemMonHoc.Size = new System.Drawing.Size(191, 26);
            this.tsThemMonHoc.Text = "Thêm môn học";
            this.tsThemMonHoc.Click += new System.EventHandler(this.tsThemMonHoc_Click);
            // 
            // xuatFileExcelToolStripMenuItem
            // 
            this.xuatFileExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsXuatFileExcel});
            this.xuatFileExcelToolStripMenuItem.Name = "xuatFileExcelToolStripMenuItem";
            this.xuatFileExcelToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.xuatFileExcelToolStripMenuItem.Text = "Xuất";
            // 
            // tsXuatFileExcel
            // 
            this.tsXuatFileExcel.Name = "tsXuatFileExcel";
            this.tsXuatFileExcel.Size = new System.Drawing.Size(185, 26);
            this.tsXuatFileExcel.Text = "Xuất file Excel";
            this.tsXuatFileExcel.Click += new System.EventHandler(this.tsXuatFileExcel_Click);
            // 
            // lvDanhSachLop
            // 
            this.lvDanhSachLop.BackColor = System.Drawing.SystemColors.Control;
            this.lvDanhSachLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDanhSachLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDanhSachLop.ForeColor = System.Drawing.Color.Black;
            this.lvDanhSachLop.FullRowSelect = true;
            this.lvDanhSachLop.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDanhSachLop.HideSelection = false;
            this.lvDanhSachLop.Location = new System.Drawing.Point(0, 0);
            this.lvDanhSachLop.Name = "lvDanhSachLop";
            this.lvDanhSachLop.Size = new System.Drawing.Size(238, 478);
            this.lvDanhSachLop.TabIndex = 1;
            this.lvDanhSachLop.TileSize = new System.Drawing.Size(500, 30);
            this.lvDanhSachLop.UseCompatibleStateImageBehavior = false;
            this.lvDanhSachLop.View = System.Windows.Forms.View.Tile;
            this.lvDanhSachLop.SelectedIndexChanged += new System.EventHandler(this.lvDanhSachLop_SelectedIndexChanged);
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbTieuDe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.Location = new System.Drawing.Point(0, 77);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbTieuDe.Size = new System.Drawing.Size(836, 17);
            this.lbTieuDe.TabIndex = 5;
            this.lbTieuDe.Text = "Thông tin lớp học: Lớp - Mã môn học - Tên môn học - Số tín chỉ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 572);
            this.panel1.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvDanhSachLop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 478);
            this.panel3.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 94);
            this.panel2.TabIndex = 42;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(5, 28);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(225, 27);
            this.txtTimKiem.TabIndex = 4;
            // 
            // dtgvLopHoc
            // 
            this.dtgvLopHoc.AllowUserToAddRows = false;
            this.dtgvLopHoc.AllowUserToDeleteRows = false;
            this.dtgvLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgvLopHoc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvLopHoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvLopHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvLopHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvLopHoc.ColumnHeadersHeight = 30;
            this.dtgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvLopHoc.EnableHeadersVisualStyles = false;
            this.dtgvLopHoc.Location = new System.Drawing.Point(244, 122);
            this.dtgvLopHoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvLopHoc.Name = "dtgvLopHoc";
            this.dtgvLopHoc.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvLopHoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvLopHoc.RowHeadersWidth = 51;
            this.dtgvLopHoc.RowTemplate.Height = 24;
            this.dtgvLopHoc.Size = new System.Drawing.Size(818, 412);
            this.dtgvLopHoc.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbTieuDe);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(238, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(836, 94);
            this.panel4.TabIndex = 42;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnThemSinhVien);
            this.panel5.Controls.Add(this.btnXoaLop);
            this.panel5.Controls.Add(this.btnDiemDanh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(238, 541);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(836, 61);
            this.panel5.TabIndex = 43;
            // 
            // btnThemSinhVien
            // 
            this.btnThemSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnThemSinhVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThemSinhVien.FlatAppearance.BorderSize = 0;
            this.btnThemSinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSinhVien.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSinhVien.ForeColor = System.Drawing.Color.White;
            this.btnThemSinhVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSinhVien.Location = new System.Drawing.Point(132, 10);
            this.btnThemSinhVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSinhVien.Name = "btnThemSinhVien";
            this.btnThemSinhVien.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThemSinhVien.Size = new System.Drawing.Size(120, 40);
            this.btnThemSinhVien.TabIndex = 35;
            this.btnThemSinhVien.Text = "Thêm sinh viên";
            this.btnThemSinhVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemSinhVien.UseVisualStyleBackColor = false;
            this.btnThemSinhVien.Visible = false;
            this.btnThemSinhVien.Click += new System.EventHandler(this.btnThemSinhVien_Click);
            // 
            // btnXoaLop
            // 
            this.btnXoaLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaLop.BackColor = System.Drawing.Color.Red;
            this.btnXoaLop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXoaLop.FlatAppearance.BorderSize = 0;
            this.btnXoaLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLop.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLop.ForeColor = System.Drawing.Color.White;
            this.btnXoaLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaLop.Location = new System.Drawing.Point(704, 10);
            this.btnXoaLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaLop.Name = "btnXoaLop";
            this.btnXoaLop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnXoaLop.Size = new System.Drawing.Size(120, 40);
            this.btnXoaLop.TabIndex = 34;
            this.btnXoaLop.Text = "Xóa lớp học";
            this.btnXoaLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaLop.UseVisualStyleBackColor = false;
            this.btnXoaLop.Visible = false;
            this.btnXoaLop.Click += new System.EventHandler(this.btnXoaLop_Click);
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiemDanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(200)))));
            this.btnDiemDanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDiemDanh.FlatAppearance.BorderSize = 0;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanh.ForeColor = System.Drawing.Color.White;
            this.btnDiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Location = new System.Drawing.Point(6, 10);
            this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDiemDanh.Size = new System.Drawing.Size(120, 40);
            this.btnDiemDanh.TabIndex = 32;
            this.btnDiemDanh.Text = "Điểm danh";
            this.btnDiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemDanh.UseVisualStyleBackColor = false;
            this.btnDiemDanh.Visible = false;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1074, 602);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dtgvLopHoc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N16DIEMDANH";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLopHoc)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem themToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsThemLopHoc;
        private System.Windows.Forms.ToolStripMenuItem tsThemMonHoc;
        private System.Windows.Forms.ToolStripMenuItem xuatFileExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsXuatFileExcel;
        private System.Windows.Forms.ListView lvDanhSachLop;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvLopHoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnDiemDanh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsLopHoc;
        private System.Windows.Forms.ToolStripMenuItem tsMonHoc;
        private System.Windows.Forms.Button btnXoaLop;
        private System.Windows.Forms.Button btnThemSinhVien;
    }
}

