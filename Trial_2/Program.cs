using System.Collections;
using System.Xml;
using Models;
// XML ==> XmlReader ==> object "Car" in ArrayList cars ==> write cars to console ==> XmlWriter
var cars = new ArrayList();

void Read(string file)
{
    var settings = new XmlReaderSettings();
    settings.IgnoreComments = true;
    settings.IgnoreProcessingInstructions = true;
    settings.IgnoreWhitespace = true;
    var reader = XmlReader.Create(file, settings);
    reader.MoveToContent();     // Skip the XML Header
    string name = "", cylinders = "", country = "";
    do
    {
        if (reader.IsStartElement())
        {
            switch (reader.Name)
            {
                case "car":
                    // Find attribute "name" in node <car>
                    for (int i = 0; i < reader.AttributeCount; i++)
                    {
                        reader.MoveToAttribute(i);
                        if (reader.Name == "name")
                            name = reader.GetAttribute(i);
                    }; break;
                case "cylinders": cylinders = reader.ReadString(); break;
                case "country": country = reader.ReadString(); break;
            }
        }
        else if (reader.Name == "car")
            cars.Add(new Car(name, cylinders, country));
    }
    while (reader.Read());
    reader.Close();
    foreach (var car in cars)
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
    foreach (Car car in cars)
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