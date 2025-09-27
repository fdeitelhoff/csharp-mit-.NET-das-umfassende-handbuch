using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerSample
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
            // Spielerliste ausgeben
            for (int index = 0; index < 25; index++)
            {
                if (Wacker[index] != null)
                    Console.WriteLine("Name: {0,-10}Alter: {1}", Wacker[index].Name, Wacker[index].Age);
            }
            Console.ReadLine();
        }
    }
    // Mannschaft
    public class Team
    {
        Player[] team = new Player[25];
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
    }
    // Spieler
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
