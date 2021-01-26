
namespace QuoteSwift
{
    partial class frmViewPump
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
            this.msViewAllPumpControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainScreenViewQuotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPump = new System.Windows.Forms.Button();
            this.btnRemovePumpSelection = new System.Windows.Forms.Button();
            this.dgvPumpList = new System.Windows.Forms.DataGridView();
            this.clmPumpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPumpDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNewPumpPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateSelectedPump = new System.Windows.Forms.Button();
            this.msViewAllPumpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPumpList)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewAllPumpControls
            // 
            this.msViewAllPumpControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewAllPumpControls.Location = new System.Drawing.Point(0, 0);
            this.msViewAllPumpControls.Name = "msViewAllPumpControls";
            this.msViewAllPumpControls.Size = new System.Drawing.Size(465, 24);
            this.msViewAllPumpControls.TabIndex = 0;
            this.msViewAllPumpControls.Text = "msViewAllPumpControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainScreenViewQuotesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mainScreenViewQuotesToolStripMenuItem
            // 
            this.mainScreenViewQuotesToolStripMenuItem.Name = "mainScreenViewQuotesToolStripMenuItem";
            this.mainScreenViewQuotesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.mainScreenViewQuotesToolStripMenuItem.Text = "Open Main Screen (View Quotes)";
            this.mainScreenViewQuotesToolStripMenuItem.Click += new System.EventHandler(this.MainScreenViewQuotesToolStripMenuItem_Click);
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
            // btnAddPump
            // 
            this.btnAddPump.Location = new System.Drawing.Point(13, 28);
            this.btnAddPump.Name = "btnAddPump";
            this.btnAddPump.Size = new System.Drawing.Size(75, 23);
            this.btnAddPump.TabIndex = 1;
            this.btnAddPump.Text = "Add Pump";
            this.btnAddPump.UseVisualStyleBackColor = true;
            this.btnAddPump.Click += new System.EventHandler(this.BtnAddPump_Click);
            // 
            // btnRemovePumpSelection
            // 
            this.btnRemovePumpSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePumpSelection.Location = new System.Drawing.Point(318, 277);
            this.btnRemovePumpSelection.Name = "btnRemovePumpSelection";
            this.btnRemovePumpSelection.Size = new System.Drawing.Size(138, 23);
            this.btnRemovePumpSelection.TabIndex = 2;
            this.btnRemovePumpSelection.Text = "Remove Selected Pump";
            this.btnRemovePumpSelection.UseVisualStyleBackColor = true;
            this.btnRemovePumpSelection.Click += new System.EventHandler(this.BtnRemovePumpSelection_Click);
            // 
            // dgvPumpList
            // 
            this.dgvPumpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPumpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPumpList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPumpName,
            this.clmPumpDescription,
            this.clmNewPumpPrice});
            this.dgvPumpList.Location = new System.Drawing.Point(13, 57);
            this.dgvPumpList.Name = "dgvPumpList";
            this.dgvPumpList.Size = new System.Drawing.Size(443, 214);
            this.dgvPumpList.TabIndex = 3;
            // 
            // clmPumpName
            // 
            this.clmPumpName.HeaderText = "Pump Name";
            this.clmPumpName.Name = "clmPumpName";
            this.clmPumpName.ReadOnly = true;
            // 
            // clmPumpDescription
            // 
            this.clmPumpDescription.HeaderText = "Description";
            this.clmPumpDescription.Name = "clmPumpDescription";
            this.clmPumpDescription.ReadOnly = true;
            this.clmPumpDescription.Width = 200;
            // 
            // clmNewPumpPrice
            // 
            this.clmNewPumpPrice.HeaderText = "New Pump Price";
            this.clmNewPumpPrice.Name = "clmNewPumpPrice";
            this.clmNewPumpPrice.ReadOnly = true;
            // 
            // btnUpdateSelectedPump
            // 
            this.btnUpdateSelectedPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSelectedPump.Location = new System.Drawing.Point(318, 28);
            this.btnUpdateSelectedPump.Name = "btnUpdateSelectedPump";
            this.btnUpdateSelectedPump.Size = new System.Drawing.Size(138, 23);
            this.btnUpdateSelectedPump.TabIndex = 4;
            this.btnUpdateSelectedPump.Text = "Update Selected Pump";
            this.btnUpdateSelectedPump.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedPump.Click += new System.EventHandler(this.BtnUpdateSelectedPump_Click);
            // 
            // frmViewPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 306);
            this.Controls.Add(this.btnUpdateSelectedPump);
            this.Controls.Add(this.dgvPumpList);
            this.Controls.Add(this.btnRemovePumpSelection);
            this.Controls.Add(this.btnAddPump);
            this.Controls.Add(this.msViewAllPumpControls);
            this.MainMenuStrip = this.msViewAllPumpControls;
            this.Name = "frmViewPump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing All Pumps";
            this.Activated += new System.EventHandler(this.FrmViewPump_Activated);
            this.msViewAllPumpControls.ResumeLayout(false);
            this.msViewAllPumpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPumpList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewAllPumpControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPump;
        private System.Windows.Forms.Button btnRemovePumpSelection;
        private System.Windows.Forms.DataGridView dgvPumpList;
        private System.Windows.Forms.Button btnUpdateSelectedPump;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPumpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPumpDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNewPumpPrice;
        private System.Windows.Forms.ToolStripMenuItem mainScreenViewQuotesToolStripMenuItem;
    }
}