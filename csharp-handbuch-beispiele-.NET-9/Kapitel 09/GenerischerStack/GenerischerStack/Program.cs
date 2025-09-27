using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerischerStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> stack = new Stack<int>(10);
                stack.Push(123);
                stack.Push(4711);
                stack.Push(34);

                for (int i = stack.Length; i > 0; i--)
                 Console.WriteLine(stack.Pop());
                
                stack.Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }

    // generischer Stack
    class Stack<T>
    {
        private readonly int size;
        private T[] elements;
        private int pointer = 0;

        public Stack(int size)
        {
            this.size = size;
            elements = new T[size];
        }

        public void Push(T element)
        {
            if (pointer >= this.size)
                throw new StackOverflowException();
            elements[pointer] = element;
            pointer++;
        }

        public T Pop()
        {
            pointer--;
            if (pointer >= 0)
                return elements[pointer];
            else
            {
                pointer = 0;
                throw new InvalidOperationException("Der Stack ist leer");
            }
        }

        public int Length => this.pointer; 
        
    }
}
