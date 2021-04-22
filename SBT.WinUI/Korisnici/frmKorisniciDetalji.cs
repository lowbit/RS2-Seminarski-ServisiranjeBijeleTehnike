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

namespace SBT.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private int? _id = null;
        private readonly APIService _service = new APIService("Korisnici");
        KorisnikUpdateRequest request = new KorisnikUpdateRequest();
        Model.KorisniciModel korisnik;
        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            var uloge = await _service.Get<List<Model.UlogeModel>>("GetUlogeList");
            checkedListBoxRoles.DataSource = uloge;
            checkedListBoxRoles.DisplayMember = "Naziv";
            checkedListBoxRoles.ValueMember = "UlogaId";
            if (_id.HasValue)
            {
                textPassword.Enabled = false;
                textPasswordConfirm.Enabled = false;
                korisnik = await _service.GetById<Model.KorisniciModel>(_id);
                textKorisnickoIme.Text = korisnik.KorisnickoIme;
                textIme.Text = korisnik.Ime;
                textPrezime.Text = korisnik.Prezime;
                textEmail.Text = korisnik.Email;
                if (korisnik.KorisniciUloge != null)
                {
                    for (int count = 0; count < checkedListBoxRoles.Items.Count; count++)
                    {
                        foreach (var item in korisnik.KorisniciUloge)
                        {
                            if (item.UlogaId == checkedListBoxRoles.Items.Cast<Model.UlogeModel>().ToList()[count].UlogaId)
                            {
                                checkedListBoxRoles.SetItemChecked(count, true);
                            }
                        }
                    }
                }
                //Convert Byte Array to Image and display in PictureBox.
                if (korisnik.Slika != null && korisnik.Slika.Length>0)
                {
                    pictureBox1.Image = Image.FromStream(new MemoryStream(korisnik.Slika));
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var uloge = checkedListBoxRoles.CheckedItems.Cast<Model.UlogeModel>().Select(x=>x.UlogaId).ToList();

                Model.KorisnikModel entity = null;
                if (_id.HasValue)
                {
                    if (request.Slika == null && korisnik != null && korisnik.Slika != null)
                    {
                        request.Slika = korisnik.Slika;
                    }
                    request.KorisnickoIme = textKorisnickoIme.Text;
                    request.Ime = textIme.Text;
                    request.Prezime = textPrezime.Text;
                    request.Email = textEmail.Text;
                    request.Uloge = uloge;
                    entity = await _service.Update<Model.KorisnikModel>(request, _id.Value, "EditKorisnik");
                }
                else
                {
                    var requestInsert = new KorisniciInsertRequest
                    {
                        Email = textEmail.Text,
                        Ime = textIme.Text,
                        KorisnickoIme = textKorisnickoIme.Text,
                        Password = textPassword.Text,
                        PasswordPotvrda = textPasswordConfirm.Text,
                        Prezime = textPrezime.Text,
                        Uloge = uloge
                    };
                    if (request.Slika != null)
                    {
                        requestInsert.Slika = request.Slika;
                    }
                    entity = await _service.Insert<Model.KorisnikModel>(requestInsert);
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno izvrseno");
                    this.Close();
                }
            }
        }

        private void dodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;

            }
        }

        private void textPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textPasswordConfirm, null);
            if (textPassword.Text != textPasswordConfirm.Text && textPasswordConfirm.Enabled)
            {
                e.Cancel = true;
                errorProvider1.SetError(textPasswordConfirm, "Passwordi se ne poklapaju!");
            }
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textEmail, null);
            if (textEmail.Text.Length<5)
            {
                e.Cancel = true;
                errorProvider1.SetError(textEmail, "Email je prekratak");
            }
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textPassword, null);
            if (textPassword.Text.Length < 3 && textPassword.Enabled)
            {
                e.Cancel = true;
                errorProvider1.SetError(textPassword, "Password je prekratak");
            }
        }

        private void textKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textKorisnickoIme, null);
            if (textKorisnickoIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(textKorisnickoIme, "Korisnicko ime je prekratako");
            }
        }

        private void textIme_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textIme, null);
            if (textIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(textIme, "Ime je prekratako");
            }
        }

        private void textPrezime_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textPrezime, null);
            if (textPrezime.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(textPrezime, "Prezime je prekratako");
            }
        }
    }
}
