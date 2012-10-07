using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFModal;
using FFModal.Controller;

namespace FF_Network_
{
    public partial class frmTax : Form
    {
        public frmTax()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            int Num;
            bool isNum = int.TryParse(txtTaxRate.Text, out Num);
                if(isNum==true)
                {
                    TaxController.Edit(Convert.ToInt32( txtTaxRate.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tax rate should be number","FF Network",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtTaxRate.Focus();
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTax_Load(object sender, EventArgs e)
        {
            TaxSetting objTaxSetting = TaxController.GetTaxSetting();
            if (objTaxSetting != null)
            {
                txtTaxRate.Text = objTaxSetting.TaxRate.ToString();
            }

        }

        private void frmTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
