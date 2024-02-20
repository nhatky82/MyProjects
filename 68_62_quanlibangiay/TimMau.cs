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
    public partial class TimMau : Form
    {
        public TimMau()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();

        DataSet ds;
        DataSet dsMau = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void danhscach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        } 
        private void TimMau_Load(object sender, EventArgs e)
        {
            //danhscach_datagridview(dgvDanhSach, "select * from Mau");
            //dsMau = c.LayDuLieu("select * from Mau");

            //hienthicombobox2(cbmau, dsMau, "TenMau", "MaMau");
            f = true;
        }
        //void hienthicombobox2(ComboBox cbo, DataSet ds, string ten, string ma)
        //{
        //    cbo.DataSource = ds.Tables[0];
        //    cbo.DisplayMember = ten;
        //    cbo.ValueMember = ma;
        //    cbo.SelectedIndex = -1;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            danhscach_datagridview(dgvDanhSach, "select * from Mau");
            txtMau.Text = "";
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbmau_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (f)
            //{
            //    if (cbmau.SelectedIndex != -1)
            //    {
            //        //string tensp = cbSP.SelectedIndex.ToString();
            //        string sql = "select * from Mau where TenMau=N'" + cbmau.Text + "'";
            //        dsSanPham = c.LayDuLieu(sql);
            //        dgvDanhSach.DataSource = dsSanPham.Tables[0];

            //    }
            //}
        }

        private void txtMau_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Mau where TenMau like '%" + txtMau.Text + "%'";
            danhscach_datagridview(dgvDanhSach, sql);
        }
    }
    //protected void bSP_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selectedValue = bSP.SelectedItem.Value;
    //    string query = "";

    //    switch (selectedValue)
    //    {
    //        case "tenSP":
    //            query = "SELECT * FROM SanPham WHERE TenSanPham LIKE '%" + keyword + "%'";
    //            break;
    //        case "loaiSP":
    //            query = "SELECT * FROM SanPham WHERE LoaiSanPham LIKE '%" + keyword + "%'";
    //            break;
    //        case "giaSP":
    //            query = "SELECT * FROM SanPham WHERE GiaSanPham = " + keyword;
    //            break;
    //        default:
    //            break;
    //    }

        // Thực hiện truy vấn và hiển thị kết quả tìm kiếm
        // ...
    //}

}
