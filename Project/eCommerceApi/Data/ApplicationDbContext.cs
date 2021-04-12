using eCommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Culture> Cultures { get; set; }
        public DbSet<LocalizationSet> LocalizationSets { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }


      
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Localization>(etb =>
            {
                etb.HasKey(e => new { e.LocalizationSetId, e.CultureId });
                etb.ToTable("Localizations");
            });


            modelBuilder.Entity<Culture>()
              .HasData(
                       new Culture { Id = 1 ,Name = "English" , Code = "en"},
                       new Culture { Id = 2, Name = "Arabic", Code = "ar" },
                       new Culture { Id = 3, Name = "French", Code = "fr" }
                 );
        }
        

    }
}
