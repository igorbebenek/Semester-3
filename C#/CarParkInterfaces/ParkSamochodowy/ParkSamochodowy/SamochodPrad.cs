using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    internal class SamochodPrad : ISamochod, ISamochodPrad
    {
        protected bool CzyUruchomiony { get; set; }
        protected bool CzyZatankowany { get; set; }


        public void Tankuj()
        {
            TankujPrad();
        }



        public void TankujPrad()
        {
            if (!CzyZatankowany)
            {
                Console.WriteLine("Tankuję Prąd");
                CzyZatankowany = true;
                Akumulator();
            }
            else
            {
                Console.WriteLine("Samochód już zatankowany gazem");
            }
        }

        public void Akumulator()
        {
            if (CzyZatankowany)
            {
                Console.WriteLine("Ładuję akumulatory");
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
                Console.WriteLine("Brak Prądu - naładuj");
            }
            else
            {
                Console.WriteLine("Jadę na Prądzie.");
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
    }

}

