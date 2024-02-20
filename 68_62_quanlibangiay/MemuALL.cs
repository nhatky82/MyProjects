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
    public partial class MemuALL : Form
    {
        public MemuALL()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelNhapHangSubMenu.Visible = false;
            panelTimKiemSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if(panelNhapHangSubMenu.Visible == true)
                panelNhapHangSubMenu.Visible = false;
            if (panelTimKiemSubMenu.Visible == true)
                panelTimKiemSubMenu.Visible = false;

        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhapHangSubMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openChildFormInPanel(new frmkichthuoc());
            frmkichthuoc f=new frmkichthuoc();
            f.Show();
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new mau());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new NhanVien());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new KhachHang());
            hideSubMenu();
        }

        private void panelNhapHangSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new sanpham());
            hideSubMenu();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTimKiemSubMenu);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimkiemSize());
            hideSubMenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimMau());
            hideSubMenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new SanPhamTim());
            hideSubMenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimKhachHang());
            hideSubMenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimNhanVien());
            hideSubMenu();
        }
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Controls.Add(childForm);
            Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new LoaiSP());
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new NhaCungcap());
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new HoaDonBan());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new HoaDonMua());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new SanPham_CTSP());
            hideSubMenu();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimNhacc());
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimLoaiSP());
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimHDBan());
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TimHDMua());
            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        private void MemuALL_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
