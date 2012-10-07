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
using System.IO;
using System.Globalization;

namespace FF_Network_
{
    public partial class frmCustomer : Form
    {

        List<Customer> lstCustomer;
        int pCurrentRow = 0;

        DateTime rs;
        CultureInfo ci = new CultureInfo("en-US");

        public frmCustomer()
        {
            InitializeComponent();
            loadCustomerType();
        }

        #region "Form Event"

        /// <summary>
        /// Keydown event of customer form
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
            //btnFirst.Visible = false;
            //btnPrevious.Visible = false;
            //btnNext.Visible = false;
            //btnLast.Visible = false;
            txtMembershipID.Enabled = false;
            btnMembershipID.Enabled = false;
            entryControlStatus(false);
            buttonStatus(true);
            lstCustomer = CustomerController.GetAll();

            DateTime dob;
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            info.ShortDatePattern = "dd/MM/yyyy";
            DateTime.TryParse(mtxtCreatedDate.Text, info, DateTimeStyles.None, out dob);
            DateTime.TryParse(mtxtDOB.Text, info, DateTimeStyles.None, out dob);
            DateTime.TryParse(mtxtMRDate.Text, info, DateTimeStyles.None, out dob);
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
            txtMembershipID.Text = "";
            entryControlStatus(true);
            this.Text = "FF: Customer - Add";
            buttonStatus(false);
            txtMembershipID.Enabled = false;

        }

