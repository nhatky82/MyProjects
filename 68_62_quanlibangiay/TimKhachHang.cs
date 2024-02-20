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
    public partial class TimKhachHang : Form
    {
        public TimKhachHang()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMaKH = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void TimKhachHang_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from KhachHang");
            //dsMaKH = c.LayDuLieu("select * from KhachHang");
    
            //hienthicombobox2(cbPHONEKhachHang, dsMaKH, "SoPhone", "MaKH");
            f = true;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from KhachHang");
          
            txtKH.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        //void hienthicombobox2(ComboBox cbo, DataSet ds, string sophone, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = sophone;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}

       

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbPHONEKhachHang.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from KhachHang where SoPhone=N'" + cbPHONEKhachHang.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void txtKH_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where SoPhone like '%" + txtKH.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);
        }
    }
}
