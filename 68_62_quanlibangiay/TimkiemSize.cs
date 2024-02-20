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
    public partial class TimkiemSize : Form
    {
        public TimkiemSize()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void TimkiemSize_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from Size");
           // dsMasize = c.LayDuLieu("select * from Size");
            //hienthicombobox(cbSize, dsMasize, "MaSize");
            f = true;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from Size");
            txtMaSize.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet dsMasize = new DataSet();
        DataSet dsSize = new DataSet();
        //void hienthicombobox(ComboBox cbo, DataSet ds,string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //   //cbo.DisplayMember = ma; // Set DisplayMember property to 'ma'
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
      
        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (f)
            //{
            //    if (cbSize.SelectedIndex != -1)
            //    {
            //        //string tensize  = cbSize.SelectedIndex.ToString();
            //        string sql = "select * from Size where MaSize='" + cbSize.Text + "'";
            //        dsSize = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSize.Tables[0];

            //    }
            //}
        }

       

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql = "select * from Size where MaSize='" + txtMaSize.Text + "'";
            danhscach_datagridview(dgvDanhSach,sql);
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from Size");

        }

        private void btnTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtMaSize_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Size where MaSize like '%" + txtMaSize.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);

        }
    }
}
