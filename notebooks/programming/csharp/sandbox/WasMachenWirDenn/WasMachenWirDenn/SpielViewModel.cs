using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasMachenWirDenn
{
    public class SpielViewModel
    {
        public ObservableCollection<Feld> Spielfeld { get;  }
        string currentPlayer = "X";

        public SpielViewModel()
        {
            Spielfeld = new ObservableCollection<Feld>();
            for (int i = 0; i < 36; i++)
            {
                Spielfeld.Add(new Feld());
            }
        }

        public void FeldClicked(Feld feld)
        {
            if (string.IsNullOrEmpty(feld.Inhalt))
            {
                feld.Inhalt = currentPlayer;
                currentPlayer = currentPlayer == "X" ? "O" : "X";
            }
        }
    }
}
