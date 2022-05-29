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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QOMIT9\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True"))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select In_Store.*, [Carton (Warehouse)].Item_Name from In_Store join [Carton (Warehouse)] on In_Store.Item_ID = [Carton (Warehouse)].Item_ID where In_Store.Quantity < 5;", conn);
                DataTable dbl = new DataTable();
                da.Fill(dbl);
                dataGridView1.DataSource = dbl;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.In_Store' table. You can move, or remove it, as needed.
            this.in_StoreTableAdapter.Fill(this.projectDataSet.In_Store);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
