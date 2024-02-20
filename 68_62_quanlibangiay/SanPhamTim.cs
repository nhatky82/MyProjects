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
    public partial class SanPhamTim : Form
    {
        public SanPhamTim()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void SanPhamTim_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from SanPham");
            //dsMaSP = c.LayDuLieu("select * from SanPham");
            //hienthicombobox(cbSP, dsMaSP, "TenSP", "MaSP");
            f = true;
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from SanPham");
            txtSP.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet dsMaSP = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        //void hienthicombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = ten;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //tim();
        }
        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (f)
            //{
            //    if (cbSP.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from SanPham where TenSP=N'" + cbSP.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSP_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from SanPham where TenSP like'%" + txtSP.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);
        }
    }
}
