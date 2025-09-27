using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack(11);

            // Stack füllen
            for (int i = 0; i <= 10; i++)
                myStack.Push(i * i);

            // Ausgabe in der Konsole    
            PrintStack(myStack);
            Console.ReadLine();
        }


        public static void PrintStack(Stack obj)
        {
            // alle Elemente aus dem Stack holen
            while (obj.Count != 0)
              Console.WriteLine(obj.Pop());
        }
    }
}
