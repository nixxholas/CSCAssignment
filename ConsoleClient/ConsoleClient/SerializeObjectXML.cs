using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleClient
{
    class SerializeObjectXML
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.FirstName = "Jeff";
            p.MI = "A";
            p.LastName = "Price";
            XmlSerializer x = new XmlSerializer(p.GetType());
            x.Serialize(Console.Out, p);
            Console.WriteLine();
            Console.ReadLine();
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter("myXML.xml"); x.Serialize(myWriter, p);
            myWriter.Close();
        }
    }
}
