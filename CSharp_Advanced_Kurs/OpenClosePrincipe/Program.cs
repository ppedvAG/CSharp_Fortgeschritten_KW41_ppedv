namespace OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    #region Bad SourceCode
    // Diese Methode verwendet komplexe Drittanbieter 

    public class BadReportGenerator
    { 
        public int ReportType { get; set; }

        public void Generate (Employee em)
        {
            if (ReportType == 1)
            {
                //PDF wird erstellt

                //Wir verwenden eine PDF.DLL 
                //Watermark
                //CompressRate
                //Settings
            }
            else if (ReportType == 2)
            {
                //CR wird erstellt

                //Template - Path
                //Ausgabe - Path
            }
            else if (ReportType == 3)
            {
                //List&Label 10 
            }
            else
            {
                //...
            }
        }
    }
    #endregion



    #region Lösung 1
    //Abstrakte Klasse
    public abstract class GeneratorBase
    {
        public abstract void Generate (Employee em);

        protected void CentralLogicMethode()
        {
            //gemeinsame Logiken oder Hilfsmede
        }
    }

    public class PDFGenerator : GeneratorBase
    {
        //Verschiede Properties, die für PDF ausgerichtet sind
        public override void Generate(Employee em)
        {
            //Wir erstellen ein PDF-Dokument
        }

        //weitere Methoden...bei Bedarf
    }

    public class CRGenerator : GeneratorBase
    {
        //Verschiede Properties, die für CR ausgerichtet sind
        public override void Generate(Employee em)
        {
            //Wir erstellen ein CR-Dokument
        }
    }
    #endregion

    #region Lösung 2

    public interface IGenerator
    {
        public void Generate (Employee em); 
    }

    public class PDFGenerator2 : IGenerator
    {
        public void Generate(Employee em)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}