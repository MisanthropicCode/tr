using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextumReader.ProblemDomain;

namespace TextumReader.DataLayer.Concrete
{
    public class EFDbContext: DbContext
    {
        public EFDbContext(): base("EFDbContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translation> Translations { get; set; }

        // TODO add bindings insted of using attributes
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Material>().HasRequired(m => m.Category);
            //modelBuilder.Entity<Material>().HasRequired(m => m.Category);

            base.OnModelCreating(modelBuilder);
        }
    }
}
