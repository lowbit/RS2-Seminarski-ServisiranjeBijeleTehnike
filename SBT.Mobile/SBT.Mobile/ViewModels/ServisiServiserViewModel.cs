using SBT.Model;
using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    public class ServisiServiserViewModel : BaseViewModel
    {
        private readonly APIService _servisiService = new APIService("Servisi");
        public ServisiServiserViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ServisModel> ServisiList { get; set; } = new ObservableCollection<ServisModel>();
        public ObservableCollection<StatusServisaModel> VrsteStatusaList { get; set; } = new ObservableCollection<StatusServisaModel>();
        StatusServisaModel _selectedVrstaStatusa = null;
        public StatusServisaModel SelectedVrstaStatusa
        {
            get { return _selectedVrstaStatusa; }
            set
            {
                SetProperty(ref _selectedVrstaStatusa, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            SearchMobileServiceRequest req = new SearchMobileServiceRequest();
            req.KorisnikId = APIService.KorisnikId;
            if (SelectedVrstaStatusa != null)
            {
                req.VrstaStatusaId = SelectedVrstaStatusa.StatusServisaId;
            }
            var list = await _servisiService.GetParam<IEnumerable<ServisModel>>("GetServisiByUser", req);
            if (VrsteStatusaList.Count < 1)
            {
                var listaStatusa = await _servisiService.Get<IEnumerable<StatusServisaModel>>("GetVrsteStatusa");
                VrsteStatusaList.Clear();
                VrsteStatusaList.Add(new StatusServisaModel { StatusServisaId = 0, Naziv = "(SVE)"});
                foreach (var item in listaStatusa)
                {
                    VrsteStatusaList.Add(item);
                }
            }
            ServisiList.Clear();
            foreach (var item in list)
            {
                ServisiList.Add(item);
            }
            
        }
    }
}