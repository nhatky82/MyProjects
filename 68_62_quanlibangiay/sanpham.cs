using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68_62_qunalibangiay
{
    public partial class sanpham : Form
    {
        public sanpham()
        {
            InitializeComponent();
        }
        DataSet ds;
        int vitri = 0;
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsSanPham= new DataSet();
        DataSet dsLoaisp= new DataSet();
        DataSet dsnhacungcap= new DataSet();
        DataSet dsCTSP = new DataSet();
        DataSet dsMau = new DataSet();
        DataSet dsSize = new DataSet();
        //DataSet dsnhacungcap = new DataSet();


        void danhscach_datagridview(DataGridView d, string sql)
        {
             ds= c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void sanpham_Load(object sender, EventArgs e)
        {
            chucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from SanPham");
            danhscach_datagridview(dgvDanhSach, "select * from sanpham");
            dsnhacungcap = c.LayDuLieu("select * from NhaCungcap");
            dsLoaisp = c.LayDuLieu("select * from LoaiSP");
            dsSize = c.LayDuLieu("select * from Size");
            dsMau = c.LayDuLieu("select * from Mau");
            hienthi_textbox((DataSet)ds, vitri);
            f = true;
           // hienthicombobox(dsMau, cbomamau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cbomancc, "TenNCC", "MaNCC");
        }
        void chucnang(Boolean t)
        {
            btnthem.Enabled= t;
            btnXoa.Enabled= t;
            btnSua.Enabled= t;
            btnLuu.Enabled=! t;
            cbomaloai.Enabled=! t;
            cbomancc.Enabled=! t;
            //cbomamau.Enabled=! t;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            
            cbtrang.SelectedIndex= 0;
          
            //txtTenSP.Text = phatsinhten();
            flag = 1;
            hienthi_textbox((DataSet)ds, vitri);
            //hienthicombobox(dsMau, cbomamau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cbomancc, "TenNCC", "MaNCC");
            txtGiaBan.Text = "";
            txtGiaMua.Text = "";
            cbomaloai.SelectedIndex = -1;
            //cbomamau.SelectedIndex = -1;
            cbomancc.SelectedIndex = -1;
           // txtMaSize.Text = "";
            txtSoLuong.Text = "";
            txtTenSP.Text = "";
            txtMaSP.Text = phatsinhma();

        }
        int flag = 0;
        private void btnSua_Click(object sender, EventArgs e)
        {
            chucnang(false);
            flag= 2;
            //hienthicombobox(dsMau, cbomamau, "MaMau", "TenMau");
            hienthicombobox(dsLoaisp, cbomaloai, "MaLoai", "TenLoai");
            hienthicombobox(dsnhacungcap, cbomancc, "MaNCC", "TenNCC");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chucnang(false);
            flag= 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            chucnang(true);
            xulytextbox(true);
            string sql = "";
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (txtMaSize.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa chọn mã size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (txtGiaMua.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (cbomamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã giá bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into SanPham values('" + txtMaSP.Text + "','" + txtTenSP.Text + "','" + cbomancc.Text + "','" + cbomaloai.Text + "','" + /*txtMaSize.Text + "','" +*/ txtSoLuong.Text + "','" + /*cbomamau.Text + "','" +*/ txtGiaBan.Text + "','" + txtGiaMua.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update SanPham set TenSP='" + txtTenSP.Text + "'," + "MaLoai = '" + cbomaloai.Text + "'," + "MaNCC = '" + cbomancc.Text + "'," + "MaMau = '" + /*cbomamau.Text + "'," +*/ "MaSize = '" + /*txtMaSize.Text + "'," +*/ "GiaMua = '" + txtGiaMua.Text + "'," + "GiaBan = '" + txtGiaBan.Text + "'," + "SoLuong = '" + txtSoLuong.Text + "'," + "TrangThai =" + cbtrang.SelectedIndex + " where MaSP='" + txtMaSP.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update SanPham set TrangThai=1 where MaSP='" + txtMaSP.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                sanpham_Load(sender, e);
            }
        }
        void hienthi_textbox(DataSet ds,int vitri)
        {
            txtMaSP.Text = ds.Tables[0].Rows[vitri]["masp"].ToString();
            txtTenSP.Text = ds.Tables[0].Rows[vitri]["tensp"].ToString();
            //txtMaSize.Text = ds.Tables[0].Rows[vitri]["masize"].ToString();
            txtSoLuong.Text = ds.Tables[0].Rows[vitri]["soluong"].ToString();
            txtGiaMua.Text = ds.Tables[0].Rows[vitri]["giamua"].ToString();
            txtGiaBan.Text = ds.Tables[0].Rows[vitri]["giaban"].ToString();
            cbtrang.Text = ds.Tables[0].Rows[vitri]["trangthai"].ToString();

            string duongdan = ds.Tables[0].Rows[vitri]["hinh"].ToString();
            //string mancc, maloai, mach;
            string mancc, maloai, mamau;
            //maloai = ds.Tables[0].Rows[vitri]["MaLoai"].ToString();
            mancc = ds.Tables[0].Rows[vitri]["MaNCC"].ToString();
            //mamau = ds.Tables[0].Rows[vitri]["MaMau"].ToString();
            //locdulieu_theodatagridview1(cbomaloai, dsLoaisp, "TenLoai", "MaLoai", maloai);
            //locdulieu_theodatagridview1(cbomamau, dsMau, "TenMau", "MaMau", mamau);
            locdulieu_theodatagridview1(cbomancc, dsnhacungcap, "TenNCC", "MaNCC", mancc);
            String tenhinh = ds.Tables[0].Rows[vitri].ToString();
            string tenfile = Path.GetFileName("anh") + @"\" + duongdan;
            taoanh_tufileanh(picHinh, tenfile);

        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri=e.RowIndex;
            hienthi_textbox((DataSet)ds,vitri);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string masp = "";
            masp = "SP" + (ds.Tables[0].Rows.Count + 1).ToString();
            return masp;
        }
       
        void xulytextbox(Boolean t)
        {
           txtTenSP.ReadOnly = t;
            txtMaSP.ReadOnly = t;
            txtSoLuong.ReadOnly = t;
            txtGiaBan.ReadOnly = t;
            txtGiaMua.ReadOnly = t;
            txtSoLuong.ReadOnly = t;
            cbomancc.SelectedIndex = -1;
            //cbomamau.SelectedIndex = -1;
            cbomaloai.SelectedIndex = -1;
            cbtrang.SelectedIndex = 0;
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string masp = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tensp = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string maloai = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string mancc = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string mamau = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string masize = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    string giamua = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                    string giaban = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();
                    string soluong = dgvDanhSach.CurrentRow.Cells[8].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update SanPham set TenSP=N'" + tensp + "',MaLoai = N'" + maloai + "',MaNCC = N'" + mancc + "',MaMau = N'" + mamau + "',MaSize = N'" + masize + "',GiaMua = '" + giamua + "',GiaBan = '" + giaban + "',SoLuong = N'" + soluong + "',TrangThai=0 where MaSP='" + masp + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vitri = 0;
                        sanpham_Load(sender, e);
                    }
                }

            }
        }

        private void btnLoad_anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Path.GetFullPath("anh") + @"\";
            o.ShowDialog();
            string tenfile = o.FileName;
            string[] tenhinh = tenfile.Split('\\');
            Bitmap a = new Bitmap(tenfile);
            picHinh.Image = a;
            picHinh.SizeMode = PictureBoxSizeMode.StretchImage;
            taoanh_tufileanh(picHinh, tenfile);
            btnthem.Visible = true;
        }

        private void picHinh_Click(object sender, EventArgs e)
        {

        }
        //private void btnLoadHinh_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog o = new OpenFileDialog();
        //    o.InitialDirectory = Path.GetFullPatth("sanphamcuahang") + @"\";
        //    o.ShowDialog();
        //    string tenfile = o.FileName;

        //    Bitmap a = new Bitmap(tenfile);
        //    picHinhSP.Image = a;
        //    picHinhSP.SizeMode = PictureBoxSizeMode.StretchImage;
        //}
        void taoanh_tufileanh(PictureBox b, string filename)
        {
            Bitmap a = new Bitmap(filename);
            b.Image = a;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        string xulyfileanh(string filename)
        {
            string[] ten = filename.Split('\\');
            return ten[ten.Length - 2] + @"\" + ten[ten.Length - 1];
        }
        void loaddulieu_datagrid(DataGridView d, string sql)
        {
            dsSanPham = c.LayDuLieu(sql);
            d.DataSource = dsSanPham.Tables[0];
        }
        void hienthicombobox(DataSet ds, ComboBox cbo, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = 0;

        }
        void locdulieu_theodatagridview1(ComboBox cbo, DataSet ds, string ten, string ma, string giatrima)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            dv.RowFilter = ma + " = '" + giatrima + " '";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from SanPham");
            danhscach_datagridview(dgvDanhSach, "select * from sanpham");
            dsnhacungcap = c.LayDuLieu("select * from NhaCungcap");
            dsLoaisp = c.LayDuLieu("select * from LoaiSP");
            dsSize = c.LayDuLieu("select * from Size");
            dsMau = c.LayDuLieu("select * from Mau");
            hienthi_textbox((DataSet)ds, vitri);
            f = true;
            //hienthicombobox(dsMau, cbomamau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cbomancc, "TenNCC", "MaNCC");
        }
    }
   
}
