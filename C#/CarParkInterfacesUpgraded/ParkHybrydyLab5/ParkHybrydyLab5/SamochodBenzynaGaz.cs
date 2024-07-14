using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    class SamochodBenzynaGaz : ISamochod, ISamochodBenzyna, ISamochodGaz
    {
        public bool SilnikSpalinowy { get; set; }
        public bool Butla { get; set; }
        public bool Bak { get; set; }

        public void Tankuj()
        {
            if (!Bak && !Butla)
            {
                Console.WriteLine("Tankuje benzyne i tankuje gaz.");
                Bak = true;
                Butla = true;
            }
            else if (Bak && Butla)
            {
                Console.WriteLine("Samochod jest juz zatankowany benzyna i gazem");
            }
            else if (Bak)
            {
                Console.WriteLine("Back jest pelny");
                Butla = true;
            }

        }
        void ISamochodBenzyna.Tankuj()
        {
            if (!Bak)
            {
                Console.WriteLine("Tankuje benzyna");
                Bak = true;
            }
            else
            {
                Console.WriteLine("Samochod jest juz zatankowany benzyna");
            }
        }
        void ISamochodGaz.Tankuj()
        {
            if (!Butla)
            {
                Console.WriteLine("Tankuje gaz");
                Bak = true;
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
            if (!SilnikSpalinowy)
            {
                Console.WriteLine("Silnik jest nieuruchomiony");
            }
            else if (Bak)
            {
                Console.WriteLine("Jade na benzynie");
                Bak = false;
            }

            else if (Butla)
            {
                Console.WriteLine("Jade na gazie");
                Butla = false;
            }

            else if (!Butla && !Bak)
            {
                Console.WriteLine("Brak gazu i benzyny zatankuj");
            }

        }
    }
}
