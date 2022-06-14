using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Windows.UI;

namespace modelmvvm
{
    class myviewmodel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void onpropertychanged([CallerMemberName] string PropetyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropetyName));
            }
        }

        public ObservableCollection<mojzapis> zapisi { get; set; }
        public string naslov { get; set; }
        private mojzapis trenutni;
        public mojzapis Trenutni { get { return trenutni; } set { this.onpropertychanged(); } }
        public Delegate naredizeleno {get; set;}
    public myviewmodel()
            
        {

            zapisi = new ObservableCollection<mojzapis>();
            for(int k = 0; k < 10; k++)
            {
                zapisi.Add(new mojzapis { Ime = k.ToString(), Barva = Windows.UI.Color.FromArgb(255,255,165,0) });
            }
            naslov = "moji zapiski";
            trenutni = zapisi.First();
            naredizeleno = new DelegateCommand(
                (p) => { trenutni.Barva = Color.FromArgb(255, 0, 255, 0); },
                (p) => { return trenutni != null; }
                );
        }
      
    }
}
