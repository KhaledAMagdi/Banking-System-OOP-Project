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

namespace atmmmm
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private static string connection = "Data Source=El-3nteel\\SQLEXPRESS03;Initial Catalog=\"Banking info\";Integrated Security=True";
        private SqlConnection con = new SqlConnection(connection);

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f1 = new Welcome();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Random generator = new Random();
            var r = generator.Next(100000, 1000000);
            string s = r.ToString("000000");

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into info (Fname,Lname,Pin,Phone,Balance,Point,Cardnumber) values('"+textBox5.Text+"','"+ textBox4.Text + "','"+ textBox1.Text + "','"+ textBox3.Text + "','"+0+"','"+0+"','"+s+"')", con);
                
            cmd.ExecuteNonQuery();

            MessageBox.Show("Your card number is"+s);

            con.Close();

            this.Hide();
            Welcome f1 = new Welcome();
            f1.Show();

        }
    }
}
