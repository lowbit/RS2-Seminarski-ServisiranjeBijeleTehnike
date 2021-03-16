using SBT.Mobile.Views;
using SBT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    class LoginViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(() => Register());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand{ get; set; }
        public ICommand RegisterCommand { get; set; }
        async Task Login()
        {
            IsBusy = true;
            bool userIsServiser = false;
            bool userIsKorisnik = false;

            try
            {
                KorisniciModel korisnik = await _service.Authenticate<KorisniciModel>(Username, Password);
                if (korisnik != null)
                {
                    foreach (var item in korisnik.KorisniciUloge)
                    {
                        if (item.Uloga.Naziv == "serviser")
                        {
                            userIsServiser = true;
                            APIService.Username = Username;
                            APIService.Password = Password;
                            APIService.KorisnikId = item.KorisnikId;
                        } else if(item.Uloga.Naziv == "korisnik")
                        {
                            userIsKorisnik = true;
                            APIService.Username = Username;
                            APIService.Password = Password;
                        }
                    }
                    if (userIsServiser)
                    {
                        Application.Current.MainPage = new AppShellServiser();
                    }
                    else if (userIsKorisnik)
                    {
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", "Korisnik mora biti pod Serviser ili Korisnik rolom", "OK");
                    }
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešan Username ili Password", "OK");
                }
            }
            catch
            {

            }
        }
        void Register()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
