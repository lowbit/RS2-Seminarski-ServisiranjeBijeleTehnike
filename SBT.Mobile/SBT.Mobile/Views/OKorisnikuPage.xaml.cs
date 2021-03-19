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
    public partial class OKorisnikuPage : ContentPage
    {
        private OKorisnikuViewModel model = null;
        public OKorisnikuPage()
        {
            InitializeComponent();
            BindingContext = model = new OKorisnikuViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}