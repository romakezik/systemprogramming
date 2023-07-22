/*using BooksLibrary;
using System.Diagnostics;

 static void Daughter(int numStr, IReadOnlyList<Book> Books)
{
    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"run --project lab2 -- -numStr {numStr}",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        }
    };

    process.Start();

    var isWriteName = Console.ReadLine();
    process.StandardInput.WriteLine(isWriteName);

    var newName = Console.ReadLine();
    process.StandardInput.WriteLine(newName);

    var isWriteTitle = Console.ReadLine();
    process.StandardInput.WriteLine(isWriteTitle);

    var newTitle = Console.ReadLine();
    process.StandardInput.WriteLine(newTitle);

    var isWriteDate = Console.ReadLine();
    process.StandardInput.WriteLine(isWriteDate);

    var newDate = Console.ReadLine();
    process.StandardInput.WriteLine(newDate);

    process.WaitForExit();
}
*/