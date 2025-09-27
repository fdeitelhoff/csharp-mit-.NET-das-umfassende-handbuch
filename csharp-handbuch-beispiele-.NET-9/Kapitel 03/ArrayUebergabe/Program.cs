using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayUebergabe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 6, 9, 4, 13, 22, 2, 29, 17 };
            Console.WriteLine($"Maximalwert = {GetMaxValue(array)}");
            Console.ReadLine();
        }

        static int GetMaxValue(int[] arr)
        {
            int maxValue = arr[0];
            foreach (int element in arr)
                if (element > maxValue)
                    maxValue = element;
            return maxValue;
        }
    }

}
