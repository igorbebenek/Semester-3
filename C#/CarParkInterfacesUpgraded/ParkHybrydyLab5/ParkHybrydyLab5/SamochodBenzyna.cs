using ParkHybrydyLab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    class SamochodBenzyna : ISamochod, ISamochodBenzyna
    {
        public bool SilnikSpalinowy { get; set; }
        public bool Bak { get; set; }

        public void Tankuj()
        {
            if (!Bak)
            {
                Console.WriteLine("Tankuje benzyne.");
                Bak = true;
            }
            else
            {
                Console.WriteLine("Samochod jest juz zatankowany benzyna");
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
            if (!SilnikSpalinowy && !Bak)
            {
                Console.WriteLine("Silnik jest nieuruchomiony i back jest pusty");
            }
            else if (!Bak)
            {
                Console.WriteLine("Back jest pusty");
            }
            else if (!SilnikSpalinowy)
            {
                Console.WriteLine("Silnik nie jest uruchomiony");
            }
            else
            {
                Console.WriteLine("Jade na benzynie");
                Bak = false;
            }

        }
    }
}
