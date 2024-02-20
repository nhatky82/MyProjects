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
    public partial class TimNhanVien : Form
    {
        public TimNhanVien()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaNV = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
       

        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from NhanVien");

            txtPhoneNV.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //void hienthicombobox2(ComboBox cbo, DataSet ds, string phone, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = phone;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}

        private void cbTenNV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbPhoneNV.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from NhanVien where Phone=N'" + cbPhoneNV.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void TimNhanVien_Load_1(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from NhanVien");
            //dsMaNV = c.LayDuLieu("select * from NhanVien");
            //hienthicombobox2(cbPhoneNV, dsMaNV, "Phone","MaNV");
            f = true;
        }

        private void btnTrove_Click_1(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from NhanVien");
            txtPhoneNV.Text = "";
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhoneNV_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from NhanVien where Phone like '%" + txtPhoneNV.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);
        }
    }
}
