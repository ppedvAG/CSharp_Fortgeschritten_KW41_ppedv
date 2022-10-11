using System.Threading;

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Der Thread-Konstruktor verwendet ein Delegate 

            //1.) Starten die Methode MachEtasInEinemThread in einem Thread-Kontext (Thread-Ids) 
            //2.) Das Ergebnis oder eine Fehlermeldung werden via Callbacks an den Haupt-Thread zurück gegeben 

            Thread thread = new Thread(MacheEtwasInEinemThread); //Funktionszeiger einer Methode wird übergeben
            thread.Start();

            
            thread.Join(); //Calback bekommen wir hier, dass der Thread mit seiner Arbeit fertig ist 
            //Können auch mit thread.Join() solange warten, bis die Methode 'MacheEtwasInEinemThread' fertig durchgelaufen ist


            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }


        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}