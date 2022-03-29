using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vajajaj
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities context = new BazaZaVajeEntities();
            // vsi dobavitelji
            var x1 = from a in context.DOBAVITELJ
                     select a;
            foreach(var y in x1)
                {
                Console.WriteLine(y.D_IME+" "+y.D_KONTAKT);

            }
            Console.ReadLine();
        }
    }
}
