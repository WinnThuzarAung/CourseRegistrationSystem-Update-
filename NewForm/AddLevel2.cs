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
using System.Reflection.Emit;

namespace NewForm
{
    public partial class AddLevel2 : Form
    {
        AddLevel adf;
        public AddLevel2(AddLevel add)
        {
            InitializeComponent();
            this.adf = add;
        }

        private void AddLevel2_Load(object sender, EventArgs e)
        {
            coursename.Text = adf.coursename.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select course_id from courses where course_name like @coursename", con);
            cmd3.Parameters.AddWithValue("@coursename", coursename.Text);
            int courseid = Convert.ToInt16(cmd3.ExecuteScalar());
            string level = levelname.Text;
            string fee = fees.Text;
            string duration = textBox1.Text;
            CourseInterface courseInterface = new CourseInterface();
            courseInterface.addlevel(courseid, level, fee, duration);
            MessageBox.Show("Successful New level added!!");
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select course_id from courses where course_name like @coursename", con);
            cmd3.Parameters.AddWithValue("@coursename", coursename.Text);
            int courseid = Convert.ToInt16(cmd3.ExecuteScalar());
            string level = levelname.Text;
            string fee = fees.Text;
            string duration = textBox1.Text;
            CourseInterface courseInterface = new CourseInterface();
            courseInterface.addlevel(courseid, level, fee,duration);
            MessageBox.Show("Successful New level added!!");
            this.Hide();

            AddLevel3 adl3 = new AddLevel3(this);
            adl3.ShowDialog();
            con.Close();


        }
    }
}
