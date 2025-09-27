using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComaparable_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo[] arr = new Demo[] {
                                      new Demo { Value = 56 },
                                      new Demo { Value = 72 },
                                      new Demo { Value = 35 },
                                      new Demo { Value = 3 }
                                    };
            ArrayList liste = new ArrayList();
            liste.AddRange(arr);
            liste.Sort();
            foreach (Demo item in liste)            
                Console.WriteLine($"Index: {liste.IndexOf(item)} / Wert: {item.Value}");            
            Console.ReadLine();
        }

        public class Demo : IComparable
        {
            public int Value { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Demo demo = obj as Demo;
                if (demo != null)
                    return Value.CompareTo(demo.Value);
                throw new ArgumentException("Objekt ist nicht vom Typ Demo");
            }
        }

    }

}
