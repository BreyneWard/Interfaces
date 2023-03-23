using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._2_
{
    internal class Werknemer
    {

        private int _commissie;

        public int Commissie
        {
            get { return _commissie; }
            set { _commissie = value; }
        }


        private int _aantal;

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }

        private string _werknemerType;

        public string WerknemerType
        {
            get { return _werknemerType; }
            set { _werknemerType = value; }
        }

        private decimal _verdiensten;
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }

        public decimal Verdiensten
        {
            get { return _verdiensten; }
            set
            {
                if (value > 0)
                {
                    _verdiensten = value;
                }
            }
        }



        public Werknemer() { }
        public Werknemer(string achternaam, string voornaam, decimal verdiensten, int aantal, int commissie, string werknemertype)
        {

            Achternaam = achternaam;
            Voornaam = voornaam;
            Verdiensten = verdiensten;
            Aantal = aantal;
            Commissie = commissie;
            WerknemerType = werknemertype;
            
        }

        public string GetDisplayText(string sep)
        {
            return Achternaam + sep + Voornaam + sep +
            Verdiensten.ToString("0.00") + sep + WerknemerType + Environment.NewLine;
        }
        //method overloading
        public string GetDisplayText()
        {
            //return code + "-" + price.ToString("c") + "-" + 
            //description;
            return GetDisplayText("-");
        }
    }

    class NameComparer: IComparer<Werknemer>
    {
        public int Compare(Werknemer x, Werknemer y)
        {
            return x.Achternaam.CompareTo(y.Achternaam);
        }
    }

    class VerdienstenComparer : IComparer<Werknemer>
    {
        public int Compare(Werknemer? x, Werknemer? y)
        {
            return x.Verdiensten.CompareTo(y.Verdiensten);
        }
    }
}
