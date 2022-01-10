namespace Models;

public class Car
{
    public string Name { get; }
    public string Cylinders { get; }
    public string Country { get; }

    public Car(string name, string cylinders, string country)
    {
        Name = name;
        Cylinders = cylinders;
        Country = country;
    }

    public override string ToString()
    {
        return $"name: \"{Name}\";\ncylinders: : \"{Cylinders}\";\ncountry: : \"{Country}\";";
    }
}