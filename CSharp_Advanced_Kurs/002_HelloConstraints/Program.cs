namespace _002_HelloConstraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore<int> integerDataStore = new DataStore<int>();
            DataStore<DateTime> dateTimeDataStore = new DataStore<DateTime>();

            //Constraints können die Typen, die verwendet werden einschränken 


        }
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
    }

    public class DataStore1<T> where T : class //T muss ein Referenztyp sein 
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
    }

    public class DataStore2<T> where T : struct //T muss ein Wertetyp sein 
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
    }


    public class DataStore3<T> where T : new() //T muss ein Wertetyp sein 
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
    }


    public class DataStore4<TKey, T> where T : Animal
        where TKey : struct
        //T muss vom Vererbungsbaum von Animal sein 
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
    }
}