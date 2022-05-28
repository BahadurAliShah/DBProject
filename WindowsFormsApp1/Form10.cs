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
            string query = "SELECT itm.item_ID, crt.item, crt.perPrice, ist.Quantity, itm.Sale_Price FROM Items as itm, In_Store as ist, Carton as crt WHERE itm.Item_ID = ist.Item_ID AND itm.item_ID = crt.item_ID;";

            comm = new SqlCommand(query, conn);
            SqlDataReader result = comm.ExecuteReader();

            listBox1.Items.Clear();
            String empDetails = "{0, 0}{1, 45}{2, 45}{3, 30}";
            listBox1.Items.Add(String.Format(empDetails, "Item ID", "Name", "Remaining Items", "Price"));

            while (result.Read())
            {
                empDetails = "{0, 5}{1, 50}{2, "+(80 - result[1].ToString().Length - 30)+"}{3,40}";
                listBox1.Items.Add(String.Format(empDetails, result[0].ToString(), result[1].ToString(), result[3].ToString(), result[2].ToString()));
            }
            //comm.Dispose();
            conn.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }
    }
}
