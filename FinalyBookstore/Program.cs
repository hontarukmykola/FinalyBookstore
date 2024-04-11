using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalyBookstore
{

    class MaanagerBooks
    {
        public BookstoreDbContex contex { get; set; }

        public MaanagerBooks()
        {
            contex = new BookstoreDbContex();
        }

        public void SearchBooksByAuthor(string authorName)
        {
            var books = contex.Books
                               .Where(b => b.Author.Name.Contains(authorName) ||
                                           b.Author.SurName.Contains(authorName) ||
                                           b.Author.LastName.Contains(authorName))
                               .ToList();

            // Відображення результатів пошуку
            foreach (var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }
        public void SearchBooksByName(string bookName)
        {
            var books = contex.Books.Where(b => b.Name.Contains(bookName)).ToList();

            foreach(var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }
        public void SearchBooksByGenre(string genre)
        {
            var books = contex.Books.Where(b => b.Genre.Name.Contains(genre)).ToList();

            foreach(var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }

        public void SortByNovelty()
        {
            var books = contex.Books.OrderByDescending(b => b.Year).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }
        public void SortByPopularity()
        {
            var books = contex.Books.OrderByDescending(b => b.Pages).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }

        public void ShowAllBooks()
        {
            //var books = contex.Books.ToList();
            var books = contex.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($" {book.Name} {book.Author.Name} {book.Genre.Name} {book.Year}");
            }
        }
        public void ShowAllAuthors()
        {
            var authors = contex.Authors.ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Id}{author.Name} {author.SurName} {author.LastName}");
            }
        }
        public void ShowAllGenres()
        {
            var genres = contex.Genres.ToList();

            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.Id}\t{genre.Name}");
            }
        }
        public void ShowAllPublisher()
        {
            var publisher = contex.Publishers.ToList();

            foreach (var publishers in publisher)
            {
                Console.WriteLine($"{publishers.Id} {publishers.Name}");
            }
        }



        public void DeleteBookByName(string bookName)
        {
            var bookToDelete = contex.Books.FirstOrDefault(b => b.Name == bookName);

            if (bookToDelete != null)
            {
                contex.Books.Remove(bookToDelete);
                contex.SaveChanges();
                Console.WriteLine($"Book \"{bookName}\" delete in database.");
            }
            else
            {
                Console.WriteLine($"The book \"{bookName}\" not found.");
            }
        }

        public void AddNewBook(string name, int pages, int year, decimal costPrice, decimal price, bool heir, int authorId, int genreId, int publisherId)
        {
            var newBook = new Book
            {
                Name = name,
                Pages = pages,
                Year = year,
                CostPrice = costPrice,
                Price = price,
                Heir = heir,
                AuthorId = authorId,
                GenreId = genreId,
                PublisherId = publisherId
            };

            contex.Books.Add(newBook);
            contex.SaveChanges();

            Console.WriteLine("New book successfully added");
        }

        public void AddNewAuthor(string name, string surName,string lastName)
        {
            var newAuthor = new Author
            {
                Name = name,
                SurName = surName,
                LastName = lastName
            };
            contex.Authors.Add(newAuthor);
            contex.SaveChanges();
            Console.WriteLine("new author successfully added");
        }

        public void AddNewPublisher(string name)
        {
            var newPublisher = new Publisher
            {
                Name = name,
            };
            contex.Publishers.Add(newPublisher);
            contex.SaveChanges();
            Console.WriteLine("New publishing house successfully added");
        }

        public void AddNewGenre(string name)
        {
            var newGenre = new Publisher
            {
                Name = name,
            };
            contex.Publishers.Add(newGenre);
            contex.SaveChanges();
            Console.WriteLine("New genre house successfully added");
        }


    }


    internal class Program
    {
       


        static void Main(string[] args)
        {
            MaanagerBooks managerBooks = new MaanagerBooks();


            const string LoginUser = "User";
            const int PasswordUser = 123321;
            const string LoginManager = "Manager";
            const int PasswordManager = 123123;
            //const string LoginAdmin = "Admin";
            //const int PasswordAdmin = 123456;


            int attemptsLeft = 5;
            string name1;
            Console.WriteLine("Who you are:");
            name1 = Console.ReadLine();
            Console.WriteLine("Enter password :");
            int password = int.Parse(Console.ReadLine());

            if (name1 == LoginUser)
            {
                while (attemptsLeft > 0)
                {
                    if (password == PasswordUser)
                    {
                        int b = new int();
                        do
                        {
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("search books by author (Enter 1)");
                            Console.WriteLine("search books by name (Enter 2)");
                            Console.WriteLine("search books by genre (Enter 3)");
                            Console.WriteLine("sorting by novelty (Enter 4)");
                            Console.WriteLine("sorting by popularity (Enter 5)");
                            Console.WriteLine("Show all Books (Enter 6)");
                            Console.WriteLine("Show all author (Enter 7)");
                            Console.WriteLine("Show all genre (Enter 8)");
                            Console.WriteLine("Show all publishers (Enter 9)");

                            Console.WriteLine("0 - exit");

                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 0:
                                    {
                                        Environment.Exit(0);
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter the author's name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByAuthor(name);
                                        
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter book name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByName(name);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter genre name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByGenre(name);
                                        break;
                                    }
                                case 4:
                                    {
                                        managerBooks.SortByNovelty();
                                        break;
                                    }
                                case 5:
                                    {
                                        managerBooks.SortByPopularity();
                                        break;
                                    }
                                case 6:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Books");
                                        managerBooks.ShowAllBooks();
                                        break;
                                    }
                                case 7:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Authors");
                                        managerBooks.ShowAllAuthors();
                                        break;
                                    }
                                case 8:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Genres");
                                        managerBooks.ShowAllGenres();
                                        break;
                                    }
                                case 9:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All publishers");
                                        managerBooks.ShowAllPublisher();
                                        break;
                                    }
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        } while (b != 0);


                    }
                    else
                    {
                        attemptsLeft--;
                        Console.WriteLine($"The password is incorrect. Remaining attempts : {attemptsLeft}");
                    }
                    if (attemptsLeft == 0)
                    {
                        Console.WriteLine("You have exhausted all attempts. The program will be closed.");
                        Environment.Exit(0);
                    }
                }
            }

            //manager

            if(name1 == LoginManager)
            {
                while (attemptsLeft > 0)
                {
                    if (password == PasswordManager)
                    {
                        int b = new int();
                        do
                        {
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("search books by author (Enter 1)");
                            Console.WriteLine("search books by name (Enter 2)");
                            Console.WriteLine("search books by genre (Enter 3)");
                            Console.WriteLine("sorting by novelty (Enter 4)");
                            Console.WriteLine("sorting by popularity (Enter 5)");
                            Console.WriteLine("Show all Books (Enter 6)");
                            Console.WriteLine("Show all author (Enter 7)");
                            Console.WriteLine("Show all genre (Enter 8)");
                            Console.WriteLine("add new book (Enter 9)");
                            Console.WriteLine("delete book (Enter 10)");
                            Console.WriteLine("0 - exit");

                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 0:
                                    {
                                        Environment.Exit(0);
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter the author's name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByAuthor(name);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter book name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByName(name);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter genre name");
                                        string name = Console.ReadLine();
                                        managerBooks.SearchBooksByGenre(name);
                                        break;
                                    }
                                case 4:
                                    {
                                        managerBooks.SortByNovelty();
                                        break;
                                    }
                                case 5:
                                    {
                                        managerBooks.SortByPopularity();
                                        break;
                                    }
                                case 6:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Books");
                                        managerBooks.ShowAllBooks();
                                        break;
                                    }
                                case 7:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Authors");
                                        managerBooks.ShowAllAuthors();
                                        break;
                                    }
                                case 8:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Genres");
                                        managerBooks.ShowAllGenres();
                                        break;
                                    }
                                case 9:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter name book :");
                                        string BookName = Console.ReadLine();
                                        Console.WriteLine("Enter count of pages : ");
                                        int pages = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter year : ");
                                        int year = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter cost price : ");
                                        decimal costPrice = decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter price : ");
                                        decimal price = decimal.Parse(Console.ReadLine());
                                        Console.Write("Is Heir? (true/false): ");
                                        bool heir;
                                        while (!bool.TryParse(Console.ReadLine(), out heir))
                                        {
                                            Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                                            Console.Write("Is Heir? (true/false): ");
                                        }

                                        int AuthorId = 0;
                                        int choice1;
                                        Console.Clear();
                                        Console.WriteLine("1 - choose from existing authors");
                                        Console.WriteLine("2 - create an author");
                                        choice1 = int.Parse(Console.ReadLine());
                                        switch (choice1)
                                        {
                                            case 1:
                                                {
                                                    managerBooks.ShowAllAuthors();
                                                    Console.WriteLine("Enter id author");
                                                    AuthorId = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter author name");
                                                    string AuthorName = Console.ReadLine();
                                                    Console.WriteLine("Enter author SurName");
                                                    string AuthorSurname = Console.ReadLine();
                                                    Console.WriteLine("Enter author LastName");
                                                    string Lastname = Console.ReadLine();
                                                    managerBooks.AddNewAuthor(AuthorName, AuthorSurname, Lastname);
                                                    AuthorId = managerBooks.contex.Authors.OrderByDescending(x => x.Id)
                                                        .FirstOrDefault()?.Id ?? 0;
                                                    break;
                                                }
                                        }

                                        int PublisherId = 0;
                                        int choice2;
                                        Console.Clear();
                                        Console.WriteLine("1 - choose an existing publishing house");
                                        Console.WriteLine("2 - create a publishing house");
                                        choice2 = int.Parse(Console.ReadLine());
                                        switch (choice2)
                                        {
                                            case 1:
                                                {
                                                    managerBooks.ShowAllPublisher();
                                                    Console.WriteLine("Enter id publishers");
                                                    PublisherId = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter publisher name");
                                                    string PublisherName = Console.ReadLine();
                                                    managerBooks.AddNewPublisher(PublisherName);
                                                    PublisherId = managerBooks.contex.Publishers.OrderByDescending(x => x.Id)
                                                        .FirstOrDefault()?.Id ?? 0;
                                                    break;
                                                }
                                        }
                                        int genreId = 0;
                                        int choice3;
                                        Console.Clear();
                                        Console.WriteLine("1 - choose an existing genre");
                                        Console.WriteLine("2 - create a genre");
                                        choice3 = int.Parse(Console.ReadLine());
                                        switch (choice3)
                                        {
                                            case 1:
                                                {
                                                    managerBooks.ShowAllGenres();
                                                    Console.WriteLine("Enter id genre");
                                                    genreId = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter genre name");
                                                    string GenreName = Console.ReadLine();
                                                    managerBooks.AddNewGenre(GenreName);
                                                    genreId = managerBooks.contex.Genres.OrderByDescending(x => x.Id)
                                                        .FirstOrDefault()?.Id ?? 0;

                                                    break;
                                                }
                                        }
                                        Console.WriteLine("book added successfully");
                                        managerBooks.AddNewBook(BookName, pages, year, costPrice, price, heir, AuthorId, genreId, PublisherId);






                                        break;
                                    }
                                case 10:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter book name for delete");
                                        string name = Console.ReadLine();
                                        managerBooks.DeleteBookByName(name);
                                        break;
                                    }
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        } while (b != 0);
                    }
                    else
                    {
                        attemptsLeft--;
                        Console.WriteLine($"The password is incorrect. Remaining attempts : {attemptsLeft}");
                    }
                    if (attemptsLeft == 0)
                    {
                        Console.WriteLine("You have exhausted all attempts. The program will be closed.");
                        Environment.Exit(0);
                    }
                }
            }

        }
    }
}
