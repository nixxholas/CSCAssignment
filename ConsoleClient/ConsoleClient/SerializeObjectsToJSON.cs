using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class SerializeObjectsToJSON
    {
        static List<Person> persons = new List<Person>();
        static void Main(string[] args) {
            Person p1 = new Person();
            p1.FirstName = "Jeff";
            p1.MI = "A";
            p1.LastName = "Price";
            persons.Add(p1);

            Person p2 = new Person();
            p2.FirstName = "Jeff";
            p2.MI = "A";
            p2.LastName = "Price";
            persons.Add(p2);

            serialize();
            deserialize();

            Console.ReadLine();
        }
        private static void serialize()
        {
            // var javaScriptSerializer = new //JavaScriptSerializer();
            //string jsonString = javaScriptSerializer.Serialize(persons);
            //higher performance
            string jsonString = JsonConvert.SerializeObject(persons, Formatting.Indented);
            Console.WriteLine(jsonString);
            // To write to a file, create a StreamWriter object. 
            StreamWriter myWriter = new StreamWriter("myJSON.json");
            myWriter.WriteAsync(jsonString);
            myWriter.Close();
        }

        public static void deserialize()
        {
            // JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonString = File.ReadAllText("myJSON.json");
            //List<Person> persons = js.Deserialize<List<Person>>(jsonString);
            List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(jsonString);
            //display the result in the list
            int numofPersons = persons.Count;
            Console.WriteLine("number of persons" + numofPersons); foreach (Person p in persons)
            {
                Console.WriteLine("{0}\t${1}\t{2}", p.LastName,
                p.FirstName,
                p.MI);
            }
        }
    }
    }
