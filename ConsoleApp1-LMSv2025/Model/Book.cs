using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_LMSv2025.Model
{
    public class Book
    {
        // Properties of the book
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }

        // Overrides the ToString method to provide a string representation of the book details
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Published Date: {PublishedDate.ToShortDateString()}";
        }
    }
}
