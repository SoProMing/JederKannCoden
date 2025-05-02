using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasMachenWirDenn
{
    class SpielViewModel : INotifyPropertyChanged // todo: try without notification
    {
        ObservableCollection<Feld> Spielfeld { get;  }

        public SpielViewModel()
        {
            Spielfeld = new ObservableCollection<Feld>();
            for (int i = 0; i < 36; i++)
            {
                Spielfeld.Add(new Feld());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
