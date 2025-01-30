using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1_LMSv2025.Model;

namespace ConsoleApp1_LMSv2025.Service
{
    public interface ILibrary
    {
        //List ll the books
        void ListAllBooks();

        //Add book
        void AddBook(Book book);

        //Edit book
        void EditBook(string isbn);

        //Remove book
        void RemoveBook(string isbn);

        //Search by author name
        void SearchByAuthor(string author);

        //Search by book title
        void SearchByTitle(string title);
    }
}
