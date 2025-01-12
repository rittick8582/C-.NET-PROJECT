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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True");
            con.Open();
            string searchQuery = "SELECT * FROM bus where sid='" + textBox1.Text + "'";
            SqlDataAdapter b = new SqlDataAdapter(searchQuery, con);
            DataSet c = new DataSet();
            b.Fill(c, "emp");
            if (c.Tables[0].Rows.Count != 0)
            {
                textBox2.Text = c.Tables[0].Rows[0].ItemArray[1].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(c.Tables[0].Rows[0].ItemArray[2]);
                dateTimePicker2.Value = Convert.ToDateTime(c.Tables[0].Rows[0].ItemArray[3]);
                textBox3.Text = c.Tables[0].Rows[0].ItemArray[4].ToString();


                con.Close();
             
        
            }
            else
            {
                MessageBox.Show("Record Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker2.Value = DateTime.Now;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
