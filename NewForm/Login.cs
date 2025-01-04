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

namespace NewForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
         
             string query = "select count(*) from login where username ='"+textBox1.Text+"' and password = '"+textBox2.Text+"'";
             SqlCommand cmd = new SqlCommand(query, conn);
            
                 
                 if (textBox1.Text == "Admin" && textBox2.Text=="admin@12345")
                 {
                     new mainpage().Show();
                     this.Hide();
                 }
                 else if (textBox1.Text == "Win Thuzar Aung" && textBox2.Text == "genius@123")
                 {
                     new mainpage().Show();
                     this.Hide();

                 }
                 else if (textBox1.Text == "Myo Sandar Aye" && textBox2.Text == "myo@222")
                 {
                     new mainpage().Show();
                     this.Hide();

                 }
                 else
                 {
                     MessageBox.Show("Username or password is not correct!,try again");
                     textBox1.Clear();
                     textBox2.Clear();
                     textBox1.Focus();
                 }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
