using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFNetwork;
using FFModal.Controller;
namespace FF_Network_
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (UserController.GetUser(Utility.AdminUserName, txtOldPassword.Text) == null)
            {
                MessageBox.Show("Please correct old password.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
            {
                MessageBox.Show("Please correct confirm new password.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmNewPassword.Focus();
                return;
            }

            UserController.ChangePassword(Utility.AdminUserName, txtConfirmNewPassword.Text);
            this.Close();
        }
    }
}
