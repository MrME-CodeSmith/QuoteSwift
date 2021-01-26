
namespace QuoteSwift
{
    partial class FrmManageAllEmails
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
            this.msManageEmailAddressesControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmEmailAddresses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEmailAddtressesList = new System.Windows.Forms.Label();
            this.btnRemoveEmail = new System.Windows.Forms.Button();
            this.msManageEmailAddressesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // msManageEmailAddressesControls
            // 
            this.msManageEmailAddressesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msManageEmailAddressesControls.Location = new System.Drawing.Point(0, 0);
            this.msManageEmailAddressesControls.Name = "msManageEmailAddressesControls";
            this.msManageEmailAddressesControls.Size = new System.Drawing.Size(367, 24);
            this.msManageEmailAddressesControls.TabIndex = 0;
            this.msManageEmailAddressesControls.Text = "msManageEmailAddressesControls";
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
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmailAddresses});
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(343, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // clmEmailAddresses
            // 
            this.clmEmailAddresses.HeaderText = "Email Address";
            this.clmEmailAddresses.Name = "clmEmailAddresses";
            this.clmEmailAddresses.ReadOnly = true;
            this.clmEmailAddresses.Width = 300;
            // 
            // lblEmailAddtressesList
            // 
            this.lblEmailAddtressesList.AutoSize = true;
            this.lblEmailAddtressesList.Location = new System.Drawing.Point(12, 24);
            this.lblEmailAddtressesList.Name = "lblEmailAddtressesList";
            this.lblEmailAddtressesList.Size = new System.Drawing.Size(118, 13);
            this.lblEmailAddtressesList.TabIndex = 2;
            this.lblEmailAddtressesList.Text = "List of Email Addresses:";
            // 
            // btnRemoveEmail
            // 
            this.btnRemoveEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEmail.Location = new System.Drawing.Point(271, 196);
            this.btnRemoveEmail.Name = "btnRemoveEmail";
            this.btnRemoveEmail.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveEmail.TabIndex = 3;
            this.btnRemoveEmail.Text = "Remove Email";
            this.btnRemoveEmail.UseVisualStyleBackColor = true;
            // 
            // FrmManageAllEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 225);
            this.Controls.Add(this.btnRemoveEmail);
            this.Controls.Add(this.lblEmailAddtressesList);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.msManageEmailAddressesControls);
            this.MainMenuStrip = this.msManageEmailAddressesControls;
            this.Name = "FrmManageAllEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Managing < Business Name > Email Addresses";
            this.msManageEmailAddressesControls.ResumeLayout(false);
            this.msManageEmailAddressesControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msManageEmailAddressesControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmailAddresses;
        private System.Windows.Forms.Label lblEmailAddtressesList;
        private System.Windows.Forms.Button btnRemoveEmail;
    }
}