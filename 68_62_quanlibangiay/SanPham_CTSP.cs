using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68_62_qunalibangiay
{
    public partial class SanPham_CTSP : Form
    {
        public SanPham_CTSP()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataSet ds2;
        int vitri = 0;
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsSanPham = new DataSet();
        DataSet dsLoaisp = new DataSet();
        DataSet dsnhacungcap = new DataSet();
        DataSet dsCTSP = new DataSet();
        DataSet dsMau = new DataSet();
        DataSet dsSize = new DataSet();
        DataView dvloai = new DataView();
        DataView dvmau = new DataView();
        DataView dvnhacc = new DataView();


        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void danhsach_datagridview_ctsp(DataGridView d,string sql)
        {
            ds2 = c.LayDuLieu(sql);
            d.DataSource= ds2.Tables[0]; 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        void chucnang(Boolean t)
        {
            btnthem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
            cbMauct.Enabled = !t;
            cbomaloai.Enabled = !t;
           // cbomaMau.Enabled = !t;
            cboMaNCC.Enabled = !t;
            btnSize.Enabled = !t;
            txtsl.Enabled = !t;
            txtGiaLech.Enabled = !t;
            btnMau.Enabled = !t;    
        }
        string phatsinhmaCTSP()
        {
            string mactsp = "";
            mactsp = "SP" + (ds.Tables[0].Rows.Count + 1).ToString()+"M"+ (ds.Tables[0].Rows.Count + 1).ToString();
            return mactsp;
        }
        int tongsoluong = 0;
        private void btnthem_Click(object sender, EventArgs e)
        {
            
            xulytextbox(false);
            chucnang(false);
            cbtrang.SelectedIndex = 0;
            
            tongsoluong = 0;
            flag = 1;
            hienthi_textbox(ds, vitri);
            //hienthicombobox(dsMau, cbomaMau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cboMaNCC, "TenNCC", "MaNCC");
            txtGiaBan.Text = "";
            txtGiaMua.Text = "";
            cbomaloai.SelectedIndex = -1;
            //cbomaMau.Enabled= false;
            cbMauct.SelectedIndex = -1;
            cboMaNCC.SelectedIndex = -1;
            //txtMasize.Text = "";
            txtMaSP.Text = phatsinhma();
            txtTenSP.Text = "";
            txtSoLuong.Enabled= false;

        }
        int flag = 0;
        private void btnSua_Click(object sender, EventArgs e)
        {
            chucnang(false);
            flag = 2;
            xulytextbox(false);
           // hienthicombobox(dsMau, cbomaMau, "MaMau", "TenMau");
            hienthicombobox(dsLoaisp, cbomaloai, "MaLoai", "TenLoai");
            hienthicombobox(dsnhacungcap, cboMaNCC, "MaNCC", "TenNCC");
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
            //if (txtMasize.Text == "")
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
            if (cboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (cbomaMau.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa chọn mã màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
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
                sql = "insert into SanPham values('" + txtMaSP.Text + "','" + txtTenSP.Text + "','" + cboMaNCC.Text + "','" + cbomaloai.Text + "','" + /*txtMasize.Text + "','" +*/ txtSoLuong.Text + "','" + /*cbomaMau.Text + "','" +*/ txtGiaBan.Text + "','" + txtGiaMua.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update SanPham set TenSP='" + txtTenSP.Text + "'," + "MaLoai = '" + cbomaloai.Text + "'," + "MaNCC = '" + cboMaNCC.Text + "'," + "MaMau = '" +/* cbomaMau.Text + "'," +*/ "MaSize = '" + /*txtMasize.Text + "'," + */"GiaMua = '" + txtGiaMua.Text + "'," + "GiaBan = '" + txtGiaBan.Text + "'," + "SoLuong = '" + txtSoLuong.Text + "'," + "TrangThai =" + cbtrang.SelectedIndex + " where MaSP='" + txtMaSP.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update SanPham set TrangThai=1 where MaSP='" + txtMaSP.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                SanPham_CTSP_Load_1(sender, e);
            }
        }
        void hienthi_textbox(DataSet ds, int vitri)
        {
            txtMaSP.Text = ds.Tables[0].Rows[vitri]["MaSP"].ToString();
            
            txtTenSP.Text = ds.Tables[0].Rows[vitri]["TenSP"].ToString();
            
            //txtMasize.Text = ds.Tables[0].Rows[vitri]["MaSize"].ToString();
            txtSoLuong.Text = ds.Tables[0].Rows[vitri]["SoLuong"].ToString();
            txtGiaMua.Text = ds.Tables[0].Rows[vitri]["GiaMua"].ToString();
            txtGiaBan.Text = ds.Tables[0].Rows[vitri]["GiaBan"].ToString();
            string hinh = ds.Tables[0].Rows[vitri]["Hinh"].ToString();
            cbtrang.Text = ds.Tables[0].Rows[vitri]["TrangThai"].ToString();
            

            //locdulieu_theodatagridview(cbomasize, dsSize, "MaLoai", maloai);
            string duongdan = ds.Tables[0].Rows[vitri]["Hinh"].ToString();
            string mancc, maloai, mamau;
            //maloai = ds.Tables[0].Rows[vitri]["MaLoai"].ToString();
            mancc = ds.Tables[0].Rows[vitri]["MaNCC"].ToString();
            //mamau = ds.Tables[0].Rows[vitri]["MaMau"].ToString();
            //locdulieu_theodatagridview1(cbomaloai, dsLoaisp, "TenLoai", "MaLoai", maloai);
           // locdulieu_theodatagridview1(cbomaMau, dsMau, "TenMau", "MaMau", mamau);
            locdulieu_theodatagridview1(cboMaNCC, dsnhacungcap, "TenNCC", "MaNCC", mancc);
            string tenfile = Path.GetFileName("anh") + @"\" + duongdan;
            taoanh_tufileanh(picHinh, tenfile);
            loadctsptheomaSP(ds.Tables[0].Rows[vitri]["MaSP"].ToString());

        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textbox((DataSet)ds, vitri);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        string phatsinhma()
        { 
            
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
           // txtMasize.ReadOnly= t;
            txtSoLuong.ReadOnly = t;
            cboMaNCC.SelectedIndex = 0;
           // cbomaMau.SelectedIndex = 0;
            cbomaloai.SelectedIndex = 0;   
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
                    string hinh=dgvDanhSach.CurrentRow.Cells[9].Value.ToString();
                    string sql = "update SanPham set TenSP=N'" + tensp + "',MaLoai = N'" + maloai + "',MaNCC = N'" + mancc + "',MaMau = N'" + mamau + "',MaSize = N'" + masize + "',GiaMua = '" + giamua + "',GiaBan = '" + giaban + "',SoLuong = N'" + soluong+ "',Hinh = N'" + hinh +"',TrangThai=0 where MaSP='" + masp + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vitri = 0;
                        SanPham_CTSP_Load_1(sender, e);
                    }
                }

            }
        }

        private void btnLoad_anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "anh");
            o.ShowDialog();
            string tenfile = o.FileName;
            if (!string.IsNullOrEmpty(tenfile))
            {
                string[] tenhinh = tenfile.Split('\\');
                Bitmap a = new Bitmap(tenfile);
                picHinh.Image = a;
                picHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                taoanh_tufileanh(picHinh, tenfile);
                btnthem.Visible = true;
            }
        }

        private void picHinh_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textbox(ds, vitri);
        }

        private void SanPham_CTSP_Load_1(object sender, EventArgs e)
        {
            chucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from SanPham");
            danhscach_datagridview(dgvDanhSach, "select * from SanPham");
            danhsach_datagridview_ctsp(dgvDanhsach_Ct, "select * from CT_SanPham");
            dsnhacungcap = c.LayDuLieu("select * from NhaCungcap");
            dsLoaisp = c.LayDuLieu("select * from LoaiSP");
            dsMau = c.LayDuLieu("select * from Mau");
            hienthi_textbox(ds, vitri);
            //hienthicombobox(dsMau, cbomaMau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cboMaNCC, "TenNCC", "MaNCC");
            
            f = true;
            
        }
        void taoanh_tufileanh(PictureBox b, string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                Bitmap a = new Bitmap(filename);
                b.Image = a;
                b.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void hienthicombobox(DataSet ds,ComboBox cbo,string ten,string ma)
        {
            cbo.DataSource= ds.Tables[0];
            cbo.DisplayMember= ten;
            cbo.ValueMember= ma;
            cbo.SelectedIndex= 0;
            
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
        void loaddulieu_datagrid(DataGridView d,string sql)
        {
            dsSanPham = c.LayDuLieu(sql);
            d.DataSource = dsSanPham.Tables[0];
            dsnhacungcap = c.LayDuLieu(sql);
            d.DataSource = dsnhacungcap.Tables[0];
            dsLoaisp = c.LayDuLieu(sql);
            d.DataSource = dsLoaisp.Tables[0];
            dsMau=c.LayDuLieu(sql);
            d.DataSource = dsMau.Tables[0];
        }
        string xulyfileanh(string filename)
        {
            string[] ten = filename.Split('\\');
            return ten[ten.Length-2]+@"\"+ten[ten.Length-1];
        }
        void loadctsptheomaSP(string masp)
        {
            string s=" select * from CT_SanPham where MaSP='"+masp+"'";
            dsCTSP = c.LayDuLieu(s);
            dgvDanhsach_Ct.DataSource = null;
            dgvDanhsach_Ct.Columns.Clear();
            dgvDanhsach_Ct.DataSource= dsCTSP.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chucnang(false);
            hienthicombobox(dsMau, cbMauct, "TenMau", "MaMau");
            object[] d = new object[9];
            float giabansize = 0;
            int tongsoluong = 0;
            giabansize = float.Parse(txtGiaBan.Text);
            foreach (CheckBox c in flpSize.Controls)
            {
                d[0] = txtMaSP.Text + "." + cbMauct.SelectedValue.ToString() + "." + c.Name;// mã chi tiết sản phẩm
                d[1] = txtMaSP.Text;
                d[2] = cbMauct.SelectedValue.ToString();
                d[3] = c.Name;
                d[4] = txtsl.Text;
                if (txtGiaLech.Text == "")
                    d[5] = txtGiaBan.Text;
                else
                {
                    giabansize += float.Parse(txtGiaLech.Text);
                    d[5] = giabansize.ToString();

                }
                d[6] = "at006\\1.jpg";
                d[7] = "a";

                tongsoluong += int.Parse(txtsl.Text);
                txtSoLuong.Text = tongsoluong.ToString();
                dgvDanhsach_Ct.Rows.Add(d);
            }
        }
        
        private void flpSize_Paint(object sender, PaintEventArgs e)
        {

        }
        ArrayList s = new ArrayList();
        private void cboSize_Click(object sender, EventArgs e)
        {
           size s=new size();
            if (s.ShowDialog() == DialogResult.OK)
            {
                flpSize.Controls.Clear();
                foreach(CheckBox chk in s.dschonsize)
                {
                    flpSize.Controls.Add(chk);
                }
            }
        }
       

        private void btnMau_Click(object sender, EventArgs e)
        {
            mau mau= new mau();
            mau.Show();
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
            //hienthicombobox(dsMau, cbomaMau, "TenMau", "MaMau");
            hienthicombobox(dsLoaisp, cbomaloai, "TenLoai", "MaLoai");
            hienthicombobox(dsnhacungcap, cboMaNCC, "TenNCC", "MaNCC");
            txtsl.Text = "";
            txtGiaLech.Text = "";
            flpSize.Controls.Clear();
        }

        private void txtGiaMua_TextChanged(object sender, EventArgs e)
        {

        }
        Boolean themctsp=false;
        private void txtGiaMua_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvDanhsach_Ct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
                if (flag == 1)//THEM
                    if (e.ColumnIndex == 4)
                    {
                        int TONGSL = 0;
                        for (int i = 0; i < dgvDanhsach_Ct.Rows.Count - 1; i++)
                        {
                            TONGSL += int.Parse(dgvDanhsach_Ct.Rows[i].Cells[4].Value.ToString());
                        }
                        txtSoLuong.Text = TONGSL.ToString();
                    }
        }
        Boolean flagmau = false;

        private void cbMauct_SelectedIndexChanged(object sender, EventArgs e)
        {
            flagmau = true;
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            object[] d = new object[8];
            d[0] = txtMaSP.Text;
            d[1] = txtTenSP.Text;
            d[2] = cbomaloai.SelectedValue.ToString();
            d[3] = cboMaNCC.SelectedValue.ToString();
            d[4] = txtSoLuong.Text;
            dgvDanhSach.Rows.Add(d);
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            this.Refresh();     
        }
    }
}
