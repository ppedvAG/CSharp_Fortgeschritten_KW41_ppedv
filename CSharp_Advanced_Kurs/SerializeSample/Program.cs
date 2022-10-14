
using Newtonsoft.Json;

using System.Xml.Serialization;

namespace SerializeSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Moritz",
                Alter = 19,
                Kontostand = 5_000_000,
                KreditLimit = 10_000_000,
                Lieblingsfarbe = "orange"
            };

            Stream stream = null;


            #region Binary

            //Schreiben
            BinaryFormatter binary = new BinaryFormatter();
            stream = File.OpenWrite("Person.bin");
            binary.Serialize(stream, person);
            stream.Close();


            //Lesen
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)binary.Deserialize(stream);
            stream.Close();
            #endregion


            #region XML 
            //Schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);    
            stream.Close();


            //Lesen
            stream = File.OpenRead("Person.xml");
            Person xmlPersonen = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();

            #endregion


            #region JSON Newtonsoft -> JSON-Konvertiert
            string jsonString = JsonConvert.SerializeObject(person);
            File.WriteAllText("Person.json", jsonString);

            string loadedJson = File.ReadAllText("Person.json");
            Person loadedPerson = JsonConvert.DeserializeObject<Person>(loadedJson);
            #endregion
        }
    }

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        public string Lieblingsfarbe { get; set; }

        [field: NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public decimal Kontostand { get; set; } //Autoproperty sind

        [field: NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public decimal KreditLimit;
    }

    public class PersonShow
    {
        private string _vorname;

        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }
    }
}