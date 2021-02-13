
namespace QuoteSwift
{
    partial class FrmEditPhoneNumber
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnUpdateNumber = new System.Windows.Forms.Button();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.msEditPhoneNumberControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.msEditPhoneNumberControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 74);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnUpdateNumber
            // 
            this.btnUpdateNumber.Location = new System.Drawing.Point(148, 74);
            this.btnUpdateNumber.Name = "btnUpdateNumber";
            this.btnUpdateNumber.Size = new System.Drawing.Size(93, 23);
            this.btnUpdateNumber.TabIndex = 6;
            this.btnUpdateNumber.Text = "Update Number";
            this.btnUpdateNumber.UseVisualStyleBackColor = true;
            this.btnUpdateNumber.Click += new System.EventHandler(this.BtnUpdateNumber_Click);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(9, 32);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 5;
            this.lblPhoneNumber.Text = "Phone Number:";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msEditPhoneNumberControls
            // 
            this.msEditPhoneNumberControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msEditPhoneNumberControls.Location = new System.Drawing.Point(0, 0);
            this.msEditPhoneNumberControls.Name = "msEditPhoneNumberControls";
            this.msEditPhoneNumberControls.Size = new System.Drawing.Size(253, 24);
            this.msEditPhoneNumberControls.TabIndex = 8;
            this.msEditPhoneNumberControls.Text = "menuStrip1";
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
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(12, 48);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(229, 20);
            this.txtPhoneNumber.TabIndex = 9;
            // 
            // FrmEditPhoneNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 111);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnUpdateNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.msEditPhoneNumberControls);
            this.MainMenuStrip = this.msEditPhoneNumberControls;
            this.Name = "FrmEditPhoneNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Phone Number";
            this.Load += new System.EventHandler(this.FrmEditPhoneNumber_Load);
            this.msEditPhoneNumberControls.ResumeLayout(false);
            this.msEditPhoneNumberControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnUpdateNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.MenuStrip msEditPhoneNumberControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPhoneNumber;
    }
}