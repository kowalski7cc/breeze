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
    /// 
    public sealed partial class MainPage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings =
    Windows.Storage.ApplicationData.Current.LocalSettings;
        LinkedList<Daikin> units = new LinkedList<Daikin>();

        Daikin[] hosts = new Daikin[]
        {
            new Daikin("192.168.0.215"),
            //new Daikin("192.168.0.214"),
            //new Daikin("192.168.0.213")
        };

        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Creating data object");
            var data = new UnitDataView()
            {
                //RetrivedData = new DaikinData[hosts.Length]
            };

            if (hosts.Length > 0)
            {
                Debug.WriteLine("Found units! Polling");
                for (int i = 0; i < hosts.Length; i++)
                {
                    Debug.WriteLine("------START POLLING OF " + hosts[i].Host + "-----------");
                    hosts[i].GetStatus().Wait();
                    data.RetrivedData[i] = hosts[i].GetStatus().Result;
                    Debug.WriteLine("------END POLLING OF " + hosts[i].ToString() + "-----------");
                }
                Debug.Write("Polling ended");
                data.SelectedUnitData = data.RetrivedData[0];
            }          

            DataContext = data;
            refreshView();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }


        private void refreshView()
        {
            if ((((UnitDataView)DataContext).RetrivedData != null) && ((UnitDataView)DataContext).RetrivedData.Length > 0)
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
            if (address != null && address.Length > 0)
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
                if(a!=null)
                {
                    units.AddLast(new Daikin(a.ToString()));
                }
                Debug.WriteLine(a!=null?"Inserted IP: " + a.ToString():"Invalid ip inserted");


                DaikinData newData = await units.First.Value.GetStatus();

                DataContext = new UnitDataView()
                {
                    RetrivedData = new DaikinData[]
                    {
                        newData
                    },
                    SelectedUnitData = newData

                };
                refreshView();
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
