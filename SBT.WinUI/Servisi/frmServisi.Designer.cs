
namespace SBT.WinUI.Servisi
{
    partial class frmServisi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailKlijenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrezimeKlijenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImeKlijenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImeServisera = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvServisi = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.servisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumServisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocjenaServisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uredjaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipPlacanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipDostave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmailKlijenta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPrezimeKlijenta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtImeKlijenta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtImeServisera);
            this.groupBox1.Controls.Add(this.btnPrikazi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(955, 58);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Email klijenta";
            // 
            // txtEmailKlijenta
            // 
            this.txtEmailKlijenta.Location = new System.Drawing.Point(484, 32);
            this.txtEmailKlijenta.Name = "txtEmailKlijenta";
            this.txtEmailKlijenta.Size = new System.Drawing.Size(160, 20);
            this.txtEmailKlijenta.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Prezime klijenta";
            // 
            // txtPrezimeKlijenta
            // 
            this.txtPrezimeKlijenta.Location = new System.Drawing.Point(328, 32);
            this.txtPrezimeKlijenta.Name = "txtPrezimeKlijenta";
            this.txtPrezimeKlijenta.Size = new System.Drawing.Size(150, 20);
            this.txtPrezimeKlijenta.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ime klijenta";
            // 
            // txtImeKlijenta
            // 
            this.txtImeKlijenta.Location = new System.Drawing.Point(161, 32);
            this.txtImeKlijenta.Name = "txtImeKlijenta";
            this.txtImeKlijenta.Size = new System.Drawing.Size(161, 20);
            this.txtImeKlijenta.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ime servisera";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtImeServisera
            // 
            this.txtImeServisera.Location = new System.Drawing.Point(9, 32);
            this.txtImeServisera.Name = "txtImeServisera";
            this.txtImeServisera.Size = new System.Drawing.Size(146, 20);
            this.txtImeServisera.TabIndex = 3;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(874, 30);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 4;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvServisi);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 370);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servisi";
            // 
            // dgvServisi
            // 
            this.dgvServisi.AllowUserToAddRows = false;
            this.dgvServisi.AllowUserToDeleteRows = false;
            this.dgvServisi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServisi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servisId,
            this.opis,
            this.datumServisa,
            this.cijena,
            this.status,
            this.ocjenaServisa,
            this.serviser,
            this.klijent,
            this.uredjaj,
            this.tipPlacanja,
            this.tipDostave});
            this.dgvServisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServisi.Location = new System.Drawing.Point(3, 16);
            this.dgvServisi.Name = "dgvServisi";
            this.dgvServisi.ReadOnly = true;
            this.dgvServisi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServisi.Size = new System.Drawing.Size(952, 351);
            this.dgvServisi.TabIndex = 0;
            this.dgvServisi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServisi_CellMouseDoubleClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(683, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(659, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Datum servisa";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(662, 35);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(15, 14);
            this.checkBox.TabIndex = 16;
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // servisId
            // 
            this.servisId.DataPropertyName = "ServisId";
            this.servisId.FillWeight = 20F;
            this.servisId.HeaderText = "ID";
            this.servisId.Name = "servisId";
            this.servisId.ReadOnly = true;
            this.servisId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // opis
            // 
            this.opis.DataPropertyName = "Opis";
            this.opis.FillWeight = 87.66498F;
            this.opis.HeaderText = "Opis";
            this.opis.Name = "opis";
            this.opis.ReadOnly = true;
            // 
            // datumServisa
            // 
            this.datumServisa.DataPropertyName = "DatumServisa";
            this.datumServisa.FillWeight = 87.66498F;
            this.datumServisa.HeaderText = "Datum Servisa";
            this.datumServisa.Name = "datumServisa";
            this.datumServisa.ReadOnly = true;
            // 
            // cijena
            // 
            this.cijena.DataPropertyName = "Cijena";
            this.cijena.FillWeight = 50F;
            this.cijena.HeaderText = "Cijena";
            this.cijena.Name = "cijena";
            this.cijena.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.FillWeight = 87.66498F;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // ocjenaServisa
            // 
            this.ocjenaServisa.DataPropertyName = "OcjenaServisa";
            this.ocjenaServisa.FillWeight = 40F;
            this.ocjenaServisa.HeaderText = "Ocjena";
            this.ocjenaServisa.Name = "ocjenaServisa";
            this.ocjenaServisa.ReadOnly = true;
            // 
            // serviser
            // 
            this.serviser.DataPropertyName = "ServiserIme";
            this.serviser.FillWeight = 87.66498F;
            this.serviser.HeaderText = "Serviser";
            this.serviser.Name = "serviser";
            this.serviser.ReadOnly = true;
            // 
            // klijent
            // 
            this.klijent.DataPropertyName = "KlijentIme";
            this.klijent.FillWeight = 87.66498F;
            this.klijent.HeaderText = "Klijent";
            this.klijent.Name = "klijent";
            this.klijent.ReadOnly = true;
            // 
            // uredjaj
            // 
            this.uredjaj.DataPropertyName = "UredjajNaziv";
            this.uredjaj.FillWeight = 87.66498F;
            this.uredjaj.HeaderText = "Uredjaj";
            this.uredjaj.Name = "uredjaj";
            this.uredjaj.ReadOnly = true;
            // 
            // tipPlacanja
            // 
            this.tipPlacanja.DataPropertyName = "TipPlacanjaNaziv";
            this.tipPlacanja.FillWeight = 87.66498F;
            this.tipPlacanja.HeaderText = "Tip Placanja";
            this.tipPlacanja.Name = "tipPlacanja";
            this.tipPlacanja.ReadOnly = true;
            // 
            // tipDostave
            // 
            this.tipDostave.DataPropertyName = "TipDostaveNaziv";
            this.tipDostave.FillWeight = 87.66498F;
            this.tipDostave.HeaderText = "Tip Dostave";
            this.tipDostave.Name = "tipDostave";
            this.tipDostave.ReadOnly = true;
            // 
            // frmServisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServisi";
            this.Text = "frmServisi";
            this.Load += new System.EventHandler(this.frmServisi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmailKlijenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrezimeKlijenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImeKlijenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImeServisera;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvServisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn servisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumServisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocjenaServisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviser;
        private System.Windows.Forms.DataGridViewTextBoxColumn klijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn uredjaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipPlacanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipDostave;
    }
}