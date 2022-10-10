namespace InterfaceSegerationPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region BadCode

    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Swim();
    }


    public class Vehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Vehicle kann fahren");
        }

        public void Fly()
        {
            Console.WriteLine("Vehicle kann fliegen");
        }

        public void Swim()
        {
            Console.WriteLine("Vehicle kann schwimmen");
        }
    }

    public class AmphibischesFahrzeug : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Kann fahren");
        }

        public void Swim()
        {
            Console.WriteLine("Kann schwimmen");
        }

        //Methode Fly macht in der Klasse AmphibischesFahrzeug keinen Sinn 
        public void Fly()
        {
            throw new NotImplementedException();
        }

        
    }
    #endregion

    #region Good Code

    public interface IDrive
    {
        void Drive();
    }

    public interface ISwim
    {
        void Swim();
    }

    public interface IFly
    {
        void Fly();
    }


    public class Vehicle2 : IDrive, ISwim, IFly
    {
        public void Drive()
        {
            //Kann fahren
        }

        public void Fly()
        {
            //Kann fliegen
        }

        public void Swim()
        {
            //Kann schwimmen
        }
    }


    public class AmphibischesFahrzeug2 : IDrive, ISwim
    {
        public void Drive()
        {
            //Kann fahren
        }

        public void Swim()
        {
            //Kann schwimmen
        }
    }

    #endregion
}