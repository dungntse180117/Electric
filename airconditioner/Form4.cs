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
using System.Xml.Linq;

namespace Electric
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source=.;initial catalog = Electric;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pass = txtPass.Text;
            string email = txtEmail.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "INSERT INTO customers (FullName, Password, EmailAddress) VALUES (@FullName, @Password, @EmailAddress)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.Parameters.AddWithValue("@EmailAddress", email);
     

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Account create successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 mainPage = new Form3();
            mainPage.Show();
            this.Hide();
        }
    }
}
