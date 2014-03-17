using System;
using System.Globalization;
using System.Windows.Data;
using SportEasy.Model.Localization;

namespace SportEasy.WP8.Helper.Converter
{
    public class FreeToggleSwitchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if ((bool) value)
                return AppResources.string_Yes;

            return AppResources.string_No;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}