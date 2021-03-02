namespace SBT.WinUI
{
    partial class frmIndex
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uređajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviUređajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaKategorijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviProizvođačToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.uređajiToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1059, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            // 
            // uređajiToolStripMenuItem
            // 
            this.uređajiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviUređajToolStripMenuItem,
            this.novaKategorijaToolStripMenuItem,
            this.noviProizvođačToolStripMenuItem});
            this.uređajiToolStripMenuItem.Name = "uređajiToolStripMenuItem";
            this.uređajiToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.uređajiToolStripMenuItem.Text = "Uređaji";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // noviUređajToolStripMenuItem
            // 
            this.noviUređajToolStripMenuItem.Name = "noviUređajToolStripMenuItem";
            this.noviUređajToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noviUređajToolStripMenuItem.Text = "Novi uređaj";
            this.noviUređajToolStripMenuItem.Click += new System.EventHandler(this.noviUređajToolStripMenuItem_Click);
            // 
            // novaKategorijaToolStripMenuItem
            // 
            this.novaKategorijaToolStripMenuItem.Name = "novaKategorijaToolStripMenuItem";
            this.novaKategorijaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novaKategorijaToolStripMenuItem.Text = "Nova kategorija";
            this.novaKategorijaToolStripMenuItem.Click += new System.EventHandler(this.novaKategorijaToolStripMenuItem_Click);
            // 
            // noviProizvođačToolStripMenuItem
            // 
            this.noviProizvođačToolStripMenuItem.Name = "noviProizvođačToolStripMenuItem";
            this.noviProizvođačToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noviProizvođačToolStripMenuItem.Text = "Novi proizvođač";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 526);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1059, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 548);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uređajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviUređajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaKategorijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviProizvođačToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
    }
}



