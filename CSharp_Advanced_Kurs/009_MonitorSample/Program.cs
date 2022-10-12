using System.Threading.Tasks.Sources;

namespace _009_MonitorSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        static void KritischerCodeAbschnitt()
        {
            int x = 1;

            if (Monitor.TryEnter(x))
            {
                try
                {
                    //Codeabschnitt meines tuns
                    //Fehler in dieser Zeile -> Wird Monitor.Exit(x) nicht ausgeführt
                    //Monitor.Exit(x);

                    //Untermethoden mit Param
                    SubMethode(ref x);
                }
                finally
                {
                    //Wird immer aufgerufen (auch im Fehlerfall) 
                    Monitor.Exit(x);
                }

            }
        }


        static void SubMethode(ref int flagParameter)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                Monitor.Exit(flagParameter);

        }

    }
}