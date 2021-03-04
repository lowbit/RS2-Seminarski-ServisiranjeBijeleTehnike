using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBT.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _apiService = new APIService("korisnici");
        public frmKorisnici()
        {
            InitializeComponent();
        }

        private void dgvUredjaji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {

            dgvKorisnici.AutoGenerateColumns = false;
            var search = new SearchRequest()
            {
                Naziv = txtPretraga.Text,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Email = txtEmail.Text
            };
            var result = await _apiService.GetParam<List<Model.KorisnikModel>>("GetKorisniciList", search);
            dgvKorisnici.DataSource = result;
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvKorisnici_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvKorisnici.Rows[e.RowIndex].Cells[0].Value;
            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
