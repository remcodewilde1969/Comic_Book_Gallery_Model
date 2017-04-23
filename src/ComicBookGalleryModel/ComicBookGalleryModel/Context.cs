using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //drop database als het model veranderd
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            
            //EF gebruikt create datebase if not exists by default dus eigenlijk niet nodig
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            //drop database bij elke herstart
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
