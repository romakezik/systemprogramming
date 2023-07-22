using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace lab2
{
    internal class Book
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        public override string ToString()
        {
            return $"{Author}, {Title}, {Year}, {Pages}";
        }
    }

    internal static class MainProc
    {
        private const string FileName = "Books.txt";

        private static List<Book> ReadBooksFromFile(string fileName)
        {
            var Books = new List<Book>();

            using var reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                var fields = reader.ReadLine().Split(',');

                var Book = new Book
                {
                    Author = fields[0],
                    Title = fields[1],
                    Year = int.Parse(fields[2]),
                    Pages = int.Parse(fields[3])
                };

                Books.Add(Book);
            }

            return Books;
        }

        private static void Daughter(int numStr, IReadOnlyList<Book> Books)
        {
            Console.WriteLine("Do you want to write new Author?");
            var isWriteName = Console.ReadLine();
            if (isWriteName.Equals("y"))
            {
                Console.WriteLine("Enter new Author");
                var newName = Console.ReadLine();
                Books[numStr].Author = newName;
            }

            Console.WriteLine("Do you want to write new title?");
            var isWriteTitle = Console.ReadLine();
            if (isWriteTitle.Equals("y"))
            {
                Console.WriteLine("Enter new Title");
                var newTitle = Console.ReadLine();
                Books[numStr].Title = newTitle;
            }

            Console.WriteLine("Do you want to write new pages?");
            var isWriteDate = Console.ReadLine();
            if (isWriteDate.Equals("y"))
            {
                Console.WriteLine("Enter new date");
                var newDate = int.Parse(Console.ReadLine());
                Books[numStr].Pages = newDate;
            }

            var newTextFile = Books
                .Aggregate<Book, string>(null,
                    (current, Book) =>
                        current +
                        $"{Book.Author}, {Book.Title}, {Book.Year.ToString()}, {Book.Pages.ToString():d}\n");

            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c echo {newTextFile} > {FileName}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private static void Main()
        {
            var Books = ReadBooksFromFile(FileName);

            foreach (var Book in Books) Console.WriteLine(Book.Author);

            Console.WriteLine("write number of structure");
            var numberStr = int.Parse(Console.ReadLine() ?? string.Empty);

            Daughter(numberStr, Books);

            Console.WriteLine();
            var newBooks = ReadBooksFromFile(FileName);
            foreach (var newBook in newBooks)
                Console.WriteLine($"{newBook.Author}, {newBook.Title}, " +
                                  $"{newBook.Year}, {newBook.Pages}");
        }
    }
}
