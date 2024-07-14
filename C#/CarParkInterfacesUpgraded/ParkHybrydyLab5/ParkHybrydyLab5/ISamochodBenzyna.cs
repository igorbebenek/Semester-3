using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    public interface ISamochodBenzyna
    {
        // SilnikSpalinowy (true/false),  Bak (true/false) 
        public bool SilnikSpalinowy { get; set; }
        public bool Bak { get; set; }
        void Tankuj();
        void Jedz();
        void Wylacz();
        void Uruchom();
    }
}
