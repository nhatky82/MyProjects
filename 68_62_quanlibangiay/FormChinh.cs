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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        private void sdBVsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkichthuoc f = new frmkichthuoc();
            //f.MdiParent= this;
            f.Show();
           
        }

        private void nhậpHnagfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormChinh_Load(object sender, EventArgs e)
        {

        }

        private void dvdsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mau m= new mau();   
            m.MdiParent= this;
            m.Show();
        }

        private void btnThaotFChinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void sanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sanpham f = new sanpham();
            f.MdiParent= this;
            f.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiSP l=new LoaiSP();
            l.MdiParent= this;
            l.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungcap ncc=new NhaCungcap();
            ncc.MdiParent= this;
            ncc.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb=new HoaDonBan();
            hdb.MdiParent= this;
            hdb.Show();
        }

        private void hóaĐƠnMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonMua hdm=new HoaDonMua();
            hdm.MdiParent= this;
            hdm.Show();
        }

        private void sdvdvsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nv=new NhanVien(); 
            nv.MdiParent= this;
            nv.Show();
        }

        private void vsdvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang kh=new KhachHang();
            kh.MdiParent= this;
            kh.Show();
        }

        private void FormChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có chắc muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
             if(dialogResult==DialogResult.Cancel)
                e.Cancel = true;

        }

        private void tìmKiếmSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimkiemSize tk=new TimkiemSize();
            tk.MdiParent= this;
            tk.Show();
        }

        private void tìmKiếmMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimMau tm=new TimMau();
            tm.MdiParent= this;
             tm.Show();
        }

        private void timToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPhamTim t=new SanPhamTim();
            t.MdiParent= this;
            t.Show();
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size s=new size();
            s.MdiParent= this;
            s.Show();
        }

        private void tìmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKhachHang timkh=new TimKhachHang();
            timkh.MdiParent= this;
            timkh.Show();
        }

        private void tìmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimNhanVien timnv = new TimNhanVien();
            timnv.MdiParent = this;
            timnv.Show();
        }

        private void tìmNhàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimNhacc ncctim=new TimNhacc();
            ncctim.MdiParent= this;
            ncctim.Show();
        }

        private void tìmLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimLoaiSP timLoaiSP=new TimLoaiSP();
            timLoaiSP.MdiParent= this;
            timLoaiSP.Show();
        }

        private void tìmHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimHDBan timHDBan=new TimHDBan();
            timHDBan.MdiParent= this;
            timHDBan.Show();

        }

        private void tìmHóaĐơnMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimHDMua timHDMua= new TimHDMua(); 
            timHDMua.MdiParent=this;
            timHDMua.Show();
        }

        private void chiTiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPham_CTSP ctsp=new SanPham_CTSP();
            ctsp.MdiParent= this;
            ctsp.Show();
        }
    }
}