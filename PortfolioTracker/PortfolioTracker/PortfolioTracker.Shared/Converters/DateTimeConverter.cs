using System;
using Windows.UI.Xaml.Data;

namespace PortfolioTracker.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //if ((DateTime)value == DateTime.MinValue)
            //    return new DateTimeOffset(DateTime.Now);

            var date = (DateTime)value;
            return new DateTimeOffset(date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var offset = (DateTimeOffset)value;
            return offset.DateTime;
        }
    }
}
