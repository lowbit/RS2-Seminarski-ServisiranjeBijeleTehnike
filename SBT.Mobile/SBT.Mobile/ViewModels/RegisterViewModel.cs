using SBT.Mobile.Views;
using SBT.Model;
using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    class RegisterViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
            LoginCommand = new Command(() => Login());
        }
        public KorisniciInsertRequest request { get; set; } = new KorisniciInsertRequest();
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand{ get; set; }
        async Task Register()
        {
            IsBusy = true;
            try
            {
                if (request.KorisnickoIme == null || request.KorisnickoIme.Length < 4)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime prekratko", "Ok");
                }
                else if (request.Password == null || request.Password.Length < 4)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Password prekratak", "Ok");
                }
                else if (request.PasswordPotvrda == null || request.Password != request.PasswordPotvrda)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Password se ne poklapaju", "Ok");
                }
                else if (request.Email == null ||request.Email.Length < 6)
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
                    var returnObj = await _service.InsertNoAuth<Model.KorisnikModel>(request, "Register");
                    if (returnObj != null)
                    {
                        Application.Current.MainPage = new LoginPage();
                        await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste napravili korisnički račun", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "Ok");
            }
        }
        void Login()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
