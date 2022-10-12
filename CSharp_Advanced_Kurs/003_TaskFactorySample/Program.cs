namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.NET 4.0 -> Task

            Task task1 = new Task(MacheEtwasInEinemThread);
            
            task1.Start();
            task1.Wait();

            //.NET 4.0 -> TasFactory
            Task task2 = Task.Factory.StartNew(MacheEtwasInEinemThread); //Thread-Methode wird sofort gestartet 
            task2.Wait();

          
            //.NET 4.5 -> Task.Run -> 
            Task task3 = Task.Run(MacheEtwasInEinemThread);
            task3.Wait();
        }


        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");
        }
    }
}