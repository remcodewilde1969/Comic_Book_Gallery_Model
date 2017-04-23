﻿using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooks = context.ComicBooks.ToList();

                var comicBooksQuery = from cb in context.ComicBooks select cb;
                var comicBooks = comicBooksQuery.ToList();

                Console.WriteLine("# of comic books: {0}", comicBooks.Count);

                //var comicBooks = context.ComicBooks
                //    // dit zal werken maar string heb je kans op typos .Include("Series")
                //    // beter is using System.Data.Entity toevoegen
                //    .Include(cb => cb.Series) //nu kan je het met een lambda doen en werkt intelisense
                //    .Include(cb => cb.Artists.Select(a => a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();
                //foreach (var comicBook in comicBooks)
                //{
                //    //new collection artisNames
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}
                Console.ReadLine();
            }
        }
    }
}
