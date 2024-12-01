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
    public partial class frmLogin : Form
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


        public frmLogin( )
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

    

        private void btn_LogIn_Click_1(object sender, EventArgs e)
        {
            string username = (txt_username.Text.Trim());
            string password = (txt_password.Text.Trim());

            // Check the credentials (replace this with your actual logic)
            if ((username == "admin") && (password == "admin"))
            {
                // admin keeps alive while switch among the pages to being button enabled 
                UserSession.IsAdmin = true;
                 
                frmDashBoard dashboard = new frmDashBoard();
                dashboard.EnableButtons();
                dashboard.Show();

                this.Hide();
            }
            else if ((username == "user") && (password == "user"))
            {
                frmDashBoard dashboard = new frmDashBoard();
                dashboard.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            } 
        }

       



  

        
    }
}
