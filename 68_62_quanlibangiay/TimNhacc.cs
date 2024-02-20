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
    public partial class TimNhacc : Form
    {
        public TimNhacc()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaNCC = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }


        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from NhaCungcap");

            txtNCC.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //void hienthicombobox2(ComboBox cbo, DataSet ds, string ten, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = ten;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void btnTrove_Click_1(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from NhaCungcap");
            txtNCC.Text = "";
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimNhacc_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from NhaCungcap");
            //dsMaNCC = c.LayDuLieu("select * from NhaCungcap");
            //hienthicombobox2(cbTenNcc, dsMaNCC, "TenNCC", "MaNCC");
            f = true;

        }

        private void cbTenNcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbTenNcc.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from NhaCungcap where TenNCC=N'" + cbTenNcc.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void txtNCC_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from NhaCungcap where TenNCC like '%" + txtNCC.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);
        }
    }
}
