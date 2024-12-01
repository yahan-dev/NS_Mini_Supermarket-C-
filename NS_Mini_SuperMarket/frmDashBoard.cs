using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace NS_Mini_SuperMarket
{
    public partial class frmDashBoard : Form
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
        

        public frmDashBoard()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // admin keeps alive while switch among the pages to being button enabled 
            EnableButton();
        }

        // admin keeps alive while switch among the pages to being button enabled 
        public void EnableButton()
        {
            btn_DailSalesForm.Enabled = UserSession.IsAdmin;  // Enable the button
        }



        private void btn_SalesCalculationForm_Click(object sender, EventArgs e)
        {
            frmSalesCalculation salesCalculationForm = new frmSalesCalculation();
            salesCalculationForm.Show();

            

        }

        private void btn_ItemDetailsForm_Click(object sender, EventArgs e)
        {
            frmItemDetailsForm itemDetailsForm = new frmItemDetailsForm();
            itemDetailsForm.Show();
        }

        public void btn_DailSalesForm_Click(object sender, EventArgs e)
        {
            btn_DailSalesForm.Enabled = true;
            frmDailySales dailySalesForm = new frmDailySales();
            dailySalesForm.Show();
        }

        private void btn_SupplierDetailsForm_Click(object sender, EventArgs e)
        {
            frmSupplierDetails supplierDetailsForm = new frmSupplierDetails();
            supplierDetailsForm.Show();
        }

        public void EnableButtons()
        {
            btn_DailSalesForm.Enabled = true; // Enable the specific buttons
            
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            this.Close();
            frmReports reports = new frmReports();
            reports.Show();
        }

        
    }
}
