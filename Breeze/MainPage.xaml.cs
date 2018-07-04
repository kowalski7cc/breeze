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
using Breeze.Library;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Breeze.Models;


// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace Breeze
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Daikin[] hosts = new Daikin[]
        {
            new Daikin("192.168.0.152"),
            new Daikin("192.168.0.156"),
            new Daikin("192.168.0.132")
        };

        public MainPage()
        {
            this.InitializeComponent();

            var a = new DaikinData[]
            {
                new DaikinData()
                {
                    Name = "Office",
                    PowerStatus = Library.Options.PowerStatus.On,
                    Mode = Library.Options.Mode.Heat,
                    Temperature = new Library.Options.Temperature()
                    {
                        Actual = 21,
                        Target = 23,
                        Outside = 15
                    }
                },
                new DaikinData()
                {
                    Name = "Livingroom",
                    PowerStatus = Library.Options.PowerStatus.Off,
                    Mode = Library.Options.Mode.Auto,
                    Temperature = new Library.Options.Temperature()
                    {
                        Actual = 22,
                        Target = 22,
                        Outside = 15
                    }
                },
                new DaikinData()
                {
                    Name = "Bedroom",
                    PowerStatus = Library.Options.PowerStatus.Off,
                    Mode = Library.Options.Mode.Fan,
                    Temperature = new Library.Options.Temperature()
                    {
                        Actual = 20,
                        Target = null,
                        Outside = 15
                    }
                },
                new DaikinData()
                {
                    Name = "Kitchen",
                    PowerStatus = Library.Options.PowerStatus.Off,
                    Mode = Library.Options.Mode.Cool,
                    Temperature = new Library.Options.Temperature()
                    {
                        Actual = 24,
                        Target = 22,
                        Outside = 15
                    }
                },
                new DaikinData()
                {
                    Name = "Whatever",
                    PowerStatus = Library.Options.PowerStatus.Off,
                    Mode = Library.Options.Mode.Dry,
                    Temperature = new Library.Options.Temperature()
                    {
                        Actual = 20,
                        Target = null,
                        Outside = 15
                    }
                },
            };

            var data = new UnitDataView()
            {
                RetrivedData = a,
            };

            DataContext = data;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (((UnitDataView)DataContext).RetrivedData.Length > 0)
            {
                AddUnitHint.Visibility = Visibility.Collapsed;
                UnitsListView.SelectedIndex = 0;
                ((UnitDataView)DataContext).SelectedUnitData = ((UnitDataView)DataContext).RetrivedData.First();
                UnitDetailFrame.Navigate(typeof(UnitDetailPage), (UnitDataView)DataContext);
            }
            else
            {
                UnitDetailFrame.Visibility = Visibility.Collapsed;
            }
        }

        private async Task<string> InputTextDialogAsync(string title)
        {
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = title;
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                return inputTextBox.Text;
            else
                return null;
        }

        private async Task UnreachableDialogAsync()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Unit unreachable",
                Content = "Check your connection and try again.",
                CloseButtonText = "Ok"
            };
            await dialog.ShowAsync();
        }

        private async void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            String address = await InputTextDialogAsync("Insert host address");
            if (address != null && address.Length == 0)
            {
                IPAddress a;
                bool r = IPAddress.TryParse(address, out a);
                if (!r)
                {
                    try
                    {
                        IPAddress[] addresslist = await Dns.GetHostAddressesAsync(address);
                        a = addresslist[0];
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        await UnreachableDialogAsync();
                        return;
                    }
                }
                Debug.WriteLine(a!=null?"Inserted IP: " + a.ToString():"Invalid ip inserted");

                
            }
        }

        private async void IsReachable(IPAddress host)
        {
            Ping p = new Ping();
            var reply = await p.SendPingAsync(host);
            Debug.WriteLine("Ping: " + reply.Status);
        }

        private void ListView_Holding(object sender, HoldingRoutedEventArgs e)
        {
            Debug.WriteLine(((UnitDataView)DataContext).SelectedUnitData.Name);
        }

        private async void ListView_RightTappedAsync(object sender, RightTappedRoutedEventArgs e)
        {
            var menu = new PopupMenu();
            menu.Commands.Add(new UICommand("Power on"));
            menu.Commands.Add(new UICommand("Power off"));

            menu.Commands.Add(new UICommandSeparator());
            menu.Commands.Add(new UICommand("Reboot"));
            menu.Commands.Add(new UICommandSeparator());    
            menu.Commands.Add(new UICommand("Remove"));

            var itemsList = sender as ListView;
            var result = await menu.ShowAsync(e.GetPosition(sender as UIElement));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitDetailFrame.Navigate(typeof(UnitDetailPage), (UnitDataView) DataContext);
        }
    }


    public class UnitDataView
    {
        public DaikinData[] RetrivedData { get; set; }
        private DaikinData _SelectedUnitData;

        public DaikinData SelectedUnitData
        {
            get { return _SelectedUnitData; }
            set { _SelectedUnitData = value; }
        }
    }
    
}
