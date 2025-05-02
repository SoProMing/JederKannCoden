using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasMachenWirDenn
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BoardCell> Board { get; }
        private string currentPlayer = "X";

        public GameViewModel()
        {
            Board = new ObservableCollection<BoardCell>();
            for (int i = 0; i < 9; i++)
                Board.Add(new BoardCell());
        }

        public void CellClicked(BoardCell cell)
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
