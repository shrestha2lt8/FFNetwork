namespace FF_Network_
{
    partial class frmArea
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
            this.lblAreaHeading = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
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
            this.shapeContainer1.Size = new System.Drawing.Size(446, 232);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.CornerRadius = 5;
            this.rectangleShape2.Location = new System.Drawing.Point(15, 169);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(414, 53);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.CornerRadius = 5;
            this.rectangleShape1.Location = new System.Drawing.Point(15, 48);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(414, 101);
            // 
            // lblAreaHeading
            // 
            this.lblAreaHeading.AutoSize = true;
            this.lblAreaHeading.Location = new System.Drawing.Point(22, 40);
            this.lblAreaHeading.Name = "lblAreaHeading";
            this.lblAreaHeading.Size = new System.Drawing.Size(29, 13);
            this.lblAreaHeading.TabIndex = 1;
            this.lblAreaHeading.Text = "Area";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(89, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(163, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(32, 68);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(56, 13);
            this.lblAreaCode.TabIndex = 5;
            this.lblAreaCode.Text = "Area code";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(94, 68);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(104, 20);
            this.txtAreaCode.TabIndex = 7;
            this.txtAreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaCode_KeyDown);
            this.txtAreaCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtAreaCode_Validating);
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(94, 103);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(195, 20);
            this.txtAreaName.TabIndex = 9;
            this.txtAreaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaName_KeyDown);
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(32, 103);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(58, 13);
            this.lblAreaName.TabIndex = 7;
            this.lblAreaName.Text = "Area name";
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(199, 67);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(30, 23);
            this.btnDump.TabIndex = 8;
            this.btnDump.Text = "......";
            this.btnDump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(139, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(217, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(318, 12);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(31, 23);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(349, 12);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(375, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(401, 12);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(29, 23);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // frmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 232);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.txtAreaName);
            this.Controls.Add(this.lblAreaName);
            this.Controls.Add(this.txtAreaCode);
            this.Controls.Add(this.lblAreaCode);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAreaHeading);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FF: Area";
            this.Load += new System.EventHandler(this.frmArea_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmArea_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmArea_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label lblAreaHeading;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.TextBox txtAreaCode;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
    }
}