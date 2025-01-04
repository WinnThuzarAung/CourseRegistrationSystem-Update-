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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string nrc = textBox1.Text;

            string query = "select student.NRC,enroll.enroll_id,student.name,courses.course_name,levels.level_name,payment.date,payment.fees from student inner join enroll on student.studentid=enroll.studentid inner join levels on levels.level_id=enroll.level_id inner join courses on courses.course_id=levels.course_id inner join payment on payment.enroll_id=enroll.enroll_id where student.NRC='" + nrc + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            DataTable dt = new DataTable();
            dt = ds.Tables["student"];
            date.DataSource = dt;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            

            SqlCommand cmd1 = new SqlCommand("insert into payment(enroll_id,date,fees) values (@enroll_id,@date,@fees)", con);
            cmd1.Parameters.AddWithValue("@enroll_id", double.Parse(enrollid.Text));
            cmd1.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd1.Parameters.AddWithValue("@fees", double.Parse(fees.Text));
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Payment Successful");
            this.Hide();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string query = "select distinct student.NRC,enroll.enroll_id,student.name,courses.course_name,levels.level_name,payment.date,payment.fees from student inner join enroll on student.studentid=enroll.studentid inner join levels on levels.level_id=enroll.level_id inner join courses on courses.course_id=levels.course_id inner join payment on payment.enroll_id=enroll.enroll_id ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            DataTable dt = new DataTable();
            dt = ds.Tables["student"];
            date.DataSource = dt;
            con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age;
            age = int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(dateTimePicker1.Value.ToString("yyyy"));
        }
    }
}
