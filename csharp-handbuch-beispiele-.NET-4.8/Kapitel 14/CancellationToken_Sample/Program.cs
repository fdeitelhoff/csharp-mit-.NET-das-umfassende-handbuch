using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        var task = Task.Run(() =>
        {
            while (true)
            {
                Console.Write("X");
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("\nAbbruch des Tasks");
                    token.ThrowIfCancellationRequested();
                }
            }
        }, token); 
        
        try
        {
            Thread.Sleep(20);
            cts.Cancel();
            task.Wait();
        }
        catch (AggregateException ex)
        {
            foreach (var item in ex.InnerExceptions)
                Console.WriteLine($"{ex.Message} - {item.Message}");
        }
        Console.ReadLine();
    }
}