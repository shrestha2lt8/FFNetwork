namespace FF_Network_
{
    partial class frmTax
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(241, 112);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.CornerRadius = 4;
            this.rectangleShape2.Location = new System.Drawing.Point(9, 64);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(222, 43);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.CornerRadius = 4;
            this.rectangleShape1.Location = new System.Drawing.Point(8, 14);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(223, 43);
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Location = new System.Drawing.Point(22, 28);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(51, 13);
            this.lblTaxRate.TabIndex = 1;
            this.lblTaxRate.Text = "Tax Rate";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(81, 25);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(103, 20);
            this.txtTaxRate.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(46, 72);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 112);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.lblTaxRate);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FF: Tax";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button2;
    }
}