using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleClient
{
    class SerializeObjectsToXML
    {
        static List<Person> persons = new List<Person>();
        static void Main(string[] args)
        {
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
            XmlSerializer x = new XmlSerializer(persons.GetType()); x.Serialize(Console.Out, persons); Console.WriteLine();
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter("myXML.xml");
            x.Serialize(myWriter, persons);
            myWriter.Close();
        }

        public static void deserialize()
        {
            XmlSerializer myDeserializer = new XmlSerializer(persons.GetType());
            FileStream myFileStream = new FileStream("myXML.xml", FileMode.Open);
            var listOfPersons = (List<Person>)myDeserializer.Deserialize(myFileStream); myFileStream.Close();
            //display the result in the list
            int numofPersons = listOfPersons.Count;
            Console.WriteLine("number of persons" + numofPersons);
            foreach (Person p in listOfPersons)
            {
                Console.WriteLine("{0}\t${1}\t{2}",
                p.LastName,
                p.FirstName,
                p.MI);
            }
        }
    }
}
