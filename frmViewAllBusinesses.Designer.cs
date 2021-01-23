
namespace QuoteSwift
{
    partial class frmViewAllBusinesses
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddBusiness = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmBusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeInformation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRemoveBusiness = new System.Windows.Forms.Button();
            this.msViewAllBusinessesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewAllBusinessesControls
            // 
            this.msViewAllBusinessesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewAllBusinessesControls.Location = new System.Drawing.Point(0, 0);
            this.msViewAllBusinessesControls.Name = "msViewAllBusinessesControls";
            this.msViewAllBusinessesControls.Size = new System.Drawing.Size(412, 24);
            this.msViewAllBusinessesControls.TabIndex = 0;
            this.msViewAllBusinessesControls.Text = "msViewAllBusinessesControls";
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
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // btnAddBusiness
            // 
            this.btnAddBusiness.Location = new System.Drawing.Point(12, 27);
            this.btnAddBusiness.Name = "btnAddBusiness";
            this.btnAddBusiness.Size = new System.Drawing.Size(85, 23);
            this.btnAddBusiness.TabIndex = 1;
            this.btnAddBusiness.Text = "Add Business";
            this.btnAddBusiness.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmBusinessName,
            this.clmChangeInformation});
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(392, 200);
            this.dataGridView1.TabIndex = 2;
            // 
            // clmBusinessName
            // 
            this.clmBusinessName.HeaderText = "Business Name";
            this.clmBusinessName.Name = "clmBusinessName";
            this.clmBusinessName.ReadOnly = true;
            this.clmBusinessName.Width = 200;
            // 
            // clmChangeInformation
            // 
            this.clmChangeInformation.HeaderText = "";
            this.clmChangeInformation.Name = "clmChangeInformation";
            this.clmChangeInformation.ReadOnly = true;
            this.clmChangeInformation.Width = 150;
            // 
            // btnRemoveBusiness
            // 
            this.btnRemoveBusiness.Location = new System.Drawing.Point(303, 27);
            this.btnRemoveBusiness.Name = "btnRemoveBusiness";
            this.btnRemoveBusiness.Size = new System.Drawing.Size(101, 23);
            this.btnRemoveBusiness.TabIndex = 3;
            this.btnRemoveBusiness.Text = "Remove Business";
            this.btnRemoveBusiness.UseVisualStyleBackColor = true;
            this.btnRemoveBusiness.Click += new System.EventHandler(this.btnRemoveBusiness_Click);
            // 
            // frmViewAllBusinesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 264);
            this.Controls.Add(this.btnRemoveBusiness);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddBusiness);
            this.Controls.Add(this.msViewAllBusinessesControls);
            this.MainMenuStrip = this.msViewAllBusinessesControls;
            this.Name = "frmViewAllBusinesses";
            this.Text = "Viewing All Businesses";
            this.msViewAllBusinessesControls.ResumeLayout(false);
            this.msViewAllBusinessesControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewAllBusinessesControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnAddBusiness;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBusinessName;
        private System.Windows.Forms.DataGridViewButtonColumn clmChangeInformation;
        private System.Windows.Forms.Button btnRemoveBusiness;
    }
}