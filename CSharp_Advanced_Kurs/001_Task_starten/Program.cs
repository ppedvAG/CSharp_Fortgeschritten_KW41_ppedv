namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TPL -> Task Parallel Library (ab .NET 4.0) 
            //Neues Namespace -> System.Threading.Tasks

            Task task = new Task(MacheEtwasInEinemThread); //Funktionszeiger wird übergeben 
            task.Start();
            task.Wait(); //Callback-Funktion -> Warten bis Task fertig ist 
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