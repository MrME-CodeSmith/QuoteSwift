
namespace QuoteSwift
{
    partial class FrmManagingPhoneNumbers
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
            this.msManagePhoneNumbersControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTelephoneNumbers = new System.Windows.Forms.DataGridView();
            this.clmTelephoneNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTelephoneNumberList = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.Label();
            this.dgvCellphoneNumbers = new System.Windows.Forms.DataGridView();
            this.ClmCellphoneNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveTelNumber = new System.Windows.Forms.Button();
            this.btnRemoveCellNumber = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUpdateCellphoneNumber = new System.Windows.Forms.Button();
            this.BtnUpdateTelephoneNumber = new System.Windows.Forms.Button();
            this.msManagePhoneNumbersControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelephoneNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCellphoneNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // msManagePhoneNumbersControls
            // 
            this.msManagePhoneNumbersControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msManagePhoneNumbersControls.Location = new System.Drawing.Point(0, 0);
            this.msManagePhoneNumbersControls.Name = "msManagePhoneNumbersControls";
            this.msManagePhoneNumbersControls.Size = new System.Drawing.Size(774, 24);
            this.msManagePhoneNumbersControls.TabIndex = 0;
            this.msManagePhoneNumbersControls.Text = "msManagePhoneNumbersControls";
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
            // dgvTelephoneNumbers
            // 
            this.dgvTelephoneNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTelephoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelephoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTelephoneNumbers});
            this.dgvTelephoneNumbers.Location = new System.Drawing.Point(12, 56);
            this.dgvTelephoneNumbers.Name = "dgvTelephoneNumbers";
            this.dgvTelephoneNumbers.Size = new System.Drawing.Size(350, 184);
            this.dgvTelephoneNumbers.TabIndex = 1;
            this.dgvTelephoneNumbers.Leave += new System.EventHandler(this.DgvTelephoneNumbers_Leave);
            // 
            // clmTelephoneNumbers
            // 
            this.clmTelephoneNumbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTelephoneNumbers.HeaderText = "Telephone Numbers";
            this.clmTelephoneNumbers.Name = "clmTelephoneNumbers";
            this.clmTelephoneNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTelephoneNumbers.Width = 98;
            // 
            // lblTelephoneNumberList
            // 
            this.lblTelephoneNumberList.AutoSize = true;
            this.lblTelephoneNumberList.Location = new System.Drawing.Point(12, 40);
            this.lblTelephoneNumberList.Name = "lblTelephoneNumberList";
            this.lblTelephoneNumberList.Size = new System.Drawing.Size(137, 13);
            this.lblTelephoneNumberList.TabIndex = 2;
            this.lblTelephoneNumberList.Text = "List of Telephone Numbers:";
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(403, 40);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(133, 13);
            this.x.TabIndex = 4;
            this.x.Text = "List of Cellphone Numbers:";
            // 
            // dgvCellphoneNumbers
            // 
            this.dgvCellphoneNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCellphoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCellphoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCellphoneNumbers});
            this.dgvCellphoneNumbers.Location = new System.Drawing.Point(406, 56);
            this.dgvCellphoneNumbers.Name = "dgvCellphoneNumbers";
            this.dgvCellphoneNumbers.Size = new System.Drawing.Size(350, 184);
            this.dgvCellphoneNumbers.TabIndex = 3;
            this.dgvCellphoneNumbers.Leave += new System.EventHandler(this.DgvCellphoneNumbers_Leave);
            // 
            // ClmCellphoneNumbers
            // 
            this.ClmCellphoneNumbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmCellphoneNumbers.HeaderText = "Cellphone Numbers";
            this.ClmCellphoneNumbers.Name = "ClmCellphoneNumbers";
            this.ClmCellphoneNumbers.ReadOnly = true;
            this.ClmCellphoneNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmCellphoneNumbers.Width = 95;
            // 
            // btnRemoveTelNumber
            // 
            this.btnRemoveTelNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveTelNumber.Location = new System.Drawing.Point(184, 246);
            this.btnRemoveTelNumber.Name = "btnRemoveTelNumber";
            this.btnRemoveTelNumber.Size = new System.Drawing.Size(178, 23);
            this.btnRemoveTelNumber.TabIndex = 5;
            this.btnRemoveTelNumber.Text = "Remove Selected Phone Number";
            this.btnRemoveTelNumber.UseVisualStyleBackColor = true;
            this.btnRemoveTelNumber.Click += new System.EventHandler(this.BtnRemoveTelNumber_Click);
            // 
            // btnRemoveCellNumber
            // 
            this.btnRemoveCellNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveCellNumber.Location = new System.Drawing.Point(577, 246);
            this.btnRemoveCellNumber.Name = "btnRemoveCellNumber";
            this.btnRemoveCellNumber.Size = new System.Drawing.Size(179, 23);
            this.btnRemoveCellNumber.TabIndex = 6;
            this.btnRemoveCellNumber.Text = "Remove Selected Phone Number";
            this.btnRemoveCellNumber.UseVisualStyleBackColor = true;
            this.btnRemoveCellNumber.Click += new System.EventHandler(this.BtnRemoveCellNumber_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(12, 246);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpdateCellphoneNumber
            // 
            this.BtnUpdateCellphoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateCellphoneNumber.Location = new System.Drawing.Point(577, 27);
            this.BtnUpdateCellphoneNumber.Name = "BtnUpdateCellphoneNumber";
            this.BtnUpdateCellphoneNumber.Size = new System.Drawing.Size(179, 23);
            this.BtnUpdateCellphoneNumber.TabIndex = 6;
            this.BtnUpdateCellphoneNumber.Text = "Update Selected Phone Number";
            this.BtnUpdateCellphoneNumber.UseVisualStyleBackColor = true;
            this.BtnUpdateCellphoneNumber.Click += new System.EventHandler(this.BtnChangePhoneNumberInfo_Click);
            // 
            // BtnUpdateTelephoneNumber
            // 
            this.BtnUpdateTelephoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateTelephoneNumber.Location = new System.Drawing.Point(184, 27);
            this.BtnUpdateTelephoneNumber.Name = "BtnUpdateTelephoneNumber";
            this.BtnUpdateTelephoneNumber.Size = new System.Drawing.Size(178, 23);
            this.BtnUpdateTelephoneNumber.TabIndex = 8;
            this.BtnUpdateTelephoneNumber.Text = "Update Selected Phone Number";
            this.BtnUpdateTelephoneNumber.UseVisualStyleBackColor = true;
            this.BtnUpdateTelephoneNumber.Click += new System.EventHandler(this.BtnUpdateTelephoneNumber_Click);
            // 
            // FrmManagingPhoneNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 275);
            this.Controls.Add(this.BtnUpdateTelephoneNumber);
            this.Controls.Add(this.BtnUpdateCellphoneNumber);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnRemoveCellNumber);
            this.Controls.Add(this.btnRemoveTelNumber);
            this.Controls.Add(this.x);
            this.Controls.Add(this.dgvCellphoneNumbers);
            this.Controls.Add(this.lblTelephoneNumberList);
            this.Controls.Add(this.dgvTelephoneNumbers);
            this.Controls.Add(this.msManagePhoneNumbersControls);
            this.MainMenuStrip = this.msManagePhoneNumbersControls;
            this.Name = "FrmManagingPhoneNumbers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Managing < Business Name > Phone Numbers";
            this.Load += new System.EventHandler(this.FrmManagingPhoneNumbers_Load);
            this.msManagePhoneNumbersControls.ResumeLayout(false);
            this.msManagePhoneNumbersControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelephoneNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCellphoneNumbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msManagePhoneNumbersControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTelephoneNumbers;
        private System.Windows.Forms.Label lblTelephoneNumberList;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.DataGridView dgvCellphoneNumbers;
        private System.Windows.Forms.Button btnRemoveTelNumber;
        private System.Windows.Forms.Button btnRemoveCellNumber;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnUpdateCellphoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTelephoneNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCellphoneNumbers;
        private System.Windows.Forms.Button BtnUpdateTelephoneNumber;
    }
}