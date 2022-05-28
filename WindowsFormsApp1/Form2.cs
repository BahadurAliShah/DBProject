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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int custid = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            double cnic = double.Parse(textBox3.Text);
            string number = textBox4.Text;
            string q = "select Sold.Cust_ID, Sold.Sold_ID, Sold.Sold_Date, Sold.Bill_amount, Customer_Items.Quantity from [dbo].[Sold] join [dbo].[Customer_Items] on Sold.Sold_ID = Customer_Items.Sold_Id where Sold.Cust_ID = " + custid + ";";
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
