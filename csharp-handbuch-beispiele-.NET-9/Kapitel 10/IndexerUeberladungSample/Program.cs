using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerUeberladungSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Team Wacker = new Team();
            // Spieler der Mannschaft hinzufügen 
            Wacker[0] = new Player { Name = "Fischer", Age = 23 };
            Wacker[1] = new Player { Name = "Müller", Age = 19 };
            Wacker[2] = new Player { Name = "Mamic", Age = 33 };
            Wacker[3] = new Player { Name = "Meier", Age = 31 };
            // Spieler suchen
            Console.Write("Spieler suchen: ... ");
            string spieler = Console.ReadLine();
            if (Wacker[spieler] != null)
                Console.WriteLine("{0} gefunden, Alter = {1}", Wacker[spieler].Name, Wacker[spieler].Age);

            else
                Console.WriteLine("Der Spieler gehört nicht zum Team.");
            Console.ReadLine();
        }
    }
    // Mannschaft
    public class Team
    {
        private Player[] team = new Player[25];
        // Indexer
        public Player this[int index]
        {
            get { return team[index]; }
            set
            {
                // prüfen, ob der Index schon besetzt ist
                if (team[index] == null)
                    team[index] = value;
                else
                    // nächsten freien Index suchen
                    for (int i = 0; i < 25; i++)
                        if (team[i] == null)
                        {
                            team[i] = value;
                            return;
                        }
            }
        }

        public Player this[string name]
        {
            get
            {
                for (int index = 0; index < 25; index++)
                {
                    if (team[index] != null && team[index].Name == name)
                        return team[index];
                }
                return null;
            }
        }
    }

    // Spieler
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
