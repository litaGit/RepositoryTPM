using CodigoBarrasDemo.ViewModels;
using CodigoBarrasDemo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CodigoBarrasDemo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QualityPage), typeof(QualityViewModel));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Set("isLogin", false);
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
