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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 empshift = new Form9();
            empshift.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 storeItems = new Form10();
            storeItems.Show();
            Visible = false;
        }
    }
}
