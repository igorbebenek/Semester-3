using ParkHybrydyLab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    class SamochodPrad : ISamochod, ISamochodPrad
    {
        public bool SilnikElektryczny { get; set; }
        public bool Akumulator { get; set; }

        public void Tankuj()
        {
            if (!Akumulator)
            {
                Console.WriteLine("Laduje akumulator.");
                Akumulator = true;
            }
            else
            {
                Console.WriteLine("Samochod jest juz naladowany");
            }
        }
        public void Wylacz()
        {
            if (SilnikElektryczny)
            {
                Console.WriteLine("Wylaczam silnik elektryczny");
                SilnikElektryczny = false;
            }
            else
            {
                Console.WriteLine("Silnik jest juz wylaczony");
            }

        }
        public void Uruchom()
        {
            if (!SilnikElektryczny)
            {
                Console.WriteLine("Uruchamiam silnik elektryczny");
                SilnikElektryczny = true;
            }
            else
            {
                Console.WriteLine("Silnik jest juz uruchomiony");
            }
        }

        public void Jedz()
        {
            if (!SilnikElektryczny && !Akumulator)
            {
                Console.WriteLine("Silnik jest nieuruchomiony i Akumulator jest nienaladowany");
            }
            else if (!Akumulator)
            {
                Console.WriteLine("Akumulator jest nienaladowany");
            }
            else if (!SilnikElektryczny)
            {
                Console.WriteLine("Silnik nie jest uruchomiony");
            }
            else
            {
                Console.WriteLine("Jade na pradzie");
                Akumulator = false;
            }

        }
    }
}
