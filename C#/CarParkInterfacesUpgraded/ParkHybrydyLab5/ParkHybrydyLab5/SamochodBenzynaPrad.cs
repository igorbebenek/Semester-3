using ParkHybrydyLab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    class SamochodBenzynaPrad : ISamochod, ISamochodBenzyna, ISamochodPrad
    {
        public bool SilnikElektryczny { get; set; }
        public bool SilnikSpalinowy { get; set; }
        public bool Bak { get; set; }
        public bool Akumulator { get; set; }


        public void Tankuj()
        {
            if (!Bak && !Akumulator)
            {
                Console.WriteLine("Tankuje benzyne i laduje prad.");
                Bak = true;
                Akumulator = true;
            }
            else if (Bak && Akumulator)
            {
                Console.WriteLine("Samochod jest juz zatankowany benzyna i naladowany pradem");
            }
            else if (Bak)
            {
                Console.WriteLine("Back jest pelny");
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
        void ISamochodPrad.Tankuj()
        {
            if (!Akumulator)
            {
                Console.WriteLine("Laduje akumulator");
                Akumulator = true;
            }
            else
            {
                Console.WriteLine("Akumulator jest juz naladowany");
            }
        }
        public void Wylacz()
        {
            if (SilnikSpalinowy && SilnikElektryczny)
            {
                Console.WriteLine("Wylaczam oba silniki");
                SilnikSpalinowy = false;
                SilnikElektryczny = false;
            }
            else if (SilnikSpalinowy)
            {
                Console.WriteLine("wylaczam silnik spalinowy");
                SilnikSpalinowy = false;
            }
            else if (SilnikElektryczny)
            {
                Console.WriteLine("wylaczam silnik elektryczny");
                SilnikElektryczny = false;
            }
            else
            {
                Console.WriteLine("Silnik spalinowy i elektryczny sa wylaczone");
            }

        }
        public void Uruchom()
        {
            if (!SilnikSpalinowy && !SilnikElektryczny)
            {
                Console.WriteLine("Uruchamiam silnik spalinowy i elektryczny");
                SilnikSpalinowy = true;
                SilnikElektryczny = true;
            }
            else
            {
                Console.WriteLine("oba Silniki sa juz uruchomione");
            }
        }
        void ISamochodBenzyna.Uruchom()
        {
            if (!SilnikSpalinowy)
            {
                Console.WriteLine("Uruchamiam silnik spalinowy");
                SilnikSpalinowy = true;
            }
            else
            {
                Console.WriteLine("Silnik spalinowy jest juz uruchomiony");
            }
        }
        void ISamochodPrad.Uruchom()
        {
            if (!SilnikElektryczny)
            {
                Console.WriteLine("Uruchamiam silnik elektryczny");
                SilnikElektryczny = true;
            }
            else
            {
                Console.WriteLine("Silnik elektryczny jest juz uruchomiony");
            }
        }

        public void Jedz()
        {
            if (!SilnikSpalinowy && !SilnikElektryczny)
            {
                Console.WriteLine("Silniki sa nieuruchomione");
            }
            else if (!Bak && !Akumulator)
            {
                Console.WriteLine("Back jest pusty i akumulator jest nienaladowany");
            }
            else if (Bak)
            {
                Console.WriteLine("Jade na benzynie ");
                Bak = false;
            }
            else if (Akumulator)
            {
                Console.WriteLine("Jade na pradzie");
                Akumulator = false;
            }

        }
    }
}
