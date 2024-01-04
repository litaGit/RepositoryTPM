using Acr.UserDialogs;
using CodigoBarrasDemo.Interfaces;
using CodigoBarrasDemo.Models;
using CodigoBarrasDemo.Services;
using CodigoBarrasDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CodigoBarrasDemo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public IAuthenticateService _authenticate = new AuthenticateService();


        public LoginViewModel()
        {
            
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Cargando...");
            AuthenticateResponseModel responseData = new AuthenticateResponseModel();
            AuthenticateRequestModel login = new AuthenticateRequestModel
            {
                userCode = User,
                password = Password
            };

           responseData = await _authenticate.Authenticate(login);

            if (responseData.isSucces)
            {
                Preferences.Set("isLogin", true);
                Preferences.Set("nameLogin", responseData.data.userCode + "-" + responseData.data.userName);
                Preferences.Set("userLogin", responseData.data.userCode);
                Application.Current.MainPage = new AppShell();
                UserDialogs.Instance.HideLoading();
                await Shell.Current.GoToAsync("//ItemsPage");

            }
            else 
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("", "Usuario o Contraseña incorrectos favor de verificar información", "Aceptar");
                Preferences.Set("isLogin", false);
            }
          
            
        }
    }
}
