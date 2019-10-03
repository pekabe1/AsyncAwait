using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(a => { Console.WriteLine("ala ma kota"); });
            t.Start();
            //  Thread.Sleep(3000);
            Task task = new Task(() => Console.WriteLine("Hello word"));
            Task task2 = new Task(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine("word hello");
            });

            task.Start();
            task2.Start();
            Task.WaitAll(task);
            Task.WhenAll(task, task2);
            PrintOK().Wait();

            Console.Read();
            // Console.WriteLine("Hello World!");
        }

        public static async Task PrintOK()
        {
            await Task.Run(() => Console.WriteLine("OK"));

        }

    }
}
