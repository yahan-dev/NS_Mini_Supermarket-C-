namespace NS_Mini_SuperMarket
{
    partial class Form2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tb_ItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NSMniSuperMarket_dbDataSet2 = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_ItemTableAdapter = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet2TableAdapters.tb_ItemTableAdapter();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btn_close = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet2)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_ItemBindingSource
            // 
            this.tb_ItemBindingSource.DataMember = "tb_Item";
            this.tb_ItemBindingSource.DataSource = this.NSMniSuperMarket_dbDataSet2;
            // 
            // NSMniSuperMarket_dbDataSet2
            // 
            this.NSMniSuperMarket_dbDataSet2.DataSetName = "NSMniSuperMarket_dbDataSet2";
            this.NSMniSuperMarket_dbDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tb_ItemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NS_Mini_SuperMarket.test_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1140, 273);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_ItemTableAdapter
            // 
            this.tb_ItemTableAdapter.ClearBeforeFill = true;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 15;
            this.guna2GroupBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2GroupBox1.Controls.Add(this.guna2CircleButton2);
            this.guna2GroupBox1.Controls.Add(this.guna2CircleButton1);
            this.guna2GroupBox1.Controls.Add(this.btn_close);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(11, 11);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1142, 41);
            this.guna2GroupBox1.TabIndex = 22;
            this.guna2GroupBox1.Text = "Item Details Report";
            this.guna2GroupBox1.TextOffset = new System.Drawing.Point(50, 0);
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.Animated = true;
            this.guna2CircleButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.BorderColor = System.Drawing.Color.Red;
            this.guna2CircleButton2.BorderThickness = 2;
            this.guna2CircleButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.Red;
            this.guna2CircleButton2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2CircleButton2.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2CircleButton2.HoverState.ForeColor = System.Drawing.Color.Black;
            this.guna2CircleButton2.Location = new System.Drawing.Point(1104, 6);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.PressedColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.Size = new System.Drawing.Size(31, 31);
            this.guna2CircleButton2.TabIndex = 15;
            this.guna2CircleButton2.Text = "X";
            this.guna2CircleButton2.TextOffset = new System.Drawing.Point(1, 0);
            this.guna2CircleButton2.Click += new System.EventHandler(this.guna2CircleButton2_Click);
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
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1164, 354);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet2)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_ItemBindingSource;
        private NSMniSuperMarket_dbDataSet2 NSMniSuperMarket_dbDataSet2;
        private NSMniSuperMarket_dbDataSet2TableAdapters.tb_ItemTableAdapter tb_ItemTableAdapter;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton btn_close;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
    }
}