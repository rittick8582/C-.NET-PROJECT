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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            string searchQuery = "SELECT * FROM student where sid='" + textBox1.Text + "'";
            SqlDataAdapter b = new SqlDataAdapter(searchQuery, con);
            DataSet c = new DataSet();
            b.Fill(c, "emp");
            if (c.Tables[0].Rows.Count != 0)
            {
                textBox2.Text = c.Tables[0].Rows[0].ItemArray[1].ToString();
                textBox3.Text = c.Tables[0].Rows[0].ItemArray[2].ToString();
                textBox4.Text = c.Tables[0].Rows[0].ItemArray[3].ToString();
                textBox5.Text = c.Tables[0].Rows[0].ItemArray[4].ToString();
                textBox6.Text = c.Tables[0].Rows[0].ItemArray[5].ToString();
                textBox7.Text = c.Tables[0].Rows[0].ItemArray[6].ToString();
                textBox8.Text = c.Tables[0].Rows[0].ItemArray[7].ToString();
                textBox9.Text = c.Tables[0].Rows[0].ItemArray[8].ToString();
                textBox10.Text = c.Tables[0].Rows[0].ItemArray[9].ToString();
                textBox11.Text = c.Tables[0].Rows[0].ItemArray[10].ToString();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record Not Found","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Text="";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
{         
               string connectionstring="Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";
    using (SqlConnection con = new SqlConnection(connectionstring))
    {
        con.Open();

        string updateQuery = "UPDATE student SET sname=@sname, fname=@fname, addre=@addre, phone=@phone, vid=@vid, class=@class, rollno=@rollno, sec=@sec, libcard=@libcard, bus=@bus WHERE sid=@sid";

        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
        {
            cmd.Parameters.AddWithValue("@sname", textBox2.Text);
            cmd.Parameters.AddWithValue("@fname", textBox3.Text);
            cmd.Parameters.AddWithValue("@addre", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@vid", textBox6.Text);
            cmd.Parameters.AddWithValue("@class", textBox7.Text);
            cmd.Parameters.AddWithValue("@rollno", textBox8.Text);
            cmd.Parameters.AddWithValue("@sec", textBox9.Text);
            cmd.Parameters.AddWithValue("@libcard", textBox10.Text);
            cmd.Parameters.AddWithValue("@bus", textBox11.Text);
            cmd.Parameters.AddWithValue("@sid", textBox1.Text);

            cmd.ExecuteNonQuery();
        }
    }

    MessageBox.Show("Update Successfully", "Active Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    SqlDataAdapter sqlda = new SqlDataAdapter("select * from student",connectionstring);
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
}
catch (Exception ex)
{
    MessageBox.Show("Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
   
}
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

       
    }
}
