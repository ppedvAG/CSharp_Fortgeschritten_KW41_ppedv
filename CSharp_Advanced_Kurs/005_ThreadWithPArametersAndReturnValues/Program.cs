namespace _005_ThreadWithPArametersAndReturnValues
{
    internal class Program
    {
        private static string meinText = "hello world";
        private static string retString = string.Empty;


        static void Main(string[] args)
        {
            //Variante 1 mit anonyme Methode 
            Thread thread = new Thread(() =>
            {
                //Thread-Kontext 
                retString = StringToUpper(meinText);
            });

            thread.Start();//brauche ich das? Oder wird direkt gestartet?

            thread.Join();


            Thread.Sleep(5000);

            //Variante 2 mit ausgelagerte Methode
            //Thread thread2 = new Thread(AusgelagerteMethode);
            //thread2.Start();
            //thread2.Join();

            Console.ReadLine();

        }

        private static string StringToUpper(string param)
         => param.ToUpper();

        public static void AusgelagerteMethode()
        {
            retString = StringToUpper(meinText);
        }
    }
}