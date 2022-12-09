using Acr.UserDialogs;
using App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

        #region Properties
        private string user = string.Empty;
        public string User
        {
            get => user;
            set { 
                SetProperty(ref user, value);
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
            }
        }

        private bool rememberme;
        public bool RememberMe
        {
            get => rememberme;
            set
            {
                SetProperty(ref rememberme, value);
            }
        }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            CancelCommand = new Command(OnCancelClicked);
        }

        private void OnCancelClicked(object obj)
        {

        }

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrEmpty(User) || string.IsNullOrWhiteSpace(User))
            {
                await UserDialogs.Instance.AlertAsync("Por favor digite un Usuario.");
                return;
            }

            if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                await UserDialogs.Instance.AlertAsync("Por favor digite una Contraseña.");
                return;
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
