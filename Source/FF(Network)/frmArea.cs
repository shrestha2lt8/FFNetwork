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
namespace FF_Network_
{
    public partial class frmArea : Form
    {
        List<Area> lstArea;
        int pCurrentRow = 0;
        public frmArea()
        {
            InitializeComponent();
        }

        #region "Form Event"

        /// <summary>
        /// Keydown event of  area form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmArea_KeyDown(object sender, KeyEventArgs e)
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
        private void frmArea_Load(object sender, EventArgs e)
        {
            this.Tag = "Nav";
            entryControlStatus(false);
            buttonStatus(true);
            lstArea = AreaController.GetAll();
        }

        private void frmArea_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            this.Text = "FF: Area - Add";
            buttonStatus(false);
        }

        /// <summary>
        /// Edit button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            clearControls();
            entryControlStatus(true);
            buttonStatus(false);
            this.Tag = "Edit";
            this.Text = "FF: Area - Edit";
        }

        /// <summary>
        /// Delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtAreaCode.Text.Trim() == "")
            {
                MessageBox.Show("Area code can not be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaCode.Focus();
                return;
            }
            else
            {
                int customerCount=0;
                Area objArea = AreaController.GetAreaByCode(txtAreaCode.Text.Trim(),out customerCount);
                if (customerCount < 1)
                {
                    AreaController.Delete(txtAreaCode.Text);
                    if ((pCurrentRow - 1) >= 0)
                    {
                        navigation(pCurrentRow - 1);
                    }
                    else
                    {
                        clearControls();
                    }
                    lstArea = AreaController.GetAll();
                }
                else
                {
                    MessageBox.Show("Area can not be deleted.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Dump button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDump_Click(object sender, EventArgs e)
        {
            frmLookup frmLookup = new frmLookup();
            frmLookup.lookupType =  LookupType.Area;
            frmLookup.ShowDialog();
            txtAreaCode.Text = frmLookup.returnField1;
            txtAreaName.Text = frmLookup.returnField2;
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
            if (txtAreaCode.Text.Trim() == "")
            {
                MessageBox.Show("Area code can not be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaCode.Focus();
                return;
            }

            if (txtAreaName.Text.Trim() == "")
            {
                MessageBox.Show("Area name can not be blank.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAreaName.Focus();
                return;
            }


            //---------------------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------------------
            //Insert process
            //---------------------------------------------------------------------------------------------------------------------
            if (this.Tag.ToString() == "Add")
            {
                if (AreaController.GetAreaByCode(txtAreaCode.Text.Trim()) != null)
                {
                    MessageBox.Show("Area code already exists.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAreaCode.Focus();
                    return;
                }

                if (AreaController.GetAreaByCode(txtAreaName.Text.Trim()) != null)
                {
                    MessageBox.Show("Area name already exists.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAreaCode.Focus();
                    return;
                }

                AreaController.Add(txtAreaCode.Text, txtAreaName.Text);

            }
            else if (this.Tag.ToString() == "Edit")
            {
                AreaController.Edit(txtAreaCode.Text, txtAreaName.Text);
            }
            this.Tag = "Nav";
            entryControlStatus(false);
            buttonStatus(true);
            lstArea = AreaController.GetAll();

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
            this.Text = "FF: Area";
            entryControlStatus(false);
            buttonStatus(true);
        }

        /// <summary>
        /// Validation of Area code for edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaCode_Validating(object sender, CancelEventArgs e)
        {
            if (this.Tag.ToString() == "Edit")
            {
                if (txtAreaCode.Text.Trim()!="")
                {
                if (AreaController.GetAreaByCode(txtAreaCode.Text) == null)
                {
                    MessageBox.Show("Area code does not exists.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
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
            if( pCurrentRow>0)
            {
                pCurrentRow=pCurrentRow-1;
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
            if (pCurrentRow < lstArea.Count)
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
            pCurrentRow = lstArea.Count-1;
            navigation(pCurrentRow);
        }

        /// <summary>
        /// Keydown event for txtAreaCode textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
            else if (e.KeyCode == Keys.F1)
                btnDump_Click(null, null);


        }

        /// <summary>
        /// Keydown event for txtAreaName textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(null, null);
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
            txtAreaCode.Enabled = pState;
            btnDump.Enabled = pState;
            txtAreaName.Enabled = pState;
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
            txtAreaCode.Text = "";
            txtAreaName.Text = "";
        }

        private void navigation(int pRowIndex)
        {
            if (lstArea.Count > 0)
            {
                if (pRowIndex >= 0 && pRowIndex < lstArea.Count)
                {
                    txtAreaCode.Text = lstArea[pRowIndex].AreaCode;
                    txtAreaName.Text = lstArea[pRowIndex].AreaDescription;
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
