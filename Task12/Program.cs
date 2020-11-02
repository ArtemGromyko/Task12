using System;
using System.IO;
using System.Xml.Serialization;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Book1", 250, "Tom");
            b1.SerializeXML(@"..\..\..\Serialize.xml");
            Book b2 = Book.DeserializeXML(@"..\..\..\Serialize.xml");
            b2.Disp();
            b2.SerializeJSON(@"..\..\..\Serialize.json");
            Console.WriteLine();
            Book b3 = new Book();
            b3 = Book.DeserializeXML(@"..\..\..\Serialize.xml");
            b3.Disp();
        }
    }
}
