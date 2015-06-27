using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using PinboardDomain.Model;

namespace Pinboard8.Converters
{
    public class StringConcatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var tagCollection = value as List<Tag>;
            var stringCollection = tagCollection.Select(t => t.Name).ToList();
            var result = stringCollection.Aggregate((a, b) => a + " " + b);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
