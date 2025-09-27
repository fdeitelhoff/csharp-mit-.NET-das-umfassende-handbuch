using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartielleMethoden
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pers = new Person { Name = "Fischer", Alter = 67 };
            pers.Name = "Müller";
            Console.WriteLine(pers.Name);
            Console.ReadLine();
        }
    }

    // partielle Klasse 
    public partial class Person
    {
        // Felder
        private string _Name { get; set; }
        public int Alter { get; set; }

        // Partielle Methoden
        partial void ChangingName(string name);
        partial void ChangedName();

        // Eigenschaft
        public string Name
        {
            get { return _Name; }
            set
            {
                ChangingName(_Name);
                _Name = value;
                ChangedName();
            }
        }
    }

    // partielle Klasse
    public partial class Person
    {
        partial void ChangingName(string name) => Console.WriteLine($"Der alte Name '{name}' wird geändert.");

        partial void ChangedName() => Console.WriteLine("Name erfolgreich geändert.");        
    }

}
