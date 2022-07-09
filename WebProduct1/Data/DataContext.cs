using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProduct1.Models;

namespace WebProduct1.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<WebProduct1.Models.Product>? Product { get; set; }

        public DbSet<WebProduct1.Models.Category>? Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebProduct1.Models.Product>()
                .HasOne<WebProduct1.Models.Category>(p => p.Category)
                .WithMany(Cat => Cat.Products)
                .HasForeignKey(p => p.CategoriesId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
