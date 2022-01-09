# Læsning og skrivning af XML

Lav en klasse Car, der repræsenterer en bil, med attributterne: name, cylinders og country; hvor name er navnet på bilen (f.eks. "Toyota Corolla"), cylinders er antallet af cylindere (f.eks. 4) og country er hvilket land bilen er fremstillet i (f.eks. "Japan").

Lav et program, der gennemlæser filen: cars.xml, og opretter en instans af Car for hver bil, der optræder i filen, og placerer disse instanser i en ArrayList (eller en tilsvarende collection-klasse). Udskriv dernæst bilerne fra ArrayList'en, idet du laver en passende ToString-metode til Car-klassen.

Filen: cars.xml befinder sig på nettet:

http://www.fkj.dk/cars.xml

Man kan læse fra denne fil med en XmlReader, der kan laves på følgende måde:

XmlReader reader = XmlReader.Create("http://www.fkj.dk/cars.xml", settings);

Udvid dit program, så det kan udskrive bilerne i en XML-fil på din computer. Det skal tilstræbes at denne nye XML-fil får samme indhold som den læste XML-fil, og at den laves med XmlWriter.

[Der skal anvendes C# til løsning af denne opgave]
