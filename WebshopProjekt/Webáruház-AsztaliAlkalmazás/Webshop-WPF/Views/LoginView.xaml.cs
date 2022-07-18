using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Webshop_WPF.ViewModels;

namespace Webshop_WPF.Views
{
   
    public partial class LoginView : Window
    {
        private LoginViewModel loginViewModel;
        public LoginView()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginViewModel.Password = password.Password;
        }
    }
}
