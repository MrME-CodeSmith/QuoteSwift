
namespace QuoteSwift
{
    partial class FrmViewAllBusinesses
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
            this.msViewAllBusinessesControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddBusiness = new System.Windows.Forms.Button();
            this.DgvBusinessList = new System.Windows.Forms.DataGridView();
            this.clmBusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateBusiness = new System.Windows.Forms.Button();
            this.BtnRemoveSelected = new System.Windows.Forms.Button();
            this.msViewAllBusinessesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusinessList)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewAllBusinessesControls
            // 
            this.msViewAllBusinessesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewAllBusinessesControls.Location = new System.Drawing.Point(0, 0);
            this.msViewAllBusinessesControls.Name = "msViewAllBusinessesControls";
            this.msViewAllBusinessesControls.Size = new System.Drawing.Size(412, 24);
            this.msViewAllBusinessesControls.TabIndex = 0;
            this.msViewAllBusinessesControls.Text = "msViewAllBusinessesControls";
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
            // btnAddBusiness
            // 
            this.btnAddBusiness.Location = new System.Drawing.Point(12, 27);
            this.btnAddBusiness.Name = "btnAddBusiness";
            this.btnAddBusiness.Size = new System.Drawing.Size(85, 23);
            this.btnAddBusiness.TabIndex = 1;
            this.btnAddBusiness.Text = "Add Business";
            this.btnAddBusiness.UseVisualStyleBackColor = true;
            this.btnAddBusiness.Click += new System.EventHandler(this.BtnAddBusiness_Click);
            // 
            // DgvBusinessList
            // 
            this.DgvBusinessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBusinessList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmBusinessName});
            this.DgvBusinessList.Location = new System.Drawing.Point(12, 56);
            this.DgvBusinessList.Name = "DgvBusinessList";
            this.DgvBusinessList.Size = new System.Drawing.Size(392, 200);
            this.DgvBusinessList.TabIndex = 2;
            // 
            // clmBusinessName
            // 
            this.clmBusinessName.HeaderText = "Business Name";
            this.clmBusinessName.Name = "clmBusinessName";
            this.clmBusinessName.ReadOnly = true;
            this.clmBusinessName.Width = 200;
            // 
            // btnUpdateBusiness
            // 
            this.btnUpdateBusiness.Location = new System.Drawing.Point(248, 27);
            this.btnUpdateBusiness.Name = "btnUpdateBusiness";
            this.btnUpdateBusiness.Size = new System.Drawing.Size(156, 23);
            this.btnUpdateBusiness.TabIndex = 3;
            this.btnUpdateBusiness.Text = "View Business Information";
            this.btnUpdateBusiness.UseVisualStyleBackColor = true;
            this.btnUpdateBusiness.Click += new System.EventHandler(this.BtnUpdateBusiness_Click);
            // 
            // BtnRemoveSelected
            // 
            this.BtnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveSelected.Location = new System.Drawing.Point(248, 262);
            this.BtnRemoveSelected.Name = "BtnRemoveSelected";
            this.BtnRemoveSelected.Size = new System.Drawing.Size(156, 23);
            this.BtnRemoveSelected.TabIndex = 4;
            this.BtnRemoveSelected.Text = "Remove Selected Business";
            this.BtnRemoveSelected.UseVisualStyleBackColor = true;
            this.BtnRemoveSelected.Click += new System.EventHandler(this.BtnRemoveSelected_Click);
            // 
            // FrmViewAllBusinesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.BtnRemoveSelected);
            this.Controls.Add(this.btnUpdateBusiness);
            this.Controls.Add(this.DgvBusinessList);
            this.Controls.Add(this.btnAddBusiness);
            this.Controls.Add(this.msViewAllBusinessesControls);
            this.MainMenuStrip = this.msViewAllBusinessesControls;
            this.Name = "FrmViewAllBusinesses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing All Businesses";
            this.Load += new System.EventHandler(this.FrmViewAllBusinesses_Load);
            this.msViewAllBusinessesControls.ResumeLayout(false);
            this.msViewAllBusinessesControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusinessList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewAllBusinessesControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnAddBusiness;
        private System.Windows.Forms.DataGridView DgvBusinessList;
        private System.Windows.Forms.Button btnUpdateBusiness;
        private System.Windows.Forms.Button BtnRemoveSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBusinessName;
    }
}