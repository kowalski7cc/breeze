using Breeze.Library.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Breeze.Converters
{
    class PowerStatusToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return PowerStatus.On.Equals(value) ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool) value ? PowerStatus.On : PowerStatus.Off;
        }
    }
}
