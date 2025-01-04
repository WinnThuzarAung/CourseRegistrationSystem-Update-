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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            /*SqlDataAdapter da = new SqlDataAdapter("select enroll.enroll_id,student.name,courses.course_name,levels.level_name,payment.date,payment.fees from student inner join enroll on student.studentid=enroll.studentid inner join levels on levels.level_id=enroll.level_id inner join courses on courses.course_id=levels.course_id inner join payment on payment.enroll_id=enroll.enroll_id", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            DataTable dt = new DataTable();
            dt = ds.Tables["student"];
            dataGridView1.DataSource = dt;
            con.Close();*/

            SqlDataAdapter da = new SqlDataAdapter("select enroll.enroll_id,student.name,courses.course_name,levels.level_name,sum(payment.fees) as fees,count(payment.enroll_id) as Duration_Months from student inner join enroll on student.studentid=enroll.studentid inner join levels on levels.level_id=enroll.level_id inner join courses on courses.course_id=levels.course_id inner join payment on payment.enroll_id=enroll.enroll_id group by enroll.enroll_id,student.name,courses.course_name,levels.level_name", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "enroll");
            DataTable dt = new DataTable();
            dt = ds.Tables["enroll"];
            dataGridView1.DataSource = dt;
            con.Close();

           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
           /* SqlDataAdapter da1 = new SqlDataAdapter("select * from levels", conn);*/
            SqlDataAdapter da1=new SqlDataAdapter("select levels.level_id,levels.level_name,courses.course_name,levels.duration_month,levels.fees from levels inner join courses on levels.course_id=courses.course_id",conn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "levels");
            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables["levels"];
            dataGridView2.DataSource = dt1;
            conn.Close();
        }
    }
}
