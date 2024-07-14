using System;

namespace ParkHybrydyLab5
{
    class Program
    {
       /* static void JazdaTestowa(ISamochod samochod)
        {
            samochod.Tankuj();
            samochod.Tankuj();
            samochod.Jedz();
            samochod.Uruchom();
            samochod.Uruchom();
            samochod.Jedz();
            samochod.Jedz();
            samochod.Jedz();
            samochod.Wylacz();
            samochod.Wylacz();
        }*/
        static void Main(string[] args)
        {


            var car = new SamochodBenzynaPrad();




            ((ISamochod)car).Uruchom();           //->uruchamia oba silniki. 
            ((ISamochodPrad)car).Uruchom();       //->uruchamia silnik elektryczny. 
            ((ISamochodBenzyna)car).Uruchom();    //->uruchamia silnik spalinowy. 
        }
    }
}
