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
    public partial class Form15 : Form
    {
        public string selectedEmployeeID { get; set; }
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string query = "SELECT Starting_date, F_name, L_name, E_shift, Salary, Manager_ID  FROM Employee AS E WHERE CNIC = " + selectedEmployeeID.ToString() + ";";

            comm = new SqlCommand(query, conn);
            SqlDataReader result = comm.ExecuteReader();

            cnic.Text = selectedEmployeeID.ToString();
            textBox2.Text = result[0].ToString();
            textBox1.Text = result[1].ToString();
            textBox3.Text = result[2].ToString();
            textBox4.Text = result[4].ToString();
            textBox5.Text = result[5].ToString();
            comboBox1.Text = result[3].ToString();

            //comm.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string query = "UPDATE table_name Starting_date = " + textBox2.Text.ToString() +" , F_name = "+textBox1.Text.ToString()+", L_name = "+textBox3.Text.ToString()+", E_shift = "+comboBox1.SelectedItem.ToString()+", Salary = "+textBox4.ToString()+", Manager_ID = "+textBox5.Text.ToString()+" WHERE CNIC = "+selectedEmployeeID+";";

            comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            Visible = false;
        }
    }
}
