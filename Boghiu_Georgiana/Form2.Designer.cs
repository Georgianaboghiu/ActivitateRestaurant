namespace Boghiu_Georgiana
{
    partial class Form2
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
            this.rezervareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notaDePlataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateAngajatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meniuriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rezervareToolStripMenuItem,
            this.notaDePlataToolStripMenuItem,
            this.dateAngajatiToolStripMenuItem,
            this.meniuriToolStripMenuItem,
            this.produseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rezervareToolStripMenuItem
            // 
            this.rezervareToolStripMenuItem.Name = "rezervareToolStripMenuItem";
            this.rezervareToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.rezervareToolStripMenuItem.Text = "Rezervare";
            this.rezervareToolStripMenuItem.Click += new System.EventHandler(this.rezervareToolStripMenuItem_Click);
            // 
            // notaDePlataToolStripMenuItem
            // 
            this.notaDePlataToolStripMenuItem.Name = "notaDePlataToolStripMenuItem";
            this.notaDePlataToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.notaDePlataToolStripMenuItem.Text = "Nota de plata";
            this.notaDePlataToolStripMenuItem.Click += new System.EventHandler(this.notaDePlataToolStripMenuItem_Click);
            // 
            // dateAngajatiToolStripMenuItem
            // 
            this.dateAngajatiToolStripMenuItem.Name = "dateAngajatiToolStripMenuItem";
            this.dateAngajatiToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.dateAngajatiToolStripMenuItem.Text = "Date Angajati";
            this.dateAngajatiToolStripMenuItem.Click += new System.EventHandler(this.dateAngajatiToolStripMenuItem_Click);
            // 
            // meniuriToolStripMenuItem
            // 
            this.meniuriToolStripMenuItem.Name = "meniuriToolStripMenuItem";
            this.meniuriToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.meniuriToolStripMenuItem.Text = "Meniuri";
            this.meniuriToolStripMenuItem.Click += new System.EventHandler(this.meniuriToolStripMenuItem_Click);
            // 
            // produseToolStripMenuItem
            // 
            this.produseToolStripMenuItem.Name = "produseToolStripMenuItem";
            this.produseToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.produseToolStripMenuItem.Text = "Produse";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Boghiu_Georgiana.Properties.Resources.imagine6;
            this.ClientSize = new System.Drawing.Size(1300, 741);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rezervareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notaDePlataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateAngajatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meniuriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produseToolStripMenuItem;
    }
}