using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68_62_qunalibangiay
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void cbTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
           
            //txttenMau.Text= phatsinhten();
            txtHoLot.Text = "";
            txtDiaChi.Text = "";
            txtDiaChi.Text = "";
            txtGioitinh.Text = "";
            txtNgaySinh.Text = "";
            txtTenNV.Text = "";
            txtSoPhone.Text = "";
            txtnhap.Text = phatsinhma();
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
            if (txtnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtHoLot.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ lót!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into NhanVien values('" + txtnhap.Text + "',N'" + txtHoLot.Text + "',N'" + txtTenNV.Text + "',N'" + txtGioitinh.Text + "',N'" + txtDiaChi.Text + "','" + txtNgaySinh.Text + "','" + txtSoPhone.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update NhanVien set TenLot = N'" + txtHoLot.Text + "'," + "TenNv = N'" + txtTenNV.Text + "'," + "GioiTinh = N'" + txtGioitinh.Text + "'," + "Dchi = N'" + txtDiaChi.Text + "'," + "Ngsinh = '" + txtNgaySinh.Text + "'," + "Phone = '" + txtSoPhone.Text + "'," + "trangthai =" + cbTrang.SelectedIndex + " where MaNV='" + txtnhap.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update NhanVien set trangthai=1 where MaNV='" + txtnhap.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                NhanVien_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void chucnang(Boolean t)
        {
            btnLuu.Enabled =! t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnthem.Enabled = t;
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from NhanVien");
            hienthi_textbox(ds,vt);
            f = true;
        }
        
        int vt = 0;
        DataSet ds;
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void hienthi_textbox(DataSet ds, int vt)
        {
            
            txtnhap.Text = ds.Tables[0].Rows[vt]["manv"].ToString();
            txtGioitinh.Text = ds.Tables[0].Rows[vt]["gioitinh"].ToString();
            txtHoLot.Text = ds.Tables[0].Rows[vt]["tenlot"].ToString();
            txtTenNV.Text = ds.Tables[0].Rows[vt]["tennv"].ToString();
            txtNgaySinh.Text = ds.Tables[0].Rows[vt]["ngsinh"].ToString();
            txtSoPhone.Text = ds.Tables[0].Rows[vt]["phone"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["dchi"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["trangthai"].ToString();

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt= e.RowIndex;
            hienthi_textbox(ds, vt);
        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string mamau = "";
            DataSet dsmau = c.LayDuLieu("select MaNV from NhanVien");
            mamau = "NV" + (ds.Tables[0].Rows.Count + 1).ToString();
            return mamau;
        }
        int flag = 0;
        void xulytextbox(Boolean t)
        {
            txtnhap.ReadOnly = t;
            txtHoLot.ReadOnly = t;
            txtTenNV.ReadOnly = t;
            txtDiaChi.ReadOnly= t;
            txtSoPhone.ReadOnly = t;
            txtNgaySinh.ReadOnly = t;
            cbTrang.SelectedIndex = 0;

        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string manv = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string holot = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string tennv = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string gioitinh = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string diachi = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string ngaysinh = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    string phone = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update NhanVien set TenLot=N'" + holot + "',TenNv = N'" + tennv + "',GioiTinh = N'" + gioitinh + "',Dchi = N'" + diachi + "', NgSinh = N'" + ngaysinh + "',Phone = N'" + phone + "',TrangThai=0 where MaNV='" + manv + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                        NhanVien_Load(sender, e);
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from NhanVien");
            hienthi_textbox(ds, vt);
            f = true;
        }
    }
}
