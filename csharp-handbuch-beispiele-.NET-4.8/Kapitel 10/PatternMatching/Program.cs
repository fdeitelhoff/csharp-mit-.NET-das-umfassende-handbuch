using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            GetParameterType("Hallo");
            GetParameterType(50);
            GetParameterType(2.25);
            GetParameterType(new Person { Name = "Thomas"});
            Console.ReadLine();
        }

        static void GetParameterType(object obj)
        {
            switch (obj)
            {
                case null:
                    Console.WriteLine("Keine gültige Variable. ");
                    break;
                case int a:
                    Console.Write("Der Typ ist Integer. ");
                    Console.WriteLine($"Der Wert ist {a}");
                    break;
                case double b:
                    Console.Write("Der Typ ist Double. ");
                    Console.WriteLine($"Der Wert ist {b}");
                    break;
                case string c:
                    Console.Write("Der Typ ist String. ");
                    Console.WriteLine($"Inhalt: {c}");
                    break;
                case Person d:
                    Console.Write("Der Typ ist Person. ");
                    Console.WriteLine($"Name: {d.Name}");
                    break;                   
                default:
                    Console.WriteLine("Der Typ ist unbekannt");
                    break;
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
