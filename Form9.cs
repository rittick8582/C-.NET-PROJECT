using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace school_management_system
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from library", con);
            DataTable dtb1 = new DataTable();
            sqlda.Fill(dtb1);
            dataGridView1.DataSource = dtb1;
            dataGridView1.Columns[0].HeaderText = "Student_ID";
            dataGridView1.Columns[1].HeaderText = "Card_No";
            dataGridView1.Columns[2].HeaderText = "Book_Name";
            dataGridView1.Columns[3].HeaderText = "Issue_Date";
            dataGridView1.Columns[4].HeaderText = "Submit_date";
            dataGridView1.Columns[5].HeaderText = "Total_Fine";
            textBox1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
