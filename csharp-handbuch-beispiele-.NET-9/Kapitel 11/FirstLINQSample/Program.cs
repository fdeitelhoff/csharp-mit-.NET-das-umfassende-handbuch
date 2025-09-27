using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLINQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = 
                {
                          new Person { Name = "Meier", Age = 34 },
                          new Person { Name = "Müller", Age = 51 },
                          new Person { Name = "Schmidt", Age = 30 },
                          new Person { Name = "Fischer", Age = 25 },
                          new Person { Name = "Schulz", Age = 67 },
                };
            var query = from pers in persons
                        where pers.Age >= 50
                        select pers;
            foreach (var item in query)
                Console.WriteLine($"{item.Name,-8}{item.Age}");
            Console.ReadLine();
        }
    }


    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
