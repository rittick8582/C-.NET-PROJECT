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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "INSERT INTO library VALUES(@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Param1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Param2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Param3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Param4", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Param5", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@Param6",textBox4.Text);
                    
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data inserted successfully!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from library", connectionString);
            DataTable dtb1 = new DataTable();
            sqlda.Fill(dtb1);
            dataGridView1.DataSource = dtb1;
            dataGridView1.Columns[0].HeaderText = "Student_ID";
            dataGridView1.Columns[1].HeaderText = "Card_No";
            dataGridView1.Columns[2].HeaderText = "Book_Name";
            dataGridView1.Columns[3].HeaderText = "Issue_Date";
            dataGridView1.Columns[4].HeaderText = "Submit_date";
            dataGridView1.Columns[5].HeaderText = "Total_Fine";
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
