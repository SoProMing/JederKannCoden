using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosDieserWelt
{
    internal class EAuto : Auto
    {
        private int _AkkuStand;
        public int AkkuStand { get { return _AkkuStand; } set
            {
                if (value + _AkkuStand > Kapazität)
                    _AkkuStand = Kapazität;
                else
                    _AkkuStand = value + _AkkuStand;
                Console.WriteLine($"Das EAuto ist mit {_AkkuStand} kWh geladen.");
            }
        }

        public int Kapazität {  get; init; }

        public EAuto( int Kapazität, int AnzahlTüren, int AnzahlSitze, string Farbe = "grau") : base(Farbe, AnzahlTüren, AnzahlSitze)
        {
            this.Kapazität = Kapazität;
        }

        public void laden(int KiloWattStunden)
        {
            AkkuStand += KiloWattStunden;
        }

        public override void fahren(int Distanz)
        {
            // Standortänderung
            Kilometerstand += Distanz;
        }
    }
}
