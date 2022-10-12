namespace _007a_ThreadPool_CancelThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ab .NET 4.0 im Rahmen von TPL ist die Klasse CancellationTokenSource und CancellationToken hinzugekommen
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(MachEtwas, tokenSource.Token);
            }
            Thread.Sleep(3000);
            tokenSource.Cancel();
            Console.ReadLine();
        }


        private static void MachEtwas(object? param)
        {
            CancellationToken token = (CancellationToken)param;

            try
            {
                //10 Sekunden in der Schlafschleife
                for (int i = 0; i < 500; i++)
                {
                    Console.WriteLine("zzZZZZzzzzZZZzzzzZZzz");
                    Thread.Sleep(200); //Wir warten 0.2 Sek

                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    token.WaitHandle.WaitOne(1000);
                }
            }
            catch (OperationCanceledException ex) //von thread.Interruppt eskaliert
            {
                Console.WriteLine("Methode wurde beendet " + ex.Message);
                
            }
        }
    }
}