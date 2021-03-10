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

namespace SBT.WinUI.Uredjaji
{
    public partial class frmUredjaji : Form
    {
        private readonly APIService _apiService = new APIService("uredjaji");
        List<Model.KategorijaModel> kategorije;
        public frmUredjaji()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvUredjaji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            dgvUredjaji.AutoGenerateColumns = false;
            var search = new SearchRequest()
            {
                Naziv = txtPretraga.Text,
                KategorijaId = int.Parse(listKategorija.SelectedValue.ToString()) != 0 ? listKategorija.SelectedValue.ToString() : null
            };
            var result = await _apiService.GetParam<List<Model.UredjajModel>>("GetUredjajiList", search);
            dgvUredjaji.DataSource = result;
        }

        private void frmUredjaji_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void dgvUredjaji_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvUredjaji.Rows[e.RowIndex].Cells[0].Value;
            frmUredjajiDetalji frm = new frmUredjajiDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {

        }

        private async void frmUredjaji_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
        }
        private async Task LoadKategorije()
        {
            var result = await _apiService.Get<List<Model.KategorijaModel>>("GetKategorijeList");
            result.Insert(0, new Model.KategorijaModel());
            listKategorija.DisplayMember = "Naziv";
            listKategorija.ValueMember = "KategorijaId";
            listKategorija.DataSource = result;
            kategorije = result;
        }
    }
}
