namespace _002_Task_beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, cts.Token);
                task.Start();

                Task.Delay(3000).Wait();
                cts.Cancel();
                //Ausgeschriebene Alternative
                //Task delayTask = Task.Delay(3000);
                //delayTask.Wait();
            }
            finally
            {
                cts.Dispose(); //CancellationTokenSource wird expliziet abgebaut 
            }

            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationToken cancellationToken = (CancellationToken)param;

            try
            {
                while (true)
                {
                    Console.WriteLine("schnarch....");
                    Task.Delay(50).Wait();

                    if (cancellationToken.IsCancellationRequested)
                        cancellationToken.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}