namespace _010_AsyncAwaitSample
{
    internal class Program
    {
        
        //Async Await:

        //1.) Wenn wir bei einer Methode (Die ein Task-Objekt zurück gibt) das Keyword 'AWAIT' verwenden, dann MÜSSEN wir, 'ASYNC' in den MethodenKopf hinzufügen
        static async Task Main(string[] args)
        {
            #region Beispiel1

            string dayTimeResult = await Task.Run(DayTime);

            await Task.Run(()=>ShowDayTime(dayTimeResult));

            string translatedDayTime = await Task.Run(() => GiveMessage(dayTimeResult));

            await Task.Run(() => ShowDayTime(translatedDayTime));
            #endregion


            #region Beispiel1

            Task<string> task = Task.Run(DayTime);
            await task;

            await task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);


           
            #endregion

            Console.ReadLine();
        }


        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static string GiveMessage(string daytime)
        {
            if (daytime == "evening")
                return "Guten Abend";
            else if (daytime == "afternoon")
                return "Guten Nachmittag";
            else
                return "Guten Morgen";

        }

        public static void ShowDayTime(string result)
            => Console.WriteLine(result);
    }
}