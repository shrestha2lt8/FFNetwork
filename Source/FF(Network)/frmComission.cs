using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFNetwork;
using FFModal;
using FFModal.Controller;

namespace FF_Network_
{
    public partial class frmComission : Form
    {
        public frmComission()
        {
            InitializeComponent();
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
        /// Save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //validation
            if (txtMaxLevel.Text.Trim() == "")
            {
                MessageBox.Show("Please enter max level.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxLevel.Focus();
                return;
            }

            if (txtMaxNode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter max node.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxNode.Focus();
                return;
            }


            if (txtPercentage.Text.Trim() == "")
            {
                MessageBox.Show("Please enter max node.", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPercentage.Focus();
                return;
            }


            if (Utility.IsNumber(txtMaxLevel.Text) == false)
            {
                MessageBox.Show("Max level should be number", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxLevel.Focus();
                return;
            }

            if (Utility.IsNumber(txtMaxNode.Text) == false)
            {
                MessageBox.Show("Max Node should be number", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxNode.Focus();
                return;
            }

            if (Utility.IsDecimal(txtPercentage.Text) == false)
            {
                MessageBox.Show("Percentage should be number or decimal", "FF Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPercentage.Focus();
                return;
            }

            //Adding or editing comission setting table
            ComissionSettingController.Edit(Convert.ToInt32(txtMaxLevel.Text), Convert.ToInt32(txtMaxNode.Text), Convert.ToDecimal(txtPercentage.Text));
            this.Close();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmComission_Load(object sender, EventArgs e)
        {
            ComissionSetting objComissionSetting = ComissionSettingController.GetComission();
            if (objComissionSetting != null)
            {
                txtMaxLevel.Text = objComissionSetting.MaxLevel.ToString();
                txtMaxNode.Text = objComissionSetting.MaxNode.ToString();
                txtPercentage.Text = objComissionSetting.ComissionPercentage.ToString();
            }
        }

        private void frmComission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
