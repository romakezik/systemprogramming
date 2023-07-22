using System;
using System.Collections.Generic;
using System.IO;
namespace lab2;
class Book
{
    public string ?Author { get; set; }
    public string ?Title { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }

    public override string ToString()
    {
        return $"{Author}, {Title}, {Year}, {Pages}";
    }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> GetBooksAfterYear(int year)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Year > year)
            {
                result.Add(book);
            }
        }

        return result;
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Book book in books)
            {
                writer.WriteLine(book.ToString());
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                Book book = new Book
                {
                    Author = parts[0].Trim(),
                    Title = parts[1].Trim(),
                    Year = int.Parse(parts[2].Trim()),
                    Pages = int.Parse(parts[3].Trim())
                };
                AddBook(book);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book { Author = "Достоевский", Title = "Преступление и наказание", Year = 1866, Pages = 671 });
        library.AddBook(new Book { Author = "Толстой", Title = "Война и мир", Year = 1869, Pages = 1274 });
        library.AddBook(new Book { Author = "Толстой", Title = "Анна Каренина", Year = 1877, Pages = 864 });
        library.AddBook(new Book { Author = "Лермонтов", Title = "Мцыри", Year = 1841, Pages = 49 });

        library.SaveToFile("books.txt");

        library = new Library();

        library.LoadFromFile("books.txt");

        int year = 1870;
        List<Book> booksAfterYear = library.GetBooksAfterYear(year);
        Console.WriteLine($"Книги, изданные после {year} года:");
        foreach (Book book in booksAfterYear)
        {
            Console.WriteLine(book);
        }

        using (StreamWriter writer = new StreamWriter("result.txt"))
        {
            writer.WriteLine($"Книги, изданные после {year} года:");
            foreach (Book book in booksAfterYear)
            {
                writer.WriteLine(book.ToString());
            }
        }
    }
}
