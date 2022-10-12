namespace _007_ContinueWithParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Beispiel1

            Task<string> task = Task.Run(DayTime);
            //task.Result;

            Task weitereFolgetask = task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            Task<string> translateTask = weitereFolgetask.ContinueWith<string>(weitereFolgetask => GiveMessage(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            translateTask.ContinueWith(translateTask => ShowDayTime(translateTask.Result), TaskContinuationOptions.OnlyOnRanToCompletion);


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