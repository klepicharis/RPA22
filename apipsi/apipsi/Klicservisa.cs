using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apipsi
{
    class Klicservisa
    {
        public static async Task PopulatePsi(ObservableCollection<Slika> poti)
        {
            String url = "https://dog.ceo/api/breed/bullterrier/staffordshire/images";
            odgovor p = new odgovor();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                p = await sp.Content.ReadAsAsync<odgovor>();
            }
            foreach(var x in p.message)
            {
                Slika s = new Slika();
                s.Pot = x;
                poti.Add(s);

            }
        }
    }
}
