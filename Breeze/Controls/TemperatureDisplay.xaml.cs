using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Breeze.Controls
{
    public sealed partial class TemperatureDisplay : UserControl
    {
        public TemperatureDisplay()
        {
            this.InitializeComponent();
        }

        public int? TargetTemperature
        {
            get { return (int?)GetValue(TargetTemperatureProperty); }
            set { SetValue(TargetTemperatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetTemperature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetTemperatureProperty =
            DependencyProperty.Register("TargetTemperature", typeof(int?), typeof(TemperatureDisplay), new PropertyMetadata(null));



        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            if (TargetTemperature != null && (MinimumRange != null || TargetTemperature > MinimumRange))
            {
                TargetTemperature--;
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (TargetTemperature != null && (MaximumRange == null || TargetTemperature < MaximumRange))
            {
                TargetTemperature++;
            }
        }


        public int? MinimumRange
        {
            get { return (int?)GetValue(MinimumRangeProperty); }
            set { SetValue(MinimumRangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimumRange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumRangeProperty =
            DependencyProperty.Register("MinimumRange", typeof(int?), typeof(TemperatureDisplay), new PropertyMetadata(null));



        public int? MaximumRange
        {
            get { return (int?)GetValue(MaximumRangeProperty); }
            set { SetValue(MaximumRangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumRange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumRangeProperty =
            DependencyProperty.Register("MaximumRange", typeof(int?), typeof(TemperatureDisplay), new PropertyMetadata(null));


    }
}