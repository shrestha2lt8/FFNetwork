using System;
using System.Windows.Forms;
using FFModal.Controller;
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
            btnAction_click(btnAdd, new EventArgs());
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
        }

        private void SetControlsUsability(FormAction pAction)
        {

            switch (pAction)
            {
                case FormAction.Search:
                    {
                        txtOrderID.Enabled = true;
                        mtxtOrderDate.Enabled = true;
                        txtMemberID.Enabled = true;
                        btnLookUp.Enabled = true;
                        txtAmount.Enabled = false;
                        txtDesc.Enabled = false;
                        txtRemarks.Enabled = false;

                        btnOk.Enabled = true;
                        btnCancel.Enabled = true;
                        break;
                    }
                case FormAction.Add:
                case FormAction.Edit:
                    {
                        txtOrderID.Enabled = false;
                        mtxtOrderDate.Enabled = true;
                        txtMemberID.Enabled = true;
                        btnLookUp.Enabled = true;
                        txtAmount.Enabled = true;
                        txtDesc.Enabled = true;
                        txtRemarks.Enabled = true;

                        btnOk.Enabled = true;
                        btnCancel.Enabled = true;
                        break;
                    }
                case FormAction.Delete:
                case FormAction.Navigation:
                default:
                    txtOrderID.Enabled = false;
                    mtxtOrderDate.Enabled = false;
                    txtMemberID.Enabled = false;
                    btnLookUp.Enabled = false;
                    txtAmount.Enabled = false;
                    txtDesc.Enabled = false;
                    txtRemarks.Enabled = false;

                    btnOk.Enabled = false;
                    btnCancel.Enabled = false;
                    break;
            }
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
            btnSearch.BackColor = Button.DefaultBackColor;
            btnEdit.BackColor = Button.DefaultBackColor;
            btnDelete.BackColor = Button.DefaultBackColor;

            if (pbutton != null)
                pbutton.BackColor = System.Drawing.Color.Gray;
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

        private void btnAction_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name.ToUpper())
            {
                case "BTNSEARCH":
                    ClearCtrls();
                    this.Tag = FormAction.Search;
                    ChangeButtonColor(btnSearch);
                    SetControlsUsability(FormAction.Search);
                    EnableNavigation(false);
                    break;
                case "BTNADD":
                    ClearCtrls();
                    this.Tag = FormAction.Add;
                    ChangeButtonColor(btnAdd);
                    SetControlsUsability(FormAction.Add);
                    EnableNavigation(false);
                    break;
                case "BTNEDIT":
                    if (string.IsNullOrEmpty(txtOrderID.Text.Trim()))
                        MessageBox.Show("No record is selected to edit.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        this.Tag = FormAction.Edit;
                        ChangeButtonColor(btnEdit);
                        SetControlsUsability(FormAction.Edit);
                        EnableNavigation(true);
                    }
                    break;
                case "BTNDELETE":
                    this.Tag = FormAction.Delete;
                    if (string.IsNullOrEmpty(txtOrderID.Text.Trim()))
                        MessageBox.Show("No record is selected to delete.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        OrderController.Delete(Convert.ToInt32(txtOrderID.Text.Trim()));
                    break;
                default:
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch ((FormAction)this.Tag)
            {
                case FormAction.Search:
                    lstOrder = OrderController.Search(txtOrderID.Text.Trim(), mtxtOrderDate.Text.Trim(), txtMemberID.Text.Trim());
                    if (lstOrder.Count > 0)
                    {
                        EnableNavigation(true);
                        navigation(0);
                    }
                    break;
                case FormAction.Add:
                    OrderController.Add(txtMemberID.Text.Trim(), Convert.ToDecimal(txtAmount.Text.Trim()), txtDesc.Text.Trim(), txtRemarks.Text.Trim(), mtxtOrderDate.Text.Trim());
                    ClearCtrls();
                    break;
                case FormAction.Edit:
                    if (OrderController.Edit(int.Parse(txtOrderID.Text.Trim()), txtMemberID.Text.Trim(), mtxtOrderDate.Text.Trim(),
                        txtAmount.Text.Trim(), txtDesc.Text.Trim(), txtRemarks.Text.Trim()))
                        MessageBox.Show("Record Edited Successfully", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Application encounter fatal error.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCtrls();
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

        #endregion
    }
}
