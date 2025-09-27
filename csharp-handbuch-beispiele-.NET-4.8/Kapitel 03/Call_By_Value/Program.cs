using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_By_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 3;
            DoSomething(value);
            Console.WriteLine($"value = {value}");
            Console.ReadLine();
        }

        static void DoSomething(int param)
        {
            param = 550;
        }
    }
}
