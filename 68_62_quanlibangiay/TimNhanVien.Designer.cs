namespace _68_62_qunalibangiay
{
    partial class TimNhanVien
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHoLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNgaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColsoPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPhoneNV = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(89, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Chọn Số Phone Nhân Viên";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThoat.Location = new System.Drawing.Point(507, 178);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 25;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(206)))), ((int)(((byte)(181)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(54, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(688, 44);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tìm Kiếm Nhân Viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseMnemonic = false;
            // 
            // btnTrove
            // 
            this.btnTrove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTrove.Location = new System.Drawing.Point(148, 178);
            this.btnTrove.Name = "btnTrove";
            this.btnTrove.Size = new System.Drawing.Size(75, 23);
            this.btnTrove.TabIndex = 23;
            this.btnTrove.Text = "Trở về";
            this.btnTrove.UseVisualStyleBackColor = false;
            this.btnTrove.Click += new System.EventHandler(this.btnTrove_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(54, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 265);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(205)))), ((int)(((byte)(155)))));
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNV,
            this.ColHoLot,
            this.ColTen,
            this.ColGioitinh,
            this.ColDiaChi,
            this.ColNgaysinh,
            this.ColsoPhone,
            this.ColTrangThai});
            this.dgvDanhSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.Location = new System.Drawing.Point(16, 36);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.Size = new System.Drawing.Size(642, 199);
            this.dgvDanhSach.TabIndex = 1;
            // 
            // colMaNV
            // 
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.HeaderText = "Mã Nhân Viên";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Width = 125;
            // 
            // ColHoLot
            // 
            this.ColHoLot.DataPropertyName = "TenLot";
            this.ColHoLot.HeaderText = "Họ và Tên Lót";
            this.ColHoLot.MinimumWidth = 6;
            this.ColHoLot.Name = "ColHoLot";
            this.ColHoLot.Width = 300;
            // 
            // ColTen
            // 
            this.ColTen.DataPropertyName = "TenNv";
            this.ColTen.HeaderText = "Tên Nhân Viên";
            this.ColTen.MinimumWidth = 6;
            this.ColTen.Name = "ColTen";
            this.ColTen.Width = 125;
            // 
            // ColGioitinh
            // 
            this.ColGioitinh.DataPropertyName = "GioiTinh";
            this.ColGioitinh.HeaderText = "Giới Tính";
            this.ColGioitinh.MinimumWidth = 6;
            this.ColGioitinh.Name = "ColGioitinh";
            this.ColGioitinh.Width = 125;
            // 
            // ColDiaChi
            // 
            this.ColDiaChi.DataPropertyName = "DChi";
            this.ColDiaChi.HeaderText = "ĐỊa Chỉ";
            this.ColDiaChi.MinimumWidth = 6;
            this.ColDiaChi.Name = "ColDiaChi";
            this.ColDiaChi.Width = 300;
            // 
            // ColNgaysinh
            // 
            this.ColNgaysinh.DataPropertyName = "Ngsinh";
            this.ColNgaysinh.HeaderText = "Ngày SInh";
            this.ColNgaysinh.MinimumWidth = 6;
            this.ColNgaysinh.Name = "ColNgaysinh";
            this.ColNgaysinh.Width = 300;
            // 
            // ColsoPhone
            // 
            this.ColsoPhone.DataPropertyName = "Phone";
            this.ColsoPhone.HeaderText = "Số Phone";
            this.ColsoPhone.MinimumWidth = 6;
            this.ColsoPhone.Name = "ColsoPhone";
            this.ColsoPhone.Width = 250;
            // 
            // ColTrangThai
            // 
            this.ColTrangThai.DataPropertyName = "trangthai";
            this.ColTrangThai.HeaderText = "Trạng Thái";
            this.ColTrangThai.MinimumWidth = 6;
            this.ColTrangThai.Name = "ColTrangThai";
            this.ColTrangThai.Width = 125;
            // 
            // txtPhoneNV
            // 
            this.txtPhoneNV.Location = new System.Drawing.Point(351, 117);
            this.txtPhoneNV.Name = "txtPhoneNV";
            this.txtPhoneNV.Size = new System.Drawing.Size(161, 22);
            this.txtPhoneNV.TabIndex = 27;
            this.txtPhoneNV.TextChanged += new System.EventHandler(this.txtPhoneNV_TextChanged);
            // 
            // TimNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(214)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.txtPhoneNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTrove);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimNhanVien";
            this.Text = "TimNhanVien";
            this.Load += new System.EventHandler(this.TimNhanVien_Load_1);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHoLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNgaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColsoPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTrangThai;
        private System.Windows.Forms.TextBox txtPhoneNV;
    }
}