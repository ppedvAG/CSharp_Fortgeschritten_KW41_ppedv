namespace JahrmarktBeispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Todo-Liste
            IList<Jahrmarkstand> listeDerZuBesuchendenJahrmarktstaende = new List<Jahrmarkstand>();

            listeDerZuBesuchendenJahrmarktstaende.Add(new AutoScooter());
            listeDerZuBesuchendenJahrmarktstaende.Add(new HorrorCabinett());
            listeDerZuBesuchendenJahrmarktstaende.Add(new SchnellsteAchterbahnDerWelt());



            foreach (Jahrmarkstand jahrmarkstand in listeDerZuBesuchendenJahrmarktstaende)
            {
                if (jahrmarkstand is IFSK18 jahrmarkstandMitAltersCheck)
                {
                    if (jahrmarkstandMitAltersCheck.CheckAge(17))
                    {
                        Console.WriteLine("Darf fahren");
                    }
                    else
                    {
                        Console.WriteLine("Darf nicht fahren");
                    }
                }
            }
        }
    }

    public interface IFSK18
    {
        bool CheckAge(int alter);


        //Default-Implementierung eines Interface
        bool CheckAge2(int alter)
        {
            return alter < 18 ? true : false;   
        }
    }

    public class Jahrmarkstand
    {
        public int MitarbeiterAnzahl { get; set; }  

        public int Quatratmeter { get; set; }

        public DateTime OeffnetUm { get; set; }
        public DateTime SchliesstUm { get; set; }

        public decimal Eintritt { get; set; }

        public string Name { get; set; }
        
    }

    public class AutoScooter : Jahrmarkstand
    {
        public int AnzahlDerAutos { get; set; }
    }

    public class HorrorCabinett : Jahrmarkstand, IFSK18
    {
        public int SchockerAnzahl { get; set; }

        public bool CheckAge(int alter)
        {
            return alter < 18 ? false : true; 
        }
    }

    public class SchnellsteAchterbahnDerWelt : Jahrmarkstand, IFSK18
    {
        public int Bahnstrecke { get; set; }

        public double Geschwindigkeit { get; set; }

        public bool CheckAge(int alter)
        {
            return alter < 18 ? false : true;
        }
    }
}