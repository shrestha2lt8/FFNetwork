using System;
using System.Windows.Forms;
using FFModal.Controller;
using FFModal;
using FFNetwork;
using System.Collections.Generic;

namespace FF_Network_
{
    public partial class frmOrder : Form
    {
        #region Constructor

        public frmOrder()
        {
            InitializeComponent();
            lstOrder = OrderController.GetAll();
        }

        #endregion

        #region Class Members

        private enum FormAction
        {
            Search = 0,
            Add,
            Edit,
            Delete,
            Ok,
            Cancel,
            Navigation,
            None
        }

        private List<FFModal.Order> lstOrder;

        private int pCurrentRow = 0;

        private List<string> paramlist = new List<string>(3);

        #endregion

        #region Methods

        private void ClearCtrls()
        {
            this.txtOrderID.Clear();
            this.mtxtOrderDate.Clear();
            this.txtMemberID.Clear();
            this.txtAmount.Clear();
            this.txtDesc.Clear();
            this.txtRemarks.Clear();
            this.chkIsPaid.Checked = false;
            this.chkIsDelivered.Checked = false;
            this.mtxtPaidDate.Clear();
            this.mtxtDeliverdDate.Clear();
        }

        private void EnableControls(bool pState)
        {
            txtOrderID.Enabled = pState;
            mtxtOrderDate.Enabled = pState;
            txtMemberID.Enabled = pState;
            btnLookUp.Enabled = pState;
            txtAmount.Enabled = pState;
            txtDesc.Enabled = pState;
            txtRemarks.Enabled = pState;
            chkIsDelivered.Enabled = pState;
            chkIsPaid.Enabled = pState;
            btnOk.Enabled = pState;
            btnCancel.Enabled = pState;
            mtxtDeliverdDate.Enabled = false;
            mtxtPaidDate.Enabled = false;
            NavigationButtonStatus(!pState);
            btnAdd.Enabled =! pState;
            btnEdit.Enabled =! pState;
            btnDelete.Enabled =! pState;
        }

        private void NavigationButtonStatus(bool pState)
        {
            btnFirst.Enabled = pState;
            btnLast.Enabled = pState;
            btnPrevious.Enabled = pState;
            btnNext.Enabled = pState;
        }

        private void ChangeButtonColor(Button pbutton = null)
        {
            btnAdd.BackColor = Button.DefaultBackColor;
 
            btnEdit.BackColor = Button.DefaultBackColor;
            btnDelete.BackColor = Button.DefaultBackColor;

            if (pbutton != null)
                pbutton.BackColor = System.Drawing.Color.Gray;
        }

        private void SetLblHeadingName(Button pbutton = null)
        {
            if (pbutton == null)
                lblHeading.Text = "Order Form";
            else
                lblHeading.Text = pbutton.Text;
        }

