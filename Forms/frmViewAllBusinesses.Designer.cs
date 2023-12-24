
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddBusiness = new System.Windows.Forms.Button();
            this.DgvBusinessList = new System.Windows.Forms.DataGridView();
            this.clmBusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateBusiness = new System.Windows.Forms.Button();
            this.BtnRemoveSelected = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.msViewAllBusinessesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusinessList)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewAllBusinessesControls
            // 
            this.msViewAllBusinessesControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msViewAllBusinessesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msViewAllBusinessesControls.Location = new System.Drawing.Point(0, 0);
            this.msViewAllBusinessesControls.Name = "msViewAllBusinessesControls";
            this.msViewAllBusinessesControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msViewAllBusinessesControls.Size = new System.Drawing.Size(618, 30);
            this.msViewAllBusinessesControls.TabIndex = 0;
            this.msViewAllBusinessesControls.Text = "msViewAllBusinessesControls";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // btnAddBusiness
            // 
            this.btnAddBusiness.Location = new System.Drawing.Point(18, 37);
            this.btnAddBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBusiness.Name = "btnAddBusiness";
            this.btnAddBusiness.Size = new System.Drawing.Size(128, 32);
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
            this.DgvBusinessList.Location = new System.Drawing.Point(18, 78);
            this.DgvBusinessList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvBusinessList.Name = "DgvBusinessList";
            this.DgvBusinessList.Size = new System.Drawing.Size(588, 277);
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
            this.btnUpdateBusiness.Location = new System.Drawing.Point(372, 37);
            this.btnUpdateBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateBusiness.Name = "btnUpdateBusiness";
            this.btnUpdateBusiness.Size = new System.Drawing.Size(234, 32);
            this.btnUpdateBusiness.TabIndex = 3;
            this.btnUpdateBusiness.Text = "View Selected Business";
            this.btnUpdateBusiness.UseVisualStyleBackColor = true;
            this.btnUpdateBusiness.Click += new System.EventHandler(this.BtnUpdateBusiness_Click);
            // 
            // BtnRemoveSelected
            // 
            this.BtnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveSelected.Location = new System.Drawing.Point(372, 363);
            this.BtnRemoveSelected.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRemoveSelected.Name = "BtnRemoveSelected";
            this.BtnRemoveSelected.Size = new System.Drawing.Size(234, 32);
            this.BtnRemoveSelected.TabIndex = 4;
            this.BtnRemoveSelected.Text = "Remove Selected Business";
            this.BtnRemoveSelected.UseVisualStyleBackColor = true;
            this.BtnRemoveSelected.Click += new System.EventHandler(this.BtnRemoveSelected_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 363);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmViewAllBusinesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 402);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnRemoveSelected);
            this.Controls.Add(this.btnUpdateBusiness);
            this.Controls.Add(this.DgvBusinessList);
            this.Controls.Add(this.btnAddBusiness);
            this.Controls.Add(this.msViewAllBusinessesControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msViewAllBusinessesControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnAddBusiness;
        private System.Windows.Forms.DataGridView DgvBusinessList;
        private System.Windows.Forms.Button btnUpdateBusiness;
        private System.Windows.Forms.Button BtnRemoveSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBusinessName;
        private System.Windows.Forms.Button BtnCancel;
    }
}