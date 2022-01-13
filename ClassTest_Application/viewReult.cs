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
    public partial class viewResult : Form
    {
        string conn = "datasource=localhost;database=class_test;username=root;password=";
        string path = "";
        public viewResult()
        {
            InitializeComponent();
        }

        private void viewResult_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showResult_Click(object sender, EventArgs e)
        {

        }

        private void showResult_Click_1(object sender, EventArgs e)
        {
            
            MySqlConnection conn2 = new MySqlConnection(conn);
            string query = "SELECT first_name, last_name, marksw, marksm FROM student_login";
            conn2.Open();
            dataGridView1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn2);
            DataTable dtbl = new DataTable();
            adapter.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            conn2.Close();
       
        }
    }
}
