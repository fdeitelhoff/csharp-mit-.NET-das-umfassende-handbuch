using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public static class Calculator
    {
        public static long Add(int a, int b) => a + b;
        public static long Subtract(int a, int b) => a - b;
        public static long Multiply(int a, int b) => a * b;
        public static double Divide(double a, double b) => a / b;
    }
}
