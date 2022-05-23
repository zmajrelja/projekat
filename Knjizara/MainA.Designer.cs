
namespace Knjizara
{
    partial class MainA
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.knjigeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promeniKnjiguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knjigeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // knjigeToolStripMenuItem
            // 
            this.knjigeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promeniKnjiguToolStripMenuItem,
            this.stanjeToolStripMenuItem});
            this.knjigeToolStripMenuItem.Name = "knjigeToolStripMenuItem";
            this.knjigeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.knjigeToolStripMenuItem.Text = "knjige";
            // 
            // promeniKnjiguToolStripMenuItem
            // 
            this.promeniKnjiguToolStripMenuItem.Name = "promeniKnjiguToolStripMenuItem";
            this.promeniKnjiguToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.promeniKnjiguToolStripMenuItem.Text = "dodaj knjigu";
            this.promeniKnjiguToolStripMenuItem.Click += new System.EventHandler(this.promeniKnjiguToolStripMenuItem_Click);
            // 
            // stanjeToolStripMenuItem
            // 
            this.stanjeToolStripMenuItem.Name = "stanjeToolStripMenuItem";
            this.stanjeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stanjeToolStripMenuItem.Text = "stanje";
            this.stanjeToolStripMenuItem.Click += new System.EventHandler(this.stanjeToolStripMenuItem_Click);
            // 
            // MainA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainA";
            this.Text = "MainA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem knjigeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promeniKnjiguToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stanjeToolStripMenuItem;
    }
}