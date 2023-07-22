using System.Collections.Generic;

namespace BooksLibrary
{
    public class Library
    {
        public string Name { get; private set; }
        public List<Book> Books { get; private set; }

        public Library(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }
    }
}