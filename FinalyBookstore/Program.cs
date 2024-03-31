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
            var books = contex.Books.ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Book name :{book.Name}  Book author :{book.Author}  Book genre :{book.Genre}  Book Year :{book.Year}");
            }
        }
        public void ShowAllAuthors()
        {
            var authors = contex.Authors.ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Name} {author.SurName} {author.LastName}");
            }
        }
        public void ShowAllGenres()
        {
            var genres = contex.Genres.ToList();

            foreach (var genre in genres)
            {
                Console.WriteLine(genre.Name);
            }
        }

        public void DeleteBookByName(string bookName)
        {
            var bookToDelete = contex.Books.FirstOrDefault(b => b.Name == bookName);

            if (bookToDelete != null)
            {
                contex.Books.Remove(bookToDelete);
                contex.SaveChanges();
                Console.WriteLine($"Книгу \"{bookName}\" видалено з бази даних.");
            }
            else
            {
                Console.WriteLine($"Книгу з назвою \"{bookName}\" не знайдено.");
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

            Console.WriteLine("Нову книгу успішно додано до бази даних.");
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

            

            string key;
            Console.WriteLine("Who you are:");
            key = Console.ReadLine();
            switch (key)
            {
                case "User":
                    {
                        int attemptsLeft = 5;
                        while (attemptsLeft > 0)
                        {
                            Console.WriteLine("Enter password :");
                            int password = int.Parse(Console.ReadLine());
                            if (password == PasswordUser)
                            {
                                int b = new int();
                                do
                                {
                                    Console.WriteLine("search books by author (Enter 1)");
                                    Console.WriteLine("search books by name (Enter 2)");
                                    Console.WriteLine("search books by genre (Enter 3)");
                                    Console.WriteLine("sorting by novelty (Enter 4)");
                                    Console.WriteLine("sorting by popularity (Enter 5)");
                                    Console.WriteLine("Show all Books (Enter 6)");
                                    Console.WriteLine("Show all author (Enter 7)");
                                    Console.WriteLine("Show all genre (Enter 8)");
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
                                                Console.WriteLine("Enter the author's name");
                                                string name = Console.ReadLine();
                                                managerBooks.SearchBooksByAuthor(name);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Enter book name");
                                                string name = Console.ReadLine();
                                                managerBooks.SearchBooksByName(name);
                                                break;
                                            }
                                        case 3:
                                            {
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
                                                managerBooks.ShowAllBooks();
                                                break;
                                            }
                                        case 7:
                                            {
                                                managerBooks.ShowAllAuthors();
                                                break;
                                            }
                                        case 8:
                                            {
                                                managerBooks.ShowAllGenres();
                                                break;
                                            }
                                        default:
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
                        }
                        if (attemptsLeft == 0)
                        {
                            Console.WriteLine("You have exhausted all attempts. The program will be closed.");
                            Environment.Exit(0);
                        }
                        break;
                    }



                case "Manager":
                    {
                        int attemptsLeft = 5;
                        while (attemptsLeft > 0)
                        {
                            Console.WriteLine("Enter password :");
                            int password = int.Parse(Console.ReadLine());
                            if (password == PasswordManager)
                            {
                                int b = new int();
                                do
                                {
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
                                                Console.WriteLine("Enter the author's name");
                                                string name = Console.ReadLine();
                                                managerBooks.SearchBooksByAuthor(name);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Enter book name");
                                                string name = Console.ReadLine();
                                                managerBooks.SearchBooksByName(name);
                                                break;
                                            }
                                        case 3:
                                            {
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
                                                managerBooks.ShowAllBooks();
                                                break;
                                            }
                                        case 7:
                                            {
                                                managerBooks.ShowAllAuthors();
                                                break;
                                            }
                                        case 8:
                                            {
                                                managerBooks.ShowAllGenres();
                                                break;
                                            }
                                            case 9:
                                            {
                                                break;
                                            }
                                            case 10:
                                            {
                                                break;
                                            }
                                        default:
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
                        }
                        if (attemptsLeft == 0)
                        {
                            Console.WriteLine("You have exhausted all attempts. The program will be closed.");
                            Environment.Exit(0);
                        }
                        break;
                    }
               
            }

        }
    }
}