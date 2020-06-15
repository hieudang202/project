using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI2_QLSV
{
    public partial class sinhvien : Form
    {
        static string conString = ConfigurationManager.ConnectionStrings["BAI2_QLSV"].ConnectionString.ToString();
        SqlConnection conn = new SqlConnection(conString);
        public sinhvien()
        {
            InitializeComponent();
        }
        private void ketnoi()
        {

            string sqlSelect = "Select *from sinhvien";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);


            DataView dv = dt.DefaultView;
            dv.Sort = "ID ASC";
            dt = dv.ToTable();
            dataGridView1.DataSource = dt;
        }


        private void sinhvien_Load(object sender, EventArgs e)
        {
            conn.Open();
            ketnoi();
        }

        [Obsolete]
        private void btthem_Click(object sender, EventArgs e)
        {
            string sqlInsert = "Insert into sinhvien values (@ID,@MaSV,@Hovaten,@Lop,@Ngaysinh)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.Parameters.Add("@ID", txtID.Text);
            cmd.Parameters.Add("@MaSV", txtMSV.Text);
            cmd.Parameters.Add("@Hovaten", txtHT.Text);
            cmd.Parameters.Add("@Lop", txtL.Text);
            cmd.Parameters.Add("@Ngaysinh", txtNS.Text);
            cmd.ExecuteNonQuery();
            ketnoi();

        }

        [Obsolete]
        private void btsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatesinhvien";
            cmd.Parameters.Add("@ID", txtID.Text);
            cmd.Parameters.Add("@MaSV", txtMSV.Text);
            cmd.Parameters.Add("@Hovaten", txtHT.Text);
            cmd.Parameters.Add("@Lop", txtL.Text);
            cmd.Parameters.Add("@Ngaysinh", txtNS.Text);
            cmd.ExecuteNonQuery();
            ketnoi();
        }

        [Obsolete]
        private void btxoa_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM sinhvien WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(sqlDELETE, conn);
            cmd.Parameters.Add("@ID", txtID.Text);
            cmd.Parameters.Add("@MaSV", txtMSV.Text);
            cmd.Parameters.Add("@Hovaten", txtHT.Text);
            cmd.Parameters.Add("@Lop", txtL.Text);
            cmd.Parameters.Add("@Ngaysinh", txtNS.Text);
            cmd.ExecuteNonQuery();
            ketnoi();            
        }
    }
}
