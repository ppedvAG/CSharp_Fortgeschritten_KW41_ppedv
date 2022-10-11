namespace IOCSampleInWebAPI.Services
{
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
