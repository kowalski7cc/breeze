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
    class PowerToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            SolidColorBrush _Off = new SolidColorBrush(Windows.UI.Colors.Gray);
            SolidColorBrush _On = new SolidColorBrush(Windows.UI.Colors.ForestGreen);

            switch (value)
            {
                case PowerStatus.On:
                    return _On;
                case PowerStatus.Off:
                default:
                    return _Off;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
