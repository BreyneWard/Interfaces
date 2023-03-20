using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._1_
{
    public class Figuur : InterfaceObject
    {
        private double _breedte;

        public double Breedte
        {
            get { return _breedte; }
            set { _breedte = value; }
        }

        private double _hoogte;

        public double Hoogte
        {
            get { return _hoogte; }
            set { _hoogte = value; }
        }

        public override string ToString()
        {
            return $"De oppervlakte van de figuur met hoogte {this.Hoogte} en breedte {this.Breedte} is {Bereken()}";
        }

        public Figuur() { }
        public Figuur(double hoogte, double breedte)
        {
            Hoogte= hoogte;
            Breedte= breedte;
        }

        public double Bereken()
        {
            
            return Hoogte * Breedte;
        }
    }
  
}
