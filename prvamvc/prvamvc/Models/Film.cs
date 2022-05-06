using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prvamvc.Models
{
    public class Film
    {
        public int Id { get; set; }
        public String Naslov { get; set; }
        public DateTime Izdano { get; set; }
        public String Tip { get; set; }
        public decimal Cena { get; set; }
    }
}