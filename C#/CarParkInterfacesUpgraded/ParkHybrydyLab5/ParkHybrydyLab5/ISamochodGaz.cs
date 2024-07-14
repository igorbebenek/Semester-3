using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHybrydyLab5
{
    public interface ISamochodGaz
    {
        public bool SilnikSpalinowy { get; set; }
        public bool Butla { get; set; }
        void Tankuj();
        void Jedz();
        void Wylacz();
        void Uruchom();
    }

}

