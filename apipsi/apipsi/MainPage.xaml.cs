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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace apipsi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Slika> vsipsi;
        public MainPage()
        {
            this.InitializeComponent();
            vsipsi = new ObservableCollection<Slika>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mojp.IsActive = true;
            mojp.Visibility = Visibility.Visible;
            await Klicservisa.PopulatePsi(vsipsi);
            mojp.IsActive = false;
            mojp.Visibility = Visibility.Collapsed;
        }
    }
}
