using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFModal.Controller;

namespace FF_Network_
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Commision menu click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComission frmComission = new frmComission();
            frmComission.ShowDialog();
        }

        /// <summary>
        /// About menu click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }

        /// <summary>
        /// Tax menu click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTax frmTax = new frmTax();
            frmTax.ShowDialog();
        }

        /// <summary>
        /// Main form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            enableMenus(false);
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.success == true)
                enableMenus(true);
        }

        private void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.success == true)
                enableMenus(true);
        }

        public void enableMenus(bool pState )
        {

            loginToolStripMenuItem.Enabled =! pState;
            logoutToolStripMenuItem.Enabled = pState;
            customerToolStripMenuItem.Enabled = pState;
            orderToolStripMenuItem.Enabled = pState;
            taxToolStripMenuItem.Enabled = pState;
            commisionToolStripMenuItem.Enabled = pState;
            customerHierarchyToolStripMenuItem.Enabled = pState;
            orderReportToolStripMenuItem.Enabled = pState;
            areaToolStripMenuItem.Enabled = pState;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableMenus(false);
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArea frmArea = new frmArea();
            frmArea.ShowDialog();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrder frmOrder = new frmOrder();
            frmOrder.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.ShowDialog();
        }
    }
}
