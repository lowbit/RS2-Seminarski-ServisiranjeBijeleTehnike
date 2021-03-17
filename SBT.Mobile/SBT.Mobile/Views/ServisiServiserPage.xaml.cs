using SBT.Mobile.ViewModels;
using SBT.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServisiServiserPage : ContentPage
    {
        private ServisiServiserViewModel model = null;

        public ServisiServiserPage()
        {
            InitializeComponent();
            BindingContext = model = new ServisiServiserViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ServisModel;

            await Navigation.PushAsync(new ServisiServiserDetailPage(item.ServisId));
        }
    }
}
