using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue();

            // Queue füllen
            for (int i = 0; i <= 10; i++)
                myQueue.Enqueue(i * i);

            // Ausgabe in der Konsole
            PrintQueue(myQueue);
            Console.ReadLine();
        }


        public static void PrintQueue(Queue obj)
        {
            // alle Elemente aus der Queue holen
            while (obj.Count != 0)
               Console.WriteLine(obj.Dequeue());
        }
    }
}
