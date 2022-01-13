using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClassTest_Application
{
    public partial class selectExam : Form

    {
       // int count_ans = 0;
        string conn = "datasource=localhost;username=root;password=";
        //string q1ans = "";
        //string q2ans = "";
        //string q3ans = "";
        //string q4ans = "";
        //string q5ans = "";
        String emailadd;
        String username;
        public selectExam(String email, String use)
        {
            emailadd = email;
            username = use;
            InitializeComponent();
            DatabaseConnection();


        }

        public void DatabaseConnection()
        {
            MySqlConnection conn2 = new MySqlConnection(conn);
            string query = "Select * from class_test.s_mcq";
            string query2 = "Select * from class_test.student_login where username collate utf8_bin = '" + username + "'";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dtt = new DataTable();
            sda2.Fill(dtt);
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            emailadd = "";
            // MessageBox.Show(""+xyz);
            username = dt.Rows[0][1].ToString();
        }

        private void selectExam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exam_Paper exm = new Exam_Paper(emailadd, username);
            this.Hide();
            exm.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            ShortQ sq = new ShortQ(emailadd, username);
            this.Hide();
            sq.ShowDialog();
            Close();
        }
    }
}
