using System.Diagnostics.Metrics;
using System.Threading;

namespace ThreadManager
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

    public class ThreadManager
    {
        protected Random random;
        protected readonly List<int> counters;
        protected readonly List<Thread> threads;

        public ThreadManager()
        {
            random = new Random();
            counters = new List<int>();
            threads = new List<Thread>();
        }

        public virtual void DoLab()
        {

        }
    }
    public class ThreadManager4 : ThreadManager
    {
        public ThreadManager4()
        {
            for (int i = 0; i < 5; i++)
            {
                counters.Add(0);
            }
        }

        public override void DoLab()
        {
            threads.Add(new Thread(ChangeNumbers));
            threads.Add(new Thread(CheckNumbers));

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        private void ChangeNumbers()
        {
            var locker = new object();
            while (true)
            {
                lock (locker)
                {
                    Console.WriteLine("\nAfter check numbers:");
                    foreach (var counter in counters)
                    {
                        Console.Write($"{counter} ");
                    }
                    for (int i = 0; i < counters.Count; i++)
                    {
                        counters[i] = random.Next(-150, 150);
                    }
                    Console.WriteLine("\nChanged numbers:");
                    foreach (var counter in counters)
                    {
                        Console.Write($"{counter} ");
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private void CheckNumbers()
        {
            while (true)
            {
                for (int i = 0; i < counters.Count; i += 2)
                {
                    counters[i] = 0;
                }
                Thread.Sleep(1000);
            }
        }
    }
}