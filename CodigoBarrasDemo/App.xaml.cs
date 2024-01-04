using CodigoBarrasDemo.Services;
using CodigoBarrasDemo.Views;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodigoBarrasDemo
{
    public partial class App : Application
    {
        Boolean IsLogin = Preferences.Get("isLogin", false);

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataTasks>();
            DependencyService.Register<DataAlmacen>();

            if (IsLogin)
            {
                MainPage = new AppShell();
                Shell.Current.GoToAsync("//ItemsPage");

            }
            else
            {
                MainPage = new LoginPage();
                Preferences.Set("isLogin", false);
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
