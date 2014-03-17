using System;
using System.Globalization;
using System.Windows.Data;
using SportEasy.Model.Localization;

namespace SportEasy.WP8.Helper.Converter
{
    public class ParticipantStatusConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            int statusEnum = System.Convert.ToInt32(value.ToString());

            switch (statusEnum)
            {
                case 1:
                    return AppResources.string_Yes;
                case 2:
                    return AppResources.string_No;
                case 3:
                    return AppResources.string_Maybe;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}