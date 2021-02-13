
namespace QuoteSwift
{
    partial class FrmEditEmailAddress
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.mtxtEmail = new System.Windows.Forms.MaskedTextBox();
            this.btnUpdateBusinessEmail = new System.Windows.Forms.Button();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.msEditEmailControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msEditEmailControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(9, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Location = new System.Drawing.Point(88, 37);
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(257, 20);
            this.mtxtEmail.TabIndex = 5;
            // 
            // btnUpdateBusinessEmail
            // 
            this.btnUpdateBusinessEmail.Location = new System.Drawing.Point(237, 69);
            this.btnUpdateBusinessEmail.Name = "btnUpdateBusinessEmail";
            this.btnUpdateBusinessEmail.Size = new System.Drawing.Size(108, 23);
            this.btnUpdateBusinessEmail.TabIndex = 6;
            this.btnUpdateBusinessEmail.Text = "Update Email";
            this.btnUpdateBusinessEmail.UseVisualStyleBackColor = true;
            this.btnUpdateBusinessEmail.Click += new System.EventHandler(this.BtnUpdateBusinessEmail_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(6, 40);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(76, 13);
            this.lblEmailAddress.TabIndex = 4;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // msEditEmailControls
            // 
            this.msEditEmailControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msEditEmailControls.Location = new System.Drawing.Point(0, 0);
            this.msEditEmailControls.Name = "msEditEmailControls";
            this.msEditEmailControls.Size = new System.Drawing.Size(357, 24);
            this.msEditEmailControls.TabIndex = 8;
            this.msEditEmailControls.Text = "menuStrip1";
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
            // 
            // FrmEditEmailAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 101);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.mtxtEmail);
            this.Controls.Add(this.btnUpdateBusinessEmail);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.msEditEmailControls);
            this.MainMenuStrip = this.msEditEmailControls;
            this.Name = "FrmEditEmailAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Email Address";
            this.Load += new System.EventHandler(this.FrmEditEmailAddress_Load);
            this.msEditEmailControls.ResumeLayout(false);
            this.msEditEmailControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox mtxtEmail;
        private System.Windows.Forms.Button btnUpdateBusinessEmail;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.MenuStrip msEditEmailControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}