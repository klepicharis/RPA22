using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarska1.Models
{
    public class Zaposleni
    {
        public int id { get; set; }
        public String Ime { get; set; }
        public String Priimek { get; set; }
        public DateTime DatumRojstva{ get; set; }

        public int KnjiznicaId { get; set; }

        public virtual Knjiznica Knjiznica { get; set; }
    }
}