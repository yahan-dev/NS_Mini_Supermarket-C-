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
    public partial class report_DailySalesFull : Form
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


        public report_DailySalesFull()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void report_DailySalesFull_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'NSMniSuperMarket_dbDataSet.tb_DailySale' table. You can move, or remove it, as needed.
            this.tb_DailySaleTableAdapter.Fill(this.NSMniSuperMarket_dbDataSet.tb_DailySale);

            this.reportViewer1.RefreshReport();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
