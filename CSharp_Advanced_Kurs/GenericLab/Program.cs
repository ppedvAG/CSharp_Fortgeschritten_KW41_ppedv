using System.Collections;

namespace GenericLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was sind Wertetypen: int, float, decimal, bool, long, float, struct, enum
            //Was sind Referenztypen: class, interfaces, string


            PersonClass personClass = new PersonClass() { Alter = 30 };
            PersonStruct personStruct = new PersonStruct() { Alter = 30 };

            PersonAlternClass(personClass);
            PersonAlternStruct(personStruct);

            Console.WriteLine(personClass.Alter);
            Console.WriteLine(personStruct.Alter);

            #region ReferenzTypen Beispiel
            IList<City> cities = new List<City>();
            cities.Add(new City { Name = "LA" });
            cities.Add(new City { Name = "Seattle" });

            City currentCity = cities[0];
            currentCity.Name = "Los Angeles";

            foreach (City city in cities)
                Console.WriteLine(city.Name);
            #endregion


            ////DataStore<T> where T : class

            //DataStore<string> store1 = new DataStore<string>();
            //DataStore<MyClass> store2 = new DataStore<MyClass>();
            //DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();
            //DataStore<MyStruct> store4 = new DataStore<MyStruct>();
            //DataStore<int> store5 = new DataStore<int>();
            //DataStore<ArrayList> store6 = new DataStore<ArrayList>();
            //DataStore<MyRecord> store7 = new DataStore<MyRecord>();


            //////DataStore1<T> where T : struct 
            //DataStore1<string> store7 = new DataStore1<string>();
            //DataStore1<MyClass> store8 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store9 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store10 = new DataStore1<MyStruct>();
            //DataStore1<int> store11 = new DataStore1<int>();
            //DataStore1<MyRecord> store7 = new DataStore1<MyRecord>();


        }



        private static void PersonAlternClass(PersonClass p) //Referenz wird weitergegeben 
            => p.Alter++;


        //Wertetypen übergeben eine Kopie, Ihres Wertes in eine neue Speicheradresse rein 
        private static void PersonAlternStruct(PersonStruct s) //Neue Speicheradresse wird angelegt 
            => s.Alter++;

    }

    public class City
    {
        public string Name { get; set; }
    }

    public class PersonClass
    {
        public int Alter { get; set; }
    }

    public struct PersonStruct
    {
        public int Alter { get; set; }
    }
































    //In T dürfen nur Referenztypen (Klasse, Interfaces, string, List<T>,  .... )
    public class DataStore<T> where T : class
    {
    }

    //In T dürfen nur Wertettypen (Structs, Enums?, int, float, bool, double, chars ) 
    public class DataStore1<T> where T : struct
    {

    }
    // In T dürfen nur Animal oder abgeleitete Klasse von Animal (Vererbungsbaum) 
    public class DataStore2<T> where T : Animal
    {

    }

    //Hier dürfen nur Objekte, die einen Default-Konstruktor beinhalten
    public class DataStore3<T> where T : new()
    {

    }



    public class Animal
    {
        //ctor
        public Animal() //<- Default-Konstruktor
        {
            //hier darf stehen 
        }
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "ein wau wau";
    }

    public record MyRecord
    {

    }
    public class MyClass
    {

    }

    public interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }

    public class MyDictionary<TKey, TItem> where TKey : struct
    {
        public void Add(TKey key, TItem item)
        {
            //...
        }

        public TItem GetByKey(TKey key)
        {
            // 

            return default(TItem);
        }

        public void DataTypeOftheYear<DataType>(DataType theType)
        {
        }
    }


    public interface IGenericInterface<T> where T : class
    {

    }

}