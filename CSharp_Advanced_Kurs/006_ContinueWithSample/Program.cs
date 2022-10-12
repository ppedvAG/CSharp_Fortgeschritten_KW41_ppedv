namespace _006_ContinueWithSample
{
    internal class Program
    {

        private static int[] Lottozahlen = new int[7];

        
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task1 - Lottozahlen werden ermittelt");

                Lottozahlen[0] = 2;
                Lottozahlen[1] = 12;
                Lottozahlen[2] = 22;
                Lottozahlen[3] = 32;
                Lottozahlen[4] = 42;
                Lottozahlen[5] = 52;
                Lottozahlen[6] = 62;

                //throw new Exception();
            });

            t1.Start();

            //Verwendet intern ein Wait (Callback) 



            Task t2 = t1.ContinueWith(t => AllgemeinerFolgetask()); //Werde immer auferufen
            //Weiterer Folgetask, wenn AllgemeinerFolgetask fertig ist

            t2.ContinueWith(t => AllgemeinerFolgetask2());


            t1.ContinueWith(t => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);
            t1.ContinueWith(t => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);


            Console.WriteLine("Main Done");
            Console.ReadLine();
        }

        private static void AllgemeinerFolgetask()
            => Console.WriteLine("Werde immer aufgerufen");

        private static void AllgemeinerFolgetask2()
            => Console.WriteLine("Werde auch immer aufgerufen");

        private static void FolgetaskBeiFehler()
            => Console.WriteLine("Ich werde für Aufräumarbeiten aufgerufen, wenn im vorigen Task ein Fehler enstanden ist");

        private static void FolgetaskBeiErfolg()
            => Console.WriteLine("Werde im Erfolgsfall aufgerufen");
    }
}