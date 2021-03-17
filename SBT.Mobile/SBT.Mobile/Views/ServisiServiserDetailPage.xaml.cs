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
    public partial class ServisiServiserDetailPage : ContentPage
    {
        private ServisiServiserDetailViewModel model = null;
        int ServisId;
        public ServisiServiserDetailPage(int servisId)
        {
            InitializeComponent();
            ServisId = servisId;
            BindingContext = model = new ServisiServiserDetailViewModel(servisId);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(ServisId);
        }
    }
}