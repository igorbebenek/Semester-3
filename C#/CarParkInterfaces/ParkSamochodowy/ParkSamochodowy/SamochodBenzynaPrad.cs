using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    public class SamochodBenzynaPrad : ISamochod, ISamochodBenzyna, ISamochodPrad
    {
        protected bool CzyUruchomiony { get; set; }
        protected bool CzyZatankowanyBenzyna { get; set; }
        protected bool CzyZatankowanyPradem { get; set; }

        public void Uruchom()
        {
            if (!CzyUruchomiony)
            {
                Console.WriteLine("Uruchamiam samochod.");
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
            else if (CzyZatankowanyBenzyna)
            {
                Console.WriteLine("Jadę na benzynie");
                CzyZatankowanyBenzyna = false;
            }
            else if (CzyZatankowanyPradem)
            {
                Console.WriteLine("Jadę na prądzie");
                CzyZatankowanyPradem = false;
            }
            else if (!CzyZatankowanyPradem && !CzyZatankowanyBenzyna)
            {
                Console.WriteLine("Brak prądu i benzyny zatankuj/naładuj");
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
            TankujBenzyna();
            TankujPrad();
        }
        void ISamochodBenzyna.Tankuj()
        {
            TankujBenzyna();
        }

        void ISamochodPrad.Tankuj()
        {
            TankujPrad();
        }

        public void Akumulator()
        {
            if (CzyZatankowanyPradem)
            {
                Console.WriteLine("Ładuję akumulatory");
            }
        }

        public void TankujBenzyna()
        {
            if (!CzyZatankowanyBenzyna)
            {
                Console.WriteLine("Tankuję Benzyne");
                CzyZatankowanyBenzyna = true;
            }
            else
            {
                Console.WriteLine("Samochód już zatankowany benzyną");
            }
        }

        public void TankujPrad()
        {
            if (!CzyZatankowanyPradem)
            {
                Console.WriteLine("Tankuję Prąd");
                CzyZatankowanyPradem = true;
                Akumulator();
            }
            else
            {
                Console.WriteLine("Samochód już naładowany");
            }
        }
    }
}
