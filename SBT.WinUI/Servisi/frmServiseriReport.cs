using Microsoft.Reporting.WinForms;
using SBT.Model;
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
    public partial class frmServiseriReport : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _servisiService = new APIService("Servisi");
        public frmServiseriReport()
        {
            InitializeComponent();
        }

        private async void frmServiseriReport_Load(object sender, EventArgs e)
        {
            await LoadServiseri();
        }
        private async Task LoadServiseri()
        {
            var result = await _korisniciService.Get<List<Model.KorisniciModel>>("GetServiseriList");
            result.Insert(0, new Model.KorisniciModel());
            listServiseri.DisplayMember = "Ime";
            listServiseri.ValueMember = "Ime";
            listServiseri.DataSource = result;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(listServiseri, null);
            if (listServiseri.SelectedValue == null)
            {
                errorProvider1.SetError(listServiseri, "Izaberi servisera");
            }
            else
            {
                KorisniciModel selectedItem = (KorisniciModel)listServiseri.SelectedItem;
                var search = new SearchRequestServis()
                {
                    ImeServisera = selectedItem.Ime,
                    KoristiDatum = checkBox.Checked,
                    DatumServisa = dateTimePicker1.Value
                };
                var servisi = await _servisiService.GetParam<List<Model.ServisModel>>("GetServisiList", search);
                ReportDataSource rds = new ReportDataSource("DataSet1", servisi);
                this.reportViewer1.LocalReport.DataSources[0] = rds;
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
