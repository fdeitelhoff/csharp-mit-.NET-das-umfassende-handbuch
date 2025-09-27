using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateExceptionSample_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task task1 = new Task(() => { throw new DivideByZeroException(); });
                Task task2 = new Task(() => { throw new InvalidCastException(); });
                Task task3 = new Task(() => { throw new InvalidProgramException(); });
                task1.Start();
                task2.Start();
                task3.Start();
                Task.WaitAll(task1, task2, task3);
            }
            catch (AggregateException ex)
            {
                AggregateException aggEx = ex.Flatten();
                aggEx.Handle(type =>
                {
                    if (type is DivideByZeroException)
                    {
                        Console.WriteLine("Nulldivision ist nicht erlaubt.");
                        return true;
                    }
                    if (type is InvalidCastException)
                    {
                        Console.WriteLine("Nicht mögliche Typumwandlung.");
                        return true;
                    }
                    if (type is InvalidProgramException)
                    {
                        Console.WriteLine("Fehler im Programm.");
                        return true;
                    }
                    return false;
                });
            }
            Console.WriteLine("Anwendung beendet");
            Console.ReadLine();
        }
    }

}
