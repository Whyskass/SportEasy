using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SportEasy.ViewModel.Pages;

namespace SportEasy.WP8.Helper.Converter
{
    public class LoginViewVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            if ((LoginViewEnum) value == LoginViewEnum.Home && parameter.ToString() == "Home")
                return Visibility.Visible;

            if ((LoginViewEnum)value == LoginViewEnum.Login && parameter.ToString() == "Login")
                return Visibility.Visible;

            if ((LoginViewEnum)value == LoginViewEnum.Register && parameter.ToString() == "Register")
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}