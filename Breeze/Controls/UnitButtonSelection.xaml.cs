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
    public sealed partial class UnitButtonSelection : UserControl
    {
        public UnitButtonSelection()
        {
            this.InitializeComponent();
        }

        public String UnitName
        {
            get { return (String)GetValue(UnitNameProperty); }
            set { SetValue(UnitNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.Register("UnitName", typeof(String), typeof(UnitButtonSelection), new PropertyMetadata("Room unit"));

        public Mode DaikinMode
        {
            get { return (Mode)GetValue(DaikinModeProperty); }
            set { SetValue(DaikinModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaikinMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaikinModeProperty =
            DependencyProperty.Register("DaikinMode", typeof(Mode), typeof(UnitButtonSelection), new PropertyMetadata(Mode.Auto));

        public int ActualTemperature
        {
            get { return (int)GetValue(ActualTemperatureProperty); }
            set { SetValue(ActualTemperatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActualTemperature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActualTemperatureProperty =
            DependencyProperty.Register("ActualTemperature", typeof(int), typeof(UnitButtonSelection), new PropertyMetadata(0));



        public int TargetTemperature
        {
            get { return (int)GetValue(TargetTemperatureProperty); }
            set { SetValue(TargetTemperatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetTemperature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetTemperatureProperty =
            DependencyProperty.Register("TargetTemperature", typeof(int), typeof(UnitButtonSelection), new PropertyMetadata(0));

        public PowerStatus DaikinPower
        {
            get { return (PowerStatus)GetValue(DaikinPowerProperty); }
            set { SetValue(DaikinPowerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaikinPower.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaikinPowerProperty =
            DependencyProperty.Register("DaikinPower", typeof(PowerStatus), typeof(UnitButtonSelection), new PropertyMetadata(PowerStatus.Off));
    }
}
