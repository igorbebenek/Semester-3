using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    public class SamochodBenzynaGaz : ISamochod, ISamochodBenzyna, ISamochodGaz
    {
       protected bool CzyUruchomiony { get; set; }
       protected bool CzyZatankowany { get; set; }
       protected bool CzyZatankowanyBenzyna { get; set; }
       protected bool CzyZatankowanyGazem { get; set; }


        public void TankujGaz()
        {
            if (!CzyZatankowanyGazem)
            {
                Console.WriteLine("Tankuję Gaz");
                CzyZatankowanyGazem = true;
            }
            else
            {
                Console.WriteLine("Samochód już zatankowany gazem");
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
            else if (CzyZatankowanyGazem)
            {
                Console.WriteLine("Jadę na gazie");
                CzyZatankowanyGazem = false;
            }
            else if (!CzyZatankowanyGazem && !CzyZatankowanyBenzyna)
            {
                Console.WriteLine("Brak gazu i benzyny - zatankuj");
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
            TankujBenzyna();
        }
        void ISamochodBenzyna.Tankuj()
        {
            TankujBenzyna();
        }
        void ISamochodGaz.Tankuj()
        {
            TankujGaz();
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
