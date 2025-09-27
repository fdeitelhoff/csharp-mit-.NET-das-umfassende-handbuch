using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_Sample
{
    [Developer("Meier")]
    class Demo
    {
        [Developer("Fischer", Identifier = 455)]
        public void DoSomething() { }
        public void DoMore() { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DeveloperAttribute : Attribute
    {
        public string Name { get; set; }
        public int Identifier { get; set; }
        public DeveloperAttribute(string name) => Name = name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type tDemo = typeof(Demo);
            Type tAttr = typeof(DeveloperAttribute);
            MethodInfo mInfo1 = tDemo.GetMethod("DoSomething");
            MethodInfo mInfo2 = tDemo.GetMethod("DoMore");
            // Prüfen, ob die Klasse Demo das Attribute hat
            DeveloperAttribute attr =
              (DeveloperAttribute)Attribute.GetCustomAttribute(tDemo, tAttr);
            if (attr != null)
            {
                Console.WriteLine("Name: {0}", attr.Name);
                Console.WriteLine("Identifier: {0}", attr.Identifier);
            }
            else
                Console.WriteLine("Attribut nicht gesetzt");
            // Prüfen, ob das Attribut bei der Methode DoSomething gesetzt ist
            attr = (DeveloperAttribute)Attribute.GetCustomAttribute(mInfo1, tAttr);
            if (attr != null)
            {
                Console.WriteLine("Name: {0}", attr.Name);
                Console.WriteLine("Identifier: {0}", attr.Identifier);
            }
            // Prüfen, ob das Attribut bei der Methode DoMore gesetzt ist
            bool isDefinied = Attribute.IsDefined(mInfo2, tAttr);
            if (isDefinied)
                Console.WriteLine("DoMore hat das Attribut.");
            else
                Console.WriteLine("DoMore hat das Attribut nicht.");
            Console.ReadLine();
        }
    }
}
