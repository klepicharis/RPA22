using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asihroni

{
    class Coffee { }
    class Bacon { }
    class Egg { }
    class Toast { }
    class Juice { }
    class Program
    {
        static async Task Main(string[] args)
        {
            //Coffee cup = KuhajKavo();
            //Console.WriteLine("Kava je kuhana");
            //Egg eggs = Cvrijajca(2);
            //Console.WriteLine("Jajca so cvrta");
            //Bacon bacon = Cvrislanino(3);
            //Console.WriteLine("slanina narejena");
            //Toast toast = PrečiKruh(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toasti so pripravljeni");
            //Juice juice = StisniSok();
            //Console.WriteLine("Sok je pripravljen");
            //Console.WriteLine("zajtrk je pripravljen");
            //asihrono

            var c = KuhajKavo();
            
            // Egg eggs = await Cvrijajca(2);
            var eggs = Cvrijajca(2);
           
            //Bacon bacon = await Cvrislanino(3);
            var bacon = Cvrislanino(3);
            var vsitaski = new List<Task> { eggs, bacon, c };
            
            Toast toast = await PrečiKruh(2);
            //Task<Toast> toast = PrečiKruh(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toasti so pripravljeni");
            Juice juice = StisniSok();
            Console.WriteLine("Sok je pripravljen");
            Coffee cup = await c;
            //Console.WriteLine("Kava je kuhana");
            //Egg egg = await eggs;
            //Console.WriteLine("Jajca so cvrta");
            //Bacon b = await bacon;
            //Console.WriteLine("slanina narejena");
            while (vsitaski.Count > 0)
            {
                Task končan = await Task.WhenAny(vsitaski);
                if (končan == eggs)
                {
                    Console.WriteLine("Jajca so cvrta");
                }
                else 
                    if(končan == bacon){
                    Console.WriteLine("slanina narejena");
                }
                else
                    if (končan == c)
                {
                    Console.WriteLine("Kava je kuhana");
                }
                vsitaski.Remove(končan);
            }

            Console.WriteLine("zajtrk je pripravljen");
            Console.ReadLine();
        }

        private static Juice StisniSok()
        {
            Console.WriteLine("Stiskanje soka iz pomaranč");
            Task.Delay(3000).Wait();
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Dodajanje marmelade");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("dodajanje masla na toast");
        }

        private async static Task<Toast> PrečiKruh(int v)
        {
            for(int k = 0; k < v; k++)
            {
                Console.WriteLine("dodajam toast v toaster");
            }
            Console.WriteLine("začenjam peči");
            await Task.Delay(3000);
            Console.WriteLine("Odstrani toat iz toasterja");
            return new Toast();
        }

        private async static Task<Bacon> Cvrislanino(int v)
        {
            Console.WriteLine("Dodajanje "+v+" kosov slanine v ponev");
            Console.WriteLine("Pečenje na eni strani");
            Task.Delay(3000).Wait();
            for(int k = 0; k < v; k++)
            
                Console.WriteLine("obračanje slanine");
                Console.WriteLine("pečenje druge strani");
            await Task.Delay(3000);
            Console.WriteLine("daj slanino na krožnik");
                return new Bacon();
            
        }

        private async static Task<Egg> Cvrijajca(int v)
        {
            Console.WriteLine("Segrevanje ponve...");
            await Task.Delay(3000);
            Console.WriteLine("Razbijanje "+v+" jajc");
            Console.WriteLine("Cvretje jajc........");
            await Task.Delay(3000);
            Console.WriteLine("Daj jajca na krožnik");
            return new Egg();
        }

        private  async static Task<Coffee> KuhajKavo()
        {
            Console.WriteLine("Kuhanje kave");
            Task.Delay(3000).Wait();
            return new Coffee();
        }
    }
}
