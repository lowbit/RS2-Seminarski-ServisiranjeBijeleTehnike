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
    public class NoviServisViewModel:BaseViewModel
    {
        private readonly APIService _servisiService = new APIService("Servisi");
        private readonly APIService _uredjajiService = new APIService("Uredjaji");
        public NoviServisViewModel()
        {

        }
        public NoviServisViewModel(int id)
        {
            InitCommand = new Command(async() => await Init(id));
            DodajServisCommand = new Command(async () => await DodajServis());
        }
        public int KlijentId { get; set; } = 0;
        public ICommand InitCommand { get; set; }
        public ICommand DodajServisCommand { get; set; }
        public ServisInsertRequest request { get; set; } = new ServisInsertRequest();
        public ObservableCollection<KategorijaModel> KategorijeList { get; set; } = new ObservableCollection<KategorijaModel>();
        KategorijaModel _selectedKategorijaModel = null;
        public KategorijaModel SelectedKategorijaModel
        {
            get
            {
                return _selectedKategorijaModel;
            }
            set
            {
                SetProperty(ref _selectedKategorijaModel, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }
        public ObservableCollection<UredjajModel> UredjajiList { get; set; } = new ObservableCollection<UredjajModel>();
        UredjajModel _selectedUredjajModel = null;
        public UredjajModel SelectedUredjajModel
        {
            get
            {
                return _selectedUredjajModel;
            }
            set
            {
                SetProperty(ref _selectedUredjajModel, value);
            }
        }
        public ObservableCollection<TipPlacanjaModel> TipoviPlacanjaList { get; set; } = new ObservableCollection<TipPlacanjaModel>();
        TipPlacanjaModel _selectedTipPlacanjaModel = null;
        public TipPlacanjaModel SelectedTipPlacanjaModel
        {
            get
            {
                return _selectedTipPlacanjaModel;
            }
            set
            {
                SetProperty(ref _selectedTipPlacanjaModel, value);
            }
        }
        public ObservableCollection<TipDostaveModel> TipoviDostaveList { get; set; } = new ObservableCollection<TipDostaveModel>();
        TipDostaveModel _selectedTipDostaveModel = null;
        public TipDostaveModel SelectedTipDostaveModel
        {
            get
            {
                return _selectedTipDostaveModel;
            }
            set
            {
                SetProperty(ref _selectedTipDostaveModel, value);
            }
        }
        public async Task Init(int id)
        {
            KlijentId = id;

            if (request.Opis == null)
                request.Opis = "";
            if (KategorijeList.Count < 1)
            {
                var kategorijeList = await _uredjajiService.Get<IEnumerable<KategorijaModel>>("GetKategorijeListNotEmpty");
                KategorijeList.Clear();
                foreach (var item in kategorijeList)
                {
                    KategorijeList.Add(item);
                }
            }
            if (TipoviDostaveList.Count < 1)
            {
                var list = await _servisiService.Get<IEnumerable<TipDostaveModel>>("GetTipoveDostave");
                TipoviDostaveList.Clear();
                foreach (var item in list)
                {
                    TipoviDostaveList.Add(item);
                }
            }
            if (TipoviPlacanjaList.Count < 1)
            {
                var list = await _servisiService.Get<IEnumerable<TipPlacanjaModel>>("GetTipovePlacanja");
                TipoviPlacanjaList.Clear();
                foreach (var item in list)
                {
                    TipoviPlacanjaList.Add(item);
                }
            }
            if (KategorijeList.Count > 0 && SelectedKategorijaModel != null && SelectedKategorijaModel.KategorijaId > 0)
            {
                var list = await _uredjajiService.GetParam<IEnumerable<UredjajModel>>("GetUredjajiByKategorijaList", _selectedKategorijaModel.KategorijaId);
                UredjajiList.Clear();
                foreach (var item in list)
                {
                    UredjajiList.Add(item);
                }
            }
        }
        public async Task DodajServis()
        {
            if (request.Opis.Length < 6)
                await Application.Current.MainPage.DisplayAlert("Greška", "Opis prekratak", "Ok");
            else if (SelectedKategorijaModel == null)
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate izabrati kategoriju", "Ok");
            else if (SelectedUredjajModel == null)
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate izabrati model", "Ok");
            else if (SelectedTipDostaveModel == null)
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate izabrati tip dostave", "Ok");
            else if (SelectedTipPlacanjaModel == null)
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate izabrati tip placanja", "Ok");
            else
            {
                request.KlijentId = KlijentId;
                request.DatumServisa = DateTime.Now;
                request.UredjajId = SelectedUredjajModel.UredjajId;
                request.TipDostaveId = SelectedTipDostaveModel.TipDostaveId;
                request.TipPlacanjaId = SelectedTipPlacanjaModel.TipPlacanjaId;
                var returnObj = await _servisiService.Insert<ServisInsertRequest>(request, "AddServis");
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste dodali servis", "Ok");
            }
        }
    }
}
