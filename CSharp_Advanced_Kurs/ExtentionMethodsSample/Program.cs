using ExtentionMethodsSample.WeiteresNamespace;

namespace ExtentionMethodsSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new ();
            person.Name = "Max Muster";
            person.Email = "Max@Muster.de";

            person.SendEmail("kevinw@ppedv.de", "Der Kurs war lehrreich");
        }
    }

    public class Person
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}

namespace ExtentionMethodsSample.WeiteresNamespace
{
    public static class PersonExtentionMethods
    {
        public static void SendEmail(this Person p, string ToEmailAdress, string EmailBody)
        {
            Console.WriteLine($"{p.Name} sendet eine Email an {ToEmailAdress}");
        }
    }
}