﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 shifts = new Form9();
            shifts.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 addemp = new Form12();
            addemp.Show();
            Visible = false;
        }
    }
}