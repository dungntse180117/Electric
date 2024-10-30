using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using Electric;

namespace Electric
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string name = txtid.Text;
            string password = txtpassword.Text;
            
            if (ValidateUser(name, password, out bool isStaff))
            {
                if (isStaff)
                {
                    Form2 staffPage = new Form2();
                    staffPage.Show();
                }
                else
                {
                    Form5 customerPage = new Form5();
                    customerPage.Show();
                }
                this.Hide();
            }
            else
            {
                // Show an error message
                MessageBox.Show("Invalid User ID or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Validate user credentials
        private bool ValidateUser(string userId, string password, out bool isStaff)
        {
            isStaff = false;
            bool isValid = false;

            string connectionString = "Data Source=.;Initial Catalog=Electric;Integrated Security=True";

            // Check if the user is a staff member
            string staffQuery = "SELECT Password FROM StaffMember WHERE MemberID = @UserID";
            string customerQuery = "SELECT Password FROM Customers WHERE EmailAddress = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Check StaffMember table
                    using (SqlCommand staffCommand = new SqlCommand(staffQuery, connection))
                    {
                        staffCommand.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        object staffResult = staffCommand.ExecuteScalar();
                        connection.Close();

                        if (staffResult != null)
                        {
                            string storedPassword = staffResult.ToString();
                            if (storedPassword == password)
                            {
                                isValid = true;
                                isStaff = true;
                                MessageBox.Show("Staff login successful");
                                return isValid;
                            }
                        }
                    }

                    // Check Customers table
                    using (SqlCommand customerCommand = new SqlCommand(customerQuery, connection))
                    {
                        customerCommand.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        object customerResult = customerCommand.ExecuteScalar();
                        connection.Close();

                        if (customerResult != null)
                        {
                            string storedPassword = customerResult.ToString();
                            if (storedPassword == password)
                            {
                                isValid = true;
                                isStaff = false;
                                MessageBox.Show("Customer login successful");
                            }
                            else
                            {
                                MessageBox.Show("Customer password mismatch");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Customer not found");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Reset the form fields
            txtid.Text = string.Empty;
            txtpassword.Text = string.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 mainPage = new Form4();
            mainPage.Show();
            this.Hide();
        }
    }
}
