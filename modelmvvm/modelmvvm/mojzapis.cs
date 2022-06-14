using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace modelmvvm
{
    class mojzapis : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string ime;
        public string Ime {
            get { return ime; }
                set { ime = value;
                this.onpropertychanged();
            }
        }

        private Color barva;
        public Color Barva
        {
            get { return barva; }
            set { barva = value;
                this.onpropertychanged();
            }
        }
        public void onpropertychanged([CallerMemberName] string PropetyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropetyName));
            }
        }
                
    }
}
