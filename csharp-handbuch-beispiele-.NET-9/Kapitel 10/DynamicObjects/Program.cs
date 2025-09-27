using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;

namespace DynamicObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic pers = new Person();
            pers.Name = "Peter";
            pers.Alter = 12;
            pers.Ort = "Bonn";
            pers.Telefon = 0181812345;
            Console.WriteLine($"{pers.Name},{pers.Alter},{pers.Ort}, {pers.Telefon}");
            Console.ReadLine();
        }
    }
    class Person : DynamicObject
    {
        Dictionary<string, Object> dic = new Dictionary<string, object>();
        public string Name { get; set; }
        public int Alter { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dic.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dic[binder.Name] = value;
            return true;
        }
    }
}
