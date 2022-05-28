using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                input += "abc";
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        private string getRecords(string userName, string password)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VC0SEII\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            conn.Open();
            SqlCommand comm;
            string query = "SELECT * FROM Login WHERE userName = '"+userName+"' AND password = '"+password+"';";

            comm = new SqlCommand(query, conn);
            SqlDataReader result = comm.ExecuteReader();

            string res = result.Read().ToString();
            conn.Close();

            return res;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            password = password.Trim();
            userName = userName.Trim();
            textBox1.Text = userName;
            textBox2.Text = password;

            password = Hash(password);

            if (getRecords(userName, password) == "True")
            {
                Form3 menu = new Form3();
                menu.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password");
                textBox2.Text = "";
            }
        }

    }
}
