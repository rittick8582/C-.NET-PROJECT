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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            string searchQuery = "SELECT * FROM library where sid='" + textBox1.Text + "'";
            SqlDataAdapter b = new SqlDataAdapter(searchQuery, con);
            DataSet c = new DataSet();
            b.Fill(c, "emp");
            if (c.Tables[0].Rows.Count != 0)
            {
                textBox2.Text = c.Tables[0].Rows[0].ItemArray[1].ToString();
                textBox3.Text = c.Tables[0].Rows[0].ItemArray[2].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(c.Tables[0].Rows[0].ItemArray[3]);
                dateTimePicker2.Value = Convert.ToDateTime(c.Tables[0].Rows[0].ItemArray[4]);
                textBox4.Text = c.Tables[0].Rows[0].ItemArray[5].ToString();
               
                
                con.Close();
            }
            else
            {
                MessageBox.Show("Record Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    string updateQuery = "UPDATE library SET cadno=@sname, bname=@fname, isdate=@addre, subdate=@phone, tofine=@vid where sid=@sid";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@sname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@fname", textBox3.Text);
                        cmd.Parameters.AddWithValue("@addre", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@phone", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@vid", textBox4.Text);
                        cmd.Parameters.AddWithValue("@sid", textBox1.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Update Successfully", "Active Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from library", connectionstring);
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
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox4.Text = "";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
