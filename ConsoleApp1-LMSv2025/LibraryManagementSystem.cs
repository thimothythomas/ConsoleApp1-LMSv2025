using ConsoleApp1_LMSv2025.Model;
using ConsoleApp1_LMSv2025.Service;

namespace ConsoleApp1_LMSv2025
{
    public class LibraryManagementSystem
    {
        public class Program
        {
            private readonly ILibrary _library;

            public Program(ILibrary library)
            {
                _library = library;
            }

            static void Main(string[] args)
            {
                var program = new Program(new Library());

                while (true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n========================================");
                    Console.WriteLine("        LIBRARY MANAGEMENT SYSTEM        ");
                    Console.WriteLine("========================================\n");
                    Console.ResetColor();
                    Console.WriteLine("1.  List All Books");
                    Console.WriteLine("2.  Add Book");
                    Console.WriteLine("3.  Edit Book");
                    Console.WriteLine("4.  Remove Book");
                    Console.WriteLine("5.  Search by Author");
                    Console.WriteLine("6.  Search by Title");
                    Console.WriteLine("7.  Exit");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        Console.ResetColor();
                        continue;
                    }

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n========================================");
                                Console.WriteLine("         LIST OF ALL BOOKS         ");
                                Console.WriteLine("========================================\n");
                                Console.ResetColor();
                                program._library.ListAllBooks();
                                break;
                            case 2:

                                var book = new Book();
                                Console.Write("Enter ISBN: ");
                                book.ISBN = Console.ReadLine();
                                Console.Write("Enter Title: ");
                                book.Title = Console.ReadLine();
                                Console.Write("Enter Author: ");
                                book.Author = Console.ReadLine();
                                Console.Write("Enter Published Date (YYYY-MM-DD): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime publishedDate))
                                {
                                    book.PublishedDate = publishedDate;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid date format.");
                                    Console.ResetColor();
                                    break;
                                }

                                program._library.AddBook(book);
                                break;
                            case 3:
                                Console.Write("Enter ISBN of the book to edit: ");
                                program._library.EditBook(Console.ReadLine());
                                break;
                            case 4:
                                Console.Write("Enter ISBN of the book to remove: ");
                                program._library.RemoveBook(Console.ReadLine());
                                break;
                            case 5:
                                Console.Write("Enter author name: ");
                                program._library.SearchByAuthor(Console.ReadLine());
                                break;
                            case 6:
                                Console.Write("Enter book title: ");
                                program._library.SearchByTitle(Console.ReadLine());
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Exiting... Thank you for using the Library Management System!");
                                Console.ResetColor();
                                return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        Console.ResetColor();
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
