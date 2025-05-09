using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasMachenWirDenn
{
    public class Feld : INotifyPropertyChanged
    {
        string inhalt;
        public string Inhalt
        {
            get => inhalt;
            set {
                if (value != inhalt)
                {
                    inhalt = value;
                    OnPropertyChanged(nameof(Inhalt));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
