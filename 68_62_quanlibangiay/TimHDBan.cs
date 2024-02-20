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
    public partial class TimHDBan : Form
    {
        public TimHDBan()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaHDB = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        //void hienthicombobox2(ComboBox cbo, DataSet ds, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void TimHDBan_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from HoaDonBan");
            //dsMaHDB = c.LayDuLieu("select * from HoaDonBan");
            //hienthicombobox2(cbMaHDB, dsMaHDB, "MaHD");
            f = true;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonBan");
            txtHDon.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaHDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbMaHDB.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from HoaDonBan where MaHD=N'" + cbMaHDB.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void txtHDon_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonBan where MaHD like'%" + txtHDon.Text + "%'";
            danhscach_datagridview(dgvDanhSach,sql);
        }
    }
}
