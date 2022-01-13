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
    public partial class ShortQ : Form
    {


       // int count_ans = 0;
        String emailadd;
        String username;
        string conn = "datasource=localhost;username=root;password=";
        string q1ans = "";
        string q2ans = "";
        string q3ans = "";
        string q4ans = "";
        string q5ans = "";
        int marks = 0;
        int q1id = 0, q2id = 0, q3id = 0, q4id = 0, q5id = 0;


        public ShortQ(String email, String use)
        {
            InitializeComponent();
            emailadd = email;
            username = use;
            connectToDatabase();
        }


        public void connectToDatabase()
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
            if (dt.Rows.Count < 5)
            {
                MessageBox.Show("Insufficient Questions in database");
                return;
            }
            q1id = Convert.ToInt32(dt.Rows[0][0].ToString());
            q2id = Convert.ToInt32(dt.Rows[1][0].ToString());
            q3id = Convert.ToInt32(dt.Rows[2][0].ToString());
            q4id = Convert.ToInt32(dt.Rows[3][0].ToString());
            q5id = Convert.ToInt32(dt.Rows[4][0].ToString());
            
            q1.Text = dt.Rows[0][1].ToString();
            q1ans = dt.Rows[0][2].ToString();
            qans1.Text = q1ans;

            q2.Text = dt.Rows[1][1].ToString();
            q2ans = dt.Rows[1][2].ToString();
            qans2.Text = q2ans;

            q3.Text = dt.Rows[2][1].ToString();
            q3ans = dt.Rows[2][2].ToString();
            qans3.Text = q3ans;

            q4.Text = dt.Rows[3][1].ToString();
            q4ans = dt.Rows[3][2].ToString();
            qans4.Text = q4ans;

            q5.Text = dt.Rows[4][1].ToString();
            q5ans = dt.Rows[4][2].ToString();
            qans5.Text = q5ans;

            
            
            /*

            //update student in q_paper
            MySqlConnection conn3 = new MySqlConnection(conn);
            string query_update = "UPDATE class_test.q_paper set student_id = "+student_login.id+" where id in ("+q1id+","+q2id+","+q3id+","+q4id+","+q5id+" )  ";
            MySqlCommand cmd2 = new MySqlCommand(query_update, conn3);
            MySqlDataReader reader;
            conn3.Open();
            reader = cmd2.ExecuteReader();
           // MessageBox.Show("Registration Complete!");
            conn3.Close();
            */

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Qu1_Click(object sender, EventArgs e)
        {

        }

        private void ans_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ShortQ_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {

            enDOfExam();
            panelname.Show();

        }

        private void enDOfExam()
        {
            if (String.Compare(ans1.Text, q1ans) == 0) marks++;
            if (String.Compare(ans2.Text, q2ans) == 0) marks++;
            if (String.Compare(ans3.Text, q3ans) == 0) marks++;
            if (String.Compare(ans4.Text, q4ans) == 0) marks++;
            if (String.Compare(ans5.Text, q5ans) == 0) marks++;

            MessageBox.Show("You Got!" + marks);

            MySqlConnection conn3 = new MySqlConnection(conn);
            string query_update = "UPDATE class_test.student_login set marksw = " + marks + " where id = " + student_login.id + " ";
            MySqlCommand cmd2 = new MySqlCommand(query_update, conn3);
            MySqlDataReader reader;
            conn3.Open();
            reader = cmd2.ExecuteReader();
            // MessageBox.Show("Registration Complete!");
            conn3.Close();
            
        }
    }
}
