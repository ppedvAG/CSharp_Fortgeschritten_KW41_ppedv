namespace LinqLambdaSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            IList<Person> emptyList = new List<Person>();

            #region Unterschied zwischen Linq-Statement und Linq-Functions mit Lamdas
            //Linq-Statement -> Linq verwendet Keywords (from/where/orderby/select/....)
            //benötigt: using System.Linq;


            //REFERENZ -> 101 Samples -> https://learn.microsoft.com/en-us/samples/dotnet/try-samples/101-linq-samples/
            IList<Person> personsBetween40And50 = (from p in persons
                                                   where p.Age >= 40 && p.Age <= 50
                                                   orderby p.Nachname
                                                   select p).ToList();

            //Linq-Functions + Lambda Statements


            //REFERENZ -> 101 Samples -> https://linqsamples.com/
            IList<Person> personenBetween40And50 = persons.Where(e => e.Age >= 40 && e.Age <= 50)
                                                          .OrderBy(e => e.Nachname)
                                                          .ToList();



            
            #endregion


            #region Calculator Funktionen 

            double altersdurschnittAllerPersonen = persons.Average(p => p.Age);

            double alersdurchschnittAllerPersonenUeber40 = persons.Where(p => p.Age >= 40)
                                                                  .Average(p => p.Age);

            int alterAllerMitarbeiter = persons.Sum(p => p.Age);
            #endregion


            #region Einzelne Datensätze ermitteln

            //First / FirstOrDefault
            Person erstePerson = persons.First(); //Gebe mir den ersten Datensatz aus der Liste 'persons'
            Person? erstePersonOderDefaul = emptyList.FirstOrDefault();

            //Last / LastOrDefault
            Person letztePerson = persons.Last(); //Gebe mir den ersten Datensatz aus der Liste 'persons'
            Person? letztePersonOderDefaul = emptyList.LastOrDefault();


            //Single / SingleOrDefault
            Person personMitID3 = persons.Single(p => p.Id == 3);
            Person? personMitID33 = persons.SingleOrDefault(p => p.Id == 33);

            //Es gibt bei First/FirstOrDefault UND Last/LastOrDefault 

            Person? personMitID4 = persons.First(p => p.Id == 4);
            Person? personMitID44 = persons.FirstOrDefault(p => p.Id == 44);
            #endregion

            #region Datensatzzahl + Mengen 

            //Property Count ist die schnellste Variante um eine Anzahl von Datensätze zu ermiteln
            int anzahlDatensätze = persons.Count;

            //langsamer, aber viel flexibler
            int anzahlDatensätzeB = persons.Count(); //Linq-Function 
            anzahlDatensätzeB = persons.Count(p => p.Age > 40);


            //langsamer, aber viel felixbler als person.Count

            //Ist in Benchmarktest ein paar Millisekunden schneller als Count(p=>p.Age > 40)
            bool isAvailable = persons.Any();
            bool isAvailable2 = persons.Any(p => p.Age > 40);
            #endregion


            #region Paging
            int pagingSize = 3; //Anzahl der Datensätze, die auf einer ERgebnisseite angezeigt werden
            int pagingNumber = 1;

            

            IList<Person> ersteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            //Simulirtes blättern 
            pagingNumber = 2;
            IList<Person> zweiteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumber = 3;
            IList<Person> dritteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
            #endregion
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}