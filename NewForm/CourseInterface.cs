using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace NewForm
{
    internal class CourseInterface

    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
        public void deleteLevel(string levelname)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd1 = new SqlCommand("delete from levels where level_name='" + levelname + "'", conn);

            cmd1.ExecuteNonQuery();
            conn.Close();
        }
        public void addlevel(int course_id, string levelname, string fee,string duration)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("insert into levels (level_name,course_id,fees,duration_month) values (@levelname,@courseid,@fees,@duration)", conn);
            cmd1.Parameters.AddWithValue("@levelname", levelname);
            cmd1.Parameters.AddWithValue("@courseid", (int)course_id);
            cmd1.Parameters.AddWithValue("@fees", fee);
            cmd1.Parameters.AddWithValue("@duration", duration);
            cmd1.ExecuteNonQuery();
            conn.Close();

        }
        public void deletecourse(int id, string name)
        {
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("delete from levels where course_id like @id", conn);
            cmd2.Parameters.AddWithValue("@id", (int)id);
            cmd2.ExecuteNonQuery();


            SqlCommand cmd1 = new SqlCommand("delete from courses where course_name like @cname", conn);
            cmd1.Parameters.AddWithValue("@cname", name);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
