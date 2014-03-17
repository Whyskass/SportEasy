using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SportEasy.ViewModel.Pages;
using SportEasy.WP8.Helper;

namespace SportEasy.WP8.Pages
{
    public partial class Login : PhoneApplicationPage
    {
        #region Variable declaration

        private readonly LoginViewModel _loginViewModel;

        #endregion

        #region Constructor

        public Login()
        {
            StaticValues.Dispatcher = Dispatcher;

            InitializeComponent();
            this.BackKeyPress += Login_BackKeyPress;
            _loginViewModel = (LoginViewModel) DataContext;
        }

        #endregion

        #region Page event handler

        void Login_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_loginViewModel.LoginView != LoginViewEnum.Home)
            {
                e.Cancel = true;
                _loginViewModel.LoginView = LoginViewEnum.Home;
            }
        }

        #endregion
    }
}