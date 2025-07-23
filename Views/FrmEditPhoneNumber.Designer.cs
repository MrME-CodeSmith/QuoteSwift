
namespace QuoteSwift.Views
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.msEditPhoneNumberControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(18, 102);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(102, 32);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdateNumber
            // 
            this.btnUpdateNumber.Location = new System.Drawing.Point(222, 102);
            this.btnUpdateNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateNumber.Name = "btnUpdateNumber";
            this.btnUpdateNumber.Size = new System.Drawing.Size(140, 32);
            this.btnUpdateNumber.TabIndex = 1;
            this.btnUpdateNumber.Text = "Update Number";
            this.btnUpdateNumber.UseVisualStyleBackColor = true;
            this.btnUpdateNumber.Click += new System.EventHandler(this.BtnUpdateNumber_Click);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(14, 44);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(112, 18);
            this.lblPhoneNumber.TabIndex = 5;
            this.lblPhoneNumber.Text = "Phone Number:";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msEditPhoneNumberControls
            // 
            this.msEditPhoneNumberControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msEditPhoneNumberControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msEditPhoneNumberControls.Location = new System.Drawing.Point(0, 0);
            this.msEditPhoneNumberControls.Name = "msEditPhoneNumberControls";
            this.msEditPhoneNumberControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msEditPhoneNumberControls.Size = new System.Drawing.Size(380, 30);
            this.msEditPhoneNumberControls.TabIndex = 8;
            this.msEditPhoneNumberControls.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(18, 66);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(342, 24);
            this.txtPhoneNumber.TabIndex = 0;
            // 
            // FrmEditPhoneNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 154);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnUpdateNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.msEditPhoneNumberControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msEditPhoneNumberControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPhoneNumber;
    }
}