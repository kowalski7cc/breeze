using Breeze.Library;
using Breeze.Models;
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

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace Breeze
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    /// 


    public sealed partial class UnitDetailPage : Page
    {
        public UnitDetailPage()
        {
            this.InitializeComponent();

            var test = new DaikinData()
            {
                Name = "Camera",
                PowerStatus = Library.Options.PowerStatus.On,
                Mode = Library.Options.Mode.Heat,
                Temperature = new Library.Options.Temperature
                {
                    Actual = 21
                }
            };

            var data = new DetailPageData()
            {
                DaikinData = test,
            };

            DataContext = data;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (true)
            {
                var t = (UnitDataView)e.Parameter;
                if (t != null)
                {
                    DataContext = t;
                }
            }
            
        }
    }    

}
