using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    internal class SamochodBenzyna : ISamochod, ISamochodBenzyna
    {
        public bool CzyUruchomiony { get; set; }
        public bool CzyZatankowany { get; set; }
        public void Jedz()
        {
            if (!CzyUruchomiony)
            {
                Console.WriteLine("Samochod nie jest uruchomiony");
            }
            else if (!CzyZatankowany)
            {
                Console.WriteLine("Brak benzyny - zatankuj");
            }
            else
            {
                Console.WriteLine("Jadę na benzynie.");
                CzyZatankowany = false;
            }
        }

        public void Tankuj()
        {
            TankujBenzyna();
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

        public void TankujBenzyna()
        {
            if (!CzyZatankowany)
            {
                Console.WriteLine("Tankuję Benzyne");
                CzyZatankowany = true;
            }
            else
            {
                Console.WriteLine("Samochód już zatankowany benzyną");
            }
        }
    }
}
