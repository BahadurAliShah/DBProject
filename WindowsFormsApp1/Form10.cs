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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            avialableItems();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void avialableItems( )
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string query = "SELECT itm.*, ist.* FROM Items as itm, In_Store as ist WHERE itm.Item_ID = ist.Item_ID;";

            comm = new SqlCommand(query, conn);
            SqlDataReader result = comm.ExecuteReader();

            listBox1.Items.Clear();
            String empDetails = "{0, -20}{1, -20}{2, -30}";
            listBox1.Items.Add(String.Format(empDetails, "Item ID", "Total Items", "Price"));
            empDetails = "{0, -20}{1, -20}{2, -30}";
            while (result.Read())
            {
                listBox1.Items.Add(String.Format(empDetails, result[0].ToString(), result[1].ToString(), result[2].ToString()));
            }
            //comm.Dispose();
            conn.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
