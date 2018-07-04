using Breeze.Library.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Breeze.Converters
{
    public class ModeToColorConverter : IValueConverter
    {

        private SolidColorBrush _Automatic = new SolidColorBrush(Windows.UI.Colors.ForestGreen);
        private SolidColorBrush _Cooling = new SolidColorBrush(Windows.UI.Colors.RoyalBlue);
        private SolidColorBrush _Heating = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
        private SolidColorBrush _Fan = new SolidColorBrush(Windows.UI.Colors.ForestGreen);
        private SolidColorBrush _Dry = new SolidColorBrush(Windows.UI.Colors.RoyalBlue);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case Mode.Auto:
                    return _Automatic;
                case Mode.Cool:
                    return _Cooling;
                case Mode.Heat:
                    return _Heating;
                case Mode.Fan:
                    return _Fan;
                case Mode.Dry:
                    return _Dry;

            }
            return new SolidColorBrush(Windows.UI.Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }
}
