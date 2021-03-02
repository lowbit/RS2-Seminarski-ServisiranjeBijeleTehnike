namespace SBT.WinUI.Uredjaji
{
    partial class frmUredjajiDetalji
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
            this.textNaziv = new System.Windows.Forms.TextBox();
            this.textOpis = new System.Windows.Forms.TextBox();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.labelOpis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.listKategorija = new System.Windows.Forms.ComboBox();
            this.listProizvodjac = new System.Windows.Forms.ComboBox();
            this.dodajSliku = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textNaziv
            // 
            this.textNaziv.Location = new System.Drawing.Point(11, 103);
            this.textNaziv.Name = "textNaziv";
            this.textNaziv.Size = new System.Drawing.Size(303, 20);
            this.textNaziv.TabIndex = 0;
            this.textNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.textNaziv_Validating);
            // 
            // textOpis
            // 
            this.textOpis.Location = new System.Drawing.Point(11, 142);
            this.textOpis.Name = "textOpis";
            this.textOpis.Size = new System.Drawing.Size(303, 20);
            this.textOpis.TabIndex = 1;
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(12, 87);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(34, 13);
            this.labelNaziv.TabIndex = 4;
            this.labelNaziv.Text = "Naziv";
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(12, 126);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(28, 13);
            this.labelOpis.TabIndex = 5;
            this.labelOpis.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proizvođač";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Kategorija";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(239, 168);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 10;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // listKategorija
            // 
            this.listKategorija.FormattingEnabled = true;
            this.listKategorija.Location = new System.Drawing.Point(11, 25);
            this.listKategorija.Name = "listKategorija";
            this.listKategorija.Size = new System.Drawing.Size(303, 21);
            this.listKategorija.TabIndex = 11;
            this.listKategorija.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listProizvodjac
            // 
            this.listProizvodjac.FormattingEnabled = true;
            this.listProizvodjac.Location = new System.Drawing.Point(11, 64);
            this.listProizvodjac.Name = "listProizvodjac";
            this.listProizvodjac.Size = new System.Drawing.Size(303, 21);
            this.listProizvodjac.TabIndex = 12;
            // 
            // dodajSliku
            // 
            this.dodajSliku.Location = new System.Drawing.Point(454, 142);
            this.dodajSliku.Name = "dodajSliku";
            this.dodajSliku.Size = new System.Drawing.Size(75, 23);
            this.dodajSliku.TabIndex = 13;
            this.dodajSliku.Text = "Dodaj sliku";
            this.dodajSliku.UseVisualStyleBackColor = true;
            this.dodajSliku.Click += new System.EventHandler(this.dodajSliku_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(425, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // frmUredjajiDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(541, 200);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dodajSliku);
            this.Controls.Add(this.listProizvodjac);
            this.Controls.Add(this.listKategorija);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.textOpis);
            this.Controls.Add(this.textNaziv);
            this.Name = "frmUredjajiDetalji";
            this.Text = "frmUredjajiDetalji";
            this.Load += new System.EventHandler(this.frmUredjajiDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNaziv;
        private System.Windows.Forms.TextBox textOpis;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox listKategorija;
        private System.Windows.Forms.ComboBox listProizvodjac;
        private System.Windows.Forms.Button dodajSliku;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}