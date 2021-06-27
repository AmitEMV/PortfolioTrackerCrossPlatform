using System;
using Windows.UI.Xaml.Data;

namespace PortfolioTracker.Converters
{
    public class CurrencyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return string.Format(new System.Globalization.CultureInfo("en-IN"),"{0:C2}", value);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
