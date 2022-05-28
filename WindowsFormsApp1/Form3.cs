using System;
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
            Form11 empshift = new Form11();
            empshift.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 storeItems = new Form10();
            storeItems.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 history = new Form2();
            history.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form13 genbill = new Form13();
            genbill.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 topsold = new Form4();
            topsold.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 low_stock = new Form5();
            low_stock.Show();
            Visible = false;
        }
    }
}
