
namespace QuoteSwift
{
    partial class frmManagingPhoneNumbers
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTelephoneNumbers = new System.Windows.Forms.DataGridView();
            this.clmTelephoneNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTelephoneNumberList = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.Label();
            this.dgvCellphoneNumbers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveTelNumber = new System.Windows.Forms.Button();
            this.btnRemoveCellNumber = new System.Windows.Forms.Button();
            this.msManagePhoneNumbersControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelephoneNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCellphoneNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // msManagePhoneNumbersControls
            // 
            this.msManagePhoneNumbersControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msManagePhoneNumbersControls.Location = new System.Drawing.Point(0, 0);
            this.msManagePhoneNumbersControls.Name = "msManagePhoneNumbersControls";
            this.msManagePhoneNumbersControls.Size = new System.Drawing.Size(559, 24);
            this.msManagePhoneNumbersControls.TabIndex = 0;
            this.msManagePhoneNumbersControls.Text = "msManagePhoneNumbersControls";
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
            // dgvTelephoneNumbers
            // 
            this.dgvTelephoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelephoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTelephoneNumbers});
            this.dgvTelephoneNumbers.Location = new System.Drawing.Point(12, 50);
            this.dgvTelephoneNumbers.Name = "dgvTelephoneNumbers";
            this.dgvTelephoneNumbers.Size = new System.Drawing.Size(243, 150);
            this.dgvTelephoneNumbers.TabIndex = 1;
            // 
            // clmTelephoneNumbers
            // 
            this.clmTelephoneNumbers.HeaderText = "Telephone Numbers";
            this.clmTelephoneNumbers.Name = "clmTelephoneNumbers";
            this.clmTelephoneNumbers.ReadOnly = true;
            this.clmTelephoneNumbers.Width = 200;
            // 
            // lblTelephoneNumberList
            // 
            this.lblTelephoneNumberList.AutoSize = true;
            this.lblTelephoneNumberList.Location = new System.Drawing.Point(9, 34);
            this.lblTelephoneNumberList.Name = "lblTelephoneNumberList";
            this.lblTelephoneNumberList.Size = new System.Drawing.Size(137, 13);
            this.lblTelephoneNumberList.TabIndex = 2;
            this.lblTelephoneNumberList.Text = "List of Telephone Numbers:";
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(300, 34);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(133, 13);
            this.x.TabIndex = 4;
            this.x.Text = "List of Cellphone Numbers:";
            // 
            // dgvCellphoneNumbers
            // 
            this.dgvCellphoneNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCellphoneNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvCellphoneNumbers.Location = new System.Drawing.Point(303, 50);
            this.dgvCellphoneNumbers.Name = "dgvCellphoneNumbers";
            this.dgvCellphoneNumbers.Size = new System.Drawing.Size(243, 150);
            this.dgvCellphoneNumbers.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Cellphone Numbers";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // btnRemoveTelNumber
            // 
            this.btnRemoveTelNumber.Location = new System.Drawing.Point(158, 206);
            this.btnRemoveTelNumber.Name = "btnRemoveTelNumber";
            this.btnRemoveTelNumber.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveTelNumber.TabIndex = 5;
            this.btnRemoveTelNumber.Text = "Remove Number";
            this.btnRemoveTelNumber.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCellNumber
            // 
            this.btnRemoveCellNumber.Location = new System.Drawing.Point(449, 206);
            this.btnRemoveCellNumber.Name = "btnRemoveCellNumber";
            this.btnRemoveCellNumber.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveCellNumber.TabIndex = 6;
            this.btnRemoveCellNumber.Text = "Remove Number";
            this.btnRemoveCellNumber.UseVisualStyleBackColor = true;
            // 
            // frmManagingPhoneNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 237);
            this.Controls.Add(this.btnRemoveCellNumber);
            this.Controls.Add(this.btnRemoveTelNumber);
            this.Controls.Add(this.x);
            this.Controls.Add(this.dgvCellphoneNumbers);
            this.Controls.Add(this.lblTelephoneNumberList);
            this.Controls.Add(this.dgvTelephoneNumbers);
            this.Controls.Add(this.msManagePhoneNumbersControls);
            this.MainMenuStrip = this.msManagePhoneNumbersControls;
            this.Name = "frmManagingPhoneNumbers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Managing < Business Name > Phone Numbers";
            this.msManagePhoneNumbersControls.ResumeLayout(false);
            this.msManagePhoneNumbersControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelephoneNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCellphoneNumbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msManagePhoneNumbersControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTelephoneNumbers;
        private System.Windows.Forms.Label lblTelephoneNumberList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTelephoneNumbers;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.DataGridView dgvCellphoneNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnRemoveTelNumber;
        private System.Windows.Forms.Button btnRemoveCellNumber;
    }
}