        /// <summary>
        /// Edit button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtMembershipID.Enabled = true;
            btnMembershipID.Enabled = true;
            clearControls();
            entryControlStatus(true);
            buttonStatus(false);
            this.Tag = "Edit";
            this.Text = "FF: Customer - Edit";
        }

        /// <summary>
        /// Delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMembershipID.Text.Trim() == "")
            {
                MessageBox.Show("Membership Id cannot be blank.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMembershipID.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this record", "FF Trade", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int orderCount = 0;
                    Customer objCustomer = CustomerController.GetCustomer(txtMembershipID.Text.Trim(), out orderCount);
                    if (orderCount < 1)
                    {
                        CustomerController.Delete(txtMembershipID.Text);
                        lstCustomer = CustomerController.GetAll();
                        pCurrentRow = 0;
                        if (lstCustomer.Count == 0)
                        {
                            clearControls();
                        }
                        else
                        {
                            navigation(pCurrentRow);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer can not be deleted.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// MembershipID button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMembershipID_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtMembershipID.Text = frmLookup.returnField1;
            txtMembershipID.Focus();
        }

        /// <summary>
        /// Dump1 button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIntroducerID_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtIntroducerID.Text = frmLookup.returnField1;
            txtIntroducerID.Focus();
        }

        /// <summary>
        /// Dump2 button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferenceID_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtReferenceID.Text = frmLookup.returnField1;
            txtReferenceID.Focus();
        }

        /// <summary>
        /// Dump3 button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAreCode_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Area;
            frmLookup.ShowDialog();
            txtAreaCode.Text = frmLookup.returnField1;
            txtAreaCode.Focus();
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


            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Customer name cannot be blank.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerName.Focus();
                return;
            }


            if (txtAreaCode.Text.Trim() == "")
            {
                MessageBox.Show("Area code cannot be blank.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaCode.Focus();
                return;
            }
            
            if (txtHomeTelephone.Text.Trim() == "" && txtMobileNo.Text.Trim() == "" )
            {
                MessageBox.Show("Home telephone number/Mobile number cannot be blank.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHomeTelephone.Focus();
                return; 
            }

            //---------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------

            if (CustomerController.IsValidReferenceMemberID(txtReferenceID.Text))
            {
                MessageBox.Show("Maximum horizontal node reached for this memebership id !!", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIntroducerID.Focus();
                return;
            }

            //---------------------------------------------------------------------------------------------------------------------
            //Insert process
            //---------------------------------------------------------------------------------------------------------------------
            if (this.Tag.ToString() == "Add")
            {
                txtMembershipID.Text = CustomerController.GetNextMembershipId(txtAreaCode.Text);

              
                CustomerController.Add(txtMembershipID.Text, txtIntroducerID.Text, txtReferenceID.Text, txtCustomerName.Text,
                    txtBenificiaryName.Text, ddlGender.Text, this.GetDate(mtxtDOB.Text),
                    this.GetDate(mtxtCreatedDate.Text),
                    Utility.AdminUserId, ddlMaritialStatus.Text, ddlNationality.Text , txtCitizenshipID.Text, 
                    txtLicenseID.Text, txtPassportID.Text, ddlCountry.Text, ddlCity.Text, ddlMunicipality.Text, 
                    ddlDistrict.Text, txtStreet.Text, txtHouseNo.Text, txtAreaCode.Text, txtAddress.Text, 
                    txtHomeTelephone.Text, txtMobileNo.Text, txtEmailAddress.Text,
                    Utility.GetPhotoByte(txtPhotoPath.Text), Convert.ToInt32(ddlCustomerType.SelectedValue),
                    this.GetDate(mtxtMRDate.Text));

            }
            //---------------------------------------------------------------------------------------------------------------------
            //Edit process
            //---------------------------------------------------------------------------------------------------------------------
            else if (this.Tag.ToString() == "Edit")
            {
                CustomerController.Edit(txtMembershipID.Text, txtIntroducerID.Text, txtReferenceID.Text, txtCustomerName.Text,
                    txtBenificiaryName.Text, ddlGender.Text, this.GetDate(mtxtDOB.Text),
                   this.GetDate(mtxtCreatedDate.Text), 
                    Utility.AdminUserId, ddlMaritialStatus.Text, ddlNationality.Text, txtCitizenshipID.Text, 
                    txtLicenseID.Text, txtPassportID.Text, ddlCountry.Text, ddlCity.Text, ddlMunicipality.Text, 
                    ddlDistrict.Text, txtStreet.Text, txtHouseNo.Text, txtAreaCode.Text, txtAddress.Text, 
                    txtHomeTelephone.Text, txtMobileNo.Text, txtEmailAddress.Text, 
                    Utility.GetPhotoByte(txtPhotoPath.Text), Convert.ToInt32(ddlCustomerType.SelectedValue),
                    this.GetDate(mtxtMRDate.Text));
            }

            if(txtPhotoPath.Text.Trim()!="")
            {
                MemoryStream ms = new MemoryStream(Utility.GetPhotoByte(txtPhotoPath.Text));
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();
            }
            else if (txtPhotoPath.Text.Trim() == string.Empty || txtPhotoPath.Text.Trim() == " " || txtPhotoPath.Text.Trim() == null)
            {
                lblNoPhoto.Visible = true;
            }

            this.Tag = "Nav";
            entryControlStatus(false);
            buttonStatus(true);
            lstCustomer = CustomerController.GetAll();

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
            this.Text = "FF: Customer";
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
        /// Validation of created date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtCreatedDate_Validating(object sender, CancelEventArgs e)
        {

            if (this.mtxtCreatedDate.Text.Trim() != "/  /")
            {
            if (!DateTime.TryParseExact(this.mtxtCreatedDate.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                MessageBox.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                mtxtCreatedDate.Focus();
            }
            }
        }

        /// <summary>
        /// Validation of marketing representative date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtMRDate_Validating(object sender, CancelEventArgs e)
        {
            if (this.mtxtMRDate.Text.Trim() != "/  /")
            {
            if (!DateTime.TryParseExact(this.mtxtMRDate.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                MessageBox.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                mtxtMRDate.Focus();
            }
            }
        }

        /// <summary>
        /// Validation of date of birth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtDOB_Validating(object sender, CancelEventArgs e)
        {
            if (this.mtxtDOB.Text.Trim() != "/  /")
            {
                if (!DateTime.TryParseExact(this.mtxtDOB.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
                {
                    MessageBox.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    mtxtDOB.Focus();
                }
            }
        }

        /// <summary>
        /// Validation of area code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaCode_Validating(object sender, CancelEventArgs e)
        {
            
                if (txtAreaCode.Text.Trim() != "")
                {
                    if (AreaController.GetAreaByCode(txtAreaCode.Text) == null)
                    {
                        MessageBox.Show("Area code does not exists.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        txtAreaCode.Focus();
                    }
                }
            
        }

        /// <summary>
        /// Validation of e-mail address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmailAddress.Text.Trim() != string.Empty)
            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmailAddress.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    txtEmailAddress.Focus();

                }

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
                pCurrentRow = pCurrentRow - 1;
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
            pCurrentRow = lstCustomer.Count - 1;
            navigation(pCurrentRow);
        }

        /// <summary>
        /// Keydown event for txtMembershipID textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMembershipID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
            else if (e.KeyCode == Keys.F1)
            //{
            //    if (this.Tag.ToString() != "Add")
                    btnMembershipID_Click(null, null);
            //}
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
                btnIntroducerID_Click(null, null);
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
                btnReferenceID_Click(null, null);
        }

        /// <summary>
        /// Keydown event for mask edit textbox created date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtCreatedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list customer type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for mask edit textbox MR(marketing representative) date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtMRDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox customer name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox benificary name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBenificiaryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list gender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for mask edit textbox DOB(date of birth)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list maritial status 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlMaritialStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list nationality 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlNationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox citizenship id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCitizenshipID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox license id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLicenseID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox passport id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassportID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list city
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list municipality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlMunicipality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for dropdown list district
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox street 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox house number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox area code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
            else if (e.KeyCode == Keys.F1)
                btnAreCode_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox home telephone number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHomeTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox mobile number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox email address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Keydown event for textbox photo path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhotoPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
        }

        /// <summary>
        /// Validating memebership id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMembershipID_Validating(object sender, CancelEventArgs e)
        {
            if (this.Tag.ToString() == "Edit")
            {
                if (txtMembershipID.Text.Trim() != "")
                {
                    Customer objCustomer=CustomerController.GetCustomer(txtMembershipID.Text);
                    if (objCustomer == null)
                    {
                        MessageBox.Show("Customer does not exists.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                    else
                    {
                        txtMembershipID.Text = objCustomer.MembershipID;
                        txtIntroducerID.Text = objCustomer.IntroducerID;
                        txtReferenceID.Text = objCustomer.ReferenceID;
                        ddlCustomerType.SelectedValue = objCustomer.CustomerTypeID;
                        mtxtCreatedDate.Text = objCustomer.CreatedDate.ToString();
                        mtxtMRDate.Text = objCustomer.MROrientationDate.ToString();
                        txtCustomerName.Text = objCustomer.CustomerName;
                        txtBenificiaryName.Text = objCustomer.BenificiaryName;
                        ddlGender.Text = objCustomer.Gender;
                        mtxtDOB.Text = objCustomer.DateOfBirth.ToString();
                        ddlMaritialStatus.Text = objCustomer.MaratialStatus;
                        ddlNationality.Text = objCustomer.Nationality;
                        txtCitizenshipID.Text = objCustomer.CitizenshipID;
                        txtLicenseID.Text = objCustomer.LicenseID;
                        txtPassportID.Text = objCustomer.PassportID;
                        ddlCountry.Text = objCustomer.Country;
                        ddlCity.Text = objCustomer.City;
                        ddlMunicipality.Text = objCustomer.Municipality;
                        ddlDistrict.Text = objCustomer.District;
                        txtStreet.Text = objCustomer.Street;
                        txtHouseNo.Text = objCustomer.HomeNumber;
                        txtAreaCode.Text = objCustomer.AreaCode;
                        txtAddress.Text = objCustomer.Address;
                        txtHomeTelephone.Text = objCustomer.HomeTelephone;
                        txtMobileNo.Text = objCustomer.Mobile;
                        txtEmailAddress.Text = objCustomer.EmailAddress;

                        if (objCustomer.Photo != null)
                        {
                            MemoryStream ms = new MemoryStream((byte[])objCustomer.Photo);
                            pictureBox1.Image = Image.FromStream(ms);
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            lblNoPhoto.Visible = false;
                            pictureBox1.Refresh();

                        }
                        else if (objCustomer.Photo == null)
                        {
                            pictureBox1.Image = null;
                            lblNoPhoto.Visible = true;
                        }
                    }
                }
            }
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
            txtMembershipID.Enabled = pState;
            txtIntroducerID.Enabled = pState;
            btnIntroducerID.Enabled = pState;
            txtReferenceID.Enabled = pState;
            btnReferenceID.Enabled = pState;
            mtxtCreatedDate.Enabled = pState;
            ddlCustomerType.Enabled = pState;
            mtxtMRDate.Enabled = pState;
            txtCustomerName.Enabled = pState;
            txtBenificiaryName.Enabled = pState;
            ddlGender.Enabled = pState;
            mtxtDOB.Enabled = pState;
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
            btnAreaCode.Enabled = pState;
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
            txtMembershipID.Text = "";
            txtIntroducerID.Text = "";
            txtReferenceID.Text = "";
            mtxtCreatedDate.Text = "";
            ddlCustomerType.SelectedText = "";
            mtxtDOB.Text = "";
            mtxtMRDate.Text = "";
            txtCustomerName.Text = "";
            txtBenificiaryName.Text = "";
            txtCustomerName.Text = "";
            txtCitizenshipID.Text = "";
            txtLicenseID.Text = "";
            txtPassportID.Text = "";
            txtStreet.Text = "";
            txtAreaCode.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtHomeTelephone.Text = "";
            txtMobileNo.Text = "";
            txtEmailAddress.Text = "";
            ddlCity.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlMaritialStatus.SelectedIndex = 0;
            ddlMunicipality.SelectedIndex = 0;
            ddlNationality.SelectedIndex = 0;
            ddlCustomerType.SelectedIndex = 0;
            pictureBox1.Image = null;
        }

        /// <summary>
        /// Load data on navigation
        /// </summary>
        /// <param name="pState"></param>
        private void navigation(int pRowIndex)
        {
            if (lstCustomer.Count > 0)
            {
                if (pRowIndex >= 0 && pRowIndex < lstCustomer.Count)
                {
                    
                    txtMembershipID.Text = lstCustomer[pRowIndex].MembershipID;
                    txtIntroducerID.Text = lstCustomer[pRowIndex].IntroducerID;
                    txtReferenceID.Text = lstCustomer[pRowIndex].ReferenceID;
                    ddlCustomerType.SelectedValue = lstCustomer[pRowIndex].CustomerTypeID;
                    mtxtCreatedDate.Text = lstCustomer[pRowIndex].CreatedDate.ToString();
                    mtxtMRDate.Text = lstCustomer[pRowIndex].MROrientationDate.ToString();
                    txtCustomerName.Text = lstCustomer[pRowIndex].CustomerName;
                    txtBenificiaryName.Text = lstCustomer[pRowIndex].BenificiaryName;
                    ddlGender.Text = lstCustomer[pRowIndex].Gender;
                    mtxtDOB.Text = lstCustomer[pRowIndex].DateOfBirth.ToString();
                    ddlMaritialStatus.Text = lstCustomer[pRowIndex].MaratialStatus;
                    ddlNationality.Text = lstCustomer[pRowIndex].Nationality;
                    txtCitizenshipID.Text = lstCustomer[pRowIndex].CitizenshipID;
                    txtLicenseID.Text = lstCustomer[pRowIndex].LicenseID;
                    txtPassportID.Text = lstCustomer[pRowIndex].PassportID;
                    ddlCountry.Text = lstCustomer[pRowIndex].Country;
                    ddlCity.Text = lstCustomer[pRowIndex].City;
                    ddlMunicipality.Text = lstCustomer[pRowIndex].Municipality;
                    ddlDistrict.Text = lstCustomer[pRowIndex].District;
                    txtStreet.Text = lstCustomer[pRowIndex].Street;
                    txtHouseNo.Text= lstCustomer[pRowIndex].HomeNumber;
                    txtAreaCode.Text = lstCustomer[pRowIndex].AreaCode;
                    txtAddress.Text = lstCustomer[pRowIndex].Address;
                    txtHomeTelephone.Text = lstCustomer[pRowIndex].HomeTelephone;
                    txtMobileNo.Text = lstCustomer[pRowIndex].Mobile;
                    txtEmailAddress.Text = lstCustomer[pRowIndex].EmailAddress;

                    if (lstCustomer[pRowIndex].Photo != null)
                    {
                        MemoryStream ms = new MemoryStream((byte[])lstCustomer[pRowIndex].Photo);
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblNoPhoto.Visible = false;
                        
                    }
                    else if (lstCustomer[pRowIndex].Photo == null)  
                    {
                        pictureBox1.Image = null;
                        lblNoPhoto.Visible = true;
                    }
                    pictureBox1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("No records are available.", "FF Trade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Load customer type dropdown
        /// </summary>
        /// <param name="pState"></param>
        private void loadCustomerType()
        {
            ddlCustomerType.DataSource = CustomerController.GetCustomerType();
            ddlCustomerType.DisplayMember = "Name";
            ddlCustomerType.ValueMember = "ID";
        }

        /// <summary>
        /// Get valid date format
        /// </summary>
        /// <param name="pState"></param>
        private DateTime? GetDate(String pDate)
        {
            if (pDate.Trim() == "/  /")
                return null;
            else
            {
                try
                {
                    return DateTime.ParseExact(pDate, "dd/MM/yyyy", null);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        #endregion
                
    }
}
