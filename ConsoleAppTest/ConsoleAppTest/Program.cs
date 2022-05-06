using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:21745/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("VajaWebAPI/json"));
                HttpResponseMessage response = await client.GetAsync("api/Mentor");
                if (response.IsSuccessStatusCode)
                {
                    List<Mentor> vsi = new List<Mentor>();
                    vsi = await response.Content.ReadAsAsync<List<Mentor>>();
                    foreach (Mentor product in vsi)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", product.MenIme, product.MenNaziv,
                        product.MenPriimek, product.MenUstanova, product.MenVloga);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
