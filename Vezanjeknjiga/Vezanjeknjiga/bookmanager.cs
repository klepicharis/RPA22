using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezanjeknjiga
{
    class bookmanager
    {
        public static List<book> GetBooks()
        {
            var books = new List<book>();
            books.Add(new book
            {
                BookId = 1,
                Title = "Vulpate",
                Author = "Futurum",
                CoverImage = "Assets/1.png"
            });
            books.Add(new book
            {
                BookId = 2,
                Title = "Mazim",
                Author = "Sequiter Que",
                CoverImage = "Assets/2.png"
            });
            books.Add(new book
            {
                BookId = 3,
                Title = "Elit",
                Author = "Tempor",
                CoverImage = "Assets/3.png"
            });
            books.Add(new book
            {
                BookId = 4,
                Title = "Etiam",
                Author = "Option",
                CoverImage = "Assets/4.png"
            });
            books.Add(new book
            {
                BookId = 5,
                Title = "Feugait Eros Libex",
                Author =
           "Accumsan",
                CoverImage = "Assets/5.png"
            });
            books.Add(new book
            {
                BookId = 6,
                Title = "Nonummy Erat",
                Author = "Legunt Xaepius",
                CoverImage = "Assets/6.png"
            });
            books.Add(new book
            {
                BookId = 7,
                Title = "Nostrud",
                Author = "Eleifend",
                CoverImage = "Assets/7.png"
            });
            books.Add(new book
            {
                BookId = 8,
                Title = "Per Modo",
                Author = "Vero Tation",
                CoverImage = "Assets/8.png"
            });
            books.Add(new book
            {
                BookId = 9,
                Title = "Suscipit Ad",
                Author = "Jack Tibbles",
                CoverImage = "Assets/9.png"
            });

            books.Add(new book
            {
                BookId = 10,
                Title = "Decima",
                Author = "Tuffy Tibbles",
                CoverImage = "Assets/10.png"
            });
            books.Add(new book
            {
                BookId = 11,
                Title = "Erat",
                Author = "Volupat",
                CoverImage = "Assets/11.png"
            });
            books.Add(new book
            {
                BookId = 12,
                Title = "Consequat",
                Author = "Est Possim",
                CoverImage = "Assets/12.png"
            });
            books.Add(new book
            {
                BookId = 13,
                Title = "Aliquip",
                Author = "Magna",
                CoverImage = "Assets/13.png"
            });
            return books;
        }
    }
}
