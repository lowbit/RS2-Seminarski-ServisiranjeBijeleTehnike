using SBT.Model;
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

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _servisiService.GetParam<IEnumerable<ServisModel>>("GetServisiByUser", APIService.KorisnikId);
            foreach (var item in list)
            {
                ServisiList.Add(item);
            }
        }
    }
}