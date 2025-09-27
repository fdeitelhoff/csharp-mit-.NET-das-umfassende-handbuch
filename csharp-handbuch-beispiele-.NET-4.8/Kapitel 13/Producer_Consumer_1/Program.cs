using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer_1
{
    class Program
    {
        public static bool finished;
        public static bool producerWaiting;
        public static bool consumerWaiting;
        static void Main(string[] args)
        {
            Data zahl = new Data();
            Producer producer = new Producer(zahl);
            Consumer consumer = new Consumer(zahl);
            var thProducer = new Thread(producer.Produce);
            var thConsumer = new Thread(consumer.Consume);
            thProducer.Start();
            thConsumer.Start();
            Console.ReadLine();
        }
    }
    class Producer
    {
        private Data number;

        public Producer(Data obj) => number = obj;
        
        public void Produce()
        {
            var random = new Random();
            Monitor.Enter(number);
            for (int i = 0; i < 10; i++)
            {
                Program.producerWaiting = true;
                // falls der Consumer-Thread noch nicht im Wartezustand ist, geht der 
                // Producer-Thread in den Wartezustand
                if (Program.consumerWaiting == false)
                    Monitor.Wait(number);
                number.Value = random.Next(0, 1000);
                Console.WriteLine($"Nummer {number.Value} erzeugt");
                // Dem nächsten in der Warteschlange stehenden Thread den Monitor geben 
                Monitor.Pulse(number);
                Program.consumerWaiting = false;
            }
            Program.finished = true;
            Monitor.Exit(number);
        }
    }
    class Consumer
    {
        private Data number;

        public Consumer(Data obj) => number = obj;
        
        public void Consume()
        {
            Monitor.Enter(number);
            // wenn sich der Producer-Thread im Wartezustand befindet, ihn bereit halten 
            if (Program.producerWaiting)
                Monitor.Pulse(number);
            Program.consumerWaiting = true;
            while (Monitor.Wait(number))
            {
                Console.WriteLine($"Nummer {number.Value} verbraucht");
                Monitor.Pulse(number);
                if (Program.finished) Thread.CurrentThread.Abort();
            }
        }
    }
    class Data
    {
        public int Value { get; set; }
    }

}
