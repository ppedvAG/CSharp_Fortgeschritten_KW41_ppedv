namespace _003_Thread_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas);
            thread.Start();

            Thread.Sleep(3000); //Nach drei Sekunden, wollen wir den Thread abbrechen

            //thread.Abort(); -> Obselete
            thread.Interrupt();

            Console.ReadLine();
        }


        private static void MachEtwas()
        {

            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("zzZZZZzzzzZZZzzzzZZzz");
                    Thread.Sleep(200); //Wir warten 0.2 Sek
                }
            }
            catch (ThreadInterruptedException ex) //von thread.Interruppt eskaliert
            {
                Console.WriteLine("Methode wurde mit Interrupt beendet " + ex.Message);
            }
        }
    }
}