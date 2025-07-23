
namespace QuoteSwift.Views
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msEditEmailControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 81);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Location = new System.Drawing.Point(126, 39);
            this.mtxtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(384, 24);
            this.mtxtEmail.TabIndex = 0;
            // 
            // btnUpdateBusinessEmail
            // 
            this.btnUpdateBusinessEmail.Location = new System.Drawing.Point(348, 81);
            this.btnUpdateBusinessEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateBusinessEmail.Name = "btnUpdateBusinessEmail";
            this.btnUpdateBusinessEmail.Size = new System.Drawing.Size(162, 32);
            this.btnUpdateBusinessEmail.TabIndex = 1;
            this.btnUpdateBusinessEmail.Text = "Update Email";
            this.btnUpdateBusinessEmail.UseVisualStyleBackColor = true;
            this.btnUpdateBusinessEmail.Click += new System.EventHandler(this.BtnUpdateBusinessEmail_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(11, 42);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(107, 18);
            this.lblEmailAddress.TabIndex = 4;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // msEditEmailControls
            // 
            this.msEditEmailControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msEditEmailControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msEditEmailControls.Location = new System.Drawing.Point(0, 0);
            this.msEditEmailControls.Name = "msEditEmailControls";
            this.msEditEmailControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msEditEmailControls.Size = new System.Drawing.Size(536, 30);
            this.msEditEmailControls.TabIndex = 8;
            this.msEditEmailControls.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click_1);
            // 
            // FrmEditEmailAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 127);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.mtxtEmail);
            this.Controls.Add(this.btnUpdateBusinessEmail);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.msEditEmailControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msEditEmailControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}