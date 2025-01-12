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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            string deleteQuery="delete from student where sid='"+textBox1.Text+"'";
                SqlCommand cmd=new SqlCommand(deleteQuery,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Are Deleted Succesfully!!", "Active Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from student", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);
                dataGridView1.DataSource = dtb1;
                dataGridView1.Columns[0].HeaderText = "Student_ID";
                dataGridView1.Columns[1].HeaderText = "Student_Name";
                dataGridView1.Columns[2].HeaderText = "Father's_Name";
                dataGridView1.Columns[3].HeaderText = "Address";
                dataGridView1.Columns[4].HeaderText = "Phone";
                dataGridView1.Columns[5].HeaderText = "Voter_Id";
                dataGridView1.Columns[6].HeaderText = "Class";
                dataGridView1.Columns[7].HeaderText = "Roll_No";
                dataGridView1.Columns[8].HeaderText = "Section";
                dataGridView1.Columns[9].HeaderText = "Library_Card";
                dataGridView1.Columns[10].HeaderText = "Bus";
                con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
