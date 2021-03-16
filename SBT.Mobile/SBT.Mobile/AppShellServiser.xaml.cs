using SBT.Mobile.ViewModels;
using SBT.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SBT.Mobile
{
    public partial class AppShellServiser : Xamarin.Forms.Shell
    {
        public AppShellServiser()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
