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
    public partial class frmSupplierDetails : Form
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


        public frmSupplierDetails()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        
        private string connectionString = @"Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf";

         // decimal saAmountTotal = decimal.Parse(txt_TotalSalesAmount.Text);

        String supId;
        int recordNo;
        String supName;
        String supAdLine_1;
        String supAdLine_2;
        String supAdLine_3;
        String supTp_1;
        String supTp_2;
        String supCompanyName;
        String supPaymentMethod;
        


        private void btn_SupInsert_Click(object sender, EventArgs e)
        {
            try
            {
                /*supId = Convert.ToString(txt_SupId.Text);
                recordNo = int.Parse(txt_RecordNo.Text);
                supName = (txt_SupName.Text);
                supAdLine_1 = (txt_SupAdd_1.Text);
                supAdLine_2 = (txt_SupAdd_2.Text);
                supAdLine_3 = (txt_SupAdd_3.Text);
                supTp_1 = (txt_SupTp_1.Text);
                supTp_2 = (txt_SupTp_2.Text);
                supCompanyName = (txt_SupCompanyName.Text);
                supPaymentMethod = (cmb_SupPaymentMethod.Text);*/
                

                //  SupplierNo, 
                // SQL Insert Query
                string query = @"INSERT INTO tb_Supplier (
                                                SupplierId,
                                                RecordNo, 
                                                SupplierName, 
                                                Ad_Line1,
                                                Ad_Line2,
                                                Ad_Line3, 
                                                Tp_1, 
                                                Tp_2,
                                                CompanyName, 
                                                PaymentMethod 
                                               )

                                                VALUES (

                                                @supId,
                                                @recordNo,
                                                @supName,
                                                @Ad_Line1,
                                                @Ad_Line2,
                                                @Ad_Line3,
                                                @supTp_1,
                                                @supTp_2,
                                                @supCompanyName,
                                                @PaymentMethod 
                                               )";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@supId", Convert.ToString(txt_SupId.Text));
                        cmd.Parameters.AddWithValue("@recordNo", int.Parse(txt_RecordNo.Text));
                        cmd.Parameters.AddWithValue("@supName", txt_SupName.Text);
                        cmd.Parameters.AddWithValue("@Ad_Line1", txt_SupAdd_1.Text);
                        cmd.Parameters.AddWithValue("@Ad_Line2", txt_SupAdd_2.Text);
                        cmd.Parameters.AddWithValue("@Ad_Line3", txt_SupAdd_3.Text);
                        cmd.Parameters.AddWithValue("@supTp_1", txt_SupTp_1.Text);
                        cmd.Parameters.AddWithValue("@supTp_2", txt_SupTp_2.Text);
                        cmd.Parameters.AddWithValue("@supCompanyName", txt_SupCompanyName.Text);
                        cmd.Parameters.AddWithValue("@PaymentMethod", cmb_SupPaymentMethod.Text);
                        
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

        private void btn_SupSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM tb_Supplier WHERE SupplierId = @supId";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        // Add the SupplierId parameter to the command
                        cmd.Parameters.AddWithValue("@supId", txt_SupId.Text);

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

                                txt_SupName.Text = reader["SupplierName"].ToString();
                                txt_RecordNo.Text = reader["RecordNo"].ToString();
                                cmb_SupPaymentMethod.Text = reader["PaymentMethod"].ToString();
                                txt_SupAdd_1.Text = reader["Ad_Line1"].ToString();
                                txt_SupAdd_2.Text = reader["Ad_Line2"].ToString();
                                txt_SupAdd_3.Text = reader["Ad_Line3"].ToString();
                                txt_SupTp_1.Text = reader["Tp_1"].ToString();
                                txt_SupTp_2.Text = reader["Tp_2"].ToString();
                                txt_SupCompanyName.Text = reader["CompanyName"].ToString();
                                
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
 
        private void btn_SupUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE tb_Supplier  
                             SET 
                                 SupplierName = @supName, 
                                 Ad_Line1 = @supAdLine_1, 
                                 Ad_Line2 = @supAdLine_2, 
                                 Ad_Line3 = @supAdLine_3, 
                                 Tp_1 = @supTp_1, 
                                 Tp_2 = @supTp_2,
                                 CompanyName = @supCompanyName,  
                                 PaymentMethod = @supPaymentMethod 
                                  
                             WHERE SupplierId = @supId";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@supId", txt_SupId.Text);
                        cmd.Parameters.AddWithValue("@supName", txt_SupName.Text);
                        cmd.Parameters.AddWithValue("@supAdLine_1", txt_SupAdd_1.Text);
                        cmd.Parameters.AddWithValue("@supAdLine_2", txt_SupAdd_2.Text);
                        cmd.Parameters.AddWithValue("@supAdLine_3", txt_SupAdd_3.Text);
                        cmd.Parameters.AddWithValue("@supTp_1", txt_SupTp_1.Text);
                        cmd.Parameters.AddWithValue("@supTp_2", txt_SupTp_2.Text);
                        cmd.Parameters.AddWithValue("@supCompanyName", txt_SupCompanyName.Text);
                        cmd.Parameters.AddWithValue("@supPaymentMethod", cmb_SupPaymentMethod.Text);
                         

                        
                        con.Open();

                       
                        int result = cmd.ExecuteNonQuery();
 
                        if (result > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                            clearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Error updating the record.");
                        }

                      
                        con.Close();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Data Update Invalid, Try Again!!");
            }



            
        }

        private void btn_SupDelete_Click(object sender, EventArgs e)
        {

            try
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // SQL Delete Query
                    string query = "DELETE FROM tb_Supplier WHERE SupplierId = @supId";

                    using (SqlCeConnection con = new SqlCeConnection(connectionString))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                        {
                            // Add the SupplierId parameter to the command
                            cmd.Parameters.AddWithValue("@supId", txt_SupId.Text);

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

            }
            catch (Exception)
            {
                MessageBox.Show("Data Delete Invalid, Try Again!!");
            }

           
        }


        private void clearFormFields()
        {
            txt_RecordNo.Text = "";
            txt_SupId.Text = "";
            txt_SupName.Text = "";
            txt_SupAdd_1.Text = "";
            txt_SupAdd_2.Text = "";
            txt_SupAdd_3.Text = "";
            txt_SupTp_1.Text = "";
            txt_SupTp_2.Text = "";
            txt_SupCompanyName.Text = "";
            cmb_SupPaymentMethod.Items.Clear();
            
        }

        private void btn_SupReport_Click(object sender, EventArgs e)
        {
            report_Supplier supfrm = new report_Supplier();
            supfrm.Show();
        }

        private void LoadNewSupplierID()
        {
           
            // string connectionString = "your_connection_string_here";  // Replace with your database connection string
            string newSupplierId = "S_001";  // Default ID if no data exists
            string getLastIdQuery = "SELECT TOP 1 SupplierId FROM tb_Supplier ORDER BY SupplierId DESC";

            using (SqlCeConnection con = new SqlCeConnection(connectionString))
            {
                SqlCeCommand cmd = new SqlCeCommand(getLastIdQuery, con);

                try
                {
                    con.Open();
                    var lastIdObj = cmd.ExecuteScalar();

                    if (lastIdObj != null)  // If there is a last ID, increment it
                    {
                        string lastSupplierId = lastIdObj.ToString().Trim();
                        // Assuming the ID is in the format "Sup_001"
                        int lastIdNumber = int.Parse(lastSupplierId.Substring(2));  // Extract the numeric part after "Sup_"
                        int newIdNumber = lastIdNumber + 1;  // Increment it
                        newSupplierId = "S_" + newIdNumber.ToString("D3");  // Format as "Sup_XXX"
                    }

                    // Display the new SupplierID in the TextBox
                    txt_SupId.Text = newSupplierId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadNewRecordNo()
        {
            // string connectionString = "your_connection_string_here";  // Replace with your database connection string
            string newRecordNo = "1";  // Default ID if no data exists
            string getLastIdQuery = "SELECT TOP 1 RecordNo FROM tb_Supplier ORDER BY RecordNo DESC";

            using (SqlCeConnection con = new SqlCeConnection(connectionString))
            {
                SqlCeCommand cmd = new SqlCeCommand(getLastIdQuery, con);

                try
                {
                    con.Open();
                    var lastIdObj = cmd.ExecuteScalar();

                    if (lastIdObj != null)  // If there is a last ID, increment it
                    {
                        string lastRecordNo = lastIdObj.ToString();
                        int lastIdNumber = int.Parse(lastRecordNo.Substring(0));  // Extract number part
                        int newIdNumber = lastIdNumber + 1;  // Increment it
                        newRecordNo = newIdNumber.ToString("D3");  // Format as "Sup_XXX"
                    }

                    // Display the new SupplierID in the TextBox
                    txt_RecordNo.Text = newRecordNo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void frmSupplierDetails_Load(object sender, EventArgs e)
        {
            LoadNewSupplierID();
            LoadNewRecordNo();
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDashBoard dashBoard = new frmDashBoard();
            dashBoard.Show();
        }
        

         
    }
}
