
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msViewPartsControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewPartsControls.Location = new System.Drawing.Point(0, 0);
            this.msViewPartsControls.Name = "msViewPartsControls";
            this.msViewPartsControls.Size = new System.Drawing.Size(768, 24);
            this.msViewPartsControls.TabIndex = 0;
            this.msViewPartsControls.Text = "msViewPartsControls";
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
            this.dgvAllParts.Location = new System.Drawing.Point(12, 59);
            this.dgvAllParts.Name = "dgvAllParts";
            this.dgvAllParts.Size = new System.Drawing.Size(743, 222);
            this.dgvAllParts.TabIndex = 1;
            // 
            // clmPartName
            // 
            this.clmPartName.HeaderText = "Part Name";
            this.clmPartName.Name = "clmPartName";
            this.clmPartName.ReadOnly = true;
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
            // clmMandatoryPart
            // 
            this.clmMandatoryPart.HeaderText = "Mandatory Part";
            this.clmMandatoryPart.Name = "clmMandatoryPart";
            this.clmMandatoryPart.ReadOnly = true;
            // 
            // clmPartPrice
            // 
            this.clmPartPrice.HeaderText = "Part Price";
            this.clmPartPrice.Name = "clmPartPrice";
            this.clmPartPrice.ReadOnly = true;
            this.clmPartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPartPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(12, 30);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(75, 23);
            this.btnAddPart.TabIndex = 2;
            this.btnAddPart.Text = "Add Part";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.BtnAddPart_Click);
            // 
            // btnRemovePart
            // 
            this.btnRemovePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePart.Location = new System.Drawing.Point(632, 287);
            this.btnRemovePart.Name = "btnRemovePart";
            this.btnRemovePart.Size = new System.Drawing.Size(123, 23);
            this.btnRemovePart.TabIndex = 3;
            this.btnRemovePart.Text = "Remove Selected Part";
            this.btnRemovePart.UseVisualStyleBackColor = true;
            this.btnRemovePart.Click += new System.EventHandler(this.BtnRemovePart_Click);
            // 
            // btnViewSelectedPart
            // 
            this.btnViewSelectedPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedPart.Location = new System.Drawing.Point(635, 30);
            this.btnViewSelectedPart.Name = "btnViewSelectedPart";
            this.btnViewSelectedPart.Size = new System.Drawing.Size(120, 23);
            this.btnViewSelectedPart.TabIndex = 4;
            this.btnViewSelectedPart.Text = "View Selected Part";
            this.btnViewSelectedPart.UseVisualStyleBackColor = true;
            this.btnViewSelectedPart.Click += new System.EventHandler(this.BtnUpdateSelectedPart_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(12, 287);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmViewParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 318);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnViewSelectedPart);
            this.Controls.Add(this.btnRemovePart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.dgvAllParts);
            this.Controls.Add(this.msViewPartsControls);
            this.MainMenuStrip = this.msViewPartsControls;
            this.Name = "FrmViewParts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View All Parts";
            this.Activated += new System.EventHandler(this.FrmViewParts_Activated);
            this.msViewPartsControls.ResumeLayout(false);
            this.msViewPartsControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewPartsControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
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