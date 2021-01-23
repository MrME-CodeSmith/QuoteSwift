
namespace QuoteSwift
{
    partial class frmAddPump
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
            this.lblPumpName = new System.Windows.Forms.Label();
            this.msAddPumpControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPumpDescription = new System.Windows.Forms.Label();
            this.lblNewPumpPrice = new System.Windows.Forms.Label();
            this.mtxtPumpName = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPumpDescription = new System.Windows.Forms.MaskedTextBox();
            this.mtxtNewPumpPrice = new System.Windows.Forms.MaskedTextBox();
            this.lblMandatoryParts = new System.Windows.Forms.Label();
            this.dgvMandatoryPartView = new System.Windows.Forms.DataGridView();
            this.dgvNonMandatoryPartView = new System.Windows.Forms.DataGridView();
            this.lblOtherParts = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPump = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmNMPartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOriginalPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNewPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddToPumpSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmMPartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msAddPumpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonMandatoryPartView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPumpName
            // 
            this.lblPumpName.AutoSize = true;
            this.lblPumpName.Location = new System.Drawing.Point(254, 30);
            this.lblPumpName.Name = "lblPumpName";
            this.lblPumpName.Size = new System.Drawing.Size(68, 13);
            this.lblPumpName.TabIndex = 0;
            this.lblPumpName.Text = "Pump Name:";
            // 
            // msAddPumpControls
            // 
            this.msAddPumpControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msAddPumpControls.Location = new System.Drawing.Point(0, 0);
            this.msAddPumpControls.Name = "msAddPumpControls";
            this.msAddPumpControls.Size = new System.Drawing.Size(773, 24);
            this.msAddPumpControls.TabIndex = 1;
            this.msAddPumpControls.Text = "msAddPumpControls";
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
            // lblPumpDescription
            // 
            this.lblPumpDescription.AutoSize = true;
            this.lblPumpDescription.Location = new System.Drawing.Point(229, 60);
            this.lblPumpDescription.Name = "lblPumpDescription";
            this.lblPumpDescription.Size = new System.Drawing.Size(93, 13);
            this.lblPumpDescription.TabIndex = 2;
            this.lblPumpDescription.Text = "Pump Description:";
            // 
            // lblNewPumpPrice
            // 
            this.lblNewPumpPrice.AutoSize = true;
            this.lblNewPumpPrice.Location = new System.Drawing.Point(233, 90);
            this.lblNewPumpPrice.Name = "lblNewPumpPrice";
            this.lblNewPumpPrice.Size = new System.Drawing.Size(89, 13);
            this.lblNewPumpPrice.TabIndex = 3;
            this.lblNewPumpPrice.Text = "New Pump Price:";
            // 
            // mtxtPumpName
            // 
            this.mtxtPumpName.Location = new System.Drawing.Point(328, 27);
            this.mtxtPumpName.Name = "mtxtPumpName";
            this.mtxtPumpName.Size = new System.Drawing.Size(230, 20);
            this.mtxtPumpName.TabIndex = 4;
            // 
            // mtxtPumpDescription
            // 
            this.mtxtPumpDescription.Location = new System.Drawing.Point(328, 57);
            this.mtxtPumpDescription.Name = "mtxtPumpDescription";
            this.mtxtPumpDescription.Size = new System.Drawing.Size(230, 20);
            this.mtxtPumpDescription.TabIndex = 5;
            // 
            // mtxtNewPumpPrice
            // 
            this.mtxtNewPumpPrice.Location = new System.Drawing.Point(328, 87);
            this.mtxtNewPumpPrice.Mask = "00000000";
            this.mtxtNewPumpPrice.Name = "mtxtNewPumpPrice";
            this.mtxtNewPumpPrice.Size = new System.Drawing.Size(115, 20);
            this.mtxtNewPumpPrice.TabIndex = 6;
            this.mtxtNewPumpPrice.ValidatingType = typeof(int);
            // 
            // lblMandatoryParts
            // 
            this.lblMandatoryParts.AutoSize = true;
            this.lblMandatoryParts.Location = new System.Drawing.Point(12, 128);
            this.lblMandatoryParts.Name = "lblMandatoryParts";
            this.lblMandatoryParts.Size = new System.Drawing.Size(129, 13);
            this.lblMandatoryParts.TabIndex = 8;
            this.lblMandatoryParts.Text = "Mandatory Part Selection:";
            // 
            // dgvMandatoryPartView
            // 
            this.dgvMandatoryPartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMandatoryPartView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDescription,
            this.clmOriginalPartNumber,
            this.clmNewPartNumber,
            this.clmPartPrice,
            this.clmAddToPumpSelection,
            this.clmMPartQuantity});
            this.dgvMandatoryPartView.Location = new System.Drawing.Point(15, 144);
            this.dgvMandatoryPartView.Name = "dgvMandatoryPartView";
            this.dgvMandatoryPartView.Size = new System.Drawing.Size(744, 222);
            this.dgvMandatoryPartView.TabIndex = 9;
            // 
            // dgvNonMandatoryPartView
            // 
            this.dgvNonMandatoryPartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNonMandatoryPartView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewCheckBoxColumn1,
            this.clmNMPartQuantity});
            this.dgvNonMandatoryPartView.Location = new System.Drawing.Point(15, 399);
            this.dgvNonMandatoryPartView.Name = "dgvNonMandatoryPartView";
            this.dgvNonMandatoryPartView.Size = new System.Drawing.Size(744, 222);
            this.dgvNonMandatoryPartView.TabIndex = 11;
            // 
            // lblOtherParts
            // 
            this.lblOtherParts.AutoSize = true;
            this.lblOtherParts.Location = new System.Drawing.Point(12, 383);
            this.lblOtherParts.Name = "lblOtherParts";
            this.lblOtherParts.Size = new System.Drawing.Size(152, 13);
            this.lblOtherParts.TabIndex = 10;
            this.lblOtherParts.Text = "Non-Mandatory Part Selection:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 627);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddPump
            // 
            this.btnAddPump.Location = new System.Drawing.Point(684, 627);
            this.btnAddPump.Name = "btnAddPump";
            this.btnAddPump.Size = new System.Drawing.Size(75, 23);
            this.btnAddPump.TabIndex = 13;
            this.btnAddPump.Text = "Add Pump";
            this.btnAddPump.UseVisualStyleBackColor = true;
            this.btnAddPump.Click += new System.EventHandler(this.btnAddPump_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Original Part Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "New Part Number";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Part Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Add To Current Pump";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // clmNMPartQuantity
            // 
            this.clmNMPartQuantity.HeaderText = "Part Quantity";
            this.clmNMPartQuantity.Name = "clmNMPartQuantity";
            // 
            // clmDescription
            // 
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.Width = 200;
            // 
            // clmOriginalPartNumber
            // 
            this.clmOriginalPartNumber.HeaderText = "Original Part Number";
            this.clmOriginalPartNumber.Name = "clmOriginalPartNumber";
            this.clmOriginalPartNumber.ReadOnly = true;
            // 
            // clmNewPartNumber
            // 
            this.clmNewPartNumber.HeaderText = "New Part Number";
            this.clmNewPartNumber.Name = "clmNewPartNumber";
            this.clmNewPartNumber.ReadOnly = true;
            // 
            // clmPartPrice
            // 
            this.clmPartPrice.HeaderText = "Part Price";
            this.clmPartPrice.Name = "clmPartPrice";
            this.clmPartPrice.ReadOnly = true;
            this.clmPartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPartPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmAddToPumpSelection
            // 
            this.clmAddToPumpSelection.HeaderText = "Add To Current Pump";
            this.clmAddToPumpSelection.Name = "clmAddToPumpSelection";
            // 
            // clmMPartQuantity
            // 
            this.clmMPartQuantity.HeaderText = "Part Quantity";
            this.clmMPartQuantity.Name = "clmMPartQuantity";
            // 
            // frmAddPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 657);
            this.Controls.Add(this.btnAddPump);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvNonMandatoryPartView);
            this.Controls.Add(this.lblOtherParts);
            this.Controls.Add(this.dgvMandatoryPartView);
            this.Controls.Add(this.lblMandatoryParts);
            this.Controls.Add(this.mtxtNewPumpPrice);
            this.Controls.Add(this.mtxtPumpDescription);
            this.Controls.Add(this.mtxtPumpName);
            this.Controls.Add(this.lblNewPumpPrice);
            this.Controls.Add(this.lblPumpDescription);
            this.Controls.Add(this.lblPumpName);
            this.Controls.Add(this.msAddPumpControls);
            this.MainMenuStrip = this.msAddPumpControls;
            this.Name = "frmAddPump";
            this.Text = "Adding New Pump";
            this.Activated += new System.EventHandler(this.frmAddPump_Activated);
            this.msAddPumpControls.ResumeLayout(false);
            this.msAddPumpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonMandatoryPartView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPumpName;
        private System.Windows.Forms.MenuStrip msAddPumpControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblPumpDescription;
        private System.Windows.Forms.Label lblNewPumpPrice;
        private System.Windows.Forms.MaskedTextBox mtxtPumpName;
        private System.Windows.Forms.MaskedTextBox mtxtPumpDescription;
        private System.Windows.Forms.MaskedTextBox mtxtNewPumpPrice;
        private System.Windows.Forms.Label lblMandatoryParts;
        private System.Windows.Forms.DataGridView dgvMandatoryPartView;
        private System.Windows.Forms.DataGridView dgvNonMandatoryPartView;
        private System.Windows.Forms.Label lblOtherParts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPump;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOriginalPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNewPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAddToPumpSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMPartQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNMPartQuantity;
    }
}