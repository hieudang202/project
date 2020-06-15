using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI2_QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C1VSI5K;Initial Catalog=THIQLSV;Integrated Security=True");
            try
            {

                con.Open();    
                string tendn = txtTDN.Text;
                string pass = txtMK.Text;
                string sql = "select* from taikhoan where  TenDN='" + tendn + "' and MK='" + pass + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    sinhvien f = new sinhvien();
                    f.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu chưa đúng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    txtTDN.Clear();
                    txtMK.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
