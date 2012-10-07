namespace FF_Network_
{
    partial class frmComission
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
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtMaxLevel = new System.Windows.Forms.TextBox();
            this.lblMaxLevel = new System.Windows.Forms.Label();
            this.txtMaxNode = new System.Windows.Forms.TextBox();
            this.lblMaxNode = new System.Windows.Forms.Label();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.CornerRadius = 4;
            this.rectangleShape1.Location = new System.Drawing.Point(16, 20);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(584, 43);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.CornerRadius = 4;
            this.rectangleShape2.Location = new System.Drawing.Point(15, 68);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(585, 43);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(612, 128);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(298, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(222, 74);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtMaxLevel
            // 
            this.txtMaxLevel.Location = new System.Drawing.Point(86, 33);
            this.txtMaxLevel.Name = "txtMaxLevel";
            this.txtMaxLevel.Size = new System.Drawing.Size(103, 20);
            this.txtMaxLevel.TabIndex = 8;
            // 
            // lblMaxLevel
            // 
            this.lblMaxLevel.AutoSize = true;
            this.lblMaxLevel.Location = new System.Drawing.Point(27, 36);
            this.lblMaxLevel.Name = "lblMaxLevel";
            this.lblMaxLevel.Size = new System.Drawing.Size(56, 13);
            this.lblMaxLevel.TabIndex = 7;
            this.lblMaxLevel.Text = "Max Level";
            // 
            // txtMaxNode
            // 
            this.txtMaxNode.Location = new System.Drawing.Point(259, 34);
            this.txtMaxNode.Name = "txtMaxNode";
            this.txtMaxNode.Size = new System.Drawing.Size(103, 20);
            this.txtMaxNode.TabIndex = 10;
            // 
            // lblMaxNode
            // 
            this.lblMaxNode.AutoSize = true;
            this.lblMaxNode.Location = new System.Drawing.Point(200, 37);
            this.lblMaxNode.Name = "lblMaxNode";
            this.lblMaxNode.Size = new System.Drawing.Size(56, 13);
            this.lblMaxNode.TabIndex = 9;
            this.lblMaxNode.Text = "Max Node";
            // 
            // txtPercentage
            // 
            this.txtPercentage.Location = new System.Drawing.Point(443, 34);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(103, 20);
            this.txtPercentage.TabIndex = 12;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(384, 37);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(62, 13);
            this.lblPercentage.TabIndex = 11;
            this.lblPercentage.Text = "Percentage";
            // 
            // frmComission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 128);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.txtMaxNode);
            this.Controls.Add(this.lblMaxNode);
            this.Controls.Add(this.txtMaxLevel);
            this.Controls.Add(this.lblMaxLevel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.shapeContainer1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FF - Comission";
            this.Load += new System.EventHandler(this.frmComission_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmComission_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtMaxLevel;
        private System.Windows.Forms.Label lblMaxLevel;
        private System.Windows.Forms.TextBox txtMaxNode;
        private System.Windows.Forms.Label lblMaxNode;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.Label lblPercentage;

    }
}