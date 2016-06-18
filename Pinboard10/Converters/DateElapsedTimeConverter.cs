using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Pinboard10.Converters
{
    public class DateElapsedTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var inputDate = new DateTime();
            DateTime.TryParseExact(value.ToString(), "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out inputDate);

            var timeElapsed = DateTime.Now.Subtract(inputDate);

            if (timeElapsed.TotalDays < 1)
            {
                if (timeElapsed.TotalHours < 1)
                {
                    if (timeElapsed.TotalMinutes < 1)
                    {
                        return "Recent";
                    }

                    return timeElapsed.Minutes.ToString() + " minutes ago";
                }

                return timeElapsed.Hours.ToString() + " hours ago";
            }

            if (timeElapsed.TotalDays >= 1 && timeElapsed.TotalDays < 2)
            {
                return "yesterday";
            }
            
            if (timeElapsed.TotalDays > 1 && timeElapsed.TotalDays < 7)
            {
                return timeElapsed.Days + " days ago";
            }
            
            if (timeElapsed.TotalDays >= 7 && timeElapsed.TotalDays < 15)
            {
                return "Last week";
            }

            if (timeElapsed.TotalDays >= 15 && timeElapsed.TotalDays < 22)
            {
                return "Two weeks ago";
            }

            if (timeElapsed.TotalDays >= 22 && timeElapsed.TotalDays < 29)
            {
                return "Three weeks ago";
            }

            if (timeElapsed.TotalDays >= 29 && timeElapsed.TotalDays < 366)
            {
                var monthsAgo = ((int) (timeElapsed.TotalDays/30));

                if (monthsAgo > 1)
                {
                    return monthsAgo.ToString() + " months ago";
                }
                else
                {
                    return "One month ago";
                }
            }

            if (timeElapsed.TotalDays >= 366)
            {
                var yearsAgo = ((int) (timeElapsed.TotalDays/365));


                if (yearsAgo > 1)
                {
                    return yearsAgo.ToString() + " years ago";
                }
                else
                {
                    return "One year ago";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
