using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public string cnicOfSelectedEmployee { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cnicOfSelectedEmployee.Length > 10)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
                conn.Open();
                SqlCommand comm;
                string query = "DELETE FROM Employee WHERE CNIC = " + cnicOfSelectedEmployee + ";";

                comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 form = new Form15();
            form.selectedEmployeeID = cnicOfSelectedEmployee;
            form.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form9 menu = new Form9();
            //menu.Show();
            Visible = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            id_value.Text = cnicOfSelectedEmployee;
        }
    }
}
