using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjektUebergabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1 object1 = new Demo1();
            Demo2 object2 = new Demo2();
            object2.ChangeValue(object1);
            Console.WriteLine($"Value von object1: {object1.Value}");
            Console.ReadLine();
        }
    }

    class Demo1
    {
        public int Value { get; set; } = 500;
    }

    class Demo2
    {
        public void ChangeValue(Demo1 obj)
        {
            obj.Value = 4711;
        }
    }

}
