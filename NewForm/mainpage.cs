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
    public partial class mainpage : Form
    {
       
        Form1 f1=new Form1();
        Form2 f2=new Form2();
        Form3 f3=new Form3();
        Form4 f4=new Form4();
        AddNewCourse add= new AddNewCourse();
        Default d = new Default();
       

        
        public mainpage()
        {
            InitializeComponent();
            AddingStartPanel();
        }

        public void myMessageBox(object str)
        {
            System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form { TopMost = true, Width = 500 }, str.ToString());
        }
        public void AddingStartPanel(){
            Default d = new Default();
            d.TopLevel = false;
            panel1.Controls.Add(d);
            d.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void mainpage_Load(object sender, EventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(f2);
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(f4);
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(f3);
            f3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Default d = new Default();
            d.TopLevel = false;
            panel1.Controls.Add(d);
            d.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(f1);
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int pos = -1;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CoursesRegirstration\my project\my project\myproject.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string nrc = textBox1.Text;

            string query = "select distinct student.studentid,student.name,courses.course_name,levels.level_name from student inner join enroll on student.studentid=enroll.studentid inner join levels on levels.level_id=enroll.level_id inner join courses on courses.course_id=levels.course_id inner join payment on payment.enroll_id=enroll.enroll_id where student.NRC='" + nrc + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();
            string msg = "";
            string rno = "";
            while (da.Read())
            {
                msg += da[1].ToString().PadRight(5) + "\t" + da[2].ToString().PadRight(5) + "\t" + da[3].ToString().PadRight(5) + "\n";
                rno = da[0].ToString();
                
                pos = int.Parse(rno);
           
            }
            if (pos != -1)
            {
                MessageBox.Show(msg);
                 }
                 else MessageBox.Show("Yours name is not found . Please register!!!!");
             

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddNewCourse add = new AddNewCourse();
            add.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(add);
            add.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeleteForm delete = new DeleteForm();
            delete.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(delete);
            delete.Show();
        }
    }
}
