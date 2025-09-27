using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTaskWithCallback_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zum Abbruch Leertaste drücken ...");
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // Callback-Methode registrieren
            token.Register(CancelCallbackMethod);

            // Task erzeugen
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Number: {i}");
                    Thread.Sleep(500);
                    if (token.IsCancellationRequested)
                        break;
                }
            }, token);

            // Drückt User die Leertaste, Task abbrechen
            if (Console.ReadKey().KeyChar == ' ')
                cts.Cancel();
            
            Console.ReadLine();
        }

        static void CancelCallbackMethod() => Console.WriteLine("Task wurde abgebrochen");        
    }

}
