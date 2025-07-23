
namespace QuoteSwift.Views
{
    partial class FrmAddPump
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
            this.msAddPumpControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMandatoryParts = new System.Windows.Forms.Label();
            this.dgvMandatoryPartView = new System.Windows.Forms.DataGridView();
            this.ClmPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOriginalPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNewPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddToPumpSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmMPartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNonMandatoryPartView = new System.Windows.Forms.DataGridView();
            this.ClmNMPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNonMandatoryPartSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmNMPartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOtherParts = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPump = new System.Windows.Forms.Button();
            this.gbxPartInformation = new System.Windows.Forms.GroupBox();
            this.mtxtNewPumpPrice = new QuoteSwift.Controls.NumericTextBox();
            this.mtxtPumpDescription = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPumpName = new System.Windows.Forms.MaskedTextBox();
            this.lblNewPumpPrice = new System.Windows.Forms.Label();
            this.lblPumpDescription = new System.Windows.Forms.Label();
            this.lblPumpName = new System.Windows.Forms.Label();
            this.msAddPumpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonMandatoryPartView)).BeginInit();
            this.gbxPartInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // msAddPumpControls
            // 
            this.msAddPumpControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msAddPumpControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msAddPumpControls.Location = new System.Drawing.Point(0, 0);
            this.msAddPumpControls.Name = "msAddPumpControls";
            this.msAddPumpControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msAddPumpControls.Size = new System.Drawing.Size(1302, 30);
            this.msAddPumpControls.TabIndex = 1;
            this.msAddPumpControls.Text = "msAddPumpControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePumpToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updatePumpToolStripMenuItem
            // 
            this.updatePumpToolStripMenuItem.Enabled = false;
            this.updatePumpToolStripMenuItem.Name = "updatePumpToolStripMenuItem";
            this.updatePumpToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.updatePumpToolStripMenuItem.Text = "Update Pump ";
            this.updatePumpToolStripMenuItem.Click += new System.EventHandler(this.UpdatePumpToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // lblMandatoryParts
            // 
            this.lblMandatoryParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandatoryParts.AutoSize = true;
            this.lblMandatoryParts.Location = new System.Drawing.Point(19, 187);
            this.lblMandatoryParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMandatoryParts.Name = "lblMandatoryParts";
            this.lblMandatoryParts.Size = new System.Drawing.Size(178, 18);
            this.lblMandatoryParts.TabIndex = 8;
            this.lblMandatoryParts.Text = "Mandatory Part Selection:";
            // 
            // dgvMandatoryPartView
            // 
            this.dgvMandatoryPartView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMandatoryPartView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMandatoryPartView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMandatoryPartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMandatoryPartView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmPartName,
            this.clmDescription,
            this.clmOriginalPartNumber,
            this.clmNewPartNumber,
            this.clmPartPrice,
            this.clmAddToPumpSelection,
            this.clmMPartQuantity});
            this.dgvMandatoryPartView.Location = new System.Drawing.Point(23, 210);
            this.dgvMandatoryPartView.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMandatoryPartView.Name = "dgvMandatoryPartView";
            this.dgvMandatoryPartView.Size = new System.Drawing.Size(1266, 307);
            this.dgvMandatoryPartView.TabIndex = 9;
            this.dgvMandatoryPartView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMandatoryPartView_CellContentClick);
            // 
            // ClmPartName
            // 
            this.ClmPartName.HeaderText = "Part Name";
            this.ClmPartName.Name = "ClmPartName";
            this.ClmPartName.ReadOnly = true;
            this.ClmPartName.Width = 96;
            // 
            // clmDescription
            // 
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.Width = 108;
            // 
            // clmOriginalPartNumber
            // 
            this.clmOriginalPartNumber.HeaderText = "Original Part Number";
            this.clmOriginalPartNumber.Name = "clmOriginalPartNumber";
            this.clmOriginalPartNumber.ReadOnly = true;
            this.clmOriginalPartNumber.Width = 156;
            // 
            // clmNewPartNumber
            // 
            this.clmNewPartNumber.HeaderText = "New Part Number";
            this.clmNewPartNumber.Name = "clmNewPartNumber";
            this.clmNewPartNumber.ReadOnly = true;
            this.clmNewPartNumber.Width = 138;
            // 
            // clmPartPrice
            // 
            this.clmPartPrice.HeaderText = "Part Price";
            this.clmPartPrice.Name = "clmPartPrice";
            this.clmPartPrice.ReadOnly = true;
            this.clmPartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPartPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPartPrice.Width = 71;
            // 
            // clmAddToPumpSelection
            // 
            this.clmAddToPumpSelection.HeaderText = "Add To Current Pump";
            this.clmAddToPumpSelection.Name = "clmAddToPumpSelection";
            this.clmAddToPumpSelection.Width = 106;
            // 
            // clmMPartQuantity
            // 
            this.clmMPartQuantity.HeaderText = "Part Quantity";
            this.clmMPartQuantity.Name = "clmMPartQuantity";
            this.clmMPartQuantity.Width = 108;
            // 
            // dgvNonMandatoryPartView
            // 
            this.dgvNonMandatoryPartView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNonMandatoryPartView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNonMandatoryPartView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNonMandatoryPartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNonMandatoryPartView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmNMPartName,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ClmNonMandatoryPartSelection,
            this.clmNMPartQuantity});
            this.dgvNonMandatoryPartView.Location = new System.Drawing.Point(23, 563);
            this.dgvNonMandatoryPartView.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNonMandatoryPartView.Name = "dgvNonMandatoryPartView";
            this.dgvNonMandatoryPartView.Size = new System.Drawing.Size(1266, 286);
            this.dgvNonMandatoryPartView.TabIndex = 11;
            this.dgvNonMandatoryPartView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNonMandatoryPartView_CellContentClick);
            // 
            // ClmNMPartName
            // 
            this.ClmNMPartName.HeaderText = "Part Name";
            this.ClmNMPartName.Name = "ClmNMPartName";
            this.ClmNMPartName.ReadOnly = true;
            this.ClmNMPartName.Width = 96;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 108;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Original Part Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 156;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "New Part Number";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 138;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Part Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 71;
            // 
            // ClmNonMandatoryPartSelection
            // 
            this.ClmNonMandatoryPartSelection.HeaderText = "Add To Current Pump";
            this.ClmNonMandatoryPartSelection.Name = "ClmNonMandatoryPartSelection";
            this.ClmNonMandatoryPartSelection.Width = 106;
            // 
            // clmNMPartQuantity
            // 
            this.clmNMPartQuantity.HeaderText = "Part Quantity";
            this.clmNMPartQuantity.Name = "clmNMPartQuantity";
            this.clmNMPartQuantity.Width = 108;
            // 
            // lblOtherParts
            // 
            this.lblOtherParts.AutoSize = true;
            this.lblOtherParts.Location = new System.Drawing.Point(19, 541);
            this.lblOtherParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOtherParts.Name = "lblOtherParts";
            this.lblOtherParts.Size = new System.Drawing.Size(211, 18);
            this.lblOtherParts.TabIndex = 10;
            this.lblOtherParts.Text = "Non-Mandatory Part Selection:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(22, 857);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddPump
            // 
            this.btnAddPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPump.Location = new System.Drawing.Point(1167, 857);
            this.btnAddPump.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPump.Name = "btnAddPump";
            this.btnAddPump.Size = new System.Drawing.Size(122, 32);
            this.btnAddPump.TabIndex = 3;
            this.btnAddPump.Text = "Add Pump";
            this.btnAddPump.UseVisualStyleBackColor = true;
            // 
            // gbxPartInformation
            // 
            this.gbxPartInformation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxPartInformation.AutoSize = true;
            this.gbxPartInformation.Controls.Add(this.mtxtNewPumpPrice);
            this.gbxPartInformation.Controls.Add(this.mtxtPumpDescription);
            this.gbxPartInformation.Controls.Add(this.mtxtPumpName);
            this.gbxPartInformation.Controls.Add(this.lblNewPumpPrice);
            this.gbxPartInformation.Controls.Add(this.lblPumpDescription);
            this.gbxPartInformation.Controls.Add(this.lblPumpName);
            this.gbxPartInformation.Location = new System.Drawing.Point(388, 37);
            this.gbxPartInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPartInformation.Name = "gbxPartInformation";
            this.gbxPartInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPartInformation.Size = new System.Drawing.Size(554, 139);
            this.gbxPartInformation.TabIndex = 14;
            this.gbxPartInformation.TabStop = false;
            this.gbxPartInformation.Text = "Part Information:";
            // 
            // mtxtNewPumpPrice
            // 
            this.mtxtNewPumpPrice.Value = 0M;
            this.mtxtNewPumpPrice.Location = new System.Drawing.Point(174, 90);
            this.mtxtNewPumpPrice.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtNewPumpPrice.MaxValue = 5000000M;
            this.mtxtNewPumpPrice.MinValue = 0M;
            this.mtxtNewPumpPrice.Name = "mtxtNewPumpPrice";
            this.mtxtNewPumpPrice.Size = new System.Drawing.Size(139, 24);
            this.mtxtNewPumpPrice.TabIndex = 2;
            this.mtxtNewPumpPrice.Text = "0.00";
            // 
            // mtxtPumpDescription
            // 
            this.mtxtPumpDescription.Location = new System.Drawing.Point(174, 58);
            this.mtxtPumpDescription.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPumpDescription.Name = "mtxtPumpDescription";
            this.mtxtPumpDescription.Size = new System.Drawing.Size(343, 24);
            this.mtxtPumpDescription.TabIndex = 1;
            // 
            // mtxtPumpName
            // 
            this.mtxtPumpName.Location = new System.Drawing.Point(174, 26);
            this.mtxtPumpName.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPumpName.Name = "mtxtPumpName";
            this.mtxtPumpName.Size = new System.Drawing.Size(343, 24);
            this.mtxtPumpName.TabIndex = 0;
            // 
            // lblNewPumpPrice
            // 
            this.lblNewPumpPrice.AutoSize = true;
            this.lblNewPumpPrice.Location = new System.Drawing.Point(42, 93);
            this.lblNewPumpPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPumpPrice.Name = "lblNewPumpPrice";
            this.lblNewPumpPrice.Size = new System.Drawing.Size(123, 18);
            this.lblNewPumpPrice.TabIndex = 9;
            this.lblNewPumpPrice.Text = "New Pump Price:";
            // 
            // lblPumpDescription
            // 
            this.lblPumpDescription.AutoSize = true;
            this.lblPumpDescription.Location = new System.Drawing.Point(35, 61);
            this.lblPumpDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPumpDescription.Name = "lblPumpDescription";
            this.lblPumpDescription.Size = new System.Drawing.Size(130, 18);
            this.lblPumpDescription.TabIndex = 8;
            this.lblPumpDescription.Text = "Pump Description:";
            // 
            // lblPumpName
            // 
            this.lblPumpName.AutoSize = true;
            this.lblPumpName.Location = new System.Drawing.Point(70, 29);
            this.lblPumpName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPumpName.Name = "lblPumpName";
            this.lblPumpName.Size = new System.Drawing.Size(95, 18);
            this.lblPumpName.TabIndex = 7;
            this.lblPumpName.Text = "Pump Name:";
            // 
            // FrmAddPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 902);
            this.Controls.Add(this.gbxPartInformation);
            this.Controls.Add(this.btnAddPump);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvNonMandatoryPartView);
            this.Controls.Add(this.lblOtherParts);
            this.Controls.Add(this.dgvMandatoryPartView);
            this.Controls.Add(this.lblMandatoryParts);
            this.Controls.Add(this.msAddPumpControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msAddPumpControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddPump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adding New Pump";
            this.Load += new System.EventHandler(this.FrmAddPump_Load);
            this.msAddPumpControls.ResumeLayout(false);
            this.msAddPumpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonMandatoryPartView)).EndInit();
            this.gbxPartInformation.ResumeLayout(false);
            this.gbxPartInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msAddPumpControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblMandatoryParts;
        private System.Windows.Forms.DataGridView dgvMandatoryPartView;
        private System.Windows.Forms.DataGridView dgvNonMandatoryPartView;
        private System.Windows.Forms.Label lblOtherParts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPump;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOriginalPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNewPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAddToPumpSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMPartQuantity;
        private System.Windows.Forms.GroupBox gbxPartInformation;
        private System.Windows.Forms.MaskedTextBox mtxtPumpDescription;
        private System.Windows.Forms.MaskedTextBox mtxtPumpName;
        private System.Windows.Forms.Label lblNewPumpPrice;
        private System.Windows.Forms.Label lblPumpDescription;
        private System.Windows.Forms.Label lblPumpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClmNonMandatoryPartSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNMPartQuantity;
        private System.Windows.Forms.ToolStripMenuItem updatePumpToolStripMenuItem;
        private QuoteSwift.Controls.NumericTextBox mtxtNewPumpPrice;
    }
}