using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Runtime.InteropServices;
using System.Drawing.Printing;


namespace NS_Mini_SuperMarket
{
    public partial class frmItemDetailsForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // x-coordinate of upper-left corner
            int nTopRect,       // y-coordinate of upper-left corner
            int nRightRect,     // x-coordinate of lower-right corner
            int nBottomRect,    // y-coordinate of lower-right corner
            int nWidthEllipse,  // height of ellipse
            int nHeightEllipse  // width of ellipse
        );


        public frmItemDetailsForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private string connectionString = @"Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf";


        String itemId;
        String itemType;
        String itemName;
        int itemPices;
        int itemSalesPrice;
        int itemRetailPrice;
        DateTime itemIssueDate;
        DateTime salesDate;
        String supplierId;
        //int salesRecordNo;
        
       

        private void btn_ItemInsert_Click(object sender, EventArgs e)
        {

            try
            { 

            itemId = (txt_itemId.Text);
            itemType = (cmd_ItemType.Text);
            itemName = (txt_ItemName.Text);
            itemPices = int.Parse(txt_ItemPices.Text);
            itemSalesPrice = int.Parse(txt_ItemSalesPrice.Text);
            itemRetailPrice = int.Parse(txt_ItemRetailPrice.Text);
            itemIssueDate = Convert.ToDateTime(dtp_ItemIssueDate.Value);
            //salesRecordNo = int.Parse(txt_SalesRecordNo.Text);
            supplierId = (txt_SupplierId.Text);           
            salesDate = Convert.ToDateTime(dtp_SalesDate.Value);


            string query = @"INSERT INTO tb_Item (
                                                ItemId,
                                                ItemType, 
                                                ItemName, 
                                                ItemPices,
                                                ItemSalesPrice,
                                                ItemRetailPrice,                         
                                                ItemDate,                                        
                                                SupplierId,
                                                SalesDate)

                                                VALUES (

                                                @itemId,
                                                @itemType,
                                                @itemName,
                                                @itemPices,
                                                @itemSalesPrice,
                                                @itemRetailPrice, 
                                                @itemIssueDate, 
                                                @supplierId,
                                                @salesDate)";

            using (SqlCeConnection con = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@itemId", txt_itemId.Text);
                    cmd.Parameters.AddWithValue("@itemType", cmd_ItemType.Text);
                    cmd.Parameters.AddWithValue("@itemName", txt_ItemName.Text);
                    cmd.Parameters.AddWithValue("@itemPices", int.Parse(txt_ItemPices.Text));
                    cmd.Parameters.AddWithValue("@itemSalesPrice", int.Parse(txt_ItemSalesPrice.Text));
                    cmd.Parameters.AddWithValue("@itemRetailPrice", int.Parse(txt_ItemRetailPrice.Text)); // Corrected this line
                    cmd.Parameters.AddWithValue("@itemIssueDate", dtp_ItemIssueDate.Value); // Use DateTimePicker's Value
                    //cmd.Parameters.AddWithValue("@salesRecordNo", int.Parse(txt_SalesRecordNo.Text));
                    cmd.Parameters.AddWithValue("@supplierId", txt_SupplierId.Text);
                    cmd.Parameters.AddWithValue("@salesDate", dtp_SalesDate.Value);
                   

                    // Open the connection
                    con.Open();

                    // Execute the insert command
                    int result = cmd.ExecuteNonQuery();

                    // Check if the insert was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");
                        clearFormFields();
                    }
                    else
                    {
                        MessageBox.Show("Error inserting data.");
                    }

                    // Close the connection
                    con.Close();
                }
            }
            
            }catch(Exception)
            {
                MessageBox.Show("Data Entered Invalid, Try Again!!");
            
            }




           
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM tb_Item WHERE ItemId = @ItemId";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        // Add the SupplierId parameter to the command
                        cmd.Parameters.AddWithValue("@ItemId", txt_itemId.Text);

                        // Open the connection
                        con.Open();

                        // Execute the query and read the results
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("No record found with the specified Supplier ID.");
                            }
                            else
                            {

                                cmd_ItemType.Text = reader["ItemType"].ToString();
                                txt_ItemName.Text = reader["ItemName"].ToString();
                                txt_ItemPices.Text = reader["ItemPices"].ToString();
                                txt_ItemSalesPrice.Text = reader["ItemSalesPrice"].ToString();
                                txt_ItemRetailPrice.Text = reader["ItemRetailPrice"].ToString();
                              //  txt_SalesRecordNo.Text = reader["RecordNo"].ToString();
                                txt_SupplierId.Text = reader["SupplierId"].ToString();
                                dtp_ItemIssueDate.Value = Convert.ToDateTime(reader["ItemDate"]);
                                dtp_SalesDate.Value = Convert.ToDateTime(reader["SalesDate"]);

                            }
                        }

                        // Close the connection
                        con.Close();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Data Search Invalid, Try Again!!");
           
            }
     
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

            try 
            {
                string query = @"UPDATE tb_Item 
                             SET 
                                 ItemType = @itemType, 
                                 ItemName = @itemName, 
                                 ItemPices = @itemPices, 
                                 ItemSalesPrice = @itemSalesPrice, 
                                 ItemRetailPrice = @itemRetailPrice,
                                 ItemDate = @itemIssueDate,                                                               
                                 SupplierId = @supplierId,  
                                 SalesDate = @salesDate  
                                  
                             WHERE ItemId = @itemId";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@itemId", txt_itemId.Text);
                        cmd.Parameters.AddWithValue("@itemType", cmd_ItemType.Text);
                        cmd.Parameters.AddWithValue("@itemName", txt_ItemName.Text);
                        cmd.Parameters.AddWithValue("@itemPices", txt_ItemPices.Text);
                        cmd.Parameters.AddWithValue("@itemSalesPrice", txt_ItemSalesPrice.Text);
                        cmd.Parameters.AddWithValue("@itemRetailPrice", txt_ItemSalesPrice.Text);
                       // cmd.Parameters.AddWithValue("@salesRecordNo", txt_SalesRecordNo.Text);
                        cmd.Parameters.AddWithValue("@supplierId", txt_SupplierId.Text);
                        cmd.Parameters.AddWithValue("@itemIssueDate", dtp_ItemIssueDate.Text);
                        cmd.Parameters.AddWithValue("@salesDate", dtp_SalesDate.Text);

                        // Open the connection
                        con.Open();

                        // Execute the update command
                        int result = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (result > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                            clearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the record.");
                        }

                        // Close the connection
                        con.Close();
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("Data Update Invalid, Try Again!!");
            }




            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try 
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // SQL Delete Query
                    string query = "DELETE FROM tb_Item WHERE ItemId = @itemId";

                    using (SqlCeConnection con = new SqlCeConnection(connectionString))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                        {
                            // Add the SupplierId parameter to the command
                            cmd.Parameters.AddWithValue("@itemId", txt_itemId.Text);

                            // Open the connection
                            con.Open();

                            // Execute the delete command
                            int result = cmd.ExecuteNonQuery();

                            // Check if the delete was successful
                            if (result > 0)
                            {
                                MessageBox.Show("Record deleted successfully!");

                                // Clear the form fields after deletion
                                clearFormFields();
                            }
                            else
                            {
                                MessageBox.Show("No record found with the specified Supplier ID.");
                            }

                            // Close the connection
                            con.Close();
                        }
                    }
                }
            
            }catch(Exception)
            {
                MessageBox.Show("Data Dalete Invalid, Try Again!!");
            }

            
        }


        private void clearFormFields()
        {
            txt_itemId.Text = "";
            cmd_ItemType.Text = "";
            txt_ItemName.Text = "";
            txt_ItemPices.Text = "";
            txt_ItemSalesPrice.Text = "";
            txt_ItemRetailPrice.Text = "";
            
            txt_SupplierId.Text = "";
            dtp_ItemIssueDate.Checked = false;
            dtp_SalesDate.Checked = false;
        }

        private void btn_ItemReport_Click(object sender, EventArgs e)
        {
            Form2 itemdetails = new Form2();
            itemdetails.Show();
        }


        private void LoadItemId()
        {
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ItemId FROM tb_Item";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmb_ItemId.Items.Add(reader["ItemId"].ToString());
                }

                reader.Close();
            }
        }

        private void LoadSupplierId()
        {
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SupplierId FROM tb_Supplier";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmb_supId.Items.Add(reader["SupplierId"].ToString());
                }

                reader.Close();
            }
        }

        private void frmItemDetailsForm_Load(object sender, EventArgs e)
        {
            LoadItemId();
            LoadSupplierId();
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDashBoard dashBoard = new frmDashBoard();
            dashBoard.Show();
        }

        private void txt_ItemPices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ItemSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ItemRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

    }
}
