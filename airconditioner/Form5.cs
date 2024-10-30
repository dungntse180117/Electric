using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Electric
{
    public partial class Form5 : Form
    {
        private DataTable cartTable;
        private decimal totalAmount = 0;

        public Form5()
        {
            InitializeComponent();
            
            InitializeCartTable();
        }
 
       
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Electric;Integrated Security=True");

        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("DeviceId", typeof(int));
            cartTable.Columns.Add("DeviceName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("DollarPrice", typeof(decimal));
            cartTable.Columns.Add("TotalPrice", typeof(decimal), "Quantity * DollarPrice");

            cartGridView.DataSource = cartTable;
        }

        private void BindData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DeviceId, DeviceName, Warranty, Quantity, DollarPrice, SupplierId FROM Devices", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
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
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            BindData();
            totalAmountLabel.Text = "Total Amount: $0.00";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Retrieve selected item details
                int deviceId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeviceId"].Value);
                string deviceName = dataGridView1.SelectedRows[0].Cells["DeviceName"].Value.ToString();
                int availableQuantity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Quantity"].Value);
                decimal dollarPrice = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["DollarPrice"].Value);

                // Retrieve quantity from quantityTextBox
                int quantityToAdd;
                if (int.TryParse(quantityTextBox.Text, out quantityToAdd) && quantityToAdd > 0 && quantityToAdd <= availableQuantity)
                {
                    // Add item to cart logic
                    DataRow row = cartTable.NewRow();
                    row["DeviceId"] = deviceId;
                    row["DeviceName"] = deviceName;
                    row["Quantity"] = quantityToAdd;
                    row["DollarPrice"] = dollarPrice;
                    cartTable.Rows.Add(row);

                    // Update total amount
                    totalAmount += quantityToAdd * dollarPrice;
                    totalAmountLabel.Text = $"Total Amount: ${totalAmount:F2}";
                }
                else
                {
                    MessageBox.Show("Invalid quantity. Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to add to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there are items in the cart
                if (cartTable.Rows.Count > 0)
                {
                    // Open connection to the database
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Electric;Integrated Security=True"))
                    {
                        conn.Open();

                        // Begin transaction to ensure atomicity
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // Iterate through each item in the cart
                            foreach (DataRow row in cartTable.Rows)
                            {
                                int deviceId = Convert.ToInt32(row["DeviceId"]);
                                int quantity = Convert.ToInt32(row["Quantity"]);

                                // Update the Devices table to deduct purchased quantities
                                string updateQuery = "UPDATE Devices SET Quantity = Quantity - @Quantity WHERE DeviceId = @DeviceId";
                                SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                                updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                                updateCmd.Parameters.AddWithValue("@DeviceId", deviceId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Commit the transaction if all updates succeed
                            transaction.Commit();

                            // Clear the cart and update UI
                            cartTable.Rows.Clear();
                            totalAmount = 0;
                            totalAmountLabel.Text = "Total Amount: $0.00";

                            MessageBox.Show("Purchase completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if any error occurs
                            transaction.Rollback();
                            MessageBox.Show("An error occurred during purchase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There are no items in the cart to purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

    }
}
