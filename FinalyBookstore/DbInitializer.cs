using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyBookstore
{
    public static class DbInitializer
    {
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
                {
                    new Book()
                    {
                        Id = 1,
                        Name = "war and peace",
                        Pages = 1225,
                        Year = 1867,
                        CostPrice = 200,
                        Price = 500,
                        Heir = true,

                        AuthorId = 1,
                        GenreId = 1,
                        PublisherId = 1,
                    },

                    new Book()
                    {
                        Id = 2,
                        Name = "The Master and Margarita",
                        Pages = 384,
                        Year = 1967,
                        CostPrice = 180,
                        Price = 280,
                        Heir = false,

                        AuthorId = 2,
                        GenreId = 2,
                        PublisherId = 2,
                    },

                    new Book()
                    {
                        Id = 3,
                        Name = "Harry Potter and the Philosopher's Stone",
                        Pages = 320,
                        Year = 1997,
                        CostPrice = 120,
                        Price = 200,

                        AuthorId = 3,
                        GenreId = 3,
                        PublisherId = 3,
                    },
                });
        }
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
                {
                    new Author()
                    {
                        Id = 1,
                        Name = "Lev",
                        SurName = "Tolstoy",
                        LastName = "Nikolayevich",
                    },
                     new Author()
                    {
                        Id = 2,
                        Name = "Mikhail",
                        SurName = "Bulgakov",
                        LastName = "Afanasievich",
                    },
                      new Author()
                    {
                        Id = 3,
                        Name = "Joan",
                        SurName = "Rowling",
                        LastName = "Katherine",
                    },
                });
        }
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
                {
                    new Genre()
                    {
                        Id = 1,
                        Name = "historical novel",
                    },
                     new Genre()
                    {
                        Id = 2,
                        Name = "fantasy novel",
                    },
                      new Genre()
                    {
                        Id = 3,
                        Name = "fantasy",
                    },
                });
        }
        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
                {
                    new Publisher()
                    {
                        Id = 1,
                        Name = "Russian Herald",
                    },
                     new Publisher()
                    {
                        Id = 2,
                        Name = "Moscow",
                    },
                      new Publisher()
                    {
                        Id = 3,
                        Name = "Bloomsbury",
                    },
                });
        }





    }
}
