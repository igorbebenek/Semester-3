using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSamochodowy
{
    public interface ISamochodBenzyna
    {

        void Uruchom();
        void Tankuj();
        void Jedz();
        void Wylacz();
    }
}
