using System;
using System.Windows.Forms;
using FFModal.Controller;
using FFModal;
using FFNetwork;
namespace FF_Network_
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtMemberID.Text.Trim()) || string.IsNullOrEmpty(txtMemberID.Text.Trim()))
            {
                MessageBox.Show("MemberID can not be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemberID.Focus();
                return;
            }
            else
            {
                OrderController.Add(txtMemberID.Text.Trim(), Convert.ToDecimal(txtAmount.Text.Trim()), txtDesc.Text.Trim(), txtRemarks.Text.Trim());
                ClearCtrls();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearCtrls()
        {
            txtMemberID.Text = string.Empty;
            this.txtAmount.Text = string.Empty;
            this.txtDesc.Text = string.Empty;
            this.txtRemarks.Text = string.Empty;
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType = LookupType.Customer;
            frmLookup.ShowDialog();
            txtMemberID.Text = frmLookup.returnField1;
            txtMemberID.Focus();
        }

    }
}
