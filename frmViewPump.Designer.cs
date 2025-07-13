
namespace QuoteSwift
{
    partial class FrmViewPump
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPump = new System.Windows.Forms.Button();
            this.btnRemovePumpSelection = new System.Windows.Forms.Button();
            this.dgvPumpList = new System.Windows.Forms.DataGridView();
            this.clmPumpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPumpDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNewPumpPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewSelectedPump = new System.Windows.Forms.Button();
            this.msViewAllPumpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPumpList)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewAllPumpControls
            // 
            this.msViewAllPumpControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msViewAllPumpControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.exportInventoryToolStripMenuItem});
            this.msViewAllPumpControls.Location = new System.Drawing.Point(0, 0);
            this.msViewAllPumpControls.Name = "msViewAllPumpControls";
            this.msViewAllPumpControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msViewAllPumpControls.Size = new System.Drawing.Size(698, 30);
            this.msViewAllPumpControls.TabIndex = 0;
            this.msViewAllPumpControls.Text = "msViewAllPumpControls";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // exportInventoryToolStripMenuItem
            //
            this.exportInventoryToolStripMenuItem.Name = "exportInventoryToolStripMenuItem";
            this.exportInventoryToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.exportInventoryToolStripMenuItem.Text = "Export Inventory";
            this.exportInventoryToolStripMenuItem.Click += new System.EventHandler(this.ExportInventoryToolStripMenuItem_Click);
            //
            // btnAddPump
            // 
            this.btnAddPump.Location = new System.Drawing.Point(20, 39);
            this.btnAddPump.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPump.Name = "btnAddPump";
            this.btnAddPump.Size = new System.Drawing.Size(112, 32);
            this.btnAddPump.TabIndex = 1;
            this.btnAddPump.Text = "Add Pump";
            this.btnAddPump.UseVisualStyleBackColor = true;
            this.btnAddPump.Click += new System.EventHandler(this.BtnAddPump_Click);
            // 
            // btnRemovePumpSelection
            // 
            this.btnRemovePumpSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePumpSelection.Location = new System.Drawing.Point(477, 384);
            this.btnRemovePumpSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePumpSelection.Name = "btnRemovePumpSelection";
            this.btnRemovePumpSelection.Size = new System.Drawing.Size(207, 32);
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
            this.dgvPumpList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPumpList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPumpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPumpList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPumpName,
            this.clmPumpDescription,
            this.clmNewPumpPrice});
            this.dgvPumpList.Location = new System.Drawing.Point(20, 79);
            this.dgvPumpList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPumpList.Name = "dgvPumpList";
            this.dgvPumpList.Size = new System.Drawing.Size(664, 296);
            this.dgvPumpList.TabIndex = 3;
            // 
            // clmPumpName
            // 
            this.clmPumpName.HeaderText = "Pump Name";
            this.clmPumpName.Name = "clmPumpName";
            this.clmPumpName.ReadOnly = true;
            this.clmPumpName.Width = 106;
            // 
            // clmPumpDescription
            // 
            this.clmPumpDescription.HeaderText = "Description";
            this.clmPumpDescription.Name = "clmPumpDescription";
            this.clmPumpDescription.ReadOnly = true;
            this.clmPumpDescription.Width = 108;
            // 
            // clmNewPumpPrice
            // 
            this.clmNewPumpPrice.HeaderText = "New Pump Price";
            this.clmNewPumpPrice.Name = "clmNewPumpPrice";
            this.clmNewPumpPrice.ReadOnly = true;
            this.clmNewPumpPrice.Width = 132;
            // 
            // btnViewSelectedPump
            // 
            this.btnViewSelectedPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedPump.Location = new System.Drawing.Point(477, 39);
            this.btnViewSelectedPump.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSelectedPump.Name = "btnViewSelectedPump";
            this.btnViewSelectedPump.Size = new System.Drawing.Size(207, 32);
            this.btnViewSelectedPump.TabIndex = 4;
            this.btnViewSelectedPump.Text = "View Selected Pump";
            this.btnViewSelectedPump.UseVisualStyleBackColor = true;
            this.btnViewSelectedPump.Click += new System.EventHandler(this.BtnUpdateSelectedPump_Click);
            // 
            // FrmViewPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 424);
            this.Controls.Add(this.btnViewSelectedPump);
            this.Controls.Add(this.dgvPumpList);
            this.Controls.Add(this.btnRemovePumpSelection);
            this.Controls.Add(this.btnAddPump);
            this.Controls.Add(this.msViewAllPumpControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msViewAllPumpControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmViewPump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing All Pumps";
            this.Load += new System.EventHandler(this.FrmViewPump_Load);
            this.msViewAllPumpControls.ResumeLayout(false);
            this.msViewAllPumpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPumpList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewAllPumpControls;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportInventoryToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPump;
        private System.Windows.Forms.Button btnRemovePumpSelection;
        private System.Windows.Forms.DataGridView dgvPumpList;
        private System.Windows.Forms.Button btnViewSelectedPump;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPumpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPumpDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNewPumpPrice;
    }
}