namespace _007_ThreadPoolSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ThreadPool.SetMaxThreads
            //Methode 1 mit Parameter
            ThreadPool.QueueUserWorkItem(Methode1, 123);

            //Methode 2 ohne Parameter
            ThreadPool.QueueUserWorkItem(Methode2);
            ThreadPool.QueueUserWorkItem(Methode3);



            Console.ReadLine();
        }


        static void Methode1(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("#");
            }
        }

        static void Methode2(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("+");
            }
        }

        static void Methode3(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("%");
            }
        }
    }
}