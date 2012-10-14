using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFNetwork;
namespace FF_Network_
{
    public partial class frmOrderReport : Form
    {
        public frmOrderReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Keydown event for from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOrderReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        /// <summary>
        /// Cancel button click event to close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Ok button click event to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------
            //Validation
            //-------------------------------------------------------------------------------------------------------------
            if (mtxtStartDate.Text.Trim() != "/  /")
            {
                if (Utility.IsValidDate(mtxtStartDate.Text.Trim()) == false)
                {
                    MessageBox.Show("Date should be on dd/MM/yyyy format", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtStartDate.Focus();
                    return;
                }
            }


            if (mtxtUntilDate.Text.Trim() != "/  /")
            {
                if (Utility.IsValidDate(mtxtUntilDate.Text.Trim()) == false)
                {
                    MessageBox.Show("Date should be on dd/MM/yyyy format", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtUntilDate.Focus();
                    return;
                }
            }
         
            frmReport frmReport = new frmReport();
            frmReport.dtStartDate = Utility.GetConvertedDate(mtxtStartDate.Text.Trim());
            frmReport.dtUntilDate = Utility.GetConvertedDate(mtxtUntilDate.Text.Trim());
            frmReport.ShowDialog();
            frmReport.Focus();
            this.Close();
    
        }
    }
}
