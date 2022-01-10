using System.Collections;
using System.Xml;
using Models;
// XML ==> XmlReader ==> object "Car" in ArrayList _cars ==> XmlWriter
var _cars = new ArrayList();

void Read(string file)
{
    var settings = new XmlReaderSettings();
    settings.IgnoreComments = true;
    settings.IgnoreProcessingInstructions = true;
    settings.IgnoreWhitespace = true;
    settings.Async = true;
    var reader = XmlReader.Create(file, settings);
    reader.MoveToContent();
    string name = "",
        cylinders = "",
        country = "";
    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
            if (reader.HasAttributes && reader.Name == "car")
            {
                // Find attribute "name" in node <car>
                for (int i = 0; i < reader.AttributeCount; i++)
                {
                    reader.MoveToAttribute(i);
                    if (reader.Name == "name")
                        name = reader.GetAttribute(i);
                }
            }
            else
            {
                switch (reader.Name)
                {
                    case "cylinders": cylinders = reader.ReadString(); break;
                    case "country": country = reader.ReadString(); break;
                }
                // Console.WriteLine("{0}: {1};", reader.Name, reader.ReadString());
            }
        }
        else if (reader.Name == "car" && !reader.IsStartElement())
            _cars.Add(new Car(name, cylinders, country));
    }
    reader.Close();
    foreach (var car in _cars)
        Console.WriteLine($"{car.ToString()}\n");
}

void Write(string file)
{
    var settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.NewLineChars = "\r\n";
    var writer = XmlWriter.Create(file, settings);
    writer.WriteStartDocument();
    writer.WriteStartElement("cars");
    foreach (Car car in _cars)
    {
        writer.WriteStartElement("car");
        writer.WriteAttributeString("name", car.Name);
        writer.WriteElementString("cylinders", car.Cylinders);
        writer.WriteElementString("country", car.Country);
        writer.WriteEndElement();
    }
    writer.WriteEndElement();
    writer.Flush();
    writer.Close();
}

Read("cars.xml");
Write("_cars.xml");