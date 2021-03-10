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

namespace SBT.WinUI.Servisi
{
    public partial class frmServisi : Form
    {
        private readonly APIService _apiService = new APIService("servisi");
        public frmServisi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            dgvServisi.AutoGenerateColumns = false;
            var search = new SearchRequestServis()
            {
                ImeServisera = txtImeServisera.Text,
                ImeKlijenta = txtImeKlijenta.Text,
                PrezimeKlijenta = txtPrezimeKlijenta.Text,
                EmailKlijenta = txtEmailKlijenta.Text,
                KoristiDatum = checkBox.Checked,
                DatumServisa = dateTimePicker1.Value
            };
            var result = await _apiService.GetParam<List<Model.ServisModel>>("GetServisiList", search);
            dgvServisi.DataSource = result;
        }

        private void frmServisi_Load(object sender, EventArgs e)
        {
        }
        private void dgvServisi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvServisi.Rows[e.RowIndex].Cells[0].Value;
            frmServisiDetalji frm = new frmServisiDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
