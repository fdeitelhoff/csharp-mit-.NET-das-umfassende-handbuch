using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle kreis1 = null;
            Circle kreis2 = null;
            try
            {
                kreis1 = new Circle();
                kreis1.InvalidMeasure += kreis_InvalidMeasure;
                kreis1.Radius = -100;
                kreis2 = new Circle(-89);
                kreis2.Radius = -9;
            }
            catch (InvalidMeasureException ex)
            {
                Console.WriteLine("Im Catch-Block: " + ex.Message);
                Console.WriteLine($"Log-Daten: {ex.Data["Time"]}");
            }
            Console.ReadLine();
        }
        // der Ereignishandler
        static void kreis_InvalidMeasure(object sender, InvalidMeasureEventArgs e)
        {
            Console.WriteLine("Ereignishandler: " + e.Error.Message);
        }
    }

}
