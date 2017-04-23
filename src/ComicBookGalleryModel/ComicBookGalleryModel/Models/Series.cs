using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Series
    {
        //Init de Colection in een default contstructer

        public Series()
        {
            Comicbooks = new List<ComicBook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //omdat een series met meerdere boeken kan worden gekoppeld met je een 
        //navigation property defineren
        public ICollection<ComicBook> Comicbooks { get; set; }
    }
}
