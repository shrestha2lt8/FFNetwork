using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFModal.Controller;
using FFModal;
namespace FF_Network_
{
    public partial class frmLogin : Form
    {
        public bool success = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Login button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserController.GetUser(txtUser.Text, txtPassword.Text) == null)
            {
                MessageBox.Show("Invalid login detail !!", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                success = true;
                FFNetwork.Utility.AdminUserId = UserController.GetUser(txtUser.Text, txtPassword.Text).UserID;
                this.Close();
            }
        }

        /// <summary>
        /// Keydown event of  login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
