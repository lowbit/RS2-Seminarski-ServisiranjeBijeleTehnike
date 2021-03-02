using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBT.WinUI.Uredjaji
{
    public partial class frmUredjajiDetalji : Form
    {
        private int? _id = null;
        private readonly APIService _service = new APIService("Uredjaji");
        Model.UredjajModel request = new Model.UredjajModel();
        public frmUredjajiDetalji(int? uredjajId = null)
        {
            InitializeComponent();
            _id = uredjajId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void frmUredjajiDetalji_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
            await LoadProizvodjace();

            if (_id.HasValue)
            {
                var uredjaj = await _service.GetById<Model.UredjajModel>(_id);
                listKategorija.SelectedText = uredjaj.KategorijaId.ToString();
                listProizvodjac.SelectedText = uredjaj.ProizvodjacId.ToString();
                textNaziv.Text = uredjaj.Naziv;
                textOpis.Text = uredjaj.Opis;
                //Convert Byte Array to Image and display in PictureBox.
                if (uredjaj.Slika != null)
                {
                    pictureBox1.Image = Image.FromStream(new MemoryStream(uredjaj.Slika));
                }
            }
        }
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                request.KategorijaId = int.Parse(listKategorija.Text);
                request.Naziv = textNaziv.Text;
                request.Opis = textOpis.Text;
                request.ProizvodjacId = int.Parse(listProizvodjac.Text);

                Model.UredjajModel entity = null;
                if (_id.HasValue)
                {
                    entity = await _service.Update<Model.UredjajModel>(request, _id.Value, "EditUredjaj");
                }
                else
                {
                    entity = await _service.Insert<Model.UredjajModel>(request, "AddUredjaj");
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno izvrseno");
                }
            }
        }

        private void textNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textNaziv, "Obavezno polje");
            } else
            {
                errorProvider.SetError(textNaziv, null);
            }
        }


        private void textKategorija_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task LoadKategorije()
        {
            var result = await _service.Get<List<Model.KategorijaModel>>("GetKategorijeList");
            result.Insert(0, new Model.KategorijaModel());
            listKategorija.DisplayMember = "Naziv";
            listKategorija.ValueMember = "KategorijaId";
            listKategorija.DataSource = result;
        }
        private async Task LoadProizvodjace()
        {
            var result = await _service.Get<List<Model.ProizvodjacModel>>("GetProizvodjaciList");
            result.Insert(0, new Model.ProizvodjacModel());
            listProizvodjac.DisplayMember = "Naziv";
            listProizvodjac.ValueMember = "ProizvodjacId";
            listProizvodjac.DataSource = result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;

            }
        }
    }
}
