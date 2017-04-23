using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    [Table("Talent")] 
    //tabel zal niet Artist worden maar Talent
    public class Artist
    {
        
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }
        public int Id { get; set; }
        [Required, StringLength(100), Column ("FullName")]
        //zorgt er voor dat null niet meer mag en max 100 karakters
        // en dat de naam van de Kolom niet Name maar FullName wordt EF vertaalt dit weer naar Name
        public string Name { get; set; }

        [NotMapped] 
        // prop wordt geen tabel in DB  
        public string Test { get; set; }


        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
