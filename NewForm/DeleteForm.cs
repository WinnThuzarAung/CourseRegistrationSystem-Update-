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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace NewForm
{
    public partial class DeleteForm : Form
    {
        List<Level> level = new List<Level>();
        List<Course> course = new List<Course>();
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {





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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string course = comboBoxCourse.SelectedItem.ToString();
            string level= comboBoxLevel.SelectedItem.ToString();

            CourseInterface courseInterface = new CourseInterface();
            courseInterface.deleteLevel(level);
            MessageBox.Show("Successful Deleted!!");
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            string course = comboBoxCourse.SelectedItem.ToString();
            string level = comboBoxLevel.SelectedItem.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("update levels set fees=@fee where level_name='"+level+"'", conn);
            cmd3.Parameters.AddWithValue("@fee", Fees.Text);
            cmd3.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Updated");
            this.Hide();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string course = comboBoxCourse.SelectedItem.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select course_id from courses where course_name like @name", conn);
            cmd.Parameters.AddWithValue("@name", course);
            int id = Convert.ToInt16(cmd.ExecuteScalar());
            CourseInterface courseInterface = new CourseInterface();
            courseInterface.deletecourse(id, course);
            MessageBox.Show("Course deleted successful");
            this.Hide();

        }

        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    string course = comboBoxCourse.SelectedItem.ToString();
        //    //string level = comboBoxLevel.SelectedItem.ToString();
        //    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
        //    conn.Open();
        //    SqlCommand cmd3 = new SqlCommand("select course_id from courses where course_name like @coursename", conn);
        //    cmd3.Parameters.AddWithValue("@coursename", course);
        //    int courseid = Convert.ToInt16(cmd3.ExecuteScalar());
        //    SqlCommand cmd = new SqlCommand("delete from category where course_name='" + course + "'", conn);
        //    SqlCommand cmd1 = new SqlCommand("delete from courses where course_name='" + course + "'", conn);
        //    cmd1.ExecuteNonQuery();
        //    SqlCommand cmd2 = new SqlCommand("delete from levels where course_id='" + courseid + "'", conn);
        //    cmd2.ExecuteNonQuery();
        //    conn.Close();


        //}
    }
}
