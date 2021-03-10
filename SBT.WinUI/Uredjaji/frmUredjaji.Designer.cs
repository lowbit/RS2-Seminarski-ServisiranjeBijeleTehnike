namespace SBT.WinUI.Uredjaji
{
    partial class frmUredjaji
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
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUredjaji = new System.Windows.Forms.DataGridView();
            this.uredjajId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KategorijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProizvodjacID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listKategorija = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUredjaji)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(695, 31);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(140, 33);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(549, 20);
            this.txtPretraga.TabIndex = 2;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUredjaji);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 370);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uređaji";
            // 
            // dgvUredjaji
            // 
            this.dgvUredjaji.AllowUserToAddRows = false;
            this.dgvUredjaji.AllowUserToDeleteRows = false;
            this.dgvUredjaji.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUredjaji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUredjaji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uredjajId,
            this.naziv,
            this.opis,
            this.KategorijaID,
            this.ProizvodjacID});
            this.dgvUredjaji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUredjaji.Location = new System.Drawing.Point(3, 16);
            this.dgvUredjaji.Name = "dgvUredjaji";
            this.dgvUredjaji.ReadOnly = true;
            this.dgvUredjaji.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUredjaji.Size = new System.Drawing.Size(770, 351);
            this.dgvUredjaji.TabIndex = 0;
            this.dgvUredjaji.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUredjaji_CellMouseDoubleClick);
            // 
            // uredjajId
            // 
            this.uredjajId.DataPropertyName = "UredjajId";
            this.uredjajId.HeaderText = "ID";
            this.uredjajId.Name = "uredjajId";
            this.uredjajId.ReadOnly = true;
            // 
            // naziv
            // 
            this.naziv.DataPropertyName = "Naziv";
            this.naziv.HeaderText = "Naziv";
            this.naziv.Name = "naziv";
            this.naziv.ReadOnly = true;
            // 
            // opis
            // 
            this.opis.DataPropertyName = "Opis";
            this.opis.HeaderText = "Opis";
            this.opis.Name = "opis";
            this.opis.ReadOnly = true;
            // 
            // KategorijaID
            // 
            this.KategorijaID.DataPropertyName = "KategorijaID";
            this.KategorijaID.HeaderText = "Kategorija ID";
            this.KategorijaID.Name = "KategorijaID";
            this.KategorijaID.ReadOnly = true;
            // 
            // ProizvodjacID
            // 
            this.ProizvodjacID.DataPropertyName = "ProizvodjacID";
            this.ProizvodjacID.HeaderText = "Proizvodjac ID";
            this.ProizvodjacID.Name = "ProizvodjacID";
            this.ProizvodjacID.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listKategorija);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPretraga);
            this.groupBox2.Controls.Add(this.btnPrikazi);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 59);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv";
            // 
            // listKategorija
            // 
            this.listKategorija.FormattingEnabled = true;
            this.listKategorija.Location = new System.Drawing.Point(6, 32);
            this.listKategorija.Name = "listKategorija";
            this.listKategorija.Size = new System.Drawing.Size(128, 21);
            this.listKategorija.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kategorija";
            // 
            // frmUredjaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUredjaji";
            this.Text = "frmUredjaji";
            this.Load += new System.EventHandler(this.frmUredjaji_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmUredjaji_MouseDoubleClick);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUredjaji)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUredjaji;
        private System.Windows.Forms.DataGridViewTextBoxColumn uredjajId;
        private System.Windows.Forms.DataGridViewTextBoxColumn naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProizvodjacID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listKategorija;
        private System.Windows.Forms.Label label2;
    }
}