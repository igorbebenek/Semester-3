public abstract class Samochod
{
    protected bool CzyUruchomiony = false;
    protected bool CzyZatankowany = false;

    public void Uruchom() //URUCHOM
    {
        if (!CzyUruchomiony)
        {
            Console.WriteLine("Uruchamiam samochód");
            CzyUruchomiony = true;
        }
        else
        {
            Console.WriteLine("Samochód jest już uruchomiony");
        }
    }

    public void Wylacz() //WYLACZ
    {
        if (CzyUruchomiony)
        {
            Console.WriteLine("Wyłączam silnik");
            CzyUruchomiony = false;
        }
        else
        {
            Console.WriteLine("Silnik jest wyłączony");
        }
    }

    public void Jedz() //JEDZ
    {
        if (CzyUruchomiony)
        {
            if (CzyZatankowany)
            {
                Console.WriteLine("Jadę");
                CzyZatankowany = false;
            }
            else
            {
                Console.WriteLine("Brak paliwa, zatankuj");
            }
        }
        else
        {
            Console.WriteLine("Samochód nie jest uruchomiony");
        }
    }

    public abstract void Tankuj();
}

public class SamochodBenzyna : Samochod // KLASA POTOMNA SAMOCHOD BENZYNA
{
    public override void Tankuj()
    {
        if (!CzyZatankowany)
        {
            Console.WriteLine("Tankuję benzyną");
            CzyZatankowany = true;
        }
        else
        {
            Console.WriteLine("Samochód już zatankowany");
        }
    }
}

public class SamochodGaz : Samochod // KLASA POTOMNA SAMOCHOD GAZ
{
    public override void Tankuj()
    {
        if (!CzyZatankowany)
        {
            Console.WriteLine("Tankuję gaz");
            CzyZatankowany = true;
        }
        else
        {
            Console.WriteLine("Samochód już zatankowany");
        }
    }
}

public class SamochodPrad : Samochod // KLASA POTOMNA SAMOCHOD PRAD
{
    public override void Tankuj()
    {
        if (!CzyZatankowany)
        {
            Console.WriteLine("Ładuję akumulatory");
            CzyZatankowany = true;
        }
        else
        {
            Console.WriteLine("Samochód już zatankowany");
        }
    }
}

public class TestSamochod //KLASA TESTSAMOCHOD, METODA JAZDA TESTOWA
{
    public void JazdaTestowa(Samochod samochod)
    {
        samochod.Tankuj();
        samochod.Tankuj();
        samochod.Jedz();
        samochod.Uruchom();
        samochod.Uruchom();
        samochod.Jedz();
        samochod.Jedz();
        samochod.Wylacz();
        samochod.Wylacz();
    }
}

class Program //MAIN
{
    static void Main(string[] args)
    {
        TestSamochod testSamochod = new TestSamochod();

        List<Samochod> samochody = new List<Samochod>
        {
            new SamochodBenzyna(),
            new SamochodGaz(),
            new SamochodPrad()
        };

        foreach (var samochod in samochody)
        {
            testSamochod.JazdaTestowa(samochod);
        }
    }
}
