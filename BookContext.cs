using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSite
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Book>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Book>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(y => y.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .Property(x => x.Author)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Description)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.ISBN)
                .IsRequired();
        }
    }
}
