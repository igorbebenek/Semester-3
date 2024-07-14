using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    public interface ISamochodPrad
    {
        // SilnikelEktryczny(true/false),  Akumulator(true/false)
        public bool SilnikElektryczny { get; set; }
        public bool Akumulator { get; set; }
        void Tankuj();
        void Jedz();
        void Wylacz();
        void Uruchom();
    }
}
