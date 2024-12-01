namespace NS_Mini_SuperMarket
{
    partial class report_DailySales
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
            this.tb_DailySaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NSMniSuperMarket_dbDataSet = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_Filter = new Guna.UI2.WinForms.Guna2Button();
            this.tb_DailySaleTableAdapter = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSetTableAdapters.tb_DailySaleTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btn_close = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.NSMniSuperMarket_dbDataSet1 = new NS_Mini_SuperMarket.NSMniSuperMarket_dbDataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.tb_DailySaleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_DailySaleBindingSource
            // 
            this.tb_DailySaleBindingSource.DataMember = "tb_DailySale";
            this.tb_DailySaleBindingSource.DataSource = this.NSMniSuperMarket_dbDataSet;
            // 
            // NSMniSuperMarket_dbDataSet
            // 
            this.NSMniSuperMarket_dbDataSet.DataSetName = "NSMniSuperMarket_dbDataSet";
            this.NSMniSuperMarket_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tb_DailySaleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NS_Mini_SuperMarket.rdlc_DailySalesFilter.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 220);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1366, 284);
            this.reportViewer1.TabIndex = 0;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BorderRadius = 15;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(378, 90);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.guna2DateTimePicker1.TabIndex = 1;
            this.guna2DateTimePicker1.Value = new System.DateTime(2024, 9, 17, 11, 1, 2, 590);
            this.guna2DateTimePicker1.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.BorderRadius = 15;
            this.guna2DateTimePicker2.Checked = true;
            this.guna2DateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(779, 89);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(200, 36);
            this.guna2DateTimePicker2.TabIndex = 1;
            this.guna2DateTimePicker2.Value = new System.DateTime(2024, 9, 17, 11, 1, 2, 590);
            // 
            // btn_Filter
            // 
            this.btn_Filter.Animated = true;
            this.btn_Filter.BorderRadius = 15;
            this.btn_Filter.BorderThickness = 3;
            this.btn_Filter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Filter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Filter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Filter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Filter.FillColor = System.Drawing.Color.Transparent;
            this.btn_Filter.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Filter.ForeColor = System.Drawing.Color.Black;
            this.btn_Filter.HoverState.BorderColor = System.Drawing.Color.Cyan;
            this.btn_Filter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Filter.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Filter.Location = new System.Drawing.Point(581, 142);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(180, 45);
            this.btn_Filter.TabIndex = 2;
            this.btn_Filter.Text = "Filter";
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // tb_DailySaleTableAdapter
            // 
            this.tb_DailySaleTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(345, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(723, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "From :";
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
            this.btn_close.Location = new System.Drawing.Point(1314, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_close.Size = new System.Drawing.Size(31, 31);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "X";
            this.btn_close.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
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
            this.guna2GroupBox1.Size = new System.Drawing.Size(1355, 41);
            this.guna2GroupBox1.TabIndex = 18;
            this.guna2GroupBox1.Text = "Daily Sales Report";
            this.guna2GroupBox1.TextOffset = new System.Drawing.Point(50, 0);
            // 
            // NSMniSuperMarket_dbDataSet1
            // 
            this.NSMniSuperMarket_dbDataSet1.DataSetName = "NSMniSuperMarket_dbDataSet1";
            this.NSMniSuperMarket_dbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // report_DailySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1377, 512);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "report_DailySales";
            this.Text = "report_DailySales";
            this.Load += new System.EventHandler(this.report_DailySales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_DailySaleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NSMniSuperMarket_dbDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_DailySaleBindingSource;
        private NSMniSuperMarket_dbDataSet NSMniSuperMarket_dbDataSet;
        private NSMniSuperMarket_dbDataSetTableAdapters.tb_DailySaleTableAdapter tb_DailySaleTableAdapter;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private Guna.UI2.WinForms.Guna2Button btn_Filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton btn_close;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private NSMniSuperMarket_dbDataSet1 NSMniSuperMarket_dbDataSet1;
    }
}