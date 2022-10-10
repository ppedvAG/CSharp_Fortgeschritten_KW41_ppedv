namespace LizkovischePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Anti-Code Beispiel

    public class Erdbeere
    {
        public string GetColor()
            => "red";

        public string GetColourAlternativ()
        {
            return "red";
        }
    }

    public class Kirsche : Erdbeere
    {
        public string GetColor()
            => base.GetColor();
    }

    #endregion

    #region Bessere Variante

    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Melone : Fruits
    {
        public override string GetColor()
        {
            return "gelb";
        }
    }

    public class Apfel : Fruits
    {
        public override string GetColor()
        {
            return "grün";
        }
    }

    #endregion


}