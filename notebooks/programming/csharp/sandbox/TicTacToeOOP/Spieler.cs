using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class Spieler
    {
        public string Stein { get; init; }

        public string Name { get; init; }

        public Spieler( string Name, string Stein)
        {
            this.Name = Name;
            this.Stein = Stein;
        }
    }
}
