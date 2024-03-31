using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyBookstore
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public bool Heir { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }



    }
    public class Author
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }

              


    public class BookstoreDbContex : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9K9OL7\SQLEXPRESS;
                                        Initial Catalog = BookStorage;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Book>()
               .HasOne(f => f.Author)
               .WithMany(a => a.Books)
               .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Book>()
               .HasOne(f => f.Publisher)
               .WithMany(a => a.Books)
               .HasForeignKey(a => a.PublisherId);

            modelBuilder.Entity<Book>()
               .HasOne(f => f.Genre)
               .WithMany(a => a.Books)
               .HasForeignKey(a => a.GenreId);



            modelBuilder.SeedAuthors();
            modelBuilder.SeedGenres();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedBooks();


        }
    }
}
