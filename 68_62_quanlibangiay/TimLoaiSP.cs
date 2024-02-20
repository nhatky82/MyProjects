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
    public partial class TimLoaiSP : Form
    {
        public TimLoaiSP()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaLoai = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        //void hienthicombobox2(ComboBox cbo, DataSet ds, string ten, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = ten;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void cbTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbTenLoai.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from LoaiSP where TenLoai=N'" + cbTenLoai.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from TenLoai");

            txtLoaiSP.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimLoaiSP_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from LoaiSP");
            //dsMaLoai = c.LayDuLieu("select * from LoaiSP");
            //hienthicombobox2(cbTenLoai, dsMaLoai, "TenLoai", "MaLoai");
            f = true;
        }

        private void txtLoaiSP_TextChanged(object sender, EventArgs e)
        {
             string sql = "select * from LoaiSP where TenLoai like'%" + txtLoaiSP.Text + "%'";
             danhscach_datagridview(dgvDanhSach, sql);
        }
    }
}
