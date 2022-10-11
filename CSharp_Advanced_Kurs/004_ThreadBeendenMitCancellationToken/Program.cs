namespace _004_ThreadBeendenMitCancellationToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.) Methode mit Parameter mit Thread initialisiert
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas);
            Thread thread = new Thread(parameterizedThreadStart);

            //Ab .NET 4.0 im Rahmen von TPL ist die Klasse CancellationTokenSource und CancellationToken hinzugekommen
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            thread.Start(token);

            Thread.Sleep(3000);
            tokenSource.Cancel(); //Nach 3 Sekunden signalisieren wir, dass wir den Thread beenden wollen 


        }

        /// <summary>
        /// Methode läuft 10 Sekunden lang und gibt Schnarch aus
        /// </summary>
        /// <param name="param"> CancellationToken wird übergeben. Seine Aufgabe ist das Empfangen des Signales, dass der Thread beendet werden soll </param>
        private static void MachEtwas(object param)
        {
            try
            {


                if (param is CancellationToken cancellationToken)
                {
                    ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas2);
                    Thread thread2 = new Thread(parameterizedThreadStart);
                    thread2.Start(cancellationToken);


                    for (int i = 0; i < 50; i++)
                    {
                        Console.WriteLine("schnaaarchSchnaaaarch");
                        Thread.Sleep(200);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested(); //OperationCanceldException wird ausgelöst
                        }
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Thread wird beendet: " + ex.ToString());
            }
        }


        private static void MachEtwas2 (object param)
        {
            try
            {
                if (param is CancellationToken cancellationToken)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Console.WriteLine("schnaaarchSchnaaaarch");
                        Thread.Sleep(200);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested(); //OperationCanceldException wird ausgelöst
                        }
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Thread wird beendet: " + ex.ToString());
            }
        }
    }
}