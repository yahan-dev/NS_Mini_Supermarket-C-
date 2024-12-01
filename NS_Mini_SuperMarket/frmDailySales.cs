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
    public partial class frmDailySales : Form
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



        public frmDailySales()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            rdb_FilterReport.Checked = false;
            rdb_FullReport.Checked = false;

           
        }

        private string connectionString = @"Data Source=C:/Users/YahanB/Documents/NSMniSuperMarket_db.sdf";

        private void LoadData()
        {
            using (SqlCeConnection conn = new SqlCeConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tb_DailySale";
                SqlCeDataAdapter adapeter = new SqlCeDataAdapter(query, conn);
                DataTable datatable = new DataTable();
                adapeter.Fill(datatable);
                DataGridView1.DataSource = datatable;

            }
        }

        private void frmDailySales_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                // Assuming the TextBox should show the value from the first cell of the selected row
                //textBox1.Text = selectedRow.Cells[0].Value.ToString();

                txt_RecordNo.Text = selectedRow.Cells[0].Value.ToString();
                dtp_SalesDate.Text = selectedRow.Cells[1].Value.ToString();
                txt_RetailSalesTotal.Text = selectedRow.Cells[2].Value.ToString();
                txt_SalesTotal.Text = selectedRow.Cells[3].Value.ToString();
                txt_DailySalesIncome.Text = selectedRow.Cells[4].Value.ToString();
            }
        }



        String recordNo;
        DateTime salesDate;
        Decimal retailSalesTotal;
        Decimal salesCost;
        Decimal dailySalesIncome;

            
        private void btn_DailySalesInsert_Click(object sender, EventArgs e)
        {
            try 
            {

                recordNo = (txt_RecordNo.Text);
                salesDate = DateTime.Parse(dtp_SalesDate.Text);
                retailSalesTotal = Decimal.Parse(txt_RetailSalesTotal.Text);
                salesCost = Decimal.Parse(txt_SalesTotal.Text);
                dailySalesIncome = Decimal.Parse(txt_DailySalesIncome.Text);


                //  SupplierNo, 
                // SQL Insert Query
                string query = @"INSERT INTO tb_DailySale (
                                                
                                                SalesDate, 
                                                RetailSalesTotal, 
                                                SalesTotal,
                                                DailySalesIncome)

                                                VALUES (

                                                
                                                @salesDate,
                                                @retailSalesTotal,
                                                @salesCost,
                                                @dailySalesIncome)";

                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                    {
                        // Add parameters to the command
                        //cmd.Parameters.AddWithValue("@recordNo", txt_RecordNo.Text);
                        cmd.Parameters.AddWithValue("@salesDate", DateTime.Parse(dtp_SalesDate.Text));
                        cmd.Parameters.AddWithValue("@retailSalesTotal", txt_RetailSalesTotal.Text);
                        cmd.Parameters.AddWithValue("@salesCost", txt_SalesTotal.Text);
                        cmd.Parameters.AddWithValue("@dailySalesIncome", txt_DailySalesIncome.Text);


                        // Open the connection
                        conn.Open();

                        // Execute the insert command
                        int result = cmd.ExecuteNonQuery();

                      
                        if (result > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                            clearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Error inserting data.");
                        }

                         
                        conn.Close();
                    }
                }

            }catch(Exception){

                MessageBox.Show("Invalid Data Entered, Try Again!!");

            }
  
        }
 
        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            try
            {

                String query = "SELECT * FROM tb_DailySale WHERE RecordNo = @recordNo";

                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@recordNo", txt_RecordNo.Text);

                        
                        conn.Open();

                      
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("No record found with the specified Record No.");
                            }
                            else
                            {

                                txt_RecordNo.Text = reader["RecordNo"].ToString();
                                dtp_SalesDate.Text = reader["SalesDate"].ToString();
                                txt_RetailSalesTotal.Text = reader["RetailSalesTotal"].ToString();
                                txt_SalesTotal.Text = reader["SalesTotal"].ToString();
                                txt_DailySalesIncome.Text = reader["DailySalesIncome"].ToString();

                            }
                        }

                      
                        conn.Close();
                    }
                }

            }catch(Exception)
            {
                MessageBox.Show("Invalid Data Search, Try Again!!");
            }
 
           
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {

           try  // RecordNo =  @recordNo, 
           {

                string query = @"UPDATE tb_DailySale 
                             SET 
                                
                                 SalesDate =  @salesDate, 
                                 RetailSalesTotal =  @retailSalesTotal, 
                                 SalesTotal =  @salesCost, 
                                 DailySalesIncome =  @dailySalesIncome                                   
                             WHERE RecordNo = @recordNo";

                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@recordNo", txt_RecordNo.Text);
                        cmd.Parameters.AddWithValue("@salesDate", dtp_SalesDate.Text);
                        cmd.Parameters.AddWithValue("@retailSalesTotal", txt_RetailSalesTotal.Text);
                        cmd.Parameters.AddWithValue("@salesCost", txt_SalesTotal.Text);
                        cmd.Parameters.AddWithValue("@dailySalesIncome", txt_DailySalesIncome.Text);

                         
                        conn.Open();

                      
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

                         
                        conn.Close();
                    }
                }

             }catch(Exception)
           {
               MessageBox.Show("Invalid Data Update, Try Again!!");
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
                string query = "DELETE FROM tb_DailySale WHERE RecordNo = @recordNo";

                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@recordNo", txt_RecordNo.Text);

                        
                        con.Open();

                        
                        int result = cmd.ExecuteNonQuery();

                         
                        if (result > 0)
                        {
                            MessageBox.Show("Record deleted successfully!");

                             
                            clearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified Supplier ID.");
                        }

                        
                        con.Close();
                    }
                }
            }
            
            }catch(Exception)
            {
                MessageBox.Show("Invalid Data Update, Try Again!!");
            }



            
        }


        private void clearFormFields()
        {
            txt_RecordNo.Text = "";
            dtp_SalesDate.Text = "";
            txt_DailySalesIncome.Text = "";
            txt_SalesTotal.Text = "";
            txt_RetailSalesTotal.Text = "";
           
        }

      /*  Decimal retailSalesTotal;
        Decimal salesCost;
        Decimal dailySalesIncome;*/

        private void txt_SalesTotal_TextChanged(object sender, EventArgs e)
        {
            

            if(txt_RetailSalesTotal.Text != "" && txt_SalesTotal.Text != "" ){

                dailySalesIncome = Convert.ToDecimal(txt_RetailSalesTotal.Text.Trim());
                salesCost = Convert.ToDecimal(txt_SalesTotal.Text.Trim());

                 decimal total = dailySalesIncome - salesCost;

                 txt_DailySalesIncome.Text = total.ToString();
            }

           
        }

        private void txt_RetailSalesTotal_TextChanged(object sender, EventArgs e)
        {
            txt_SalesTotal.Text = string.Empty;
        }

        private void btn_SalesReport_Click(object sender, EventArgs e)
        {
            if(rdb_FullReport.Checked ==true)
            {
                report_DailySalesFull fullreport = new report_DailySalesFull();
                fullreport.Show();
            }
            else if (rdb_FilterReport.Checked == true)
            {
                report_DailySales filterreport = new report_DailySales();
                filterreport.Show();
            }
        }

        private void rdb_FullReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FullReport.Checked == true)
            {
                btn_SalesReport.Enabled = true;
            }
        }

        private void rdb_FilterReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FilterReport.Checked == true)
            {
                btn_SalesReport.Enabled = true;
            }
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDashBoard dashBoard = new frmDashBoard();
            dashBoard.Show();
        }

        private void txt_RetailSalesTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;  
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_DailySalesIncome_TextChanged(object sender, EventArgs e)
        {

            if ((txt_RetailSalesTotal.Text == "") || (txt_SalesTotal.Text == ""))
            {
                txt_DailySalesIncome.Text =  "";
            }
        }

        private void txt_SalesTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;  
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_DailySalesIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;  
                MessageBox.Show("Error: Letters are not allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

         

    }
}
