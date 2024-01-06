
namespace QuoteSwift.Forms
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
            this.msManagePhoneNumbersControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msManagePhoneNumbersControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msManagePhoneNumbersControls.Location = new System.Drawing.Point(0, 0);
            this.msManagePhoneNumbersControls.Name = "msManagePhoneNumbersControls";
            this.msManagePhoneNumbersControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msManagePhoneNumbersControls.Size = new System.Drawing.Size(1161, 30);
            this.msManagePhoneNumbersControls.TabIndex = 0;
            this.msManagePhoneNumbersControls.Text = "msManagePhoneNumbersControls";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
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
            this.dgvTelephoneNumbers.Location = new System.Drawing.Point(18, 78);
            this.dgvTelephoneNumbers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTelephoneNumbers.Name = "dgvTelephoneNumbers";
            this.dgvTelephoneNumbers.Size = new System.Drawing.Size(525, 255);
            this.dgvTelephoneNumbers.TabIndex = 1;
            // 
            // clmTelephoneNumbers
            // 
            this.clmTelephoneNumbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTelephoneNumbers.HeaderText = "Telephone Numbers";
            this.clmTelephoneNumbers.Name = "clmTelephoneNumbers";
            this.clmTelephoneNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTelephoneNumbers.Width = 133;
            // 
            // lblTelephoneNumberList
            // 
            this.lblTelephoneNumberList.AutoSize = true;
            this.lblTelephoneNumberList.Location = new System.Drawing.Point(18, 55);
            this.lblTelephoneNumberList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelephoneNumberList.Name = "lblTelephoneNumberList";
            this.lblTelephoneNumberList.Size = new System.Drawing.Size(190, 18);
            this.lblTelephoneNumberList.TabIndex = 2;
            this.lblTelephoneNumberList.Text = "List of Telephone Numbers:";
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(604, 55);
            this.x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(187, 18);
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
            this.dgvCellphoneNumbers.Location = new System.Drawing.Point(609, 78);
            this.dgvCellphoneNumbers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCellphoneNumbers.Name = "dgvCellphoneNumbers";
            this.dgvCellphoneNumbers.Size = new System.Drawing.Size(525, 255);
            this.dgvCellphoneNumbers.TabIndex = 3;
            // 
            // ClmCellphoneNumbers
            // 
            this.ClmCellphoneNumbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClmCellphoneNumbers.HeaderText = "Cellphone Numbers";
            this.ClmCellphoneNumbers.Name = "ClmCellphoneNumbers";
            this.ClmCellphoneNumbers.ReadOnly = true;
            this.ClmCellphoneNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmCellphoneNumbers.Width = 131;
            // 
            // btnRemoveTelNumber
            // 
            this.btnRemoveTelNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveTelNumber.Location = new System.Drawing.Point(276, 341);
            this.btnRemoveTelNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveTelNumber.Name = "btnRemoveTelNumber";
            this.btnRemoveTelNumber.Size = new System.Drawing.Size(267, 32);
            this.btnRemoveTelNumber.TabIndex = 5;
            this.btnRemoveTelNumber.Text = "Remove Selected Phone Number";
            this.btnRemoveTelNumber.UseVisualStyleBackColor = true;
            this.btnRemoveTelNumber.Click += new System.EventHandler(this.BtnRemoveTelNumber_Click);
            // 
            // btnRemoveCellNumber
            // 
            this.btnRemoveCellNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveCellNumber.Location = new System.Drawing.Point(866, 341);
            this.btnRemoveCellNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveCellNumber.Name = "btnRemoveCellNumber";
            this.btnRemoveCellNumber.Size = new System.Drawing.Size(268, 32);
            this.btnRemoveCellNumber.TabIndex = 6;
            this.btnRemoveCellNumber.Text = "Remove Selected Phone Number";
            this.btnRemoveCellNumber.UseVisualStyleBackColor = true;
            this.btnRemoveCellNumber.Click += new System.EventHandler(this.BtnRemoveCellNumber_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 341);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpdateCellphoneNumber
            // 
            this.BtnUpdateCellphoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateCellphoneNumber.Location = new System.Drawing.Point(866, 37);
            this.BtnUpdateCellphoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpdateCellphoneNumber.Name = "BtnUpdateCellphoneNumber";
            this.BtnUpdateCellphoneNumber.Size = new System.Drawing.Size(268, 32);
            this.BtnUpdateCellphoneNumber.TabIndex = 6;
            this.BtnUpdateCellphoneNumber.Text = "Update Selected Phone Number";
            this.BtnUpdateCellphoneNumber.UseVisualStyleBackColor = true;
            this.BtnUpdateCellphoneNumber.Click += new System.EventHandler(this.BtnChangePhoneNumberInfo_Click);
            // 
            // BtnUpdateTelephoneNumber
            // 
            this.BtnUpdateTelephoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateTelephoneNumber.Location = new System.Drawing.Point(276, 37);
            this.BtnUpdateTelephoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpdateTelephoneNumber.Name = "BtnUpdateTelephoneNumber";
            this.BtnUpdateTelephoneNumber.Size = new System.Drawing.Size(267, 32);
            this.BtnUpdateTelephoneNumber.TabIndex = 8;
            this.BtnUpdateTelephoneNumber.Text = "Update Selected Phone Number";
            this.BtnUpdateTelephoneNumber.UseVisualStyleBackColor = true;
            this.BtnUpdateTelephoneNumber.Click += new System.EventHandler(this.BtnUpdateTelephoneNumber_Click);
            // 
            // FrmManagingPhoneNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 381);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msManagePhoneNumbersControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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