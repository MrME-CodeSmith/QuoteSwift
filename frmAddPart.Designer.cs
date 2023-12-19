
namespace QuoteSwift
{
    partial class FrmAddPart
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
            this.loadPartBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cbAddToProductSelection = new System.Windows.Forms.ComboBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblnewPartQuantity = new System.Windows.Forms.Label();
            this.NudQuantity = new System.Windows.Forms.NumericUpDown();
            this.OfdOpenCSVFile = new System.Windows.Forms.OpenFileDialog();
            this.mtxtPartPrice = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.msAddPartControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtPartPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // msAddPartControls
            // 
            this.msAddPartControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msAddPartControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msAddPartControls.Location = new System.Drawing.Point(0, 0);
            this.msAddPartControls.Name = "msAddPartControls";
            this.msAddPartControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msAddPartControls.Size = new System.Drawing.Size(487, 30);
            this.msAddPartControls.TabIndex = 0;
            this.msAddPartControls.Text = "msAddPartControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPartBatchToolStripMenuItem,
            this.updatePartToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadPartBatchToolStripMenuItem
            // 
            this.loadPartBatchToolStripMenuItem.Name = "loadPartBatchToolStripMenuItem";
            this.loadPartBatchToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.loadPartBatchToolStripMenuItem.Text = "Import Batch";
            this.loadPartBatchToolStripMenuItem.Click += new System.EventHandler(this.LoadPartBatchToolStripMenuItem_Click);
            // 
            // updatePartToolStripMenuItem
            // 
            this.updatePartToolStripMenuItem.Enabled = false;
            this.updatePartToolStripMenuItem.Name = "updatePartToolStripMenuItem";
            this.updatePartToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.updatePartToolStripMenuItem.Text = "Update Part";
            this.updatePartToolStripMenuItem.Click += new System.EventHandler(this.UpdatePartToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // lblAddPartDescription
            // 
            this.lblAddPartDescription.AutoSize = true;
            this.lblAddPartDescription.Location = new System.Drawing.Point(56, 82);
            this.lblAddPartDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddPartDescription.Name = "lblAddPartDescription";
            this.lblAddPartDescription.Size = new System.Drawing.Size(118, 18);
            this.lblAddPartDescription.TabIndex = 1;
            this.lblAddPartDescription.Text = "Part Description:";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(88, 47);
            this.lblPartName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(83, 18);
            this.lblPartName.TabIndex = 2;
            this.lblPartName.Text = "Part Name:";
            // 
            // lblOriginalPartNumber
            // 
            this.lblOriginalPartNumber.AutoSize = true;
            this.lblOriginalPartNumber.Location = new System.Drawing.Point(21, 117);
            this.lblOriginalPartNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOriginalPartNumber.Name = "lblOriginalPartNumber";
            this.lblOriginalPartNumber.Size = new System.Drawing.Size(150, 18);
            this.lblOriginalPartNumber.TabIndex = 3;
            this.lblOriginalPartNumber.Text = "Original Part Number:";
            // 
            // lblNewPartNumber
            // 
            this.lblNewPartNumber.AutoSize = true;
            this.lblNewPartNumber.Location = new System.Drawing.Point(41, 152);
            this.lblNewPartNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPartNumber.Name = "lblNewPartNumber";
            this.lblNewPartNumber.Size = new System.Drawing.Size(130, 18);
            this.lblNewPartNumber.TabIndex = 4;
            this.lblNewPartNumber.Text = "New Part Number:";
            // 
            // lblPartPrice
            // 
            this.lblPartPrice.AutoSize = true;
            this.lblPartPrice.Location = new System.Drawing.Point(94, 190);
            this.lblPartPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartPrice.Name = "lblPartPrice";
            this.lblPartPrice.Size = new System.Drawing.Size(77, 18);
            this.lblPartPrice.TabIndex = 5;
            this.lblPartPrice.Text = "Part Price:";
            // 
            // lblAddToPumpSelection
            // 
            this.lblAddToPumpSelection.AutoSize = true;
            this.lblAddToPumpSelection.Location = new System.Drawing.Point(69, 222);
            this.lblAddToPumpSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddToPumpSelection.Name = "lblAddToPumpSelection";
            this.lblAddToPumpSelection.Size = new System.Drawing.Size(102, 18);
            this.lblAddToPumpSelection.TabIndex = 6;
            this.lblAddToPumpSelection.Text = "Add To Pump:";
            // 
            // cbxMandatoryPart
            // 
            this.cbxMandatoryPart.AutoSize = true;
            this.cbxMandatoryPart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMandatoryPart.Location = new System.Drawing.Point(59, 289);
            this.cbxMandatoryPart.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMandatoryPart.Name = "cbxMandatoryPart";
            this.cbxMandatoryPart.Size = new System.Drawing.Size(132, 22);
            this.cbxMandatoryPart.TabIndex = 7;
            this.cbxMandatoryPart.Text = "Mandatory Part:";
            this.cbxMandatoryPart.UseVisualStyleBackColor = true;
            // 
            // mtxtPartName
            // 
            this.mtxtPartName.Location = new System.Drawing.Point(179, 44);
            this.mtxtPartName.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPartName.Name = "mtxtPartName";
            this.mtxtPartName.Size = new System.Drawing.Size(292, 24);
            this.mtxtPartName.TabIndex = 0;
            // 
            // mtxtPartDescription
            // 
            this.mtxtPartDescription.Location = new System.Drawing.Point(179, 79);
            this.mtxtPartDescription.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPartDescription.Name = "mtxtPartDescription";
            this.mtxtPartDescription.Size = new System.Drawing.Size(292, 24);
            this.mtxtPartDescription.TabIndex = 1;
            // 
            // mtxtOriginalPartNumber
            // 
            this.mtxtOriginalPartNumber.Location = new System.Drawing.Point(179, 114);
            this.mtxtOriginalPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtOriginalPartNumber.Name = "mtxtOriginalPartNumber";
            this.mtxtOriginalPartNumber.Size = new System.Drawing.Size(292, 24);
            this.mtxtOriginalPartNumber.TabIndex = 2;
            // 
            // mtxtNewPartNumber
            // 
            this.mtxtNewPartNumber.Location = new System.Drawing.Point(179, 149);
            this.mtxtNewPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtNewPartNumber.Name = "mtxtNewPartNumber";
            this.mtxtNewPartNumber.Size = new System.Drawing.Size(292, 24);
            this.mtxtNewPartNumber.TabIndex = 3;
            // 
            // cbAddToPumpSelection
            // 
            this.cbAddToProductSelection.FormattingEnabled = true;
            this.cbAddToProductSelection.Location = new System.Drawing.Point(179, 219);
            this.cbAddToProductSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbAddToProductSelection.Name = "cbAddToPumpSelection";
            this.cbAddToProductSelection.Size = new System.Drawing.Size(292, 26);
            this.cbAddToProductSelection.TabIndex = 5;
            this.cbAddToProductSelection.ContextMenuStripChanged += new System.EventHandler(this.CbAddToPumpSelection_ContextMenuStripChanged);
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(341, 340);
            this.btnAddPart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(130, 32);
            this.btnAddPart.TabIndex = 8;
            this.btnAddPart.Text = "Add Part";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.BtnAddPart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13, 340);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblnewPartQuantity
            // 
            this.lblnewPartQuantity.AutoSize = true;
            this.lblnewPartQuantity.Location = new System.Drawing.Point(105, 256);
            this.lblnewPartQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnewPartQuantity.Name = "lblnewPartQuantity";
            this.lblnewPartQuantity.Size = new System.Drawing.Size(66, 18);
            this.lblnewPartQuantity.TabIndex = 16;
            this.lblnewPartQuantity.Text = "Quantity:";
            // 
            // NudQuantity
            // 
            this.NudQuantity.Enabled = false;
            this.NudQuantity.Location = new System.Drawing.Point(179, 254);
            this.NudQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.NudQuantity.Name = "NudQuantity";
            this.NudQuantity.Size = new System.Drawing.Size(142, 24);
            this.NudQuantity.TabIndex = 6;
            // 
            // OfdOpenCSVFile
            // 
            this.OfdOpenCSVFile.DefaultExt = "\"csv\";";
            this.OfdOpenCSVFile.FileName = "*.csv";
            this.OfdOpenCSVFile.Filter = "\"CSV files (*.csv)|*.csv|All Files (*.*)|*.*\";";
            this.OfdOpenCSVFile.InitialDirectory = "\"C:\\\"";
            this.OfdOpenCSVFile.RestoreDirectory = true;
            this.OfdOpenCSVFile.Title = "Select CSV File Containing Parts To Add ";
            // 
            // mtxtPartPrice
            // 
            this.mtxtPartPrice.BeforeTouchSize = new System.Drawing.Size(148, 24);
            this.mtxtPartPrice.DoubleValue = 0D;
            this.mtxtPartPrice.Location = new System.Drawing.Point(181, 184);
            this.mtxtPartPrice.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPartPrice.MaxValue = 5000000D;
            this.mtxtPartPrice.MinValue = 0D;
            this.mtxtPartPrice.Name = "mtxtPartPrice";
            this.mtxtPartPrice.Size = new System.Drawing.Size(139, 24);
            this.mtxtPartPrice.TabIndex = 4;
            this.mtxtPartPrice.Text = "0.00";
            // 
            // FrmAddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 392);
            this.Controls.Add(this.mtxtPartPrice);
            this.Controls.Add(this.NudQuantity);
            this.Controls.Add(this.lblnewPartQuantity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.cbAddToProductSelection);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msAddPartControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Part";
            this.Activated += new System.EventHandler(this.FrmAddPart_Activated);
            this.Load += new System.EventHandler(this.FrmAddPart_Load);
            this.msAddPartControls.ResumeLayout(false);
            this.msAddPartControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtPartPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msAddPartControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
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
        private System.Windows.Forms.ComboBox cbAddToProductSelection;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblnewPartQuantity;
        private System.Windows.Forms.NumericUpDown NudQuantity;
        private System.Windows.Forms.ToolStripMenuItem loadPartBatchToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OfdOpenCSVFile;
        private System.Windows.Forms.ToolStripMenuItem updatePartToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox mtxtPartPrice;
    }
}