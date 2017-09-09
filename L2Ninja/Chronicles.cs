using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Ninja
{
    enum Chronicle
    {
        RiseOfDarkness,
        ScionsOfDestiny,
        OathOfBlood,
        Interlude,
        Kamael,
        Hellbound,
        GraciaPT1,
        GraciaPT2,
        GraciaFinal,
        GraciaEpilogue,
        Freya,
        HighFive,
        Awakening,
        Harmony,
        Tauti,
        GloryDays,
        Lindvior,
        Valiance,
        Ertheia,
        InfinityOdyssey,
        Helios,
        GrandCrusade
    }

    class Chronicles
    {
        public static String GetCode(Chronicle chronicle)
        {
            string code = "";
            switch(chronicle)
            {
                case Chronicle.RiseOfDarkness: code = "C3"; break;
                case Chronicle.ScionsOfDestiny: code = "C4"; break;
                case Chronicle.OathOfBlood: code = "C5"; break;
                case Chronicle.Interlude: code = "Interlude"; break;
                case Chronicle.Kamael: code = "CT1_0"; break;
                case Chronicle.Hellbound: code = "CT1_5"; break;
                case Chronicle.GraciaPT1: code = "CT2_1en"; break;
                case Chronicle.GraciaPT2: code = "CT2_2en"; break;
                case Chronicle.GraciaFinal: code = "CT2_3en"; break;
                case Chronicle.GraciaEpilogue: code = "CT2_4en"; break;
                case Chronicle.Freya: code = "CT2_5en"; break;
                case Chronicle.HighFive: code = "CT2_6"; break;
                case Chronicle.Awakening: code = "GODtw580"; break;
                case Chronicle.Harmony: code = "GODhar"; break; 
                case Chronicle.Tauti: code = "GODtau"; break; 
                case Chronicle.GloryDays: code = "GODglo"; break;  
                case Chronicle.Lindvior: code = "GODlind"; break; 
                case Chronicle.Valiance: code = "GODepei"; break; 
                case Chronicle.Ertheia: code = "GODerthkr"; break; 
                case Chronicle.InfinityOdyssey: code = "GODep2.0"; break;
                case Chronicle.Helios: code = "GOD_Helios_64"; break; 
                case Chronicle.GrandCrusade: code = "GOD_GrandCrusade_109"; break; 
                default: break;
            }

            return code;
        }
    }
}
