using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series = new Series()
                {
                    Title = "Book serie demo"
                };
                context.ComicBooks.Add(new ComicBook()
                {
                    Series= series,
                    IssueNumber=1,
                    PublishedOn = DateTime.Today
                });
                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                });
                // omdat we 2 object init doen krijg je twee de zelfde series

                //context.ComicBooks.Add(new ComicBook()
                //{
                //    Series = new Series() { Title = "Book serie demo" },

                //    IssueNumber = 2,
                //    PublishedOn = DateTime.Today
                //});
                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    // dit zal werken maar string heb je kans op typos .Include("Series")
                    // beter is using System.Data.Entity toevoegen
                    .Include(cb => cb.Series) //nu kan je het met een lambda doen en werkt intelisense
                    .ToList();
                foreach(var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }
                Console.ReadLine();
            }
        }
    }
}
