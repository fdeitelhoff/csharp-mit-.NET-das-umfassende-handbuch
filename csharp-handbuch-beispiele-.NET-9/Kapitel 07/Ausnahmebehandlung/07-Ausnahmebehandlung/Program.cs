using _07_Ausnahmebehandlung;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

//StreamReader stream = new StreamReader(@"C:\Text.txt");
//Console.WriteLine(stream.ReadToEnd());
//stream.Close();
//Console.ReadLine();
//var value = -1;


//Debug.Assert(value >= 0, "value ist negativ");


//ArrayList liste = new ArrayList() {"Peter", "Andreas", "Conie",
//                                     "Michael", "Gerd", "Freddy"};
//liste.Sort();
//for (int i = 0; i < liste.Count; i++)
//{
//    Console.WriteLine($"Index: {i} {liste[i]}");
//}
//Console.ReadLine();

ArrayList arrList = new ArrayList();
// ArrayList füllen
arrList.Add(new Person() { Name = "Meier", City = "Berlin" });
arrList.Add(new Person() { Name = "Schulz", City = "Stuttgart" });
arrList.Add(new Person() { Name = "Gerhards", City = "Hamburg" });
arrList.Add(new Person() { Name = "Müller", City = "Bremen" });
// nach Cities sortieren
arrList.Sort(new CityComparer());
Console.WriteLine("Liste nach Wohnorten sortiert");
ShowSortedList(arrList);
// nach Namen sortieren
arrList.Sort(new NameComparer());
Console.WriteLine("Liste nach Namen sortiert");
ShowSortedList(arrList);


static void ShowSortedList(IList liste)
{
    foreach (Person temp in liste)
    {
        if (temp != null)
        {
            Console.Write($"Name = {temp.Name,-12}");
            Console.WriteLine($"Wohnort = {temp.City}");
        }
    }
    Console.WriteLine();
}


Stack<int> stack = new Stack<int>(10);
stack.Push(7);