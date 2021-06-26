using System;
using Windows.UI.Xaml.Data;

namespace PortfolioTracker.Converters
{
    public class ReturnConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return string.Format("{0}%", value);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
