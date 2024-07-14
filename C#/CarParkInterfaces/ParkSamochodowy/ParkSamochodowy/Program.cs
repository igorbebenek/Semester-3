using ParkSamochodowy;
using System.Collections;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {

        ArrayList samochody = new ArrayList(3);
        samochody.Add(new SamochodBenzyna());
        samochody.Add(new SamochodGaz());
        samochody.Add(new SamochodPrad());
        samochody.Add(new SamochodBenzynaPrad());
        samochody.Add(new SamochodBenzynaGaz());



        foreach (ISamochod samochod in samochody)
        {
            Console.WriteLine("\n------ Samochod typu {0} ------", samochod.GetType().Name);
            JazdaTestowa(samochod);

        }
        Console.ReadKey();

    }
    static void JazdaTestowa(ISamochod samochod)
    {
        samochod.Tankuj();
        samochod.Tankuj();
        samochod.Jedz();
        samochod.Uruchom();
        samochod.Uruchom();
        samochod.Jedz();
        samochod.Jedz();
        samochod.Jedz();
        samochod.Wylacz();
        samochod.Wylacz();
    }
}

