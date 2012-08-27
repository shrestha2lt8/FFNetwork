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
    public partial class frmLookup : Form
    {
        public LookupType lookupType;
        public string returnField1="";
        public string returnField2="";
        public frmLookup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event of form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLookup_Load(object sender, EventArgs e)
        {
            if (lookupType == LookupType.Area)
            {
                dgvLookup.AutoGenerateColumns = false;
                DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
                makeColumn.DataPropertyName = "AreaCode";
                makeColumn.HeaderText = "Code";
                dgvLookup.Columns.Add(makeColumn);

                DataGridViewTextBoxColumn modelColumn = new DataGridViewTextBoxColumn();
                modelColumn.DataPropertyName = "AreaDescription";
                modelColumn.HeaderText = "Name";
                dgvLookup.Columns.Add(modelColumn);
                dgvLookup.DataSource = AreaController.GetAll();
            }
            else if (lookupType == LookupType.Customer)
            {
                dgvLookup.AutoGenerateColumns = false;
                DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
                makeColumn.DataPropertyName = "MembershipID";
                makeColumn.HeaderText = "Membership ID";
                dgvLookup.Columns.Add(makeColumn);

                DataGridViewTextBoxColumn modelColumn = new DataGridViewTextBoxColumn();
                modelColumn.DataPropertyName = "CustomerName";
                modelColumn.HeaderText = "Name";
                dgvLookup.Columns.Add(modelColumn);
                dgvLookup.DataSource = CustomerController.GetAll();
            }
            else if (lookupType == LookupType.Product)
            {
            }
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
        /// Ok button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvLookup.SelectedRows.Count > 0)
            {
                returnField1 = Convert.ToString( dgvLookup.SelectedRows[0].Cells[0].Value);
                returnField2 = Convert.ToString(dgvLookup.SelectedRows[0].Cells[1].Value);
            }
            this.Close();
        }
    }
}
