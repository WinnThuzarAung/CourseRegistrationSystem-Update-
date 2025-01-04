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
    public partial class AddNewCourse : Form
    {
        public AddNewCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string cat = comboBox1.SelectedItem.ToString();
            SqlConnection conn=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd2 = new SqlCommand("select category_id from category where category_name like @categoryname", conn);
            cmd2.Parameters.AddWithValue("@categoryname",cat.ToString());
            int categoryid = Convert.ToInt16(cmd2.ExecuteScalar());

            SqlCommand cmd = new SqlCommand("insert into courses (course_name,category_id) values (@coursename,@categoryid)",conn);
            cmd.Parameters.AddWithValue("@coursename", coursename1.Text);
            cmd.Parameters.AddWithValue("@categoryid", (int)categoryid);
            cmd.ExecuteNonQuery();


            SqlCommand cmd3 = new SqlCommand("select course_id from courses where course_name like @coursename", conn);
            cmd3.Parameters.AddWithValue("@coursename",coursename1.Text);
            int courseid = Convert.ToInt16(cmd3.ExecuteScalar());


            SqlCommand cmd1 = new SqlCommand("insert into levels (level_name,course_id,fees,duration_month) values (@levelname,@courseid,@fees,@duration)", conn);
            cmd1.Parameters.AddWithValue("@levelname", levelname.Text);
            cmd1.Parameters.AddWithValue("@courseid", (int)courseid);
            cmd1.Parameters.AddWithValue("@fees", Fees.Text);
            cmd1.Parameters.AddWithValue("@duration", textBox3.Text);
            cmd1.ExecuteNonQuery();

            this.Hide();
           /* MessageBox.Show("Registration Successful");*/
            AddLevel adl = new AddLevel(this);
           
            adl.ShowDialog();
          
            conn.Close();
           


           
           

        }

        private void AddNewCourse_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query="select * from category";
            SqlCommand cm = new SqlCommand(query, con);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(1).ToString());
            }
            con.Close();


           
            con.Open();
            string query1 = "select * from courses";
            SqlCommand cm1 = new SqlCommand(query1, con);
            dr = cm1.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr.GetValue(1).ToString());
            }



            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string course = comboBox2.SelectedItem.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select course_id from courses where course_name like @name", conn);
            cmd.Parameters.AddWithValue("@name", course);
            int id = Convert.ToInt16(cmd.ExecuteScalar());

            string level = textBox1.Text;
            string fee = textBox2.Text;
            string duration = textBox4.Text;
            CourseInterface courseInterface = new CourseInterface();
            courseInterface.addlevel(id, level, fee,duration);
            MessageBox.Show("Level added successfully");
            this.Hide();
            



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
