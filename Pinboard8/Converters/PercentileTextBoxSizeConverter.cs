using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using PinboardDomain.Model;
using PinboardDomain.Repository;
using PinboardDomain.ViewModels;

namespace Pinboard8.Converters
{
    public class PercentileTextBoxSizeConverter : DependencyObject, IValueConverter
    {
        public ObservableCollection<ITag> Tags
        {
            get { return (ObservableCollection<ITag>) GetValue(TagsList); }
            set { SetValue(TagsList, value); }
        }

        public static readonly DependencyProperty TagsList =
            DependencyProperty.Register("Tags",
                                typeof(List<Tag>),
                                typeof(PercentileTextBoxSizeConverter),
                                new PropertyMetadata(null));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var subjectCount = (int)value;

            if (Tags != null)
            {
                var orderedList = Tags.OrderByDescending(t => t.Count).ToList();
                var decileSize = Tags.Count/10;

                var indexOfSubject = orderedList.FindIndex(t => t.Count == subjectCount);

                var subjectPercentile = 10 - indexOfSubject/decileSize;

                return 12;// + subjectPercentile;
            }
            return 15;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
