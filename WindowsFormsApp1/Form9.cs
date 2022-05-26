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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            cnicList.Items.Clear();
            cnicList.Items.Add("temp");
            getRecords();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getRecords()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string query = "SELECT * FROM Employee WHERE E_shift IN ";

            string Conditions = "(''";
            if (checkBox1.Checked)
            {
                Conditions += ",'Night'";
            }
            if (checkBox2.Checked)
            {
                Conditions += ", 'Morning'";
            }
            if (checkBox3.Checked)
            {
                Conditions += ", 'Afternoon'";
            }
            Conditions += ");";

            comm = new SqlCommand(query+Conditions, conn);
            SqlDataReader result = comm.ExecuteReader();

            cnicList.Items.Clear();
            String empDetails = "{0, -40}{1, -35}{2, -30}{3, -25}{4, -16}{5, -25}";
            cnicList.Items.Add(String.Format(empDetails, "CNC", "Name", "Starting Date", "Shift", "Salary", "Manager ID"));
            empDetails = "{0, -25}{1, -25}{2, -30}{3, -25}{4, -16}{5, -25}";
            while (result.Read())
            {
                cnicList.Items.Add(String.Format(empDetails, result[0].ToString(), result[2].ToString()+ " " +result[3].ToString(), result[1].ToString(),
                     result[4].ToString(), result[5].ToString(), result[7].ToString()));
            }
            //comm.Dispose();
            conn.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Show();
            Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            getRecords();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            getRecords();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            getRecords();
        }
    }
}
