﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        public int SeriesId { get; set; }//foreignKey
        //[ForeignKey("SeriesID")] dit is alleen nodig als je je niet aan de confention houdt of bij bestaande DB's
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public Series Series { get; set; } // one to many relation

        public virtual ICollection<ComicBookArtist> Artists { get; set; } //many to many relation met gebruik van de nieuw bridge tabel

        //je mag read only props toevoegen deze worden niet meegenomen in je dat model
        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
                //Series? return null als leeg is want anders krijg je een null exeption terug als veld leeg is
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role=role
            });
        }

    }
}
