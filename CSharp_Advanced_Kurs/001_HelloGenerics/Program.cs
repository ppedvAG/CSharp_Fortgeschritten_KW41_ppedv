

namespace _001_HelloGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generische Klassen -> IList<T> / List<T> 
            IList<City> cities = new List<City>();
            List<City> cities2 = new List<City>();

            

            cities.Add(new City() { Name = "Hamburg", Population = 1800000 });

            foreach (City currentCity in cities)
                Console.WriteLine(currentCity.Name);
            #endregion



            #region IDictionary / Dictionary
            Dictionary<int, City> cityDictionary = new Dictionary<int, City>();

            cityDictionary.Add(1, new City() { Name = "Hamburg", Population = 1800000 });

            if (!cityDictionary.ContainsKey(2))
                cityDictionary.Add(2, new City() { Name = "München", Population = 1600000 });

            cityDictionary.Add(3, new City() { Name = "Köln", Population = 1100000 });
            cityDictionary.Add(4, new City() { Name = "Berlin", Population = 3700000 });
            
            //Durchlaufen mit KeyValuePair durch ein Dictionary 
            foreach (KeyValuePair<int, City> keyValuePair in cityDictionary)
            {
                Console.WriteLine(keyValuePair.Key);
                Console.WriteLine(keyValuePair.Value);
            }

            //cityDictionary.Add();




            IDictionary<int, City> cityDictionary2 = new Dictionary<int, City>();

            KeyValuePair<int, City> newCity = new KeyValuePair<int, City>(5, new City { Name = "Paris", Population = 4000000 });

            cityDictionary2.Add(newCity);
            #endregion



            #region Eigene Generische Liste
            DataStore<City> cityDataStore = new DataStore<City>();
            cityDataStore.AddOrUpdate(0, new City { Name = "New York", Population = 18000000 });

            //Aufruf einer generische Methode
            cityDataStore.GenerischeMethode<string>();

            #endregion

        }
    }

    public class City
    { 
        public string Name { get; set;}
        public int Population { get; set; }
    }

    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
            else
                throw new IndexOutOfRangeException();
        }

        public T GetByIndex(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                throw new IndexOutOfRangeException();
        }

        //Factory Methode
        public MyType GenerischeMethode<MyType>() 
            where MyType : class
        {
            MyType variable = default!;
            return variable;
        }
    }

}