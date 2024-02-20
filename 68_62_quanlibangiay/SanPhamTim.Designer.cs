namespace _68_62_qunalibangiay
{
    partial class SanPhamTim
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.colmasp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colmasize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGiaMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSOLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(60, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 214);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(206)))), ((int)(((byte)(181)))));
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colmasp,
            this.coltensp,
            this.colMaLoai,
            this.colMaMau,
            this.ColMaNCC,
            this.Colmasize,
            this.ColGiaMua,
            this.ColGiaBan,
            this.colSOLuong,
            this.ColTrangThai});
            this.dgvDanhSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.Location = new System.Drawing.Point(35, 31);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.Size = new System.Drawing.Size(616, 183);
            this.dgvDanhSach.TabIndex = 3;
            this.dgvDanhSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellValueChanged);
            // 
            // colmasp
            // 
            this.colmasp.DataPropertyName = "MaSP";
            this.colmasp.HeaderText = "Mã Sản Phẩm";
            this.colmasp.MinimumWidth = 6;
            this.colmasp.Name = "colmasp";
            this.colmasp.Width = 125;
            // 
            // coltensp
            // 
            this.coltensp.DataPropertyName = "TenSP";
            this.coltensp.HeaderText = "Tên Sản Phẩm";
            this.coltensp.MinimumWidth = 6;
            this.coltensp.Name = "coltensp";
            this.coltensp.Width = 200;
            // 
            // colMaLoai
            // 
            this.colMaLoai.DataPropertyName = "MaLoai";
            this.colMaLoai.HeaderText = "Mã Loại";
            this.colMaLoai.MinimumWidth = 6;
            this.colMaLoai.Name = "colMaLoai";
            this.colMaLoai.Width = 125;
            // 
            // colMaMau
            // 
            this.colMaMau.DataPropertyName = "MaMau";
            this.colMaMau.HeaderText = "Mã Màu";
            this.colMaMau.MinimumWidth = 6;
            this.colMaMau.Name = "colMaMau";
            this.colMaMau.Width = 125;
            // 
            // ColMaNCC
            // 
            this.ColMaNCC.DataPropertyName = "MaNCC";
            this.ColMaNCC.HeaderText = "Mã Nhà CUng Cấp";
            this.ColMaNCC.MinimumWidth = 6;
            this.ColMaNCC.Name = "ColMaNCC";
            this.ColMaNCC.Width = 125;
            // 
            // Colmasize
            // 
            this.Colmasize.DataPropertyName = "MaSize";
            this.Colmasize.HeaderText = "Mã Size";
            this.Colmasize.MinimumWidth = 6;
            this.Colmasize.Name = "Colmasize";
            this.Colmasize.Width = 125;
            // 
            // ColGiaMua
            // 
            this.ColGiaMua.DataPropertyName = "GiaMua";
            this.ColGiaMua.HeaderText = "Giá Mua";
            this.ColGiaMua.MinimumWidth = 6;
            this.ColGiaMua.Name = "ColGiaMua";
            this.ColGiaMua.Width = 150;
            // 
            // ColGiaBan
            // 
            this.ColGiaBan.DataPropertyName = "GiaBan";
            this.ColGiaBan.HeaderText = "Giá Bán";
            this.ColGiaBan.MinimumWidth = 6;
            this.ColGiaBan.Name = "ColGiaBan";
            this.ColGiaBan.Width = 150;
            // 
            // colSOLuong
            // 
            this.colSOLuong.DataPropertyName = "SoLuong";
            this.colSOLuong.HeaderText = "Số Lượng";
            this.colSOLuong.MinimumWidth = 6;
            this.colSOLuong.Name = "colSOLuong";
            this.colSOLuong.Width = 150;
            // 
            // ColTrangThai
            // 
            this.ColTrangThai.DataPropertyName = "TrangThai";
            this.ColTrangThai.HeaderText = "Trạng Thái";
            this.ColTrangThai.MinimumWidth = 6;
            this.ColTrangThai.Name = "ColTrangThai";
            this.ColTrangThai.Width = 145;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(95, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn tên Sản Phẩm";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(154, 199);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Trở về";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(206)))), ((int)(((byte)(181)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(60, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(688, 44);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tìm Kiếm Sản  Phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(513, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(341, 103);
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(229, 22);
            this.txtSP.TabIndex = 14;
            this.txtSP.TextChanged += new System.EventHandler(this.txtSP_TextChanged);
            // 
            // SanPhamTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(214)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(800, 591);
            this.ControlBox = false;
            this.Controls.Add(this.txtSP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "SanPhamTim";
            this.Text = "SanPhamTim";
            this.Load += new System.EventHandler(this.SanPhamTim_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmasp;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colmasize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGiaMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSOLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTrangThai;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSP;
    }
}