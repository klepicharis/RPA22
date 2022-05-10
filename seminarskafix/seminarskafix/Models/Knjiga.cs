using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarskafix.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        public String Naslov { get; set; }
        public String Založba { get; set; }
        public DateTime Datum { get; set; }

        public int Knjiznicaid { get; set; }

        public virtual Knjiznica Knjiznica { get; set; }
    }
}