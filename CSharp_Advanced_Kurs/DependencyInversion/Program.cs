namespace DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService service = new CarService();

            service.Repair(new TestCar());

            service.Repair(new Car() { Marke = "Porsche", Modell = "311" });
        }
    }

    #region BadCode
    //Programmierer A: 5 Tage (Agenda -> Tag 1 bis Tag 5)
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }

        //...
    }

    //Programmierer B: 3 Tage -> Tag 5/6 bis 8/9
    public class BadCarService
    {
        //Feste Kopplung -> Die Klasse BadCarService kennt die Klasse BadCar
        public void Repair (BadCar car) 
        {
            //Auto wird repariert 
        }
    }
    #endregion


    #region Good Code
    public interface ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
    }

    public interface ICarService
    {
        void Repair (ICar car);   
    }

    //Programmierer A -> 5 Tage (Tag1 bis Tag5)
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
    }

    //Programmierer B -> 3 Tage (Tag1 bis Tag3)
    public class CarService : ICarService
    {
        public void Repair(ICar car) //Lose Kopplung 
        {
            //repariere das Auto 
        }
    }


    public class TestCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
    }
    #endregion


}