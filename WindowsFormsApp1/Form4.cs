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
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            string q = "select Customer_Items.Item_ID, count(Customer_Items.Item_ID) as 'Amount Sold' from [dbo].[Customer_Items] join [dbo].[Sold] on Customer_Items.Sold_ID = Sold.Sold_ID group by Customer_Items.Item_ID order by 'Amount Sold' desc; ";
            SqlCommand cmd = new SqlCommand(q, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
     
        }
    }
}
