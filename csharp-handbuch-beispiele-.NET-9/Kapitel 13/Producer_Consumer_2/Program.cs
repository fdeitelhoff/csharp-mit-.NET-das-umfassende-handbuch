using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer_2
{
    class Program
    {
        private static Semaphore semEntry = new Semaphore(1, 1);
        private static Semaphore semNoEntry = new Semaphore(0, 1);
        private static bool finished;

        public static void Main()
        {
            var number = new Data();
            Thread thProducer = new Thread(Produce);
            thProducer.Start(number);
            Thread thConsumer = new Thread(Consume);
            thConsumer.Start(number);
            Console.ReadLine();
        }
        public static void Produce(object obj)
        {
            var number = obj as Data;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                semEntry.WaitOne();
                number.Value = random.Next(1000);
                Console.WriteLine("Zahl {0} erzeugt", number.Value);
                semEntry.Release();
                semNoEntry.Release();
                if (i == 9) finished = true;
                Thread.Sleep(200);
            }
        }

        public static void Consume(object obj)
        {
            var number = obj as Data;
            while (true)
            {
                semNoEntry.WaitOne();
                semEntry.WaitOne();
                Console.WriteLine("Zahl {0} verbraucht", number.Value);
                semEntry.Release();
                if (finished) Thread.CurrentThread.Abort();
            }
        }
    }

    class Data
    {
        public int Value { get; set; }
    }

}
