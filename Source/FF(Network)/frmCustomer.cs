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
using FFNetwork;
using System.Text.RegularExpressions;
namespace FF_Network_
{
    public partial class frmCustomer : Form
    {
        List<Customer> lstCustomer;
        int pCurrentRow = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }

        #region "Form Event"

        /// <summary>
        /// Keydown event of  customer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
 
        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.Tag = "Nav";
            entryControlStatus(false);
            buttonStatus(true);
            //lstCustomer = CustomerController.GetAll();
        }

        #endregion

        #region "Control Event"

        /// <summary>
        /// Add button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearControls();
            this.Tag = "Add";
            entryControlStatus(true);
            buttonStatus(false);
        }

        /// <summary>
        /// Edit button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            clearControls();
            entryControlStatus(true);
            buttonStatus(false);
            this.Tag = "Edit";
        }

        /// <summary>
        /// Delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Dump button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDump1_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtIntroducerID.Text = frmLookup.returnField1;
            txtIntroducerID.Focus();
        }

        /// <summary>
        /// Dump button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDump2_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtIntroducerID.Text = frmLookup.returnField1;
            txtIntroducerID.Focus();
            txtReferenceID.Text = frmLookup.returnField1;
            txtReferenceID.Focus();
        }

        /// <summary>
        /// Ok button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //---------------------------------------------------------------------------------------------------------------------
            //Validation
            //---------------------------------------------------------------------------------------------------------------------

            if (txtIntroducerID.Text.Trim() == "")
            {
                MessageBox.Show("Introducer id cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIntroducerID.Focus();
                return;
            }

            if (txtReferenceID.Text.Trim() == "")
            {
                MessageBox.Show("Reference id cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReferenceID.Focus();
                return;
            }

            if (dateTimePickerCreateddate.Text.Trim() == "")
            {
                MessageBox.Show("Created date cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerCreateddate.Focus();
                return;
            }

            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Customer name cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerName.Focus();
                return;
            }

            if (txtBenificiaryName.Text.Trim() == "")
            {
                MessageBox.Show("Benificiary name cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBenificiaryName.Focus();
                return;
            }

            //if (ddlGender == null || ddlGender.SelectedText == string.Empty || ddlGender.Items.Count <= 0)
            //{
            //    MessageBox.Show("Gender should be selected.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ddlGender.Focus();
            //    return;
            //}

            if (dateTimePickerDOB.Text.Trim() == "")
            {
                MessageBox.Show("Date of birth cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerDOB.Focus();
                return;
            }


            if (txtCitizenshipID.Text.Trim() == "")
            {
                MessageBox.Show("Citizenship ID cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCitizenshipID.Focus();
                return;
            }

            if (txtLicenseID.Text.Trim() == "")
            {
                MessageBox.Show("License id cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLicenseID.Focus();
                return;
            }

            if (txtPassportID.Text.Trim() == "")
            {
                MessageBox.Show("Passport id cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassportID.Focus();
                return;
            }


            if (txtStreet.Text.Trim() == "")
            {
                MessageBox.Show("Street name cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStreet.Focus();
                return;
            }

            if (txtHouseNo.Text.Trim() == "")
            {
                MessageBox.Show("House number cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStreet.Focus();
                return;
            }

            if (txtAreaCode.Text.Trim() == "")
            {
                MessageBox.Show("Area code cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaCode.Focus();
                return;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Address cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            if (txtHomeTelephone.Text.Trim() == "")
            {
                MessageBox.Show("Home telephone number cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHomeTelephone.Focus();
                return;
            }

            if (txtMobileNo.Text.Trim() == "")
            {
                MessageBox.Show("Mobile numbere cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMobileNo.Focus();
                return;
            }

            if (txtEmailAddress.Text.Trim() == "")
            {
                MessageBox.Show("Email address cannot be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmailAddress.Focus();
                return;
            }


            //---------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------------------
            //Insert process
            //---------------------------------------------------------------------------------------------------------------------
            if (this.Tag.ToString() == "Add")
            {
                txtMembershipID.Text = CustomerController.GetNextMembershipId(txtAreaCode.Text);
                CustomerController.Add( txtMembershipID.Text , txtIntroducerID.Text, txtReferenceID.Text, txtCustomerName.Text, txtBenificiaryName.Text, ddlGender.Text,
                    dateTimePickerDOB.Value, DateTime.Now, Utility.AdminUserId, ddlMaritialStatus.Text, "Nepal", txtCitizenshipID.Text,
                    txtLicenseID.Text, txtPassportID.Text, ddlCountry.Text, ddlCity.Text, ddlMunicipality.Text, ddlDistrict.Text,
                    txtStreet.Text, txtHouseNo.Text, txtAreaCode.Text, txtAddress.Text, txtHomeTelephone.Text, txtMobileNo.Text,txtEmailAddress.Text,Utility.GetPhotoByte( txtPhotoPath.Text));

            }
            else if (this.Tag.ToString() == "Edit")
            {
                CustomerController.Edit(txtMembershipID.Text, txtIntroducerID.Text, txtReferenceID.Text, txtCustomerName.Text, txtBenificiaryName.Text, ddlGender.Text,
                          dateTimePickerDOB.Value, DateTime.Now, Utility.AdminUserId, ddlMaritialStatus.Text, "Nepal", txtCitizenshipID.Text,
                          txtLicenseID.Text, txtPassportID.Text, ddlCountry.Text, ddlCity.Text, ddlMunicipality.Text, ddlDistrict.Text,
                          txtStreet.Text, txtHouseNo.Text, txtAreaCode.Text, txtAddress.Text, txtHomeTelephone.Text, txtMobileNo.Text, txtEmailAddress.Text, Utility.GetPhotoByte(txtPhotoPath.Text));
            }

            //---------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------

        }

        /// <summary>
        /// Cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Tag = "Nav";
            entryControlStatus(false);
            buttonStatus(true);
        }


        /// <summary>
        /// Browse photo button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            
            try
            {
                // open file dialog
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                this.openFileDialog1.Title = "Select Photo";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    //pictureBox1.Image = new Bitmap(open.FileName);

                    // image file path
                    txtPhotoPath.Text = open.FileName;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Image loading error....");
            }
            
        }

        /// <summary>
        /// Validation of e-mail address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmailAddress.Text.Trim() != string.Empty)
            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmailAddress.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmailAddress.Focus();

                }

            }
        }

        /// <summary>
        /// Validation of created date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePickerCreateddate_ValueChanged(object sender, EventArgs e)
        {

            if (dateTimePickerCreateddate.Value < DateTime.Today)
            {
                MessageBox.Show("Created date should not be greater than to date");
                dateTimePickerCreateddate.Value = DateTime.Today;
            }
        }

        /// <summary>
        /// Validation of gender dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlGender_Validating(object sender, CancelEventArgs e)
        {
            if (ddlGender.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of marital status dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlMaritialStatus_Validating(object sender, CancelEventArgs e)
        {
            if (ddlMaritialStatus.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of nationality dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlNationality_Validating(object sender, CancelEventArgs e)
        {

            if (ddlNationality.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of country dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCountry_Validating(object sender, CancelEventArgs e)
        {
            if (ddlCountry.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of city dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCity_Validating(object sender, CancelEventArgs e)
        {
            if (ddlCity.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of municipality dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlMunicipality_Validating(object sender, CancelEventArgs e)
        {
            if (ddlMunicipality.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Validation of district dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlDistrict_Validating(object sender, CancelEventArgs e)
        {
            if (ddlDistrict.SelectedIndex <= 0)
            {

                MessageBox.Show("The option from dropdown should be selected.", "FF Network", MessageBoxButtons.OK);

                e.Cancel = true;

            }
        }

        /// <summary>
        /// Navivation button click event(First)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            pCurrentRow = 0;
            navigation(pCurrentRow);
        }

        /// <summary>
        /// Navigation button click event(Previous)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pCurrentRow > 0)
            {
                pCurrentRow = pCurrentRow-1;
                navigation(pCurrentRow);
            }
        }

        /// <summary>
        /// Navigation button click event(Next)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            pCurrentRow = pCurrentRow + 1;
            if (pCurrentRow < lstCustomer.Count)
            {
                navigation(pCurrentRow);
            }
            else
            {
                pCurrentRow = pCurrentRow - 1;
            }
        }

        /// <summary>
        /// Navigation button click event(Last)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            pCurrentRow = lstCustomer.Count-1;
            navigation(pCurrentRow);
        }

        /// <summary>
        /// Keydown event for txtIntroducerID textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIntroducerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
            else if (e.KeyCode == Keys.F1)
                btnDump1_Click(null, null);
        }

        /// <summary>
        /// Keydown event for txtAreaName textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReferenceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
            else if (e.KeyCode == Keys.F1)
                btnDump2_Click(null, null);
        }


        #endregion

        #region "Custom Methods"
        /// <summary>
        /// Add,Edit ,Delete and Ok and cancel button status
        /// </summary>
        /// <param name="pState"></param>
        private void buttonStatus(bool pState)
        {
            btnAdd.Enabled = pState;
            btnEdit.Enabled = pState;
            btnDelete.Enabled = pState;
            btnFirst.Enabled = pState;
            btnLast.Enabled = pState;
            btnPrevious.Enabled = pState;
            btnNext.Enabled = pState;
        }

        /// <summary>
        /// Textbox control status
        /// </summary>
        /// <param name="pState"></param>
        private void entryControlStatus(bool pState)
        {
            txtIntroducerID.Enabled = pState;
            btnDump1.Enabled = pState;
            txtReferenceID.Enabled = pState;
            btnDump2.Enabled = pState;
            dateTimePickerCreateddate.Enabled = pState;
            txtCustomerName.Enabled = pState;
            txtBenificiaryName.Enabled = pState;
            ddlGender.Enabled = pState;
            dateTimePickerDOB.Enabled=pState;
            ddlMaritialStatus.Enabled = pState;
            ddlNationality.Enabled = pState;
            txtCitizenshipID.Enabled = pState;
            txtLicenseID.Enabled = pState;
            txtPassportID.Enabled = pState;
            ddlCountry.Enabled = pState;
            ddlCity.Enabled = pState;
            ddlMunicipality.Enabled = pState;
            ddlDistrict.Enabled = pState;
            txtStreet.Enabled = pState;
            txtHouseNo.Enabled = pState;
            txtAreaCode.Enabled = pState;
            txtAddress.Enabled = pState;
            txtHomeTelephone.Enabled = pState;
            txtMobileNo.Enabled = pState;
            txtEmailAddress.Enabled = pState;
            txtPhotoPath.Enabled = pState;
            btnBrowsePhoto.Enabled = pState;
            btnOk.Enabled = pState;
            btnCancel.Enabled = pState;
        }

        /// <summary>
        /// ClearControls
        /// </summary>
        /// <param name="pState"></param>
        private void clearControls()
        {
            this.Tag = "Nav";
            txtIntroducerID.Text = "";
            txtReferenceID.Text = "";
            txtCustomerName.Text = "";
            txtBenificiaryName.Text = "";
            txtCustomerName.Text = "";
            txtLicenseID.Text = "";
            txtPassportID.Text = "";
            txtStreet.Text = "";
            txtAreaCode.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtHomeTelephone.Text = "";
            txtMobileNo.Text = "";
            txtEmailAddress.Text = "";
        }

        private void navigation(int pRowIndex)
        {
            if (lstCustomer.Count > 0)
            {
                if (pRowIndex >= 0 && pRowIndex < lstCustomer.Count)
                {
                    txtIntroducerID.Text = lstCustomer[pRowIndex].IntroducerID;
                    txtReferenceID.Text = lstCustomer[pRowIndex].ReferenceID;
                }
            }
            else
            {
                MessageBox.Show("No records are available.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


    }
}
