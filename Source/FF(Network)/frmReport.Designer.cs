namespace FF_Network_
{
    partial class frmReport
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
            this.usp_GetOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FFDataSet = new FF_Network_.FFDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_GetOrdersTableAdapter = new FF_Network_.FFDataSetTableAdapters.usp_GetOrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetOrdersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_GetOrdersBindingSource
            // 
            this.usp_GetOrdersBindingSource.DataMember = "usp_GetOrders";
            this.usp_GetOrdersBindingSource.DataSource = this.FFDataSet;
            // 
            // FFDataSet
            // 
            this.FFDataSet.DataSetName = "FFDataSet";
            this.FFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FFDataSet";
            reportDataSource1.Value = this.usp_GetOrdersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FF_Network_.Report.rptOrder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(900, 651);
            this.reportViewer1.TabIndex = 0;
            // 
            // usp_GetOrdersTableAdapter
            // 
            this.usp_GetOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 651);
            this.ControlBox = false;
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FF: Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReport_FormClosing);
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetOrdersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_GetOrdersBindingSource;
        private FFDataSet FFDataSet;
        private FFDataSetTableAdapters.usp_GetOrdersTableAdapter usp_GetOrdersTableAdapter;


    }
}