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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            string deleteQuery = "delete from library where sid='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Are Deleted Succesfully!!", "Active Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
