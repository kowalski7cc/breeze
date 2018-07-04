using Breeze.Library.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Breeze.Converters
{
    class SelectedModeBoolConverter : IValueConverter
    {
        SolidColorBrush _Selected = new SolidColorBrush(Windows.UI.Colors.ForestGreen);
        SolidColorBrush _Unselected = new SolidColorBrush(Windows.UI.Colors.Transparent);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return DaikinMode.Equals(value);
        }

        public Mode DaikinMode { get; set; }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
