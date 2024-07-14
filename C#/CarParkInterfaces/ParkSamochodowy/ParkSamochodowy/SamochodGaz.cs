using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    internal class SamochodGaz : ISamochod, ISamochodGaz
    {
        protected bool CzyUruchomiony { get; set; }
        protected bool CzyZatankowany { get; set; }

        public void Uruchom()
        {
            if (!CzyUruchomiony)
            {
                Console.WriteLine("Uruchamiam samochód.");
                CzyUruchomiony = true;
            }
            else
            {
                Console.WriteLine("Samochód jest już uruchomiony.");
            }
        }

        public void Jedz()
        {
            if (!CzyUruchomiony)
            {
                Console.WriteLine("Samochód nie jest uruchomiony");
            }
            else if (!CzyZatankowany)
            {
                Console.WriteLine("Brak gazu - zatankuj");
            }
            else
            {
                Console.WriteLine("Jadę na gazie.");
                CzyZatankowany = false;
            }
        }

        public void Wylacz()
        {
            if (!CzyUruchomiony)
            {
                Console.WriteLine("Silnik jest wyłączony.");
            }
            else
            {
                Console.WriteLine("Wyłączam silnik");
                CzyUruchomiony = false;
            }

        }

        public void Tankuj()
        {
            TankujGaz();
        }

        public void TankujGaz()
        {
            if (!CzyZatankowany)
            {
                Console.WriteLine("Tankuję gaz");
                CzyZatankowany = true;
            }
            else
            {
                Console.WriteLine("Samochód już zatankowany gazem");
            }
        }
    }
}