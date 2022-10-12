using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderBenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //ein string wird als feste im Arbeitsspeicher reserviert (6 Speicheraddresse) 
            string hallo = "Hallo ";
            hallo += "Kevin";




            string aufbauenderString = string.Empty;

            //System.Diagnostics.Stopwatch
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                aufbauenderString += i.ToString(); //Performance - Killer! 
            }
            stopwatch.Stop();
            long testErgebnis1 = stopwatch.ElapsedMilliseconds;


            Console.WriteLine("Taste drücken......");
            Console.ReadKey();


            //System.Text;
            StringBuilder sb = new StringBuilder();

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i); //Strings werden mit Append hinzugefügt 
            }
            string output = sb.ToString(); //ToString() = kompletter String wird ausgelifert 
            stopwatch1.Stop();

            long testErgebnis2 = stopwatch1.ElapsedMilliseconds;

            Console.WriteLine("Benchmark Endergebnis");
            Console.WriteLine($"Ergebnis aus einfachen addieren - Zeit: {testErgebnis1}");
            Console.WriteLine($"Testergebnis - StringBuilder - Zeit: {testErgebnis2}");
            Console.ReadLine();
        }
    }
}
