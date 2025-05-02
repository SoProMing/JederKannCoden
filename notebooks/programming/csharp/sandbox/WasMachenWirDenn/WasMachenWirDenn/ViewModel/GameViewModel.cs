using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasMachenWirDenn.Model;

namespace WasMachenWirDenn.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cell> Board { get; }
        private string currentPlayer = "X";

        public GameViewModel()
        {
            Board = new ObservableCollection<Cell>();
            for (int i = 0; i < 9; i++)
                Board.Add(new Cell());
        }

        public void CellClicked(Cell cell)
        {
            if (string.IsNullOrEmpty(cell.Content))
            {
                cell.Content = currentPlayer;
                currentPlayer = currentPlayer == "X" ? "O" : "X";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
