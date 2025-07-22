
namespace QuoteSwift
{
    partial class FrmViewParts
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
            this.msViewPartsControls = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvAllParts = new System.Windows.Forms.DataGridView();
            this.clmPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOriginalPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNewPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMandatoryPart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmPartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnRemovePart = new System.Windows.Forms.Button();
            this.btnViewSelectedPart = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.msViewPartsControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllParts)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewPartsControls
            // 
            this.msViewPartsControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msViewPartsControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msViewPartsControls.Location = new System.Drawing.Point(0, 0);
            this.msViewPartsControls.Name = "msViewPartsControls";
            this.msViewPartsControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msViewPartsControls.Size = new System.Drawing.Size(1152, 30);
            this.msViewPartsControls.TabIndex = 0;
            this.msViewPartsControls.Text = "msViewPartsControls";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // dgvAllParts
            // 
            this.dgvAllParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPartName,
            this.clmDescription,
            this.clmOriginalPartNumber,
            this.clmNewPartNumber,
            this.clmMandatoryPart,
            this.clmPartPrice});
            this.dgvAllParts.Location = new System.Drawing.Point(18, 82);
            this.dgvAllParts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAllParts.Name = "dgvAllParts";
            this.dgvAllParts.Size = new System.Drawing.Size(1114, 307);
            this.dgvAllParts.TabIndex = 1;
            // 
            // clmPartName
            // 
            this.clmPartName.DataPropertyName = "PartName";
            this.clmPartName.HeaderText = "Part Name";
            this.clmPartName.Name = "clmPartName";
            this.clmPartName.ReadOnly = true;
            // 
            // clmDescription
            // 
            this.clmDescription.DataPropertyName = "PartDescription";
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.Width = 200;
            // 
            // clmOriginalPartNumber
            // 
            this.clmOriginalPartNumber.DataPropertyName = "OriginalItemPartNumber";
            this.clmOriginalPartNumber.HeaderText = "Original Part Number";
            this.clmOriginalPartNumber.Name = "clmOriginalPartNumber";
            this.clmOriginalPartNumber.ReadOnly = true;
            // 
            // clmNewPartNumber
            // 
            this.clmNewPartNumber.DataPropertyName = "NewPartNumber";
            this.clmNewPartNumber.HeaderText = "New Part Number";
            this.clmNewPartNumber.Name = "clmNewPartNumber";
            this.clmNewPartNumber.ReadOnly = true;
            // 
            // clmMandatoryPart
            // 
            this.clmMandatoryPart.DataPropertyName = "MandatoryPart";
            this.clmMandatoryPart.HeaderText = "Mandatory Part";
            this.clmMandatoryPart.Name = "clmMandatoryPart";
            this.clmMandatoryPart.ReadOnly = true;
            // 
            // clmPartPrice
            // 
            this.clmPartPrice.DataPropertyName = "PartPrice";
            this.clmPartPrice.HeaderText = "Part Price";
            this.clmPartPrice.Name = "clmPartPrice";
            this.clmPartPrice.ReadOnly = true;
            this.clmPartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPartPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(18, 42);
            this.btnAddPart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(112, 32);
            this.btnAddPart.TabIndex = 2;
            this.btnAddPart.Text = "Add Part";
            this.btnAddPart.UseVisualStyleBackColor = true;
            // 
            // btnRemovePart
            // 
            this.btnRemovePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePart.Location = new System.Drawing.Point(948, 397);
            this.btnRemovePart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePart.Name = "btnRemovePart";
            this.btnRemovePart.Size = new System.Drawing.Size(184, 32);
            this.btnRemovePart.TabIndex = 3;
            this.btnRemovePart.Text = "Remove Selected Part";
            this.btnRemovePart.UseVisualStyleBackColor = true;
            // 
            // btnViewSelectedPart
            // 
            this.btnViewSelectedPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedPart.Location = new System.Drawing.Point(952, 42);
            this.btnViewSelectedPart.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSelectedPart.Name = "btnViewSelectedPart";
            this.btnViewSelectedPart.Size = new System.Drawing.Size(180, 32);
            this.btnViewSelectedPart.TabIndex = 4;
            this.btnViewSelectedPart.Text = "View Selected Part";
            this.btnViewSelectedPart.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 397);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmViewParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 440);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnViewSelectedPart);
            this.Controls.Add(this.btnRemovePart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.dgvAllParts);
            this.Controls.Add(this.msViewPartsControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msViewPartsControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmViewParts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View All Parts";
            this.Activated += new System.EventHandler(this.FrmViewParts_Activated);
            this.Load += new System.EventHandler(this.FrmViewParts_Load);
            this.msViewPartsControls.ResumeLayout(false);
            this.msViewPartsControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewPartsControls;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAllParts;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnRemovePart;
        private System.Windows.Forms.Button btnViewSelectedPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOriginalPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNewPartNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmMandatoryPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartPrice;
        private System.Windows.Forms.Button BtnCancel;
    }
}