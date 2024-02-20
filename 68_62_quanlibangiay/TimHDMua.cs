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
    public partial class TimHDMua : Form
    {
        public TimHDMua()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaHDM = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        //void hienthicombobox2(ComboBox cbo, DataSet ds,string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbMaHD.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from HoaDonMua where MaHD=N'" + cbMaHD.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonMua");
            txtHdon.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimHDMua_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from HoaDonMua");
            //dsMaHDM = c.LayDuLieu("select * from HoaDonMua");
            //hienthicombobox2(cbMaHD, dsMaHDM,"MaHD");
            f = true;
        }

        private void txtHdon_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonMua where MaHD like '%" + txtHdon.Text + "%'";
            danhscach_datagridview(dgvDanhSach, "select * from HoaDonMua");
        }
    }
}
