namespace Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;

        static void Main(string[] args)
        {
            if (IsSingleInstance())
            {
                Console.WriteLine("One Instances");
            }
            else
                Console.WriteLine("More than one instance");


            Console.ReadLine();
        }

        static bool IsSingleInstance()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                return false; //Zweite Instance wurde gefunden. 
            }
            else
            {
                mutex = new Mutex(false, "ABC");

                return true;
            }
        }
    }
}