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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int itemid = int.Parse(textBox1.Text);
            int custid = int.Parse(textBox2.Text);
            string custname = textBox3.Text;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string q = "update In_Store SET Quantity = Quantity - 1 WHERE Item_ID = " + itemid + " AND Quantity > 0;";
            SqlCommand cmd;
            cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            q = " ";
            q = "select Sale_Price from Items where Item_ID = " + itemid + ";";
            cmd = new SqlCommand(q, conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                label5.Text = dr1.GetValue(0).ToString();
            }
            q = " ";
            q = "Select top 1 Sold_ID from Sold ORDER BY Sold_ID DESC";
            cmd.Dispose();
            dr1.Close();
            dr1.Dispose();
            cmd = new SqlCommand(q, conn);
            SqlDataReader dr2 = cmd.ExecuteReader();
            int soldid=0;
            if (dr2.Read())
            {
                soldid = int.Parse(dr2.GetValue(0).ToString());
            }
            dr2.Close();
            dr2.Dispose();
            soldid += 1;
            q = " ";
            q = "Insert into Sold values (" + soldid + ", (SELECT CAST( GETDATE() AS Date )), " + int.Parse(label5.Text) + ", " + int.Parse(label5.Text) + ", 1450, " + custid + ");";
            cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Transaction Successful \nSold ID : "+soldid);
            cmd.Dispose();
            conn.Close();
        }
    }
}
