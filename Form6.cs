using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace school_management_system
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int val = 1;
        private void Form6_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            val = val + 1;
            if (val >= 170)
            {
                pictureBox1.Visible = false;
                timer1.Stop();
                val = 0;
                Form1 frm= new Form1();
                frm.Show();
                this.Hide();
            }
        }
    }
}
