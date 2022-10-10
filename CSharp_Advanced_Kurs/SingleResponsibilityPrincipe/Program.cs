namespace SingleResponsibilityPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region unpraktischer Quellcode

    // Die Klasse BadEmployee hat zuviele Aufgaben 
    // Datenstrutktue (Id / Name)
    // Methode (InsertEmployeeToDb), die eher im DataAccessLayer aufgehoben ist
    // GenerateReport 
    public class BadEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void InsertEmployeeToDb(BadEmployee employee)
        {
            //Speichere einen Employee Datensatz in die Employee - Tabelle
        }

        //ServiceLayer 
        public void GenerateReport()
        {
            //Erstellen einen Report...
        }
    }
    #endregion

    #region Datenstruktur

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class EmployeeRepository
    {
        public void Insert(Employee em)
        {
            //Speichere Datensatz ab
        }
    }

    public class ReportGenerator
    {
        public void Generate()
        {
            //generiere Report
        }
    }
    #endregion
}