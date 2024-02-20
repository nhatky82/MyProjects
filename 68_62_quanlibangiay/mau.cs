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
    public partial class mau : Form
    {
        public mau()
        {
            InitializeComponent();
        }
        DataSet ds;
        int vt=0;
        clsquanlibanhang c = new clsquanlibanhang();
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void mau_Load(object sender, EventArgs e)
        {
            sua(true);
            danhscach_datagridview(dgvDanhSach, "select * from Mau");
            hienthi_textbox(ds, vt);
            f = true;
        }
        void sua(Boolean t)
        {
            btnthem.Enabled= t;
            btnSua.Enabled= t;  
            btnXoa.Enabled= t;
            btnLuu.Enabled=! t;
        }
        void xulytextbox(Boolean t)
        {
            txttenMau.ReadOnly = t;
            txtMaMau.ReadOnly = t;
            cbTrang.SelectedIndex = 0;
           
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            sua(false);
            xulytextbox(false);
            cbTrang.SelectedIndex = 0;
            txtMaMau.Text = phatsinhma();
            txttenMau.Text= "";
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sua(false);
            flag= 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sua(false);
            flag= 3;
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            sua(true);
            xulytextbox(true);
            string sql = "";
            if (txtMaMau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txttenMau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái size!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into Mau values('" + txtMaMau.Text + "',N" + txttenMau.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update Mau set TenMau='N"+txttenMau.Text+"',"+" TrangThai=" + cbTrang.SelectedIndex + " where MaMau='" + txtMaMau.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update Mau set TrangThai = 1 where MaMau='" + txtMaMau.Text + "'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                mau_Load(sender, e);
            }
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void hienthi_textbox(DataSet ds,int vt)
        {
            txtMaMau.Text = ds.Tables[0].Rows[vt]["mamau"].ToString();
            txttenMau.Text = ds.Tables[0].Rows[vt]["tenmau"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vt]["trangthai"].ToString();
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            hienthi_textbox(ds,vt);
        }
        //phát sinh mã
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string mamau = "";
            DataSet dsmau = c.LayDuLieu("select MaMau from Mau");
            mamau = "M" +(ds.Tables[0].Rows.Count+1).ToString();
            return mamau;
        }
        //string phatsinhten()
        //{
        //    //DataSet ds= new DataSet(); ko  cần lệ thuộc 
        //    string tenmau = "";
        //    tenmau =(ds.Tables[0].Rows.Count + 1).ToString();
        //    return tenmau;
        //}
        private void btnHuy_Click(object sender, EventArgs e)
        {
            sua(true);
            danhscach_datagridview(dgvDanhSach, "select * from Mau");
            hienthi_textbox(ds, vt);
            f = true;
        }
        int flag = 0;
        private void cbTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Boolean f=false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string mamau = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenmau = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    //string trangthai=dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update Mau set TenMau=N'" + tenmau + "',TrangThai=0 where MaMau='" + mamau + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vt = 0;
                        mau_Load(sender, e);
                    }
                }
                
            }
        }
        //c2
        //string phatsinh1()
        //{
        //    //DataSet ds= new DataSet(); ko  cần lệ thuộc 
        //    string mamau = "";
        //     DataSet dsmau=c.LayDuLieu("select mamau from mau")
        //    mamau = "M" + (ds.Tables[0].Rows.Count + 1).ToString();
        //    return mamau;
        //}
    }
}
