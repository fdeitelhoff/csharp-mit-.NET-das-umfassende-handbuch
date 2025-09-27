using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberwiseClonen
{
    class Program
    {
        static void Main(string[] args)
        {
            Owner owner = new Owner { Name = "Herbert Meier", Alter = 28 };
            Account account = new Account { Owner = owner, AccountNo = 1 };

            // Erstellen einer 'tiefen' Kopie
            Account copy = (Account)account.Clone();

            Console.WriteLine($"Hash des Originals: {account.Owner.GetHashCode()}");
            Console.WriteLine($"Hash der Kopie:     {copy.Owner.GetHashCode()}");
            Console.ReadLine();
        }
    }


    public class Owner : ICloneable
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public object Clone() => this.MemberwiseClone();        
    }

    public class Account : ICloneable
    {
        public int AccountNo { get; set; }
        public Owner Owner { get; set; }

        // Methode des Interfaces ICloneable
        public object Clone()
        {
            Account acc = (Account)MemberwiseClone();
            acc.Owner = (Owner)Owner.Clone();
            return acc;
        }
    }
}

