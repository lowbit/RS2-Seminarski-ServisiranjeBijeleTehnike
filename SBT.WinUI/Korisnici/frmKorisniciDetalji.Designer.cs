
namespace SBT.WinUI.Korisnici
{
    partial class frmKorisniciDetalji
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dodajSliku = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.textKorisnickoIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrezime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxRoles = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textPasswordConfirm = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(414, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // dodajSliku
            // 
            this.dodajSliku.Location = new System.Drawing.Point(443, 136);
            this.dodajSliku.Name = "dodajSliku";
            this.dodajSliku.Size = new System.Drawing.Size(75, 23);
            this.dodajSliku.TabIndex = 18;
            this.dodajSliku.Text = "Dodaj sliku";
            this.dodajSliku.UseVisualStyleBackColor = true;
            this.dodajSliku.Click += new System.EventHandler(this.dodajSliku_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(240, 398);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 17;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(13, 16);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(75, 13);
            this.labelNaziv.TabIndex = 16;
            this.labelNaziv.Text = "Korisničko ime";
            // 
            // textKorisnickoIme
            // 
            this.textKorisnickoIme.Location = new System.Drawing.Point(12, 32);
            this.textKorisnickoIme.Name = "textKorisnickoIme";
            this.textKorisnickoIme.Size = new System.Drawing.Size(303, 20);
            this.textKorisnickoIme.TabIndex = 15;
            this.textKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.textKorisnickoIme_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ime";
            // 
            // textIme
            // 
            this.textIme.Location = new System.Drawing.Point(12, 75);
            this.textIme.Name = "textIme";
            this.textIme.Size = new System.Drawing.Size(303, 20);
            this.textIme.TabIndex = 20;
            this.textIme.Validating += new System.ComponentModel.CancelEventHandler(this.textIme_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Prezime";
            // 
            // textPrezime
            // 
            this.textPrezime.Location = new System.Drawing.Point(12, 118);
            this.textPrezime.Name = "textPrezime";
            this.textPrezime.Size = new System.Drawing.Size(303, 20);
            this.textPrezime.TabIndex = 22;
            this.textPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.textPrezime_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Email";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(12, 160);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(303, 20);
            this.textEmail.TabIndex = 24;
            this.textEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Role";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // checkedListBoxRoles
            // 
            this.checkedListBoxRoles.FormattingEnabled = true;
            this.checkedListBoxRoles.Location = new System.Drawing.Point(12, 298);
            this.checkedListBoxRoles.Name = "checkedListBoxRoles";
            this.checkedListBoxRoles.Size = new System.Drawing.Size(303, 94);
            this.checkedListBoxRoles.TabIndex = 27;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Password";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(12, 203);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(303, 20);
            this.textPassword.TabIndex = 28;
            this.textPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textPassword_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Confirm Password";
            // 
            // textPasswordConfirm
            // 
            this.textPasswordConfirm.Location = new System.Drawing.Point(12, 244);
            this.textPasswordConfirm.Name = "textPasswordConfirm";
            this.textPasswordConfirm.PasswordChar = '*';
            this.textPasswordConfirm.Size = new System.Drawing.Size(303, 20);
            this.textPasswordConfirm.TabIndex = 30;
            this.textPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.textPasswordConfirm_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmKorisniciDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(530, 455);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textPasswordConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.checkedListBoxRoles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPrezime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textIme);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dodajSliku);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.textKorisnickoIme);
            this.Name = "frmKorisniciDetalji";
            this.Text = "frmKorisniciDetalji";
            this.Load += new System.EventHandler(this.frmKorisniciDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dodajSliku;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.TextBox textKorisnickoIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrezime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBoxRoles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPasswordConfirm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}