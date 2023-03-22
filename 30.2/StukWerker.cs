using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._2_
{
    class StukWerker:Werknemer
    {
        public StukWerker(string achternaam, string voornaam, decimal verdiensten, int aantal, string werknemerType)
        : base( achternaam, voornaam,  verdiensten,  aantal, "Stukwerker")
        {
        }
    }
}
