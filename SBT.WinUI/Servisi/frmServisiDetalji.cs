using SBT.Model;
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
    public partial class frmServisiDetalji : Form
    {
        private int? _id = null;
        private readonly APIService _service = new APIService("Servisi");
        public frmServisiDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmServisiDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                ServisModel result = await _service.GetById<ServisModel>(_id);
                textBoxCijena.Text = result.Cijena.ToString();
                textBoxDatumServisa.Text = result.DatumServisa.ToString();
                textBoxKlijent.Text = result.KlijentIme;
                textBoxOcjena.Text = result.OcjenaServisa.ToString();
                textBoxServiser.Text = result.ServiserIme;
                textBoxStatus.Text = result.Status;
                textBoxTipDostave.Text = result.TipDostaveNaziv;
                textBoxTipPlacanja.Text = result.TipPlacanjaNaziv;
                textBoxUredjaj.Text = result.UredjajNaziv;
                richTextBoxOpis.Text = result.Opis;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = result.StanjeServisa;
            }
        }
    }
}
