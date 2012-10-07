using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFModal.Controller;
using System.Text.RegularExpressions;
namespace FF_Network_
{
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }

        #region "Form Events"

        /// <summary>
        /// Form key down event to handle Escape key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Form Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCompany_Load(object sender, EventArgs e)
        {
            FFModal.Company objCompany= CompanyController.Get();
            if (objCompany != null)
            {
                txtCompany.Text = objCompany.Name;
                txtAddress.Text = objCompany.Address;
                txtRegistrationNumber.Text = objCompany.RegistrationNumber;
                txtPanNo.Text = objCompany.PanNumber;
                txtEmail.Text = objCompany.Email;
                txtWebsite.Text = objCompany.Website;
                txtPhoneNo.Text = objCompany.PhoneNumber;
                txtFax.Text = objCompany.Fax;
                txtContactPerson.Text = objCompany.ContactPerson;
            }
        }

        #endregion

        #region "Contol Events"

        /// <summary>
        /// Validating event for email textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmail.Text.Trim() != string.Empty)
            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    e.Cancel = true;

                }

            }
        }

        /// <summary>
        /// Website validation event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWebsite_Validating(object sender, CancelEventArgs e)
        {
            Regex mRegxExpression;

            if (txtWebsite.Text.Trim() != string.Empty)
            {

                mRegxExpression = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");

                if (!mRegxExpression.IsMatch(txtWebsite.Text.Trim()))
                {

                    MessageBox.Show("Please enter correct website address.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    e.Cancel = true;

                }

            }
        }

        /// <summary>
        /// OK Button click event which saves the data on database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            CompanyController.Edit(txtCompany.Text, txtAddress.Text, txtRegistrationNumber.Text, txtPanNo.Text, txtPhoneNo.Text, txtFax.Text, txtEmail.Text, txtWebsite.Text, txtContactPerson.Text);
            this.Close();
        }

        #endregion
    }
}
