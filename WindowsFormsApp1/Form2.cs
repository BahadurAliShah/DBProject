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
            bool valid = true;
            string custid = textBox1.Text.ToString();
            string query = "select Customer.*, Sold.Cust_ID, Sold.Sold_ID, Sold.Sold_Date, Sold.Bill_amount, Customer_Items.Quantity from [dbo].[Sold] join [dbo].[Customer_Items] on Sold.Sold_ID = Customer_Items.Sold_Id join Customer on Customer.ID = Sold.Cust_ID Where";
            if (custid.Length < 1)
            {
                MessageBox.Show("Entry field cannot be empty!");
                valid = false;
            }
            if (comboBox1.SelectedItem.ToString() == "Customer ID")
            {
                query += " Sold.Cust_ID = " + custid + ";";
            }else if (comboBox1.SelectedItem.ToString() == "Name")
            {
                query += " Customer.Name Like " + custid + ";";
            }
            else if (comboBox1.SelectedItem.ToString() == "CNIC")
            {
                query += " Customer.CNIC = " + custid + ";";
            }
            else if (comboBox1.SelectedItem.ToString() == "Phone No")
            {
                query += " Customer.Phone_No Like " + custid + ";";
            }
            //MessageBox.Show(query);
            
            if (valid)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader result = cmd.ExecuteReader();

                string res = result.Read().ToString();
                result.Close();
                result.Dispose();
                MessageBox.Show(res);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedItem.ToString()+":";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
