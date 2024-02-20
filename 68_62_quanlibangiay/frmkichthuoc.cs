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
    public partial class frmkichthuoc : Form
    {
        public frmkichthuoc()
        {
            InitializeComponent();
        }
        clsquanlibanhang c=new clsquanlibanhang();
        int vitri = 0;
        DataSet ds;
        void danhscach_datagridview(DataGridView d,string sql)
        {
            ds=c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(txtnhap.Text != "")
            //    {
                    chucnang(false);
                    xulytextbox(false);
                    cbTrang.SelectedIndex = 0;
                    txtnhap.Text = phatsinhma();
                    flag = 1;
            //    }
            //}
            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }
        void xulytextbox(Boolean t)
        {
            txtnhap.ReadOnly = t;
            cbTrang.SelectedIndex = 0;

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void chucnang(Boolean t)
        {
            btnthem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled =! t;
        }
        private void frmkichthuoc_Load(object sender, EventArgs e)
        {
            chucnang(true);
           danhscach_datagridview(dgvDanhSach, "select * from Size");
            hienthi_textbox(ds, vitri);
            f = true;
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
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            chucnang(true);
            xulytextbox(true);
            string sql = "";
            if (txtnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên size!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái size!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag == 1)
            {
                sql = "insert into Size values('" + txtnhap.Text + "',0)";
            }
            if (flag == 2)
            { 
                sql = "update Size set TrangThai=" + cbTrang.SelectedIndex + " where MaSize='" + txtnhap.Text+"'" ;
            }
            if(flag == 3)
            {
                sql="update Size set TrangThai=1 where MaSize='"+txtnhap.Text+"'";
            }
            if (c.Capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("cap nhat thanh cong");
                frmkichthuoc_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmkichthuoc_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }
        void hienthi_textbox(DataSet ds,int vitri)
        {
            txtnhap.Text = ds.Tables[0].Rows[vitri]["masize"].ToString();
            cbTrang.Text = ds.Tables[0].Rows[vitri]["trangthai"].ToString();
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri=e.RowIndex;
            hienthi_textbox(ds,vitri);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        //phatsinhma
        string phatsinhma()
        {
            //DataSet ds= new DataSet(); ko  cần lệ thuộc 
            string masize = "";
            masize = "S" + (ds.Tables[0].Rows.Count +1).ToString();
            return masize;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chucnang(true);
            danhscach_datagridview(dgvDanhSach, "select * from Size");
            hienthi_textbox(ds, vitri);
            f = true;
        }

        private void txtnhap_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int a=Convert.ToInt32(txtnhap.Text);
            //}
            //catch {
            //    MessageBox.Show("Lỗi");
            //}
        }
        Boolean f = false;
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vtp = dgvDanhSach.CurrentRow.Index;
                    string masize = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    //string tenmau = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    //string trangthai = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update Size set  TrangThai=0 where MaSize='" + masize + "';";
                    if (c.Capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cap nhat thanh cong");
                        vitri = 0;
                        frmkichthuoc_Load(sender, e);
                    }
                }

            }
        }
    }
}
