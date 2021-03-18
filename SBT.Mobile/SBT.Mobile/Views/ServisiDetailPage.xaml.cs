using SBT.Mobile.ViewModels;
using SBT.Model;
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
    public partial class ServisiDetailPage : ContentPage
    {
        private ServisiDetailViewModel model = null;
        int ServisId;
        public ServisiDetailPage(int servisId)
        {
            InitializeComponent();
            ServisId = servisId;
            BindingContext = model = new ServisiDetailViewModel(servisId);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(ServisId);
        }
    }
}