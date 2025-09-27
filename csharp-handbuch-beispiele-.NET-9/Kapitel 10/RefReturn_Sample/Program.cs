using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReturn_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var pers = new Person();
            ref int actualAge = ref pers.GetAge();
            int wishedAge = pers.GetAge();
            // 1. Ausgabe des Alters
            pers.PrintAge();
            Console.WriteLine($"Tatsächliches Alter: {actualAge}");
            Console.WriteLine($"Wunschalter: {wishedAge}\n");
            // Änderung des Alters
            actualAge = 10;
            wishedAge = 20;
            // 2. Ausgabe des Alters (nach der Änderung)
            pers.PrintAge();
            Console.WriteLine($"Tatsächliches Alter: {actualAge}");
            Console.WriteLine($"Wunschalter: {wishedAge}");
            Console.ReadLine();
        }
    }

    public class Person
    {
        private int age = 5;

        public ref int GetAge()
        {
            return ref age;
        }

        public void PrintAge()
        {
            Console.WriteLine($"Alter im Objekt: {age}");
        }
    }
}
