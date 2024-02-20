using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _68_62_qunalibangiay
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();
        int vt = 0;
        DataSet ds;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void chucnang(Boolean t)
        {
            btnthem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled =! t;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
            txtMaKH.Text = phatsinhma();
            txtHoLot.Text = "";
            txtDChi.Text = "";
            txtGioiTinh.Text = "";
            txtNgaySinh.Text = "";
            txtTenKH.Text = "";
            txtSoPhone.Text = "";

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
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtHoLot.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ lót", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên  khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGioiTinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into KhachHang values('" + txtMaKH.Text + "','" + txtHoLot.Text + "','" + txtTenKH.Text + "','" +txtGioiTinh.Text + "','" + txtDChi.Text + "','" + txtNgaySinh.Text + "','" + txtSoPhone.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update KhachHang set HoLot = '"+txtHoLot.Text+"',"+ "Ten = '"+txtTenKH.Text+"',"+ "GioiTinh = '"+txtGioiTinh.Text+"',"+ "Dchi = '"+txtDChi.Text+"',"+ "NgSinh = '"+txtNgaySinh.Text+"',"+ "SoPhone = '"+txtSoPhone.Text+"',"+ "TrangThai =" + cbTrang.SelectedIndex + " where MaKH='" + txtMaKH.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update Size set TrangThai=1 where MaSize='" + txtMaKH.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                KhachHang_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void hienthi_textbox(DataSet ds, int vt)
        {
            txtMaKH.Text = ds.Tables[0].Rows[vt]["MaKH"].ToString();
            txtGioiTinh.Text = ds.Tables[0].Rows[vt]["GioiTinh"].ToString();
            txtHoLot.Text = ds.Tables[0].Rows[vt]["HoLot"].ToString();
            txtTenKH.Text = ds.Tables[0].Rows[vt]["Ten"].ToString();
            txtNgaySinh.Text = ds.Tables[0].Rows[vt]["NgSinh"].ToString();
            txtSoPhone.Text = ds.Tables[0].Rows[vt]["SoPhone"].ToString();
            txtDChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();

        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from KhachHang");
            hienthi_textbox(ds, vt);
            f = true;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            hienthi_textbox(ds, vt);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int flag = 0;
        void xulytextbox(Boolean t)
        {
            txtMaKH.ReadOnly = t;
            txtHoLot.ReadOnly = t;
            txtTenKH.ReadOnly = t;
            txtDChi.ReadOnly = t;
            txtSoPhone.ReadOnly = t;
            txtNgaySinh.ReadOnly = t;
            cbTrang.SelectedIndex = 0;
            txtGioiTinh.ReadOnly = t;
        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string makh = "";
            DataSet dskh = c.LayDuLieu("select MaKH from KhachHang");
            makh = "KH" + (ds.Tables[0].Rows.Count + 1).ToString();
            return makh;
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string makh = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string holot = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string tenkh = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string gioitinh = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string diachi = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string ngaysinh = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    string phone = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update KhachHang set HoLot=N'" + holot +"',Ten = N'" + tenkh + "',GioiTinh = N'" + gioitinh + "',Dchi = N'" + diachi + "', NgSinh = N'" + ngaysinh + "',SoPhone = N'" + phone + "',TrangThai=0 where MaKH='" + makh + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                       KhachHang_Load(sender, e);
                    }
                }

            }
        }
        
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from KhachHang");
            hienthi_textbox(ds, vt);
            f = true;
        }
    }
}
