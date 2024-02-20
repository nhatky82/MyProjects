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
    public partial class NhaCungcap : Form
    {
        public NhaCungcap()
        {
            InitializeComponent();
        }
        int vt = 0;
        DataSet ds;
        DataSet dsLoaisp=new DataSet();
        DataView dvLoaisp = new DataView();
        private void btnthem_Click(object sender, EventArgs e)
        {
            chucnang(false);
            xulytextbox(false);
            cbTrang.SelectedIndex= 0;
           
            hienthi_textbox(ds, vt);
            hienthicombobox(cbLoaiSP, dsLoaisp, "TenLoai", "MaLoai");
            txtDchi.Text = "";
            txtSOPhone.Text = "";
            txtTenNCC.Text = "";
            cbLoaiSP.SelectedIndex = -1;
            txtnhap.Text = phatsinhma();
            flag = 1;
        }
        int flag= 0;
        
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
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSOPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDchi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbLoaiSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into NhaCungcap values('" + txtnhap.Text + "','" + txtTenNCC.Text + "','" + cbLoaiSP.SelectedIndex + "','" + txtDchi.Text +"','" + txtSOPhone.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update NhaCungcap set TenNCC='" + txtTenNCC.Text + "'," + "Dchi = '" + txtDchi.Text + "'," + "MaLoai='" + cbLoaiSP.Text + "'," +" SoPhone = '"+txtSOPhone.Text+"',"+"TrangThai =" + cbTrang.SelectedIndex + " where MaNCC='" + txtnhap.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update NhaCungcap set TrangThai=1 where MaNCC='" + txtnhap.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                NhaCungcap_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void chucnang(Boolean t)
        {
            btnSua.Enabled= t;
            btnthem.Enabled= t;
            btnXoa.Enabled= t;
            btnLuu.Enabled=! t;
            cbLoaiSP.Enabled=! t;
        }
        private void NhaCungcap_Load(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from NhaCungcap");
            dsLoaisp = c.LayDuLieu("select * from LoaiSP");
            hienthi_textbox(ds, vt);
            f = true;
            hienthicombobox(cbLoaiSP, dsLoaisp, "TenLoai", "MaLoai");
            //cbLoaiSP.DataSource = dsLoai.Tables[0];
            //cbLoaiSP.DisplayMember= "TenLoai";
            //cbLoaiSP.ValueMember= "MaLoai";
            //cbLoaiSP.SelectedIndex=-1;
        }
        void hienthicombobox(ComboBox cbo,DataSet ds,string ten,string ma)
        {
            cbo.DataSource= ds.Tables[0];
            cbo.DisplayMember=ten;
            cbo.ValueMember= ma;
            cbo.SelectedIndex=0;
        }
        void locdulieucombobox(DataView dv,DataSet ds,ComboBox cbo,string ten,string ma,string giatrima)
        {
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + " = '" + giatrima + " '";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void hienthi_textbox(DataSet ds,int vt)
        {
            txtnhap.Text = ds.Tables[0].Rows[vt]["mancc"].ToString();
            txtTenNCC.Text = ds.Tables[0].Rows[vt]["tenncc"].ToString();
            string maloai = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
            txtDchi.Text = ds.Tables[0].Rows[vt]["dchi"].ToString();
            txtSOPhone.Text = ds.Tables[0].Rows[vt]["sophone"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["trangthai"].ToString();
            //loai san pham

            //dvLoaisp.Table = dsLoaisp.Tables[0];
            //dvLoaisp.RowFilter="Maloai='"+maloai+"'";
            //cbLoaiSP.DataSource= dvLoaisp;
            //cbLoaiSP.DisplayMember = "TenLoai";
            //cbLoaiSP.ValueMember= "MaLoai";
            locdulieucombobox(dvLoaisp, dsLoaisp, cbLoaiSP, "TenLoai", "MaLoai", maloai);
        }
        
        
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt= e.RowIndex;
            hienthi_textbox((DataSet)ds,vt);
        }
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string mancc = "";
            DataSet dsmancc = c.LayDuLieu("select MaNCC from NhaCungcap");
            mancc = "NCC" + (ds.Tables[0].Rows.Count + 1).ToString();
            return mancc;
        }
        void xulytextbox(Boolean t)
        {
            txtnhap.ReadOnly = t;
            txtTenNCC.ReadOnly = t;
            txtDchi.ReadOnly = t;
            txtSOPhone.ReadOnly = t;
            cbTrang.SelectedIndex = 0;
            cbLoaiSP.SelectedIndex= 0;
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string mancc = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenncc = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string maloai = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string diachi = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    //string ngaysinh = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    string phone = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update NhaCungcap set TenNCC=N'" + tenncc + "',MaLoai = N'" + maloai + "',Dchi = N'" + diachi + "',SoPhone = N'" + phone + "',TrangThai=0 where MaNCC='" + mancc + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                        NhaCungcap_Load(sender, e);
                    }
                }

            }
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from NhaCungcap");
            dsLoaisp = c.LayDuLieu("select * from LoaiSP");
            hienthi_textbox(ds, vt);
            f = true;
            hienthicombobox(cbLoaiSP, dsLoaisp, "TenLoai", "MaLoai");
        }
    }
}
