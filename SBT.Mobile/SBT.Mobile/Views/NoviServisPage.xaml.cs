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
    public partial class NoviServisPage : ContentPage
    {
        private NoviServisViewModel model = null;
        int _id;
        public NoviServisPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new NoviServisViewModel(id);
            _id = id;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_id);
        }
    }
}