using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SportEasy.ViewModel;
using SportEasy.WP8.Helper;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace SportEasy.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Variable declaration

        private readonly MainViewModel _mainViewModel;

        #endregion

        #region Constructor

        public MainPage()
        {
            StaticValues.Dispatcher = Dispatcher;

            InitializeComponent();

            _mainViewModel = (MainViewModel) DataContext;
        }

        #endregion

        #region Page event handdler

        private void SeletectTeamOnTap(object sender, GestureEventArgs e)
        {
            _mainViewModel.SelectTeamCommand.Execute(null);   
        }

        #endregion
    }
}