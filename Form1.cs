using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace school_management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;



        }
        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "INSERT INTO login VALUES(@Param1, @Param2)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Param1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Param2", textBox2.Text);

                    cmd.ExecuteNonQuery();

                }
            }

            MessageBox.Show("SignUp successfully!");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";

            // Open connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    string mysql = "SELECT * FROM login WHERE username = @username AND pass = @password";

                    using (SqlCommand cmd = new SqlCommand(mysql, con))
                    {
                        // Add parameters with values
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            // Check if user exists
                            if (dr.Read())
                            {
                                // User found, show the new form
                                Form14 frm2 = new Form14();
                                frm2.Show();
                                this.Hide();
                            }
                            else
                            {
                                // User not found, show error message
                                MessageBox.Show("Wrong username or password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Text = "";
                                textBox2.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        
    

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

     
       
    }
}
