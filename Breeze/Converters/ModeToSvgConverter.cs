using Breeze.Library.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Breeze.Converters
{


    class ModeToSvgConverter : IValueConverter
    {

        public bool ColorizedIcon { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String name = null;
            switch (value)
            {
                case Mode.Auto:
                    name = ColorizedIcon ? "Automatic_Selected" : "Automatic";
                    break;
                case Mode.Cool:
                    name = ColorizedIcon ? "Cool_Selected" : "Cool";
                    break;
                case Mode.Dry:
                    name = ColorizedIcon ? "Dry_Selected" : "Dry";
                    break;
                case Mode.Fan:
                    name = ColorizedIcon ? "Fan_Selected" : "Fan";
                    break;
                case Mode.Heat:
                    name = ColorizedIcon ? "Heat_Selected" : "Heat";
                    break;
            }
            Debug.WriteLine("Convert mode: " + value);
            string sourceString = "ms-appx:///Assets/Modes/" + name + ".svg";
            Debug.WriteLine(sourceString);
            SvgImageSource source = new SvgImageSource(new Uri(sourceString));
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
