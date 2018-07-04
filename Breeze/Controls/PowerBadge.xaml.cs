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
    public sealed partial class PowerBadge : UserControl
    {
        public PowerBadge()
        {
            this.InitializeComponent();
        }



        public PowerStatus DaikinPower
        {
            get { return (PowerStatus)GetValue(DaikinPowerProperty); }
            set { SetValue(DaikinPowerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaikinPower.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaikinPowerProperty =
            DependencyProperty.Register("DaikinPower", typeof(PowerStatus), typeof(PowerBadge), new PropertyMetadata(PowerStatus.Off));



    }

}
