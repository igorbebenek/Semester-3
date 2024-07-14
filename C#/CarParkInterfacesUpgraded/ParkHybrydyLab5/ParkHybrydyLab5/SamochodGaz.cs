using ParkHybrydyLab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    class SamochodGaz : ISamochod, ISamochodGaz
    {
        public bool SilnikSpalinowy { get; set; }
        public bool Butla { get; set; }

        public void Tankuj()
        {
            if (!Butla)
            {
                Console.WriteLine("Tankuje gaz.");
                Butla = true;
            }
            else
            {
                Console.WriteLine("Samochod jest juz zatankowany gazem");
            }
        }
        public void Wylacz()
        {
            if (SilnikSpalinowy)
            {
                Console.WriteLine("Wylaczam silnik spalinowy");
                SilnikSpalinowy = false;
            }
            else
            {
                Console.WriteLine("Silnik jest juz wylaczony");
            }

        }
        public void Uruchom()
        {
            if (!SilnikSpalinowy)
            {
                Console.WriteLine("Uruchamiam silnik spalinowy");
                SilnikSpalinowy = true;
            }
            else
            {
                Console.WriteLine("Silnik jest juz uruchomiony");
            }
        }

        public void Jedz()
        {
            if (!SilnikSpalinowy && !Butla)
            {
                Console.WriteLine("Silnik jest nieuruchomiony i butla jest pusta");
            }
            else if (!Butla)
            {
                Console.WriteLine("Butla jest pusta");
            }
            else if (!SilnikSpalinowy)
            {
                Console.WriteLine("Silnik nie jest uruchomiony");
            }
            else
            {
                Console.WriteLine("Jade na gazie");
                Butla = false;
            }

        }
    }
}
