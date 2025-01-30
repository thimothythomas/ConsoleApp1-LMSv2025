using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1_LMSv2025.Model;

namespace ConsoleApp1_LMSv2025.Service
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void ListAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("| ISBN          | Title            | Author          | Date       |");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var book in books.Values)
            {
                Console.WriteLine($"| {book.ISBN,-12} | {book.Title,-15} | {book.Author,-15} | {book.PublishedDate:yyyy-MM-dd} |");
            }
        }

        public void AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.ISBN) || string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                Console.WriteLine("Invalid input. Please ensure all fields are filled correctly.");
                return;
            }

            if (!books.ContainsKey(book.ISBN))
            {
                books.Add(book.ISBN, book);
                Console.WriteLine("Book added successfully.");
            }
            else
            {
                Console.WriteLine("A book with the same ISBN already exists. Please enter a unique ISBN.");
            }
        }

        public void EditBook(string isbn)
        {
            isbn = isbn.Trim();
            if (!books.TryGetValue(isbn, out var book))
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter new title (press enter to keep unchanged): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;

            Console.Write("Enter new author (press enter to keep unchanged): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;

            Console.Write("Enter new published date (YYYY-MM-DD, press enter to keep unchanged): ");
            string newDate = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDate) && DateTime.TryParse(newDate, out DateTime publishedDate))
            {
                book.PublishedDate = publishedDate;
            }
            Console.WriteLine("Book updated successfully.");
        }

        public void RemoveBook(string isbn)
        {
            if (books.Remove(isbn.Trim()))
            {
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void SearchByAuthor(string author)
        {
            var foundBooks = books.Values.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundBooks.Count == 0)
            {
                Console.WriteLine("No books found by this author.");
                return;
            }
            ListAllBooks();
        }

        public void SearchByTitle(string title)
        {
            var foundBooks = books.Values.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundBooks.Count == 0)
            {
                Console.WriteLine("No books found with this title.");
                return;
            }
            ListAllBooks();
        }
    }
}
