﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBookArtist  // bridge table class
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public int ArtistId { get; set; }
        public int RoleId { get; set; }

        //navigate props

        public ComicBook Comicbook { get; set; }
        public Artist Artist { get; set; }
        public Role Role { get; set; }

    }
}
