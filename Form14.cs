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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void insetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.Show();
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Show();
        }
    }
}
