using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task12
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumberOfPages { get; set; }
        [DataMember]
        public string Author { get; set; }
        public Book() { }
        public Book(string name, int number, string author)
        {
            Name = name;
            NumberOfPages = number;
            Author = author;
        }
        public void Disp()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("NumberOfPages: " + NumberOfPages);
            Console.WriteLine("Author: " + Author);
        }
        public void SerializeXML(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractSerializer ds = new DataContractSerializer(typeof(Book));
                ds.WriteObject(fs, this);
            }
        }
        public static Book DeserializeXML(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractSerializer ds = new DataContractSerializer(typeof(Book));
                return (Book)ds.ReadObject(fs);
            }
        }
        public void SerializeJSON(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Book));
                ds.WriteObject(fs, this);
            }
        }
        public static Book DeserializeJSON(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Book));
                return (Book)ds.ReadObject(fs);
            }
        }
    }
}
