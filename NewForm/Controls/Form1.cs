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
    public partial class Form1 : Form
    {
        List<Level> level = new List<Level>();
        List<Course> course = new List<Course>();
        public Form1()
        {
            InitializeComponent();
        }

        private void nrc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into student (name,NRC,address,phone) values (@name,@NRC,@address,@phone)", con);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@NRC", nrc.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@phone", phone.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("select studentid from student where NRC like @nrc", con);
            cmd2.Parameters.AddWithValue("@nrc", nrc.Text);
            int id = Convert.ToInt16(cmd2.ExecuteScalar());

            Course course = (Course)comboBoxCourse.SelectedItem;
            Level level = (Level)comboBoxLevel.SelectedItem;
            SqlCommand cmd1 = new SqlCommand("insert into enroll(studentid,level_id) values (@studentid,@levelID)", con);

            cmd1.Parameters.AddWithValue("@studentid", (int)id);
            cmd1.Parameters.AddWithValue("@levelID", (int)level.id);
            cmd1.ExecuteNonQuery();



            SqlCommand cmd5 = new SqlCommand("select max(enroll_id) from enroll", con);
            int enroll_id = Convert.ToInt16(cmd5.ExecuteScalar());

            SqlCommand cmd4 = new SqlCommand("insert into payment(enroll_id,date,fees) values (@enroll_id,@date,@fees)", con);
            cmd4.Parameters.AddWithValue("@enroll_id", double.Parse(enrollid.Text));
            cmd4.Parameters.AddWithValue("@date", date.Value.Date);
            cmd4.Parameters.AddWithValue("@fees", double.Parse(fees.Text));
            cmd4.ExecuteNonQuery();
            MessageBox.Show("Registration Successful");
            this.Hide();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int pos = -1;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "select * from enroll";
            SqlCommand cm = new SqlCommand(query1, con);
            SqlDataReader drd = cm.ExecuteReader();
            
            string eno = "";
            while (drd.Read())
            {
                eno = drd[0].ToString();
                pos = Convert.ToInt16(eno);
            }
            if (pos != -1)
            {
                int roll = Convert.ToInt16(eno);
                pos = roll;
                int newroll = roll;
                newroll = newroll + 1;
                enrollid.Text = Convert.ToString(newroll);

            }


            else MessageBox.Show("Row Inserted failure");
            con.Close();


            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from courses", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = ((int)dr["course_id"]);
                string course_name = dr["course_name"] as string;
                comboBoxCourse.Items.Add(new Course(id, course_name));

                course.Add(new Course()
                {
                    id = ((int)dr["course_id"]),
                    course_name = dr["course_name"] as string,
                });

            }
            conn.Close();
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("select * from levels", conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                level.Add(new Level()
                {
                    id = ((int)dr1["level_id"]),
                    level_name = dr1["level_name"] as string,
                    course_id = ((int)dr1["course_id"]),

                });

            }
            conn.Close();
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Items.Clear();
            int id = course[comboBoxCourse.SelectedIndex].id;
            foreach (var l in level)
            {
                if (l.course_id == id)
                {
                    int level_id = l.id;
                    string level_name = l.level_name as string;
                    int course_id = l.course_id;

                    this.comboBoxLevel.Items.Add(new Level(level_id, level_name, course_id));

                }
            }
        }
            
             [Serializable]
        class Course
        {
            public int id { get; set; }
            public string course_name { get; set; }

            public Course()
            {

            }
            public Course(int id, string course_name)
            {
                this.id = id;
                this.course_name = course_name;
            }
            public override string ToString()
            {
                return course_name;
            }
        }
        [Serializable]
        class Level
        {
            public int id { get; set; }
            public string level_name { get; set; }
            public int course_id { get; set; }

            public Level()
            {

            }
            public Level(int id, string level_name, int course_id)
            {
                this.id = id;
                this.level_name = level_name;
                this.course_id = course_id;
            }
            public override string ToString()
            {
                return level_name;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void enrollid_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            int age;
            age = int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(date.Value.ToString("yyyy"));
            
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
