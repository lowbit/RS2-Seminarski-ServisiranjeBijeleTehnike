using SBT.Model;
using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    public class UpdateStanjeServisaViewModel : BaseViewModel
    {
        private readonly APIService _servisiService = new APIService("Servisi");
        public ObservableCollection<StatusServisaModel> VrsteStatusaList { get; set; } = new ObservableCollection<StatusServisaModel>();
        StatusServisaModel _selectedStatusServisaModel = null;
        StanjeServisaInsertRequest StanjeServisaModel = new StanjeServisaInsertRequest();
        public string Napomena { get; set; } = "";
        public double Cijena { get; set; } = 0;
        public int Ocijena { get; set; } = 0;
        public int ServisId { get; set; } = 0;
        bool _prikaziCijena = false;
        public bool PrikaziCijena
        {
            get
            {
                return _prikaziCijena;
            }
            set
            {
                SetProperty(ref _prikaziCijena, value);
            }
        }
        public StatusServisaModel SelectedStatusServisaModel
        {
            get
            {
                return _selectedStatusServisaModel;
            }
            set
            {
                SetProperty(ref _selectedStatusServisaModel, value);
                if(value != null)
                {
                    if (value.Naziv == "Servis zavrsen")
                        PrikaziCijena = true;
                    else
                        PrikaziCijena = false;
                }
            }
        }
        public UpdateStanjeServisaViewModel()
        {

        }
        public UpdateStanjeServisaViewModel(int id)
        {
            InitCommand = new Command(async () => await Init(id));
            UpdateStatusCommand = new Command(async () => await UpdateStatus());
        }
        public ICommand InitCommand { get; set; }
        public ICommand UpdateStatusCommand { get; set; }
        public async Task Init(int id)
        {
            ServisId = id;
            if (VrsteStatusaList.Count < 1)
            {
                var vrstaServisa = await _servisiService.Get<IEnumerable<StatusServisaModel>>("GetVrsteStatusa");
                VrsteStatusaList.Clear();
                foreach (var item in vrstaServisa)
                {
                    VrsteStatusaList.Add(item);
                }
            }
        }
        public async Task UpdateStatus()
        {

            if (Napomena.Length < 6)
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesite Napomenu, trenutna napomena je prekratka", "Ok");
            else if (Ocijena < 0 || Ocijena > 5)
                await Application.Current.MainPage.DisplayAlert("Greška", "Ocijena moze biti od 1-5", "Ok");
            else
            {
                StanjeServisaModel.TrenutniStatus = "Cekanje na odgovor servisera";
                StanjeServisaModel.Napomena = Napomena;
                StanjeServisaModel.Azurirano = DateTime.Now;
                StanjeServisaModel.ServisId = ServisId;
                StanjeServisaModel.Ocijena = Ocijena;
                await _servisiService.Insert<StanjeServisaInsertRequest>(StanjeServisaModel, "StanjeServisaAdd");
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno se updateali status", "Ok");
            }
        }
    }
}
