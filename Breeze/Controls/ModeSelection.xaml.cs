using Breeze.Library.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class ModeSelection : UserControl
    {
        public ModeSelection()
        {
            this.InitializeComponent();
        }

        private void IconMode_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DaikinMode = Mode.Auto;
            Debug.WriteLine("Mode: " + DaikinMode);
        }

        private void IconMode_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            DaikinMode = Mode.Cool;
            Debug.WriteLine("Mode: " + DaikinMode);
        }

        private void IconMode_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            DaikinMode = Mode.Heat;
            Debug.WriteLine("Mode: " + DaikinMode);
        }

        private void IconMode_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            DaikinMode = Mode.Fan;
            Debug.WriteLine("Mode: " + DaikinMode);
        }

        private void IconMode_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            DaikinMode = Mode.Dry;
            Debug.WriteLine("Mode: " + DaikinMode);
        }


        public Mode DaikinMode
        {
            get { return (Mode)GetValue(DaikinModeProperty); }
            set { SetValue(DaikinModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaikinMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaikinModeProperty =
            DependencyProperty.Register("DaikinMode", typeof(Mode), typeof(ModeSelection), new PropertyMetadata(Mode.Auto));



    }
}
