using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WasMachenWirDenn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private const int BoardSize = 6;
        private string currentPlayer = "🔴";

        public string ErsterBindingText { get; set; } = "Text1";

        int counter;
        public MainWindow()
        {
            InitializeComponent();
            counter = 0;
            CreateGameBoard();
            DataContext = new MainDataContext();
        }

        private void CreateGameBoard()
        {
            GameBoard.Rows = BoardSize;
            GameBoard.Columns = BoardSize;

            for (int i = 0; i < BoardSize * BoardSize; i++)
            {
                var button = new Button
                {
                    FontSize = 32,
                    Margin = new Thickness(5)
                };
                button.Click += GameBoard_Button_Click;
                GameBoard.Children.Add(button);
            }
        }

        void GameBoard_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && string.IsNullOrEmpty(button.Content as string))
            {
                button.Content = currentPlayer;
                currentPlayer = currentPlayer == "O" ? "🔴" : "O";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ich bin ein Küken mit Eischale!");
            //myTextBox.Text = "Geklickt";
            counter++;
            myButton.Content = $"Ich bin ein Osterei. Du hast mit {counter} Mal geklickt!";
        }
    }
}