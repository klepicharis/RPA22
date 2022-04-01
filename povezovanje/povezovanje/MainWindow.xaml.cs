using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace povezovanje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<podatki> vsipodatki = new List<podatki>();
        CollectionViewSource podatkiviewsource;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            podatkiviewsource =(CollectionViewSource) FindResource("podatkiviewsource");
            StreamReader sr = new StreamReader(@"d:\RPA22\vaja.csv");
            String vrstica = sr.ReadLine();
            while(vrstica!=null)
            {
                string[] p = vrstica.Split(';');//celo crstico razdelim
                podatki po = new podatki();
                po.Id = int.Parse(p[0]);
                po.Datum = DateTime.Parse(p[1]);
                po.Ime = p[2];
                po.Znesek = double.Parse(p[3]);
                vsipodatki.Add(po);
                vrstica = sr.ReadLine();

            }
            sr.Close();
            DataContext = this;
            podatkiviewsource.Source = vsipodatki;
        }
    }
}
