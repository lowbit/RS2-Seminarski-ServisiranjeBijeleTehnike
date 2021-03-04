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
        UredjajModelRequest request = new UredjajModelRequest();
        List<Model.KategorijaModel> kategorije;
        List<Model.ProizvodjacModel> proizvodjaci;
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
                listKategorija.SelectedValue = uredjaj.KategorijaId;
                listProizvodjac.SelectedValue = uredjaj.ProizvodjacId;
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
            errorProvider.SetError(listKategorija, null);
            errorProvider.SetError(listProizvodjac, null);
            if (int.Parse(listKategorija.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(listKategorija, "Izaberite kategoriju");
            }
            if (int.Parse(listProizvodjac.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(listProizvodjac, "Izaberite proizvodjaca");
            }
            if (this.ValidateChildren() && int.Parse(listKategorija.SelectedValue.ToString()) != 0 && int.Parse(listProizvodjac.SelectedValue.ToString()) != 0)
            {

                request.KategorijaId = int.Parse(listKategorija.SelectedValue.ToString());
                request.ProizvodjacId = int.Parse(listProizvodjac.SelectedValue.ToString());
                request.Naziv = textNaziv.Text;
                request.Opis = textOpis.Text;

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
                    if (!_id.HasValue)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void textNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (textNaziv.Text.Length<3)
            {
                e.Cancel = true;
                errorProvider.SetError(textNaziv, "Naziv mora biti veci");
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
            kategorije = result;
        }
        private async Task LoadProizvodjace()
        {
            var result = await _service.Get<List<Model.ProizvodjacModel>>("GetProizvodjaciList");
            result.Insert(0, new Model.ProizvodjacModel());
            listProizvodjac.DisplayMember = "Naziv";
            listProizvodjac.ValueMember = "ProizvodjacId";
            listProizvodjac.DataSource = result;
            proizvodjaci = result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            errorProvider.SetError(listKategorija, null);
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

        private void listProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(listProizvodjac, null);
        }
    }
}
