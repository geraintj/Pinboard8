using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Pinboard10.Converters
{
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int widthAdjustment = int.Parse(parameter.ToString());

            return Window.Current.Bounds.Width - widthAdjustment;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
