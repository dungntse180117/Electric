using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Electric
{
    public partial class airID : Form
    {
        public airID()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source=.;initial catalog = Electric;integrated security=true");
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("Select DeviceId, DeviceName, Warranty,Quantity,DollarPrice,SupplierId from Devices", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bind_data();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string DeviceId = txtAirID.Text;
            string DeviceName = txtAirName.Text;
            string Warranty = txtWarranty.Text;
            string Quantity = txtQuantity.Text;
            string Price = txtPrice.Text;
            string SupplierId = txtSupplierID.Text;
            if (string.IsNullOrWhiteSpace(DeviceId) || string.IsNullOrWhiteSpace(DeviceName) || string.IsNullOrWhiteSpace(Warranty)
                 || string.IsNullOrWhiteSpace(Quantity)
                || string.IsNullOrWhiteSpace(Price) || string.IsNullOrWhiteSpace(SupplierId))
            {
                MessageBox.Show("Please fill in all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                

                string query = "INSERT INTO AirConditioner (DeviceId, DeviceName, Warranty, Quantity,DollarPrice,SupplierId) " +
                    "VALUES (@DeviceId, @DeviceName, @Warranty,@Quantity,@DollarPrice,@SupplierId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DeviceId", DeviceId);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                cmd.Parameters.AddWithValue("@Warranty", Warranty);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@DollarPrice", Price);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Supplier added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                bind_data();

                
                txtAirID.Text = string.Empty;
                txtAirName.Text = string.Empty;
                txtWarranty.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtSupplierID.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int index = row.Index;
                        string DeviceId = dataGridView1.Rows[index].Cells["DeviceId"].Value.ToString();

                        try
                        {
                            string query = "DELETE FROM Devices WHERE DeviceId = @DeviceId";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@DeviceId", DeviceId);

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
        private string connectionString = "Data Source=.;Initial Catalog=Electric;Integrated Security=True";
        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                string DeviceId = dataGridView1.Rows[index].Cells["DeviceId"].Value.ToString();
                string DeviceName = txtAirName.Text;
                string Warranty = txtWarranty.Text;
                string Quantity = txtQuantity.Text;
                string Price = txtPrice.Text;
                string SupplierId = txtSupplierID.Text;
                
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string checkSupplierQuery = "SELECT COUNT(1) FROM SupplierCompany WHERE SupplierId = @SupplierId";
                        using (SqlCommand checkCmd = new SqlCommand(checkSupplierQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                            int supplierExists = (int)checkCmd.ExecuteScalar();
                            if (supplierExists == 0)
                            {
                                MessageBox.Show("Supplier ID does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        string query = "UPDATE Devices SET DeviceId = @DeviceId, DeviceName = @DeviceName, " +
                        "Warranty = @Warranty, Quantity = @Quantity,DollarPrice = @DollarPrice,SupplierId = @SupplierId WHERE AirConditionerId = @AirConditionerId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@DeviceId", DeviceId);
                        cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                        cmd.Parameters.AddWithValue("@Warranty", Warranty);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@DollarPrice", Price);
                        cmd.Parameters.AddWithValue("@SupplierId", SupplierId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        dataGridView1.Rows[index].Cells["DeviceName"].Value = DeviceName;
                        dataGridView1.Rows[index].Cells["Warranty"].Value = Warranty;
                        dataGridView1.Rows[index].Cells["Quantity"].Value = Quantity;
                        dataGridView1.Rows[index].Cells["DollarPrice"].Value = Price;
                        dataGridView1.Rows[index].Cells["SupplierId"].Value = SupplierId;

                        MessageBox.Show("Selected row updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void Back_Click(object sender, EventArgs e)
        {
            Form2 mainPage = new Form2();
            mainPage.Show();
            this.Hide();
        }

       
    }
}
