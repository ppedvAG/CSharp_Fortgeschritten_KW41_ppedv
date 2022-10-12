namespace _005_TaskMitExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;


            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();

                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);

                t4 = Task.Run(MachKeinenFehler);

                Task.WaitAll(t1, t2, t3, t4); //Ab hier bekommen wir mit, ob es eine Exception gab 
            }
            catch ( AggregateException ex)
            {
                foreach (Exception ex2 in ex.InnerExceptions )
                {

                    Console.Write("Exception.Message: ");
                    Console.WriteLine(ex2.Message);
                    Console.WriteLine("-------------------------");

                    //Console.Write("Exception.StackTrace (Wo ist der Fehler passiert): ");
                    //Console.WriteLine(ex2.StackTrace);
                    //Console.WriteLine("-------------------------");


                    //Console.Write("Exception.ToString() (Kombination aus Fehlermeldung und StackTrace): ");
                    //Console.WriteLine(ex2.ToString());
                    //Console.WriteLine("-------------------------");
                }
            }

            #region Abfragen des Task-Verlaufs 


            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig");

            if (t3.IsFaulted)
                Console.WriteLine("Task 3 hat einen Fehler");

            if (t3.IsCompletedSuccessfully)
                Console.WriteLine("Task 3 ist sauber durchgelaufen");

            if (t3.IsCanceled)
                Console.WriteLine("Wurde beendet -> CancellationTokenSource / CancellationToken");


            if (t4.IsCompleted)
                Console.WriteLine("Task 3 ist fertig");

            if (t4.IsFaulted)
                Console.WriteLine("Task 3 hat einen Fehler");

            if (t4.IsCompletedSuccessfully)
                Console.WriteLine("Task 3 ist sauber durchgelaufen");

            if (t4.IsCanceled)
                Console.WriteLine("Wurde beendet -> CancellationTokenSource / CancellationToken");

            #endregion


        }

        private static void MachEinenFehler1()
        {
            Task.Delay(3000).Wait();

            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Task.Delay(6000).Wait();
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Task.Delay(9000).Wait();
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
            => Console.WriteLine("Einen schönen Tag");
    }
}