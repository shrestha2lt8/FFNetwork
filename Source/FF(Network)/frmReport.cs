using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace FF_Network_
{
    public partial class frmReport : Form
    {
      public  DateTime? dtStartDate;
      public  DateTime? dtUntilDate;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FFDataSet.usp_GetOrders' table. You can move, or remove it, as needed.
            if (dtStartDate != null && dtUntilDate != null)
            {
                this.usp_GetOrdersTableAdapter.FillByDate(this.FFDataSet.usp_GetOrders,(DateTime) dtStartDate,(DateTime) dtUntilDate);
            }
            else
            {
                this.usp_GetOrdersTableAdapter.Fill(this.FFDataSet.usp_GetOrders);
            }
            /*Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1.Reset() ;  
            this.reportViewer1.LocalReport.ReportEmbeddedResource =  "FF_Network_.Report.frmOrder.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            rds.Name = "FFDataSet";
            FFDataSetTableAdapters.usp_GetOrdersTableAdapter
            FFDataSetTableAdapters.usp_GetOrdersTableAdapter objTable;
            FFDataSetTableAdapters.TableAdapterManager objAdt;
            Me.ReportViewer1.LocalReport.DataSources.Add(rds)
            Me.ReportViewer1.RefreshReport()*/
            this.reportViewer1.RefreshReport();
        }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();

        }
    }
}
