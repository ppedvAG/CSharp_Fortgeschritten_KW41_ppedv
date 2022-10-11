using Microsoft.Extensions.DependencyInjection;

namespace IOCSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Initialisierung Phase
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ITimeService, TimeService>();
            
            //Mit BuildServiceProvider schließen wir die Initialisierung-Phase ab
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            #endregion

            #region Verwenden eines IOC Containers

            //WEnn ITimeService nicht gefunden wird, wird NULL zurück gegeben
            ITimeService? timeService1 = serviceProvider.GetService<ITimeService>();


            //Wenn ITimeService nicht gefunden wird, wird eine Exception geworfen
            ITimeService timeService2 = serviceProvider.GetRequiredService<ITimeService>();
            #endregion
        }
    }


    public interface ITimeService
    {
        string GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime time;

        //ctor + Tab + Tab -> Konstruktor
        public TimeService()
        {
            time = DateTime.Now;
        }

        public string GetCurrentTime()
        {
            return time.ToString();
        }
    }
}