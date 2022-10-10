namespace DelegatesActionFuncSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegates
            //Delegate ChangeNumberDelegate hat die selbe Signatur, wie die Methode ChangeNumberOffSet5
            ChangeNumberDelegate changeNumberDelegate = new ChangeNumberDelegate(ChangeNumberOffSet5); //Funktionszeiger wird übergeben
            int result = changeNumberDelegate(11);

            Console.WriteLine($"Das Ergebis von ChangeNumberOffSet5 ist {result}");

            #region Operationen bei Delegates += und -= 
            //Operatoren bei Delegates += UND -= 
            changeNumberDelegate += ChangeNumberOffSet10; //weitere Funktionszeiger wird übergeben
            #endregion

            #region Mit direkten Aufruf erhalten wir das Return-Ergebnis nur von der LETZTEN Methode
            result = changeNumberDelegate(11);

            Console.WriteLine($"Das Ergebis von ChangeNumberOffSet5 oder ChangeNumberOffSet10 ist {result}");
            #endregion

            #region Wenn mehere Methoden an einem Delegate hängen, wäre  GetInvocationList() die bessere Verwendung
            result = 10;
            foreach (Delegate currentDelegate in changeNumberDelegate.GetInvocationList())
            {
                result = (int)currentDelegate.DynamicInvoke(result);
            }

            Console.WriteLine($"Ergebnis einer Kettenrechnung {result}");

            #endregion
            //ChangeNumberDelegate changeNumberDelegate = new ChangeNumberDelegate(ChangeNumberOffSet33);




            WriteLogDelegate writeLogDelegate = new WriteLogDelegate(WriteLogInDB);
            writeLogDelegate("Hallo liebe Teilnehmer");

            #endregion

            #region Action-Delegate
            //Action Delegate ist eine generische Klasse. 
            //Action Delegates können nur mit Methoden zusammenarbeiten, die ein VOID zurück geben 
            Action<string> logActionDelegate = new Action<string>(WriteLogInDB);
            logActionDelegate("Hallo liebe Teilnehmer");


            logActionDelegate += WriteLogInFile;

            foreach (Delegate currentDelegate in logActionDelegate.GetInvocationList())
                currentDelegate.DynamicInvoke("Hallo liebe Teilnehmer");

            #endregion

            #region Func-Delegate
            //Func-Delegate arbeiten mit Methoden zusammen, die einen Return-Weert besitzen
            //Bei der Defintion einer Func, ist der letzte Datentyp der Return-Datentyp
            //z.B Func<string, string, bool> loginDelegate -> username(string)/passwort(string) -> bool = login oder fail als Returnwert 
            
            Func<decimal, decimal> func = new Func<decimal, decimal>(ChangeNumberOffSet33);
            #endregion
        }


        public static int ChangeNumberOffSet5(int number)
            => number += 5; //Zahl wird um den Wert 5 erhöht

        public static int ChangeNumberOffSet10(int number)
            => number += 10;

        public static decimal ChangeNumberOffSet33(decimal number)
            => number += 3; //Zahl wird um den Wert 5 erhöht

        public static void WriteLogInDB (string msg)
            => Console.WriteLine(msg);

        public static void WriteLogInFile(string msg)
           => Console.WriteLine(msg);
    }

    //Delegates sind Datentypen 
    //Delegates können nur mit bestimmten Methoden zusammenarbeiten 
    public delegate int ChangeNumberDelegate(int num);

    public delegate void WriteLogDelegate(string msg);
}