        private void navigation(int pRowIndex)
        {
            if (lstOrder.Count > 0)
            {
                if (pRowIndex >= 0 && pRowIndex < lstOrder.Count)
                {
                    txtOrderID.Text = lstOrder[pRowIndex].OrderID.ToString();
                    mtxtOrderDate.Text = lstOrder[pRowIndex].OrderDate.ToString();
                    txtMemberID.Text = lstOrder[pRowIndex].MembershipID.ToString();
                    txtAmount.Text = lstOrder[pRowIndex].Amount.ToString();
                    txtDesc.Text = lstOrder[pRowIndex].Description.ToString();
                    txtRemarks.Text = lstOrder[pRowIndex].Remarks.ToString();
                    chkIsDelivered.Checked = (bool)lstOrder[pRowIndex].IsDelivered;
                    chkIsPaid.Checked = (bool)lstOrder[pRowIndex].IsPaid;
                    mtxtDeliverdDate.Text = lstOrder[pRowIndex].DeliveredDate.ToString();
                    mtxtPaidDate.Text = lstOrder[pRowIndex].PaidDate.ToString();
                }
            }
            else
            {
                MessageBox.Show("No records are available.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnableNavigation(bool pStatus)
        {
            this.btnFirst.Enabled = pStatus;
            this.btnLast.Enabled = pStatus;
            this.btnPrevious.Enabled = pStatus;
            this.btnNext.Enabled = pStatus;
        }

        #endregion

        #region Form Events

        private void frmOrder_Load(object sender, EventArgs e)
        {
            EnableControls(false);
            if (ComissionSettingController.GetComission() == null)
            {
                MessageBox.Show("Please set the commision settings.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnAction_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name.ToUpper())
            {
                case "BTNSEARCH":
                    paramlist.Clear();
                    ClearCtrls();
                    this.Tag = FormAction.Search;
                    this.Text = "FF: Order - Search";
                    EnableControls(true);
                    break;
                case "BTNADD":
                    ClearCtrls();
                    this.Tag = FormAction.Add;
                    this.Text = "FF: Order - Add";
                    EnableControls(true);
                    break;
                case "BTNEDIT":
                        this.Tag = FormAction.Edit;
                        this.Text = "FF: Order - Edit";
                        SetLblHeadingName(btnEdit);
                        EnableControls(true);
                    break;
                case "BTNDELETE":
                    this.Tag = FormAction.Delete;
                    if (string.IsNullOrEmpty(txtOrderID.Text.Trim()))
                        MessageBox.Show("No record is selected to delete.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (CustomerComissionController.Delete(txtOrderID.Text.Trim()) == true)
                        {
                            OrderController.Delete(txtOrderID.Text.Trim());
                            lstOrder = OrderController.GetAll();
                            if (pCurrentRow > 0)
                            {
                                navigation(pCurrentRow - 1);
                            }
                            else
                            {
                                ClearCtrls();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------
            //Validation
            //-------------------------------------------------------------------------------------------------------------
            if (mtxtOrderDate.Text.Trim() == "/  /")
            {
                MessageBox.Show("Order date can not be blank", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if(Utility.IsValidDate(mtxtOrderDate.Text.Trim())==false)
                {
                      MessageBox.Show("Date should be on dd/MM/yyyy format", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
            }

            if (mtxtDeliverdDate.Text.Trim() != "")
            {
                if (Utility.IsValidDate(mtxtDeliverdDate.Text.Trim()) == false)
                {
                    MessageBox.Show("Date should be on dd/MM/yyyy format", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (mtxtPaidDate.Text.Trim() != "")
            {
                if (Utility.IsValidDate(mtxtPaidDate.Text.Trim()) == false)
                {
                    MessageBox.Show("Date should be on dd/MM/yyyy format", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if(chkIsDelivered.Checked==true)
            {
                if (mtxtDeliverdDate.Text.Trim() == "/  /")
                {
                    MessageBox.Show("Deliverd date can not be blank", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtDeliverdDate.Focus();
                    return;
                }
            }

            if (chkIsPaid.Checked == true)
            {
                if (mtxtPaidDate.Text.Trim() == "/  /")
                {
                    MessageBox.Show("Paid date can not be blank", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtxtPaidDate.Focus();
                    return;
                }
            }
            //-------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------
            switch ((FormAction)this.Tag)
            {
                case FormAction.Search:

                    paramlist.Add(txtOrderID.Text.Trim());
                    paramlist.Add(mtxtOrderDate.Text.Trim());
                    paramlist.Add(txtMemberID.Text.Trim());

                    lstOrder = OrderController.Search(txtOrderID.Text.Trim(), mtxtOrderDate.Text.Trim(), txtMemberID.Text.Trim());
                    if (lstOrder.Count > 0)
                    {
                        EnableNavigation(true);
                        navigation(0);
                    }
                    break;
                case FormAction.Add:
                    if (OrderController.GetByID(txtOrderID.Text.Trim()) == null)
                    {
                        if (OrderController.Add(txtOrderID.Text.Trim(), txtMemberID.Text.Trim(), Convert.ToDecimal(txtAmount.Text.Trim()), txtDesc.Text.Trim(), txtRemarks.Text.Trim(), Utility.GetDate(mtxtOrderDate.Text), chkIsDelivered.Checked, chkIsPaid.Checked, Utility.GetConvertedDate(mtxtDeliverdDate.Text), Utility.GetConvertedDate(mtxtPaidDate.Text)) ==true)
                        {
                            Customer objCurrentCustomer = CustomerController.GetCustomer(txtMemberID.Text);
                            for (int i = 0; i <= ComissionSettingController.GetMaxLevel(); i++)
                            {
                                if (objCurrentCustomer != null)
                                {
                                    if (objCurrentCustomer.CustomerTypeID == 2)
                                    {
                                        if (objCurrentCustomer.ReferenceID != "")
                                        {
                                            CustomerComissionController.Add(objCurrentCustomer.ReferenceID, txtOrderID.Text.Trim(), Math.Round(Convert.ToDecimal(txtAmount.Text) * ComissionSettingController.GetCommisionPercentage(), 2), null);
                                        }
                                    }
                                    objCurrentCustomer = CustomerController.GetCustomer(objCurrentCustomer.ReferenceID);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Application encounter fatal error.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Order id already exists.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case FormAction.Edit:
                    if (OrderController.Edit(txtOrderID.Text.Trim(), txtMemberID.Text.Trim(),
                       Convert.ToDecimal(txtAmount.Text.Trim()), txtDesc.Text.Trim(), txtRemarks.Text.Trim(), Utility.GetDate(mtxtOrderDate.Text), chkIsDelivered.Checked, chkIsPaid.Checked, Utility.GetConvertedDate(mtxtDeliverdDate.Text), Utility.GetConvertedDate(mtxtPaidDate.Text)) == false)
                    {

                        MessageBox.Show("Application encounter fatal error.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Customer objCurrentCustomer = CustomerController.GetCustomer(txtMemberID.Text);
                        for (int i = 0; i <= ComissionSettingController.GetMaxLevel(); i++)
                        {
                            if (objCurrentCustomer != null)
                            {
                                if (objCurrentCustomer.CustomerTypeID == 2)
                                {
                                    if (objCurrentCustomer.ReferenceID != "")
                                    {
                                        CustomerComissionController.Edit(objCurrentCustomer.ReferenceID, txtOrderID.Text.Trim(), Math.Round(Convert.ToDecimal(txtAmount.Text) * ComissionSettingController.GetCommisionPercentage(), 2), false, null);
                                    }
                                }
                                objCurrentCustomer = CustomerController.GetCustomer(objCurrentCustomer.ReferenceID);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
            }
            EnableControls(false);
            lstOrder = OrderController.GetAll();
            this.Tag = null;
            btnAdd.Focus();
            this.Text = "FF: Order";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCtrls();
            this.Text = "FF: Order";
            EnableControls(false);
            btnAdd.Focus();
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtMemberID.Text = frmLookup.returnField1;
            txtMemberID.Focus();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pCurrentRow = 0;
            navigation(pCurrentRow);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pCurrentRow > 0)
            {
                pCurrentRow = pCurrentRow - 1;
                navigation(pCurrentRow);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pCurrentRow = pCurrentRow + 1;
            if (pCurrentRow < lstOrder.Count)
            {
                navigation(pCurrentRow);
            }
            else
            {
                pCurrentRow = pCurrentRow - 1;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pCurrentRow = lstOrder.Count - 1;
            navigation(pCurrentRow);
        }

        private void chkIsDelivered_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDelivered.Enabled == true)
            {
                if (chkIsDelivered.Checked == true)
                    mtxtDeliverdDate.Enabled = true;
                else
                    mtxtDeliverdDate.Enabled = false;
            }
        }

        private void chkIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsPaid.Enabled == true)
            {
                if (chkIsPaid.Checked == true)
                    mtxtPaidDate.Enabled = true;
                else
                    mtxtPaidDate.Enabled = false;
            }
        }
        private void btnDumpOrder_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Order;
            frmLookup.ShowDialog();
            txtOrderID.Text = frmLookup.returnField1;
            txtOrderID.Focus();
        }

        private void txtOrderID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((FormAction)this.Tag == FormAction.Edit)
            {
                if(txtOrderID.Text.Trim()!="")
                {
                    Order objOrder = OrderController.GetByID(txtOrderID.Text.Trim());
                    if (objOrder != null)
                    {
                        txtOrderID.Text = objOrder.OrderID.ToString();
                        mtxtOrderDate.Text = objOrder.OrderDate.ToString("dd/MM/yyyy");
                        txtMemberID.Text = objOrder.MembershipID.ToString();
                        txtAmount.Text = objOrder.Amount.ToString();
                        txtDesc.Text = objOrder.Description.ToString();
                        txtRemarks.Text = objOrder.Remarks.ToString();
                        chkIsDelivered.Checked = (bool)objOrder.IsDelivered;
                        chkIsPaid.Checked = (bool)objOrder.IsPaid;
                        mtxtDeliverdDate.Text = objOrder.DeliveredDate.ToString();
                        mtxtPaidDate.Text = objOrder.PaidDate.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Order id", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }

        }

        private void txtOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnDumpOrder_Click(null, null);
            }
        }

        private void frmOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                    btnCancel_Click(null, null);
            }
        }

        #endregion

        private void txtMemberID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnLookUp_Click(null, null);
            }
        }
    }
}
