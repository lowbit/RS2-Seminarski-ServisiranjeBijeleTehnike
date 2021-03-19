using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    public class OKorisnikuViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");
        public OKorisnikuViewModel()
        {
            InitCommand = new Command(async () => await Init());
            UpdateCommand = new Command(async () => await Update());
        }
        KorisnikUpdateRequest _request = null;
        public KorisnikUpdateRequest request {
            get
            {
                return _request;
            }
            set
            {
                SetProperty(ref _request, value);
            }
        }
        public ICommand InitCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public async Task Init()
        {
            var korisnikModel = await _service.GetById<Model.KorisniciModel>(APIService.KorisnikId);
            KorisnikUpdateRequest req = new KorisnikUpdateRequest();
            req.Email = korisnikModel.Email;
            req.Ime = korisnikModel.Ime;
            req.KorisnickoIme = korisnikModel.KorisnickoIme;
            req.Prezime = korisnikModel.Prezime;
            req.Slika = korisnikModel.Slika;
            request = req;
        }
        public async Task Update()
        {
            IsBusy = true;
            try
            {
                if (request.Email == null || request.Email.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Email nije validan", "Ok");
                }
                else if (request.Ime == null || request.Ime.Length < 3)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Ime prekratko", "Ok");
                }
                else if (request.Prezime == null || request.Prezime.Length < 3)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Prezime prekratko", "Ok");
                }
                else
                {
                    var returnObj = await _service.Update<Model.KorisnikModel>(request, APIService.KorisnikId, "EditKorisnik"); 
                    if (returnObj != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste updateali korisnički račun", "Ok");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
