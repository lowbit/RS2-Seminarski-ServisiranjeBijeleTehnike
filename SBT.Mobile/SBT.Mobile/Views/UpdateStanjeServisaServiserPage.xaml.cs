using SBT.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateStanjeServisaServiserPage : ContentPage
    {
        private UpdateStanjeServisaServiserViewModel model = null;
        int _id;
        public UpdateStanjeServisaServiserPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new UpdateStanjeServisaServiserViewModel(id);
            _id = id;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_id);
        }
    }
}