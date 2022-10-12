namespace Task_MitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new Katze(); //Parameter zum Übergeben angelegt 


            //Variante 1
            Task<string> task1 = new Task<string>(MachEtwas, katze);
            task1.Start();
            task1.Wait();
            Console.WriteLine(task1.Result);

            //Variante 2 (verkürzte Schreibweise mit Lambda) 
            Task<string> task2 = new Task<string>(()=>MachEtwas(katze)); 
            task2.Start();
            task2.Wait();
            Console.WriteLine(task2.Result);

            //Factory 

            Task<string> task3 = Task.Factory.StartNew(MachEtwas, katze);
            task3.Wait();
            Console.WriteLine(task3.Result);

            //Task.Run
            Task<string> task4 = Task.Run(() => MachEtwas(katze));
            task4.Wait();
            string result = task4.Result;



        }


        private static string MachEtwas(object input)
        {
            if (input is Katze katze)
            {
                return katze.Name;
            }

            //Wenn alles andere als eine Katze in der Variable 'input' -> dann Fehler bei der Übergabe -> ArgumentException 
            throw new ArgumentException();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}