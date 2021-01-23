
namespace QuoteSwift
{
    partial class frmAddPart
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
            this.msAddPartControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAddPartDescription = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            this.lblOriginalPartNumber = new System.Windows.Forms.Label();
            this.lblNewPartNumber = new System.Windows.Forms.Label();
            this.lblPartPrice = new System.Windows.Forms.Label();
            this.lblAddToPumpSelection = new System.Windows.Forms.Label();
            this.cbxMandatoryPart = new System.Windows.Forms.CheckBox();
            this.mtxtPartName = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPartDescription = new System.Windows.Forms.MaskedTextBox();
            this.mtxtOriginalPartNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtNewPartNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPartPrice = new System.Windows.Forms.MaskedTextBox();
            this.cbAddToPumpSelection = new System.Windows.Forms.ComboBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.msAddPartControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // msAddPartControls
            // 
            this.msAddPartControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msAddPartControls.Location = new System.Drawing.Point(0, 0);
            this.msAddPartControls.Name = "msAddPartControls";
            this.msAddPartControls.Size = new System.Drawing.Size(367, 24);
            this.msAddPartControls.TabIndex = 0;
            this.msAddPartControls.Text = "msAddPartControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "Help!";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lblAddPartDescription
            // 
            this.lblAddPartDescription.AutoSize = true;
            this.lblAddPartDescription.Location = new System.Drawing.Point(45, 75);
            this.lblAddPartDescription.Name = "lblAddPartDescription";
            this.lblAddPartDescription.Size = new System.Drawing.Size(85, 13);
            this.lblAddPartDescription.TabIndex = 1;
            this.lblAddPartDescription.Text = "Part Description:";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(70, 45);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(60, 13);
            this.lblPartName.TabIndex = 2;
            this.lblPartName.Text = "Part Name:";
            // 
            // lblOriginalPartNumber
            // 
            this.lblOriginalPartNumber.AutoSize = true;
            this.lblOriginalPartNumber.Location = new System.Drawing.Point(23, 105);
            this.lblOriginalPartNumber.Name = "lblOriginalPartNumber";
            this.lblOriginalPartNumber.Size = new System.Drawing.Size(107, 13);
            this.lblOriginalPartNumber.TabIndex = 3;
            this.lblOriginalPartNumber.Text = "Original Part Number:";
            // 
            // lblNewPartNumber
            // 
            this.lblNewPartNumber.AutoSize = true;
            this.lblNewPartNumber.Location = new System.Drawing.Point(36, 135);
            this.lblNewPartNumber.Name = "lblNewPartNumber";
            this.lblNewPartNumber.Size = new System.Drawing.Size(94, 13);
            this.lblNewPartNumber.TabIndex = 4;
            this.lblNewPartNumber.Text = "New Part Number:";
            // 
            // lblPartPrice
            // 
            this.lblPartPrice.AutoSize = true;
            this.lblPartPrice.Location = new System.Drawing.Point(74, 165);
            this.lblPartPrice.Name = "lblPartPrice";
            this.lblPartPrice.Size = new System.Drawing.Size(56, 13);
            this.lblPartPrice.TabIndex = 5;
            this.lblPartPrice.Text = "Part Price:";
            // 
            // lblAddToPumpSelection
            // 
            this.lblAddToPumpSelection.AutoSize = true;
            this.lblAddToPumpSelection.Location = new System.Drawing.Point(55, 195);
            this.lblAddToPumpSelection.Name = "lblAddToPumpSelection";
            this.lblAddToPumpSelection.Size = new System.Drawing.Size(75, 13);
            this.lblAddToPumpSelection.TabIndex = 6;
            this.lblAddToPumpSelection.Text = "Add To Pump:";
            // 
            // cbxMandatoryPart
            // 
            this.cbxMandatoryPart.AutoSize = true;
            this.cbxMandatoryPart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMandatoryPart.Location = new System.Drawing.Point(48, 225);
            this.cbxMandatoryPart.Name = "cbxMandatoryPart";
            this.cbxMandatoryPart.Size = new System.Drawing.Size(101, 17);
            this.cbxMandatoryPart.TabIndex = 7;
            this.cbxMandatoryPart.Text = "Mandatory Part:";
            this.cbxMandatoryPart.UseVisualStyleBackColor = true;
            // 
            // mtxtPartName
            // 
            this.mtxtPartName.Location = new System.Drawing.Point(136, 42);
            this.mtxtPartName.Name = "mtxtPartName";
            this.mtxtPartName.Size = new System.Drawing.Size(217, 20);
            this.mtxtPartName.TabIndex = 8;
            // 
            // mtxtPartDescription
            // 
            this.mtxtPartDescription.Location = new System.Drawing.Point(136, 72);
            this.mtxtPartDescription.Name = "mtxtPartDescription";
            this.mtxtPartDescription.Size = new System.Drawing.Size(217, 20);
            this.mtxtPartDescription.TabIndex = 9;
            // 
            // mtxtOriginalPartNumber
            // 
            this.mtxtOriginalPartNumber.Location = new System.Drawing.Point(136, 102);
            this.mtxtOriginalPartNumber.Name = "mtxtOriginalPartNumber";
            this.mtxtOriginalPartNumber.Size = new System.Drawing.Size(217, 20);
            this.mtxtOriginalPartNumber.TabIndex = 10;
            // 
            // mtxtNewPartNumber
            // 
            this.mtxtNewPartNumber.Location = new System.Drawing.Point(136, 132);
            this.mtxtNewPartNumber.Name = "mtxtNewPartNumber";
            this.mtxtNewPartNumber.Size = new System.Drawing.Size(217, 20);
            this.mtxtNewPartNumber.TabIndex = 11;
            // 
            // mtxtPartPrice
            // 
            this.mtxtPartPrice.Location = new System.Drawing.Point(136, 162);
            this.mtxtPartPrice.Mask = "00000000";
            this.mtxtPartPrice.Name = "mtxtPartPrice";
            this.mtxtPartPrice.Size = new System.Drawing.Size(95, 20);
            this.mtxtPartPrice.TabIndex = 12;
            this.mtxtPartPrice.ValidatingType = typeof(int);
            // 
            // cbAddToPumpSelection
            // 
            this.cbAddToPumpSelection.FormattingEnabled = true;
            this.cbAddToPumpSelection.Location = new System.Drawing.Point(136, 192);
            this.cbAddToPumpSelection.Name = "cbAddToPumpSelection";
            this.cbAddToPumpSelection.Size = new System.Drawing.Size(217, 21);
            this.cbAddToPumpSelection.TabIndex = 13;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(278, 248);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(75, 23);
            this.btnAddPart.TabIndex = 14;
            this.btnAddPart.Text = "Add Part";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 280);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.cbAddToPumpSelection);
            this.Controls.Add(this.mtxtPartPrice);
            this.Controls.Add(this.mtxtNewPartNumber);
            this.Controls.Add(this.mtxtOriginalPartNumber);
            this.Controls.Add(this.mtxtPartDescription);
            this.Controls.Add(this.mtxtPartName);
            this.Controls.Add(this.cbxMandatoryPart);
            this.Controls.Add(this.lblAddToPumpSelection);
            this.Controls.Add(this.lblPartPrice);
            this.Controls.Add(this.lblNewPartNumber);
            this.Controls.Add(this.lblOriginalPartNumber);
            this.Controls.Add(this.lblPartName);
            this.Controls.Add(this.lblAddPartDescription);
            this.Controls.Add(this.msAddPartControls);
            this.MainMenuStrip = this.msAddPartControls;
            this.Name = "frmAddPart";
            this.Text = "frmAddPart";
            this.msAddPartControls.ResumeLayout(false);
            this.msAddPartControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msAddPartControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblAddPartDescription;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.Label lblOriginalPartNumber;
        private System.Windows.Forms.Label lblNewPartNumber;
        private System.Windows.Forms.Label lblPartPrice;
        private System.Windows.Forms.Label lblAddToPumpSelection;
        private System.Windows.Forms.CheckBox cbxMandatoryPart;
        private System.Windows.Forms.MaskedTextBox mtxtPartName;
        private System.Windows.Forms.MaskedTextBox mtxtPartDescription;
        private System.Windows.Forms.MaskedTextBox mtxtOriginalPartNumber;
        private System.Windows.Forms.MaskedTextBox mtxtNewPartNumber;
        private System.Windows.Forms.MaskedTextBox mtxtPartPrice;
        private System.Windows.Forms.ComboBox cbAddToPumpSelection;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnCancel;
    }
}