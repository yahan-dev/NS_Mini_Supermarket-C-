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
    public partial class frmSalesCalculation : Form
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

        public frmSalesCalculation()
        {
          InitializeComponent();
          this.FormBorderStyle = FormBorderStyle.None; 
          this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

          btn_PrintRecipt.Enabled = false;
        }

        private void frmSalesCalculation_Load(object sender, EventArgs e)
        {
            LoadProducts();


            decimal reAmountTotal = Properties.Settings.Default.TotalReAmount;
            txt_TotalRetailAmount.Text = reAmountTotal.ToString("F2");

            decimal saAmountTotal = Properties.Settings.Default.TotalSaAmount;
            txt_TotalSalesAmount.Text = saAmountTotal.ToString("F2");
        }

        private void frmSalesCalculation_FormClosing(object sender, FormClosingEventArgs e)
        {
            decimal reAmountTotal = decimal.Parse(txt_TotalRetailAmount.Text);

            Properties.Settings.Default.TotalReAmount = reAmountTotal;
            Properties.Settings.Default.Save();

            decimal saAmountTotal = decimal.Parse(txt_TotalSalesAmount.Text);

            Properties.Settings.Default.TotalSaAmount = saAmountTotal;
            Properties.Settings.Default.Save();
        }



        private string connectionString = @"Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf";

        private void LoadProducts()
        {
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ItemName FROM tb_Item";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmb_Items.Items.Add(reader["ItemName"].ToString());
                }

                reader.Close();
            }
        }

        //Sales Amount Variyable
        
        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Check if a product is selected and quantity is entered
            if (cmb_Items.SelectedItem == null || string.IsNullOrEmpty(txt_Quantity.Text))
            {
                MessageBox.Show("Please select a product and enter a quantity.");       
            }

            
            int quantityToAdd;

            if (!int.TryParse(txt_Quantity.Text, out quantityToAdd))
            {
                MessageBox.Show("Please enter a valid quantity.");
                
            }

         
                string productName = cmb_Items.SelectedItem.ToString();

                using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ItemId, ItemPices, ItemSalesPrice, ItemRetailPrice FROM tb_Item WHERE ItemName = @ItemName";
                    SqlCeCommand command = new SqlCeCommand(query, connection);
                    command.Parameters.AddWithValue("@ItemName", productName);

                    SqlCeDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int productId = Convert.ToInt32(reader["ItemId"]);

                       // int availableQuantity = (int)reader["ItemPices"];
                        int availableQuantity = Convert.ToInt32(reader["ItemPices"]);

                        //int salesPrice = (int)reader["ItemSalesPrice"];
                        int salesPrice = Convert.ToInt32(reader["ItemSalesPrice"]);

                         int retailsPrice = (int)reader["ItemRetailPrice"];
                        //int retailsPrice = Convert.ToInt32(reader["ItemRetailsPrice"]);

                        // Check if there is enough stock
                        if (quantityToAdd > availableQuantity)
                        {
                            MessageBox.Show("Not enough stock available.");
                            reader.Close();
                           
                        }

                        int newQuantity = availableQuantity - quantityToAdd;

                        // Update the database
                        reader.Close();
                        query = "UPDATE tb_Item SET ItemPices = @NewQuantity WHERE ItemId = @ItemId";
                        command = new SqlCeCommand(query, connection);
                        command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                        command.Parameters.AddWithValue("@ItemId", productId);
                        command.ExecuteNonQuery();

                        // Add to DataGridView
                        DataGridView1.Rows.Add(productId, productName, quantityToAdd, salesPrice, retailsPrice);

                        int quantity = 0;
                        int totalSalesAmount = 0;
                        int salesAmount;

                        int totalRetailAmount = 0;
                        int retailAmount;

                        foreach (DataGridViewRow row in DataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            if (int.TryParse(row.Cells["Quantity"].Value.ToString(), out  quantity) && int.TryParse(row.Cells["SalesPrice"].Value.ToString(), out salesPrice))
                            {
                                // Calculate the sales amount for this row
                                salesAmount = quantity * salesPrice;

                                // Add to the total sales amount
                                totalSalesAmount += salesAmount;
                            }

                            if (int.TryParse(row.Cells["Quantity"].Value.ToString(), out  quantity) && int.TryParse(row.Cells["RetailPrice"].Value.ToString(), out retailAmount))
                            {
                                // Calculate the sales amount for this row
                                retailAmount = quantity * retailAmount;

                                // Add to the total sales amount
                                totalRetailAmount += retailAmount;
                            }
                        }

                        txt_SalesAmount.Text = totalSalesAmount.ToString("0.00");
                        txt_RetailAmount.Text = totalRetailAmount.ToString("0.00");

                        lbl_SalesAmount.Text = totalSalesAmount.ToString("0.00");
                        lbl_RetailAmount.Text = totalRetailAmount.ToString("0.00");
                    }
                    reader.Close();
                }

             
 
        }





        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                   
                    int productId = Convert.ToInt32(selectedRow.Cells[0].Value);  
                    int quantity = Convert.ToInt32(selectedRow.Cells[2].Value);  

                     
                    decimal salesPrice = Convert.ToDecimal(selectedRow.Cells[3].Value);  
                    decimal retailPrice = Convert.ToDecimal(selectedRow.Cells[4].Value);  

                     
                    decimal salesAmount = quantity * salesPrice;
                    decimal retailAmount = quantity * retailPrice;


                    
                    decimal currentTotalSalesAmount = 0.00m;
                    decimal currentTotalRetailAmount = 0.00m;

                    if (decimal.TryParse(txt_SalesAmount.Text, out currentTotalSalesAmount))
                    {
                         
                        currentTotalSalesAmount -= salesAmount;

                         
                        currentTotalSalesAmount = Math.Max(currentTotalSalesAmount, 0.00m);
                    }
                    else
                    {
                        MessageBox.Show("Error parsing current sales amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                  
                    txt_SalesAmount.Text = currentTotalSalesAmount.ToString("0.00");
                    lbl_SalesAmount.Text = currentTotalSalesAmount.ToString("0.00");


                    if (decimal.TryParse(txt_RetailAmount.Text, out currentTotalRetailAmount))
                    {
                        
                        currentTotalRetailAmount -= retailAmount;

                        
                        currentTotalRetailAmount = Math.Max(currentTotalRetailAmount, 0.00m);
                    }
                    else
                    {
                        MessageBox.Show("Error parsing current sales amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    txt_RetailAmount.Text = currentTotalRetailAmount.ToString("0.00");
                    lbl_RetailAmount.Text = currentTotalRetailAmount.ToString("0.00");
 

                    
                    using (SqlCeConnection connection = new SqlCeConnection(@"Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf"))
                    {
                        connection.Open();

                       
                        SqlCeCommand updateCommand = new SqlCeCommand("UPDATE tb_Item SET ItemPices = ItemPices + @ItemPices WHERE ItemId = @ItemId", connection);
                        updateCommand.Parameters.AddWithValue("@ItemPices", quantity);
                        updateCommand.Parameters.AddWithValue("@ItemId", productId);
                        updateCommand.ExecuteNonQuery();

                        // Remove from DataGridView
                        DataGridView1.Rows.Remove(selectedRow);

                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No available Product to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        
            decimal amount = 0;
            decimal retailAmount = 0;
        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            
            if (decimal.TryParse(txt_CustomerAmount.Text, out amount) && decimal.TryParse(lbl_RetailAmount.Text, out retailAmount))
            {
                
                decimal balance = amount - retailAmount;
                
                
                lbl_Balance.Text = balance.ToString("0.00");
            }
            else
            {
               
                MessageBox.Show("Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_AddTotal_Click(object sender, EventArgs e)
        {
            decimal reAmount;
            decimal saAmount;
            if (decimal.TryParse(lbl_RetailAmount.Text, out reAmount) && decimal.TryParse(lbl_SalesAmount.Text, out saAmount))
            {
                 
                txt_TotalRetailAmount.Text = reAmount.ToString();
            } 
        }


        private void btn_PrintRecipt_Click_1(object sender, EventArgs e)
        {

            try
            {
               
                decimal reAmountTotal = decimal.Parse(txt_TotalRetailAmount.Text);
                decimal saAmountTotal = decimal.Parse(txt_TotalSalesAmount.Text);
 
                decimal lblReAmount = decimal.Parse(lbl_RetailAmount.Text);
                decimal lblSaAmount = decimal.Parse(lbl_SalesAmount.Text);

                decimal newReAmount = reAmountTotal + lblReAmount;
                decimal newSaAmount = saAmountTotal + lblSaAmount;
               

                txt_TotalRetailAmount.Text = newReAmount.ToString("F2");
                txt_TotalSalesAmount.Text = newSaAmount.ToString();

                 
                Properties.Settings.Default.TotalReAmount = newReAmount;
                Properties.Settings.Default.Save();

                Properties.Settings.Default.TotalSaAmount = newSaAmount;
                Properties.Settings.Default.Save();


                
                //txtAmount.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the amount to add.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception  )
            {
                MessageBox.Show("Please enter a valid number for the amount to add.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            PrintDocument printDocument = new PrintDocument();

            // Set up the event handler for PrintPage
            printDocument.PrintPage += new PrintPageEventHandler(PrintReceipt);

            // Set custom paper size (in hundredths of an inch)
            PaperSize receiptSize = new PaperSize("Receipt", 400, 600); // Width=3 inches, Height=6 inches
            printDocument.DefaultPageSettings.PaperSize = receiptSize;

            // Optionally set margins (if needed)
            printDocument.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10); // 0.1 inch margins

            // Create a PrintPreviewDialog to preview the document
            PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDocument
            };

            // Show the print preview dialog
            printPreview.ShowDialog();

 
             
        }


       

        private void PrintReceipt(object sender, PrintPageEventArgs e )
        {
            // Define fonts
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10);
            Font totalFont = new Font("Arial", 12, FontStyle.Bold);
            Font smallFont = new Font("Arial", 8);

            // Define positions and spacing
            float yPosition = 10;
            float xMargin = 10;
            float lineSpacing = 20;
            float pageWidth = e.PageBounds.Width - 20;

            e.Graphics.DrawRectangle(Pens.Black, xMargin, yPosition, pageWidth, e.PageBounds.Height - 20);

            // Draw header border
            e.Graphics.DrawRectangle(Pens.Black, xMargin + 5, yPosition + 5, pageWidth - 10, 80);

            yPosition += 10;

            // Print shop name
            string shopName = "NS Mini Mart";
            SizeF shopNameSize = e.Graphics.MeasureString(shopName, headerFont);
            float xShopName = (pageWidth - shopNameSize.Width) / 2; // Centering the shop name
            e.Graphics.DrawString(shopName, headerFont, Brushes.Black, new PointF(xShopName, yPosition));
            yPosition += lineSpacing;

            // Print address and contact details
            string address = "No. 23, Highlevel Rd, Ukawatta, Avissawella.";
            SizeF addressSize = e.Graphics.MeasureString(address, bodyFont);
            float xAddress = (pageWidth - addressSize.Width) / 2; // Centering the address
            e.Graphics.DrawString(address, bodyFont, Brushes.Black, new PointF(xAddress, yPosition));
            yPosition += lineSpacing;

            string phone = "Telp. 11223344";
            SizeF phoneSize = e.Graphics.MeasureString(phone, bodyFont);
            float xPhone = (pageWidth - phoneSize.Width) / 2; // Centering the phone number
            e.Graphics.DrawString(phone, bodyFont, Brushes.Black, new PointF(xPhone, yPosition));
            yPosition += lineSpacing * 2;

            // Print receipt title
            string receiptTitle = "CASH RECEIPT";
            SizeF receiptTitleSize = e.Graphics.MeasureString(receiptTitle, headerFont);
            float xReceiptTitle = (pageWidth - receiptTitleSize.Width) / 2; // Centering the receipt title
            e.Graphics.DrawString(receiptTitle, headerFont, Brushes.Black, new PointF(xReceiptTitle, yPosition));
            yPosition += lineSpacing * 2;

            // Print table header
            string descriptionHeader = "Description";
            SizeF descriptionHeaderSize = e.Graphics.MeasureString(descriptionHeader, bodyFont);
            float xDescriptionHeader = (pageWidth - descriptionHeaderSize.Width) / 2 - 100; // Adjust as needed
            e.Graphics.DrawString(descriptionHeader, bodyFont, Brushes.Black, new PointF(xDescriptionHeader, yPosition));

            string priceHeader = "Price";
            SizeF priceHeaderSize = e.Graphics.MeasureString(priceHeader, bodyFont);
            float xPriceHeader = (pageWidth - priceHeaderSize.Width) / 2 + 100; // Adjust as needed
            e.Graphics.DrawString(priceHeader, bodyFont, Brushes.Black, new PointF(xPriceHeader, yPosition));
            yPosition += lineSpacing;

            // Draw line separator
            string separator = new string('*', 40);
            SizeF separatorSize = e.Graphics.MeasureString(separator, bodyFont);
            float xSeparator = (pageWidth - separatorSize.Width) / 2; // Centering the separator
            e.Graphics.DrawString(separator, bodyFont, Brushes.Black, new PointF(xSeparator, yPosition));
            yPosition += lineSpacing;

            // Print each item from DataGridView
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (row.Cells["ItemName"].Value != null && row.Cells["SalesPrice"].Value != null)
                {
                    string description = row.Cells["ItemName"].Value.ToString();
                    string price = row.Cells["SalesPrice"].Value.ToString();

                    SizeF descriptionSize = e.Graphics.MeasureString(description, bodyFont);
                    float xDescription = (pageWidth - descriptionSize.Width) / 2 - 100; // Adjust as needed
                    e.Graphics.DrawString(description, bodyFont, Brushes.Black, new PointF(xDescription, yPosition));

                    SizeF priceSize = e.Graphics.MeasureString(price, bodyFont);
                    float xPrice = (pageWidth - priceSize.Width) / 2 + 100; // Adjust as needed
                    e.Graphics.DrawString(price, bodyFont, Brushes.Black, new PointF(xPrice, yPosition));

                    yPosition += lineSpacing;
                }
            }

            // Draw line separator
            e.Graphics.DrawString(separator, bodyFont, Brushes.Black, new PointF(xSeparator, yPosition));
            yPosition += lineSpacing;

            // Calculate totals (assuming you have total variables)
            decimal total = retailAmount; // Example total
            decimal cash = amount;  // Example cash
            decimal change = cash - total;

            // Print totals
            string totalLabel = "Total";
            SizeF totalLabelSize = e.Graphics.MeasureString(totalLabel, totalFont);
            float xTotalLabel = (pageWidth - totalLabelSize.Width) / 2 - 100; // Adjust as needed
            e.Graphics.DrawString(totalLabel, totalFont, Brushes.Black, new PointF(xTotalLabel, yPosition));

            string totalValue = total.ToString("F2");
            SizeF totalValueSize = e.Graphics.MeasureString(totalValue, totalFont);
            float xTotalValue = (pageWidth - totalValueSize.Width) / 2 + 100; // Adjust as needed
            e.Graphics.DrawString(totalValue, totalFont, Brushes.Black, new PointF(xTotalValue, yPosition));
            yPosition += lineSpacing;

            string cashLabel = "Cash";
            SizeF cashLabelSize = e.Graphics.MeasureString(cashLabel, bodyFont);
            float xCashLabel = (pageWidth - cashLabelSize.Width) / 2 - 100; // Adjust as needed
            e.Graphics.DrawString(cashLabel, bodyFont, Brushes.Black, new PointF(xCashLabel, yPosition));

            string cashValue = cash.ToString("F2");
            SizeF cashValueSize = e.Graphics.MeasureString(cashValue, bodyFont);
            float xCashValue = (pageWidth - cashValueSize.Width) / 2 + 100; // Adjust as needed
            e.Graphics.DrawString(cashValue, bodyFont, Brushes.Black, new PointF(xCashValue, yPosition));
            yPosition += lineSpacing;

            string changeLabel = "Change";
            SizeF changeLabelSize = e.Graphics.MeasureString(changeLabel, bodyFont);
            float xChangeLabel = (pageWidth - changeLabelSize.Width) / 2 - 100; // Adjust as needed
            e.Graphics.DrawString(changeLabel, bodyFont, Brushes.Black, new PointF(xChangeLabel, yPosition));

            string changeValue = change.ToString("F2");
            SizeF changeValueSize = e.Graphics.MeasureString(changeValue, bodyFont);
            float xChangeValue = (pageWidth - changeValueSize.Width) / 2 + 100; // Adjust as needed
            e.Graphics.DrawString(changeValue, bodyFont, Brushes.Black, new PointF(xChangeValue, yPosition));
            yPosition += lineSpacing * 2;
             

            // Print thank you message
            string thankYouMessage = "THANK YOU!";
            SizeF thankYouSize = e.Graphics.MeasureString(thankYouMessage, headerFont);
            float xThankYou = (pageWidth - thankYouSize.Width) / 2; // Centering the thank you message
            e.Graphics.DrawString(thankYouMessage, headerFont, Brushes.Black, new PointF(xThankYou, yPosition));
            yPosition += lineSpacing * 2;
 
             
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            int closeCounter = Properties.Settings.Default.FormCloseCounter;

            // Increment the counter
            closeCounter++;

            // Save the values to the database before proceeding
           

            if (closeCounter >= 3)
            {
                SaveValuesToDatabase();
                // Reset the TotalAmount to zero after three closures
                Properties.Settings.Default.TotalReAmount = 0;
                Properties.Settings.Default.TotalSaAmount = 0;
                // Reset the counter
                closeCounter = 0;

                // Update the textbox to reflect the reset value
                txt_TotalRetailAmount.Text = "0.00";
                txt_TotalSalesAmount.Text = "0.00";
            }

            // Save the updated counter back to the settings
            Properties.Settings.Default.FormCloseCounter = closeCounter;

            // Save all settings
            Properties.Settings.Default.Save();

            // Close the form
            this.Close();
             
            frmDashBoard dashBoard = new frmDashBoard();
            dashBoard.Show();


        }

       private void SaveValuesToDatabase()
        {
           
                   
                    
                DateTime salesDate = Convert.ToDateTime(dtp_SalesDate.Text);

                decimal totalRetailAmount = decimal.Parse(txt_TotalRetailAmount.Text);

                decimal totalSalesAmount = decimal.Parse(txt_TotalSalesAmount.Text);

                decimal DailySalesIncome = totalRetailAmount - totalSalesAmount;


                if ((totalRetailAmount != 0) && (totalSalesAmount != 0))
                {
                    try
                    {
                        using (SqlCeConnection conn = new SqlCeConnection("Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf"))
                        {
                            conn.Open();

                             
                            string query = "INSERT INTO tb_DailySale(SalesDate, RetailSalesTotal, SalesTotal, DailySalesIncome) " +
                                           "VALUES (@SalesDate, @RetailSalesTotal, @SalesTotal, @DailySalesIncome)";

                            using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                            {

                                
                                cmd.Parameters.AddWithValue("@SalesDate", salesDate);
                                cmd.Parameters.AddWithValue("@RetailSalesTotal", totalRetailAmount);
                                cmd.Parameters.AddWithValue("@SalesTotal", totalSalesAmount);
                                cmd.Parameters.AddWithValue("@DailySalesIncome", DailySalesIncome);

                                 
                                cmd.ExecuteNonQuery();


                            }
                        }
                        MessageBox.Show("Values inserted into database successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Invalid Entering, Try again!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

               
              
            
    
        }

       private void lbl_Balance_Click(object sender, EventArgs e)
       {
           int btnTure = int.Parse(lbl_Balance.Text);
           int btnRcipt = int.Parse(btn_PrintRecipt.Text);

           if (btnTure != 0)
           {
               
           }
           else
           {
               btn_PrintRecipt.Enabled = false;
           }
       }

       private void lbl_Balance_EnabledChanged(object sender, EventArgs e)
       {
           int btnTure = int.Parse(lbl_Balance.Text);
           int btnRcipt = int.Parse(btn_PrintRecipt.Text);

           if (btnTure != 0)
           {
               btn_PrintRecipt.Enabled = true;
           }
           else
           {
               btn_PrintRecipt.Enabled = false;
           }
       }

       private void lbl_Balance_TextChanged(object sender, EventArgs e)
       {
           if (!string.IsNullOrEmpty(lbl_Balance.Text)  && !string.IsNullOrEmpty(txt_CustomerAmount.Text) && txt_CustomerAmount.Text != "0.00")
           {
               btn_PrintRecipt.Enabled = true;
           }
           else
           {
               btn_PrintRecipt.Enabled = false;
           }
       }

       private void txt_CustomerAmount_TextChanged(object sender, EventArgs e)
       {
           if (!string.IsNullOrEmpty(lbl_Balance.Text) && !string.IsNullOrEmpty(txt_CustomerAmount.Text) && txt_CustomerAmount.Text != "0.00")
           {
               btn_PrintRecipt.Enabled = true;
           }
           else
           {
               btn_PrintRecipt.Enabled = false;
           }
       }

       private void txt_TotalRetailAmount_TextChanged(object sender, EventArgs e)
       {
           if (txt_TotalRetailAmount.Text != "" && txt_TotalSalesAmount.Text != "")
           {

               btn_DashBoard.Enabled = false;
           }
       }

       private void btn_DashBoard_Click(object sender, EventArgs e)
       {
           this.Close();
           frmDashBoard dashBoard = new frmDashBoard();
           dashBoard.Show();
       }

       private void txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (char.IsLetter(e.KeyChar))
           {
               e.Handled = true;  
               MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void txt_CustomerAmount_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (char.IsLetter(e.KeyChar))
           {
               e.Handled = true;  
               MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

      

       
     

      
        

      
       
       

         


    }
}
