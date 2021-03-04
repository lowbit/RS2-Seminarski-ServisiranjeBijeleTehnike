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
                Naziv = txtPretraga.Text
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
    }
}
