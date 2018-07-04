using Breeze.Library.Options;
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
    public sealed partial class IconMode : UserControl
    {
        public IconMode()
        {
            this.InitializeComponent();
        }

        public Mode DaikinMode
        {
            get { return (Mode)GetValue(DaikinModeProperty); }
            set { SetValue(DaikinModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaikinMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaikinModeProperty =
            DependencyProperty.Register("DaikinMode", typeof(Mode), typeof(IconMode), new PropertyMetadata(Mode.Auto));





        public bool Colorized
        {
            get { return (bool)GetValue(ColorizedProperty); }
            set { SetValue(ColorizedProperty, value); }
        }

        public bool NotColorized
        {
            get { return (bool)GetValue(ColorizedProperty); }
            set { SetValue(ColorizedProperty, !value); }
        }

        // Using a DependencyProperty as the backing store for Colorized.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorizedProperty =
            DependencyProperty.Register("Colorized", typeof(bool), typeof(IconMode), new PropertyMetadata(false));


    }
}
