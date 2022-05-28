using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 empmenu = new Form11();
            empmenu.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string q = "insert into Employee values";
            double CNIC = double.Parse(textBox1.Text);
            string s_date = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            string shift = textBox5.Text;
            int salary = int.Parse(textBox6.Text);
            int storeid = int.Parse(textBox7.Text);
            double mgrid = double.Parse(textBox8.Text);
            string query = q + "(" + CNIC + ", CONVERT( date, '" + s_date + "'), '" + fname + "', '" + lname + "', '" + shift + "', " + salary + ", " + storeid + ", " + mgrid + ");";
            SqlCommand cmd;
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Inserted Entry");
        }
    }
}
