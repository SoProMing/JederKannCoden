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
    public partial class MainWindow : Window
    {
        int counter;
        public MainWindow()
        {
            InitializeComponent();
            counter = 0;
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