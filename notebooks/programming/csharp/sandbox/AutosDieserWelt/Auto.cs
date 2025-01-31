using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosDieserWelt
{
    internal abstract class Auto
    {
        public static int SummeAllerAutos { get; set; }

       
        public string Farbe { get; init; }
        public int Kilometerstand { get; set; }
        public int AnzahlTüren { get; init; }
        public int AnzahlSitze {  get; init; }

        protected Auto( string Farbe, int AnzahlTüren, int AnzahlSitze)
        {
            this.Farbe = Farbe;
            this.AnzahlTüren = AnzahlTüren;
            this.AnzahlSitze = AnzahlSitze;
            Kilometerstand = 0;
            SummeAllerAutos++;
        }

        abstract public void fahren(int Distanz);
    }
}
