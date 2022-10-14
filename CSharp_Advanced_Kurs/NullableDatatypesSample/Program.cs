namespace NullableDatatypesSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ist der Wert '0' eine INITIALISIERUNG oder EIN ERGEBNIS
            int myNumber;


            int? myBetterNumber = null; //Nullable Datentypen können NULL entgegen nehmen

            myBetterNumber = 123;

            myBetterNumber += 123;

            if (myBetterNumber.HasValue) //bist du NULL oder hast du einen nummerischen Wert
            {
                Console.WriteLine(myBetterNumber.Value);
            }


            string str = string.Empty;

            if (!string.IsNullOrEmpty(str))
            {
                //string.IsNullOrEmpty kann man bei Strings verwenden, um NULL oder Leerstring herauszufinden
            }

        }
    }
}