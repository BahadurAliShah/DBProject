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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string q = "select avg(Sold.Bill_amount) from Sold;";
            SqlCommand cmd;
            cmd = new SqlCommand(q, conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                textBox1.Text = dr1.GetValue(0).ToString();
            }
            dr1.Close();
            dr1.Dispose();
            q = "";
            q = "select [Carton (Warehouse)].Item_name, [Carton (Warehouse)].Warehouse_ID, (Items.Sale_Price - [Carton (Warehouse)].perprice) as Profit from Items join [Carton (Warehouse)] on Items.Item_ID = [Carton (Warehouse)].Item_ID order by Profit Desc;";
            cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            q = "";
            q = "select sum(Items.Sale_Price - [Carton (Warehouse)].perprice) from Items join [Carton (Warehouse)] on Items.Item_ID = [Carton (Warehouse)].Item_ID join Customer_Items on Items.Item_ID = Customer_Items.Item_ID;";
            cmd = new SqlCommand(q, conn);
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                textBox2.Text = dr2.GetValue(0).ToString();
            }
            dr2.Close();
            dr2.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }
    }
}
