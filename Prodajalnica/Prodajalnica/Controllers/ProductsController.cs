using Prodajalnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prodajalnica.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] p = new Product[]
        {
            new Product {Id=1, Ime="Paradižnikova juha",Kategorija="jestvine",Cena=1 },
            new Product {Id=2, Ime="Žoga",Kategorija="Igrače",Cena=3.75m },
            new Product {Id=3, Ime="Kladivo",Kategorija="železnina",Cena=16.99m }
        };
        public IEnumerable<Product> GetProducts()
        {
            return p;
        }
        public Product GetProduct(int id)
        {
            var Produkt = p.Where(a => a.Id == id).FirstOrDefault();
            return Produkt;
        }
    }
}
