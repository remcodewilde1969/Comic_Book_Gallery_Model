using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // remove pluralizing

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // pas default waarde van bijvoorbeeld decimal grade aan 
            // 5, 2 geeft XXX.XX

            // onderstaande zal prima werken maar voor elke decimal die je maakt.
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));

            //Beter is het op de entity zelf te doen

            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);
        }
    }
}
