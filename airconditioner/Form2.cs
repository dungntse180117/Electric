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

namespace Electric
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source=.;initial catalog = Electric;integrated security=true");
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("Select SupplierId, SupplierName, SupplierDescription, PlaceOfOrigin from SupplierCompany", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set FillWeight for each column
            dataGridView1.Columns["SupplierId"].FillWeight = 1;
            dataGridView1.Columns["SupplierName"].FillWeight = 1;
            dataGridView1.Columns["SupplierDescription"].FillWeight = 3; 
            dataGridView1.Columns["PlaceOfOrigin"].FillWeight = 1;

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            bind_data();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string supplierId = txtid.Text;
            string supplierName = txtname.Text;
            string supplierDescription = txtdescription.Text;
            string placeOfOrigin = txtorigin.Text;

            if (string.IsNullOrWhiteSpace(supplierId) || string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(placeOfOrigin))
            {
                MessageBox.Show("Please fill in all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "INSERT INTO SupplierCompany (SupplierId, SupplierName, SupplierDescription, PlaceOfOrigin) VALUES (@SupplierId, @SupplierName, @SupplierDescription, @PlaceOfOrigin)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                cmd.Parameters.AddWithValue("@SupplierDescription", supplierDescription);
                cmd.Parameters.AddWithValue("@PlaceOfOrigin", placeOfOrigin);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Supplier added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                bind_data();

                
                txtid.Text = string.Empty;
                txtname.Text = string.Empty;
                txtdescription.Text = string.Empty;
                txtorigin.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Remove_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int index = row.Index;
                        string supplierId = dataGridView1.Rows[index].Cells["SupplierId"].Value.ToString();

                        try
                        {
                            string query = "DELETE FROM SupplierCompany WHERE SupplierId = @SupplierId";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SupplierId", supplierId);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            dataGridView1.Rows.RemoveAt(index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                    }
                    MessageBox.Show("Selected row(s) deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                string supplierId = dataGridView1.Rows[index].Cells["SupplierId"].Value.ToString();
                string supplierName = txtname.Text;
                string supplierDescription = txtdescription.Text;
                string placeOfOrigin = txtorigin.Text;

                try
                {
                    string query = "UPDATE SupplierCompany SET SupplierName = @SupplierName, SupplierDescription = @SupplierDescription, PlaceOfOrigin = @PlaceOfOrigin WHERE SupplierId = @SupplierId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@SupplierDescription", supplierDescription);
                    cmd.Parameters.AddWithValue("@PlaceOfOrigin", placeOfOrigin);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    dataGridView1.Rows[index].Cells["SupplierName"].Value = supplierName;
                    dataGridView1.Rows[index].Cells["SupplierDescription"].Value = supplierDescription;
                    dataGridView1.Rows[index].Cells["PlaceOfOrigin"].Value = placeOfOrigin;

                    MessageBox.Show("Selected row updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select one row to update.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void viewAir_Click(object sender, EventArgs e)
        {
            airID mainPage = new airID(); // Assuming Form2 is the main page
            mainPage.Show();
            this.Hide();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Form3 mainPage = new Form3();
            mainPage.Show();
            this.Hide();
        }
    }
}

