namespace HelloRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
            PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");




            PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
            PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");


            #region Class vs Record  -> ==  Operator

            //Prüfung der Speicheradressen
            if (myPerson1Class == myPerson2Class)
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
            }

            //Prüfung der Werte
            if (personRecord1 == personRecord2)
            {
                Console.WriteLine("personRecord1 == personRecord2 -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
            }
            #endregion

            #region Equals - Methode
            if (myPerson1Class.Equals(myPerson2Class))
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
            }

            if (personRecord1.Equals(personRecord1))
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
            }
            #endregion
        }
    }

    public record Person (int Id, string Vorname, string Nachname, DateTime Geburtstag);


    public record Person2
    {
        public string FirstName { get; init; } //wir können nur zur Konstruktor-Zeit, die Property FirstName befüllen
        public string LastName { get; set; }

    }


    public record PersonRecord(int Id, string Name); //Init

    public class PersonClass
    {
        public PersonClass(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }


}