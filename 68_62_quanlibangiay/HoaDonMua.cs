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
    public partial class HoaDonMua : Form
    {
        public HoaDonMua()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataSet ds2;
        DataSet dsnv=new DataSet();
        DataSet dsnhacc=new DataSet();
        DataView dvNhacc = new DataView();
        int vt = 0;
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void danhsach_datagridview_cthd(DataGridView d, string sql)
        {
            ds2 = c.LayDuLieu(sql);
            d.DataSource = ds2.Tables[0];
        }
        void chucnang(Boolean u)
        {
            btnXoa.Enabled = u;
            btnthem.Enabled = u;
            btnSua.Enabled = u;
            btnLuu.Enabled =! u;
            cbMaNCCM.Enabled =! u;
            cbNV.Enabled =! u;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
           
            
                       //txttenMau.Text= phatsinhten();
            hienthi_textbox(ds, vt);
            hienthicombobox(cbMaNCCM, dsnhacc, "TenNCC", "MaNCC");
            hienthicombobox(cbNV, dsnv, "TenNv", "MaNV");
            txtNgayLap.Text = "";
            txtThanhTien.Text = "";
            cbMaNCCM.SelectedIndex = -1;
            cbNV.SelectedIndex = -1;
            txtMaHDM.Text = phatsinhma();
            flag = 1;
        }

        private void HoaDonMua_Load(object sender, EventArgs e)
        {
            chucnang(true);
            
            dsnhacc = c.LayDuLieu("select * from NhaCungcap");
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonMua");
            danhsach_datagridview_cthd(danhsachcthd, "select * from CT_HoaDon");
            dsnv = c.LayDuLieu("select * from NhanVien");
            hienthi_textbox(ds, vt);
            
            f = true;
            hienthicombobox(cbMaNCCM, dsnhacc, "TenNCC", "MaNCC");
            hienthicombobox(cbNV, dsnv, "TenNv", "MaNV");
        }
        void hienthicombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            chucnang(false);
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chucnang(false);
            flag = 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            chucnang(true);
            xulytextbox(true);
            string sql = "";
            if (txtMaHDM.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbMaNCCM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn  nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgayLap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày lập hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtThanhTien.Text == "")
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
                sql = "insert into HoaDonMua values('" + txtMaHDM.Text + "','" + cbMaNCCM.Text + "','" + cbNV.Text + "','" + txtNgayLap.Text + "','" + txtThanhTien.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update HoaDonMua set MaNCC = '" + cbMaNCCM.Text + "'," + "MaNV = '" + cbNV.Text + "'," + "NgLapHD = '" + txtNgayLap.Text + "'," + "ThanhTien = '" + txtThanhTien.Text + "'," + "TrangThai =" + cbTrang.SelectedIndex + " where MaHD='" + txtMaHDM.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update HoaDonMua set TrangThai=1 where MaHD='" + txtMaHDM.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                HoaDonMua_Load(sender, e);
            }
        }
        void hienthi_textbox(DataSet ds, int vt)
        {
            txtMaHDM.Text = ds.Tables[0].Rows[vt]["MaHD"].ToString();
            string nhacc = ds.Tables[0].Rows[vt]["Mancc"].ToString();
            string MaNV = ds.Tables[0].Rows[vt]["MaNV"].ToString();
            txtNgayLap.Text = ds.Tables[0].Rows[vt]["Nglaphd"].ToString();
            txtThanhTien.Text = ds.Tables[0].Rows[vt]["ThanhTien"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            //nha cung cap

            //dvNhacc.Table = dsnhacc.Tables[0];
            //dvNhacc.RowFilter = "MaNCC='" + nhacc + "'";
            //cbMaNCCM.DataSource = dvNhacc;
            //cbMaNCCM.DisplayMember = "TenNCC";
            //cbMaNCCM.ValueMember = "MaNCC";
            locdulieucombobox(dsnhacc, cbMaNCCM, "TenNCC", "MaNCC", nhacc);
            locdulieucombobox(dsnv, cbNV, "TenNv", "MaNV", MaNV);
            loadctsptheomaHD(ds.Tables[0].Rows[vt]["MaHD"].ToString());
        }
        void locdulieucombobox( DataSet ds, ComboBox cbo, string ten, string ma, string giatrima)
        {
            DataView dv=new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + " = '" + giatrima + " '";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            hienthi_textbox(ds, vt);
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string mahd = "";
            DataSet dskh = c.LayDuLieu("select MaHD from HoaDonMua");
            mahd = "HDM" + (ds.Tables[0].Rows.Count + 1).ToString();
            return mahd;
        }
        void xulytextbox(Boolean t)
        {
          
            txtMaHDM.ReadOnly = t;
            cbNV.SelectedIndex = -1;
            cbTrang.SelectedIndex = 0;
            txtThanhTien.ReadOnly = t;
            txtNgayLap.ReadOnly = t;
            cbMaNCCM.SelectedIndex = -1;
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
                    string mancc = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string manv = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string nglap = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string thanhtien = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update HoaDonMua set MaNCC=N'" + mancc + "',MaNV = N'" + manv + "',NgLapHD = N'" + nglap + "',ThanhTien = N'" + thanhtien  + "',TrangThai=0 where MaHD='" + mahd + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                        HoaDonMua_Load(sender, e);
                    }
                }

            }
        }
        int flag = 0;

        private void cbMaNCCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            chucnang(true);
        }
        DataSet dscthd= new DataSet();
        void loadctsptheomaHD(string mahd)
        {
            string s = " select * from CT_HoaDon where MaHD='" + mahd + "'";
            dscthd = c.LayDuLieu(s);
            danhsachcthd.DataSource = null;
            danhsachcthd.Columns.Clear();
            danhsachcthd.DataSource = dscthd.Tables[0];
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);

            dsnhacc = c.LayDuLieu("select * from NhaCungcap");
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonMua");
            danhsach_datagridview_cthd(danhsachcthd, "select * from CT_HoaDon");
            dsnv = c.LayDuLieu("select * from NhanVien");
            hienthi_textbox(ds, vt);

            f = true;
            hienthicombobox(cbMaNCCM, dsnhacc, "TenNCC", "MaNCC");
            hienthicombobox(cbNV, dsnv, "TenNv", "MaNV");
        }
    }
}
