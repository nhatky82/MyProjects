using System;
using System.Collections;
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
    public partial class size : Form
    {
        public size()
        {
            InitializeComponent();
        }
        clsquanlibanhang c=new clsquanlibanhang();
        DataSet dsSize= new DataSet();
        public ArrayList dschonsize= new ArrayList();
        private void button2_Click(object sender, EventArgs e)
        {
            //phatsinhma();
        }
        //string phatsinhma()
        //{
           
        //}
        private void size_Load(object sender, EventArgs e)
        {
            dsSize = c.LayDuLieu("select * from Size where TrangThai=0");
            for(int i = 0; i < dsSize.Tables[0].Rows.Count; i++)
            {
                CheckBox chk= new CheckBox();
                chk.Name = dsSize.Tables[0].Rows[i]["MaSize"].ToString();
                chk.Text = dsSize.Tables[0].Rows[i]["MaSize"].ToString();
                flpSize.Controls.Add(chk);  
            }
        }

        private void flpSize_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            
            foreach (CheckBox chk in flpSize.Controls) {
                if (chk.Checked) { 
                    dschonsize.Add(chk);
                }
            }
        }
    }
}
