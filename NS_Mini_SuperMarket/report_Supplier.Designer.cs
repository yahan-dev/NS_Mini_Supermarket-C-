namespace NS_Mini_SuperMarket
{
    partial class report_Supplier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tb_SupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NSMniSuperMarket_dbDataSet1 = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_SupplierTableAdapter = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet1TableAdapters.tb_SupplierTableAdapter();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btn_close = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_SupplierBindingSource
            // 
            this.tb_SupplierBindingSource.DataMember = "tb_Supplier";
            this.tb_SupplierBindingSource.DataSource = this.NSMniSuperMarket_dbDataSet1;
            // 
            // NSMniSuperMarket_dbDataSet1
            // 
            this.NSMniSuperMarket_dbDataSet1.DataSetName = "NSMniSuperMarket_dbDataSet1";
            this.NSMniSuperMarket_dbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.tb_SupplierBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NS_Mini_SuperMarket.rdlc_SupplierDetails.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1491, 296);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_SupplierTableAdapter
            // 
            this.tb_SupplierTableAdapter.ClearBeforeFill = true;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 15;
            this.guna2GroupBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2GroupBox1.Controls.Add(this.guna2CircleButton1);
            this.guna2GroupBox1.Controls.Add(this.btn_close);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(11, 11);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1492, 41);
            this.guna2GroupBox1.TabIndex = 21;
            this.guna2GroupBox1.Text = "Supplier Details Report";
            this.guna2GroupBox1.TextOffset = new System.Drawing.Point(50, 0);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.CheckedState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.FocusedColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Image = global::NS_Mini_SuperMarket.Properties.Resources.Business_Report;
            this.guna2CircleButton1.ImageOffset = new System.Drawing.Point(0, 15);
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2CircleButton1.Location = new System.Drawing.Point(-6, -4);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(72, 56);
            this.guna2CircleButton1.TabIndex = 14;
            this.guna2CircleButton1.Text = " ";
            this.guna2CircleButton1.UseTransparentBackground = true;
            // 
            // btn_close
            // 
            this.btn_close.Animated = true;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BorderColor = System.Drawing.Color.Red;
            this.btn_close.BorderThickness = 2;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.FillColor = System.Drawing.Color.Transparent;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.Red;
            this.btn_close.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_close.HoverState.FillColor = System.Drawing.Color.Red;
            this.btn_close.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btn_close.Location = new System.Drawing.Point(1452, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_close.Size = new System.Drawing.Size(31, 31);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "X";
            this.btn_close.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // test_Sup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1515, 374);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "test_Sup";
            this.Text = "test_Sup";
            this.Load += new System.EventHandler(this.test_Sup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_SupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_SupplierBindingSource;
        private NSMniSuperMarket_dbDataSet1 NSMniSuperMarket_dbDataSet1;
        private NSMniSuperMarket_dbDataSet1TableAdapters.tb_SupplierTableAdapter tb_SupplierTableAdapter;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton btn_close;
    }
}