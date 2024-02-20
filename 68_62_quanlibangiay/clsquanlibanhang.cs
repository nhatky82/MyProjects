using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _68_62_qunalibangiay
{
    internal class clsquanlibanhang
    {
        SqlConnection con = new SqlConnection();
        void ketnoi()
        {
            con.ConnectionString = @"Data source=LAPTOP-IR23TF7L;Initial Catalog=quanlibangiay1;integrated Security=True";
            if (con.State==ConnectionState.Closed) con.Open();
        }
        void dongketnoi()
        {
            con.Close();
        }
        public clsquanlibanhang() { 
         ketnoi();
        }
        public DataSet LayDuLieu(string sql)
        {
            DataSet ds= new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(ds);
            return ds;  
        }
        public int Capnhatdulieu(string sql)
        {
            SqlCommand cmd= new SqlCommand(sql,con);
            cmd.CommandText= sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection= con;
            return cmd.ExecuteNonQuery();
        }

    }
}
