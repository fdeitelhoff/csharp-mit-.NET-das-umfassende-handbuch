using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrisierteProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            PrintArray(table);
            table.Cell[2, 1] = 97;
            Console.WriteLine();
            PrintArray(table);
            Console.ReadLine();
        }

        // Ausgabe des Arrays im Tabellenformat
        static void PrintArray(Table tbl)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                    Console.Write("{0,-3}", tbl.Cell[row, col]);
                Console.WriteLine();
            }
        }
    }

    // Klasse Table
    class Table
    {
        private Content _Cell = new Content();
        public Content Cell
        {
            get { return _Cell; }
        }
    }

    // Klasse Content
    class Content
    {
        private int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
        // Indexer
        public int this[int row, int column]
        {
            get
            {
                CheckIndex(row, column);
                return arr[row, column];
            }
            set
            {
                CheckIndex(row, column);
                arr[row, column] = value;
            }
        }

        // Prüfen der Arraygrenzen
        private void CheckIndex(int row, int column)
        {
            if (row < arr.GetLength(0) && column < arr.GetLength(1))
                return;
            else
                throw new IndexOutOfRangeException("Ungültiger Index");
        }
    }

}
