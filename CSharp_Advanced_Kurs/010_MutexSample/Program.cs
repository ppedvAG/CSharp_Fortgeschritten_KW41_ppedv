namespace _010_MutexSample
{
    internal class Program
    {
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void KritischerCodeAbschnitt()
        {
            mutex = new Mutex(false, "MyMutexInfo");

            bool lockToken = false;

            try
            {
                //wird auf true gesetzt
                lockToken = mutex.WaitOne();


                //Kritischer Code
            }
            finally
            {
                if (lockToken)
                    mutex.ReleaseMutex(); //Freigabe
            }
        }
    }
}