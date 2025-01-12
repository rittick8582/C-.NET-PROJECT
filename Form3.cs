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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxState();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxState();
        }
        private void UpdateTextBoxState()
        {
            if (checkBox1.Checked)
            {
                textBox10.Enabled = true;
                // Optionally, you can disable checkBox2 if checkBox1 is checked
                checkBox2.Enabled = false;
                // Ensure that checkBox2 is unchecked if it is checked
                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                }
            }
            else if (checkBox2.Checked)
            {
                textBox10.Enabled = false;
                // Optionally, you can disable checkBox1 if checkBox2 is checked
                checkBox1.Enabled = false;
                // Ensure that checkBox1 is unchecked if it is checked
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                // If neither checkBox1 nor checkBox2 is checked, disable the textBox
                textBox10.Enabled = false;
                // Optionally, re-enable both checkBox1 and checkBox2
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void UpdateTextBoxState_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxStat();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxStat();
        }
        private void UpdateTextBoxStat()
        {
            if (checkBox3.Checked)
            {
                textBox11.Enabled = true;
                // Optionally, you can disable checkBox2 if checkBox1 is checked
                checkBox4.Enabled = false;
                // Ensure that checkBox2 is unchecked if it is checked
                if (checkBox4.Checked)
                {
                    checkBox4.Checked = false;
                }
            }
            else if (checkBox4.Checked)
            {
                textBox11.Enabled = false;
                // Optionally, you can disable checkBox1 if checkBox2 is checked
                checkBox3.Enabled = false;
                // Ensure that checkBox1 is unchecked if it is checked
                if (checkBox3.Checked)
                {
                    checkBox3.Checked = false;
                }
            }
            else
            {
                // If neither checkBox1 nor checkBox2 is checked, disable the textBox
                textBox11.Enabled = false;
                // Optionally, re-enable both checkBox1 and checkBox2
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RO7KJEO\\SQLEXPRESS01;Initial Catalog=SCHOOL;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "INSERT INTO student VALUES(@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9, @Param10, @Param11)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Param1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Param2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Param3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Param4", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Param5", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Param6", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Param7", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Param8", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Param9", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Param10", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Param11", textBox11.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data inserted successfully!");
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from student", connectionString);
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

        private void button2_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


  
  

    }
}
        