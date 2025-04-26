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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clickcount = 0;
        string buttonInitialText = string.Empty;
        public string Text { get; set; } = "Hello World!";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo Welt!");
            if (clickcount == 0)
            {
                buttonInitialText = myButton.Content.ToString();
            }
            clickcount++;
            myButton.Content = $"{buttonInitialText} Wurde {clickcount} Mal geklickt.";
        }
    }
}