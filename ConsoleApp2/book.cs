namespace BooksLibrary
{
    public class Book
    {
        public string BookName { get; private set; }
        public string AuthorName { get; private set; }
        public int Date { get; private set; }
        public int PageNumber { get; private set; }

        public Book(string bookName, string authorName, int date, int pageNumber)
        {
            BookName = bookName;
            AuthorName = authorName;
            Date = date;
            PageNumber = pageNumber;
        }
    }
}