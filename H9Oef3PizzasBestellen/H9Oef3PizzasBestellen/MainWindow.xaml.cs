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

namespace H9Oef3PizzasBestellen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            firstInputTextBox.Text = "0";
            secondInputTextBox.Text= "0";
            thirdInputTextBox.Text= "0";
            fourthInputTextBox.Text= "0";
            fifthInputTextBox.Text= "0";
            sixthInputTextBox.Text= "0";
            seventhInputTextBox.Text= "0";

            nameTextBox.Focus();

            summaryLabel.Content = "Onze pizza's zijn de beste! \nHet is wetenschappelijk bewezen dat pizza's goed zijn voor de gezondheid.";
        }
    }
}