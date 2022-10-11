namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MacheEtwasInEinemThread);
            Thread thread = new Thread(parameterizedThread);

            thread.Start(600); //Wollen 600x die Raute-Zeichen ausgebeben
            
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }

        private static void MacheEtwasInEinemThread(object obj)
        {
            //Wenn obj eine Integer-Zahl beinhaltet, wird diese nach 'until' gecastet
            if (obj is int until)
            {
                for (int i = 0; i < until; i++)
                {
                    Console.WriteLine(i.ToString() + " #");
                }
            }
        }
    }
}