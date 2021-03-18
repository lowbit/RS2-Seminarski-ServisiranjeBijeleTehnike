using SBT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    public class ServisiServiserDetailViewModel: BaseViewModel
    {
        private readonly APIService _servisiService = new APIService("Servisi"); 
        public ServisiServiserDetailViewModel()
        {
        }
        public ServisiServiserDetailViewModel(int id)
        {
            InitCommand = new Command(async () => await Init(id));
            UpdateStanjeCommand = new Command(async () => await UpdateStanje());
        }
        ServisModel _servis = null;
        public ServisModel Servis {
            get { return _servis; }
            set
            {
                SetProperty(ref _servis, value);
                //ako hocu update nakon promjene stanja objekta
                //if (value != null)
                //{
                //    InitCommand.Execute(null);
                //}
            }
        }
        public ICommand InitCommand { get; set; }
        public ICommand UpdateStanjeCommand { get; set; }
        public async Task Init(int id)
        {
            var item = await _servisiService.GetById<ServisModel>(id);
            Servis = item;
        }
        async Task UpdateStanje()
        {
            await Application.Current.MainPage.DisplayAlert("Test", "Test", "OK");
        }
    }
}
