using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68_62_qunalibangiay { 
    public partial class LoaiSP : Form
    {
        public LoaiSP()
        {
            InitializeComponent();
        }

        DataSet ds;
        int vitri = 0;
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds= c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void chucnang(Boolean t)
        {
            btnXoa.Enabled = t;
            btnSua.Enabled = t; 
            btnthem.Enabled = t;
            btnLuu.Enabled =! t;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
            txtnhap.Text = phatsinhma();
            txtMaNCC.Text = "";
            txtTenLoai.Text = "";
            //txttenMau.Text= phatsinhten();
            flag = 1;
        }
        int flag = 0;
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
                MessageBox.Show("Bạn chưa nhập mã loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên tên loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into LoaiSP values('" + txtnhap.Text + "','" + txtTenLoai.Text + "','" + txtMaNCC.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update LoaiSP set TenLoai='"+txtTenLoai.Text+"',"+ "MaNCC = '"+txtMaNCC.Text+"',"+"TrangThai =" + cbTrang.SelectedIndex + " where MaLoai='" + txtnhap.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update LoaiSP set TrangThai=1 where MaLoai='" + txtnhap.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                LoaiSP_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoaiSP_Load(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from LoaiSP");
            hienthi(ds, vitri);
            f = true;
        }
        void hienthi(DataSet ds,int vitri)
        {
            txtnhap.Text = ds.Tables[0].Rows[vitri]["maloai"].ToString();
            txtTenLoai.Text = ds.Tables[0].Rows[vitri]["tenloai"].ToString();
           txtMaNCC.Text = ds.Tables[0].Rows[vitri]["mancc"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vitri]["trangthai"].ToString();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = (int)e.RowIndex;
            hienthi(ds, vitri);
        }
        void xulytextbox(Boolean t)
        {
            txtnhap.ReadOnly = t;
            txtTenLoai.ReadOnly = t;
            txtMaNCC.ReadOnly = t;
            cbTrang.SelectedIndex = 0;

        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string maloai = "";
            DataSet dsmaloai = c.LayDuLieu("select MaLoai from LoaiSP");
            maloai = "L" + (ds.Tables[0].Rows.Count + 1).ToString();
            return maloai;
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string malaoi = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenlaoi = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string mancc = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update LoaiSP set TenLoai=N'" + tenlaoi + "',MaNCC = N'" + mancc + "',TrangThai=0 where MaLoai='" + malaoi+ "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vitri = 0;
                        LoaiSP_Load(sender, e);
                    }
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from LoaiSP");
            hienthi(ds, vitri);
            f = true;
        }
    }
}
