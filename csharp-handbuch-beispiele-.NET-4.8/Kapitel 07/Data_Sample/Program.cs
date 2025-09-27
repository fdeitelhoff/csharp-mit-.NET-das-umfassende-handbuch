using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sample
{
    class Program
    {
        static void Main(string[] args) {
            try  {
                DoSomething();
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"{ex.Data["Info"]} {ex.Data["Date"]}");
            }
            Console.ReadLine();
        }
        static void DoSomething()
        {
            Exception ex = new Exception();
            ex.Data.Add("Info", "Datum/Zeit:");
            ex.Data.Add("Date", DateTime.Now);
            throw ex;
        }
    }

}
