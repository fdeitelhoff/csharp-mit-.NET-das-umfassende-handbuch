using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateExceptionSample_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Run(() =>
            {
                throw new DivideByZeroException();
            });
            try
            {
                task1.Wait();
            }
            catch (AggregateException ex)
            {
                AggregateException aggEx = ex.Flatten();
                aggEx.Handle(type =>
                {
                    if (type is DivideByZeroException)
                    {
                        Console.WriteLine("Division durch 0 ist nicht erlaubt.");
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
