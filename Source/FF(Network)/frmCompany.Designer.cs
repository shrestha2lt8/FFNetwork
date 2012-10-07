namespace FF_Network_
{
    partial class frmCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompany));
            this.grbCompany = new System.Windows.Forms.GroupBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPanNo = new System.Windows.Forms.TextBox();
            this.lblPan = new System.Windows.Forms.Label();
            this.txtRegistrationNumber = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnOk = new System.Windows.Forms.Button();
            this.grbCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCompany
            // 
            this.grbCompany.Controls.Add(this.txtContactPerson);
            this.grbCompany.Controls.Add(this.label3);
            this.grbCompany.Controls.Add(this.txtFax);
            this.grbCompany.Controls.Add(this.label2);
            this.grbCompany.Controls.Add(this.txtWebsite);
            this.grbCompany.Controls.Add(this.label1);
            this.grbCompany.Controls.Add(this.txtEmail);
            this.grbCompany.Controls.Add(this.lblEmail);
            this.grbCompany.Controls.Add(this.txtPhoneNo);
            this.grbCompany.Controls.Add(this.lblPhone);
            this.grbCompany.Controls.Add(this.txtPanNo);
            this.grbCompany.Controls.Add(this.lblPan);
            this.grbCompany.Controls.Add(this.txtRegistrationNumber);
            this.grbCompany.Controls.Add(this.lblRegNo);
            this.grbCompany.Controls.Add(this.txtAddress);
            this.grbCompany.Controls.Add(this.lblAddress);
            this.grbCompany.Controls.Add(this.txtCompany);
            this.grbCompany.Controls.Add(this.lblName);
            this.grbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCompany.Location = new System.Drawing.Point(12, 12);
            this.grbCompany.Name = "grbCompany";
            this.grbCompany.Size = new System.Drawing.Size(615, 311);
            this.grbCompany.TabIndex = 0;
            this.grbCompany.TabStop = false;
            this.grbCompany.Text = "Company Detail";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(115, 241);
            this.txtContactPerson.MaxLength = 250;
            this.txtContactPerson.Multiline = true;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(336, 64);
            this.txtContactPerson.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Contact Person";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(115, 166);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(202, 21);
            this.txtFax.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fax";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(115, 216);
            this.txtWebsite.MaxLength = 50;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(202, 21);
            this.txtWebsite.TabIndex = 7;
            this.txtWebsite.Validating += new System.ComponentModel.CancelEventHandler(this.txtWebsite_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Website";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 190);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 21);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(18, 192);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(115, 141);
            this.txtPhoneNo.MaxLength = 50;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(202, 21);
            this.txtPhoneNo.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(18, 143);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 15);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Phone No.";
            // 
            // txtPanNo
            // 
            this.txtPanNo.Location = new System.Drawing.Point(115, 115);
            this.txtPanNo.MaxLength = 50;
            this.txtPanNo.Name = "txtPanNo";
            this.txtPanNo.Size = new System.Drawing.Size(202, 21);
            this.txtPanNo.TabIndex = 3;
            // 
            // lblPan
            // 
            this.lblPan.AutoSize = true;
            this.lblPan.Location = new System.Drawing.Point(18, 117);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(51, 15);
            this.lblPan.TabIndex = 14;
            this.lblPan.Text = "Pan No.";
            // 
            // txtRegistrationNumber
            // 
            this.txtRegistrationNumber.Location = new System.Drawing.Point(115, 89);
            this.txtRegistrationNumber.MaxLength = 50;
            this.txtRegistrationNumber.Name = "txtRegistrationNumber";
            this.txtRegistrationNumber.Size = new System.Drawing.Size(202, 21);
            this.txtRegistrationNumber.TabIndex = 2;
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.Location = new System.Drawing.Point(18, 91);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(95, 15);
            this.lblRegNo.TabIndex = 12;
            this.lblRegNo.Text = "Registration No.";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(115, 62);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(289, 21);
            this.txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 64);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 15);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(115, 35);
            this.txtCompany.MaxLength = 200;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(289, 21);
            this.txtCompany.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.CornerRadius = 5;
            this.rectangleShape2.Location = new System.Drawing.Point(15, 341);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(609, 53);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(640, 414);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(268, 356);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 414);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grbCompany);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FF: Company";
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCompany_KeyDown);
            this.grbCompany.ResumeLayout(false);
            this.grbCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCompany;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtRegistrationNumber;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.TextBox txtPanNo;
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
    }
}