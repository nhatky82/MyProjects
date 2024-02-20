using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68_62_qunalibangiay
{
    public partial class HoaDonBan : Form
    {
        public HoaDonBan()
        {
            InitializeComponent();
        }
        int vt = 0;
        DataSet ds;
        DataSet ds2;
        DataSet dsSanPham = new DataSet();
        DataSet dsNV=new DataSet();
        DataSet dsKH= new DataSet();    
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds= c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        
        void danhsach_datagridview_cthd(DataGridView d, string sql)
        {
            ds2 = c.LayDuLieu(sql);
            d.DataSource = ds2.Tables[0];
        }
        int flag = 0;
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
            
            hienthi_textbox(ds, vt);
            hienthicombobox(cbTenKH, dsKH, "Ten", "MaKH");
            hienthicombobox(cbTenNV, dsNV, "TenNv", "MaNV");
            cbTenKH.SelectedIndex= -1;
            cbTenNV.SelectedIndex= -1;
            txtNGLAp.Text = "";
            txtTT.Text = "";
            txtMaHD.Text = phatsinhma();
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chucnang(false);
            flag= 2;    
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
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNGLAp.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày lập hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into HoaDonBan values('" + txtMaHD.Text + "','" + cbTenKH.Text + "','" + cbTenNV.Text + "','" + txtNGLAp.Text + "','" + txtTT.Text  + "',0)";
            }
            if (flag == 2)
            {
                sql = "update HoaDonBan set MaKH = '" + cbTenKH.Text + "'," + "MaNV = '" + cbTenNV.Text + "'," + "NgLapHD = '" + txtNGLAp.Text + "'," + "ThanhTien = '" + txtTT.Text + "'," + "TrangThai =" + cbTrang.SelectedIndex + " where MaHD='" + txtMaHD.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update HoaDonBan set TrangThai=1 where MaHD='" + txtMaHD.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                HoaDonBan_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void chucnang(Boolean t)
        {
            btnLuu.Enabled=! t;
            btnSua.Enabled= t;
            btnthem.Enabled= t;
            btnXoa.Enabled= t;
            cbTenNV.Enabled=! t;
            cbTenKH.Enabled=! t;
        }
        void hienthi_textbox(DataSet ds,int vt)
        {
            txtMaHD.Text = ds.Tables[0].Rows[vt]["MaHD"].ToString(); 
            txtNGLAp.Text = ds.Tables[0].Rows[vt]["NgLapHD"].ToString();
            txtTT.Text = ds.Tables[0].Rows[vt]["ThanhTien"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            string khachhang, nhanvien;
            khachhang= ds.Tables[0].Rows[vt]["MaKH"].ToString();
            nhanvien= ds.Tables[0].Rows[vt]["MaNV"].ToString();
            locdulieu_theodatagridview1(cbTenKH, dsKH, "Ten", "MaKH", khachhang);
            locdulieu_theodatagridview1(cbTenNV, dsNV, "TenNv", "MaNV", nhanvien);
            loadctsptheomaHD(ds.Tables[0].Rows[vt]["MaHD"].ToString());
        }
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            chucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from HoaDonBan");
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonBan");
            danhsach_datagridview_cthd(danhsachcthd, "select * from CT_HoaDonBan");
            dsKH = c.LayDuLieu("select * from KhachHang");
            dsNV = c.LayDuLieu("select * from NhanVien");
            hienthi_textbox(ds,vt);
            f = true;
            hienthicombobox(cbTenKH, dsKH, "Ten", "MaKH");
            hienthicombobox(cbTenNV, dsNV, "TenNv", "MaNV");
        }
        void hienthicombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = 0;
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt= e.RowIndex; 
            hienthi_textbox(ds,vt);
        }
        string phatsinhma()
        {
            string maloai = "";
            DataSet dsmaloai = c.LayDuLieu("select MaHD from HoaDonBan");
            maloai = "HDB" + (ds.Tables[0].Rows.Count + 1).ToString();
            return maloai;
        }
        void xulytextbox(Boolean t)
        {
            cbTenKH.SelectedIndex= 0;
            cbTenNV.SelectedIndex= 0;
            cbTrang.SelectedIndex = 0;
            txtNGLAp.ReadOnly = t;
            txtTT.ReadOnly= t;
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string mahd = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string makh = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string manv = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string nglap = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string thanhtien = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update HoaDonBan set MaKH=N'" + makh + "',MaNV = N'" + manv + "',NgLapHD = N'" +nglap + "',ThanhTien = N'" + thanhtien +"',TrangThai=0 where MaHD='" + mahd + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                        HoaDonBan_Load(sender, e);
                    }
                }

            }
        }

        private void cbTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        void loaddulieu_datagrid(DataGridView d, string sql)
        {
            dsSanPham = c.LayDuLieu(sql);
            d.DataSource = dsSanPham.Tables[0];
        }
        DataSet dscthd= new DataSet();
        void loadctsptheomaHD(string mahd)
        {
            string s = " select * from CT_HoaDonBan where MaHD='" + mahd + "'";
            dscthd = c.LayDuLieu(s);
            danhsachcthd.DataSource = null;
            danhsachcthd.Columns.Clear();
            danhsachcthd.DataSource = dscthd.Tables[0];
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from HoaDonBan");
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonBan");
            danhsach_datagridview_cthd(danhsachcthd, "select * from CT_HoaDonBan");
            dsKH = c.LayDuLieu("select * from KhachHang");
            dsNV = c.LayDuLieu("select * from NhanVien");
            hienthi_textbox(ds, vt);
            f = true;
            hienthicombobox(cbTenKH, dsKH, "Ten", "MaKH");
            hienthicombobox(cbTenNV, dsNV, "TenNv", "MaNV");
        }
    }
}
