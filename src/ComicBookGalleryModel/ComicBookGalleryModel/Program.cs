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
                var series1 = new Series()
                {
                    Title = "Book serie1 demo"
                };
                var series2 = new Series()
                {
                    Title = "Book serie2 demo"
                };

                var artist1 = new Artist()
                {
                    Name="artist 1"
                };
                var artist2 = new Artist()
                {
                    Name = "artist 2"
                };
                var artist3 = new Artist()
                {
                    Name = "artist 3"
                };

                var comicBook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook1.Artists.Add(artist1);
                comicBook1.Artists.Add(artist2);

                var comicBook2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };
                comicBook2.Artists.Add(artist1);
                comicBook2.Artists.Add(artist2);

                var comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook3.Artists.Add(artist1);
                comicBook3.Artists.Add(artist3);

                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);
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
                    .Include(cb =>cb.Artists)
                    .ToList();
                foreach(var comicBook in comicBooks)
                {
                    //new collection artisNames
                    var artistNames = comicBook.Artists.Select(a => a.Name).ToList();
                    var artistDisplayText = string.Join(", ", artistNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistDisplayText);
                }
                Console.ReadLine();
            }
        }
    }
}
