using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Webshop_WPF.Repositories;
using Webshop_WPF.Views;

namespace Webshop_WPF.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); LoginCommand.NotifyCanExecuteChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); LoginCommand.NotifyCanExecuteChanged(); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        private FelhasznaloRepository repo;
        public RelayCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            repo = new FelhasznaloRepository();
            LoginCommand = new RelayCommand(() => Login(), () => CanLogin());
        }

        

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password);
        }
        private void Login()
        {
            ErrorMessage = repo.Authenticate(_username, _password);
            if (ErrorMessage == "Sikeres bejelentkezés")
            {
                var tv = new TermekekView();
                Application.Current.Windows[0].Close();
                //Új ablak megjelenítése
                tv.Show();
                
            }
        }


    }
}
