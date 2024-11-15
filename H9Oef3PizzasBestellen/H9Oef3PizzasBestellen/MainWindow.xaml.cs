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

        private string name;
        private string inputPhoneNumber;
        private int phoneNumber;
        private string email;
        private string address;
        private string city;
        private string inputPostalCode;
        private int postalCode;

        private string inputFirstNumber = "0";
        private int firstNumber;
        private string inputSecondNumber = "0";
        private int secondNumber;
        private string inputThirdNumber = "0";
        private int thirdNumber;
        private string inputFourthNumber = "0";
        private int fourthNumber;
        private string inputFifthNumber = "0";
        private int fifthNumber;
        private string inputSixthNumber = "0";
        private int sixthNumber;
        private string inputSeventhNumber = "0";
        private int seventhNumber;

        private int firstExtra;
        private int secondExtra;
        private int thirdExtra;
        private int fourthExtra;

        private double totalPrice;

        Random random = new Random();

        StringBuilder contactInfoBuilder = new StringBuilder();
        StringBuilder orderBuilder = new StringBuilder();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            firstNumberTextBox.Text = inputFirstNumber;
            secondNumberTextBox.Text= inputSecondNumber;
            thirdNumberTextBox.Text= inputThirdNumber;
            fourthNumberTextBox.Text= inputFourthNumber;
            fifthNumberTextBox.Text= inputFifthNumber;
            sixthNumberTextBox.Text= inputSixthNumber;
            seventhNumberTextBox.Text= inputSeventhNumber;

            int randomImage = random.Next(0,4);

            if (randomImage == 0)
            {
                displayedImage.Source = new BitmapImage(new Uri("Images/Pizza1.jpg", UriKind.Relative));
            }
            else if (randomImage == 1)
            {
                displayedImage.Source = new BitmapImage(new Uri("Images/Pizza2.jpg", UriKind.Relative));
            }
            else if (randomImage == 2)
            {
                displayedImage.Source = new BitmapImage(new Uri("Images/Pizza3.jpg", UriKind.Relative));
            }
            else if (randomImage == 3)
            {
                displayedImage.Source = new BitmapImage(new Uri("Images/Pizza4.jpg", UriKind.Relative));
            }

            nameTextBox.Focus();

            summaryLabel.Content = "Onze pizza's zijn de beste! \nHet is wetenschappelijk bewezen dat pizza's goed zijn voor de gezondheid.";
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            name = nameTextBox.Text;
            inputPhoneNumber = phoneNumberTextBox.Text;
            email = emailTextBox.Text;
            address = addressTextBox.Text;
            city = cityTextBox.Text;
            inputPostalCode = postalCodeTextBox.Text;

            inputFirstNumber = firstNumberTextBox.Text;
            inputSecondNumber = secondNumberTextBox.Text;
            inputThirdNumber = thirdNumberTextBox.Text;
            inputFourthNumber = fourthNumberTextBox.Text;
            inputFifthNumber = fifthNumberTextBox.Text;
            inputSixthNumber = sixthNumberTextBox.Text;
            inputSeventhNumber = seventhNumberTextBox.Text;

            bool isInputPhoneNumberValid = int.TryParse(inputPhoneNumber, out phoneNumber);
            bool isInputPostalCodeValid = int.TryParse(inputPostalCode, out postalCode);
            bool isInputEmailValid = email.Contains("@") && email.Contains(".");

            bool isInputFirstNumberValid = int.TryParse(inputFirstNumber, out firstNumber);
            bool isInputSecondNumberValid = int.TryParse(inputSecondNumber, out secondNumber);
            bool isInputThirdNumberValid = int.TryParse(inputThirdNumber, out thirdNumber);
            bool isInputFourthNumberValid = int.TryParse(inputFourthNumber, out fourthNumber);
            bool isInputFifthNumberValid = int.TryParse(inputFifthNumber, out fifthNumber);
            bool isInputSixthNumberValid = int.TryParse(inputSixthNumber, out sixthNumber);
            bool isInputSeventhNumberValid = int.TryParse(inputSeventhNumber, out seventhNumber);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(inputPhoneNumber) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(inputPostalCode))
            {
                MessageBox.Show("Geef al uw persoonlijke gegevens in!","Foutive invoer",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (isInputPostalCodeValid == false || isInputPhoneNumberValid == false || isInputEmailValid == false)
                {
                    MessageBox.Show("Zorg dat de postcode en telefoonnummer geldige waarden zijn en het emailadres een geldig emailadres is!", "Foutive invoer", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (isInputPostalCodeValid == false)
                    {
                        postalCodeTextBox.Focus();
                    }
                    else if (isInputEmailValid == false)
                    {
                        emailTextBox.Focus();
                    }
                    else
                    {
                        phoneNumberTextBox.Focus();
                    }
                }
                else
                {
                    if (isInputFirstNumberValid == false || isInputSecondNumberValid == false || isInputThirdNumberValid == false || isInputFourthNumberValid == false || isInputFifthNumberValid == false || isInputSixthNumberValid == false || isInputSeventhNumberValid == false)
                    {
                        MessageBox.Show("Geef getallen in in de invoervakjes!", "Foutive invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (firstNumber < 0 || firstNumber > 10 || secondNumber < 0 || secondNumber > 10 || thirdNumber < 0 || thirdNumber > 10 || fourthNumber < 0 || fourthNumber > 10 || fifthNumber < 0 || fifthNumber > 10 || sixthNumber < 0 || sixthNumber > 10 || seventhNumber < 0 || seventhNumber > 10)
                        {
                            MessageBox.Show("Geef geldige getallen in tussen 0 en 10 in de invoervakjes!", "Foutive invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            totalPrice = (firstNumber * 12.5) + (secondNumber * 13) + (thirdNumber * 12) + (fourthNumber * 11) + (fifthNumber * 12.5) + (sixthNumber * 12) + (seventhNumber * 9) + firstExtra + secondExtra + thirdExtra + fourthExtra;
                            
                            // Zonder stringBuilder:
                            // summaryLabel.Content = $"Naam: {name} \nTelefoonnummer: {inputPhoneNumber} \nE-mail: {email} \nAdres: {address} \nWoonplaats: {city} - {inputPostalCode}";
                            // resultLabel.Content = $"U heeft de volgende pizza's besteld \n--------------------- \n{firstNumber} x Quattro Stagioni \n{secondNumber} x Capricciosa \n{thirdNumber} x Salami \n{fourthNumber} x Prosciutto \n{fifthNumber} x Quattro Fromaggi \n{sixthNumber} x Hawaï \n{seventhNumber} x Margherita \nTotaalbedrag = €{totalPrice}";

                            // Met stringBuilder:
                            contactInfoBuilder.AppendLine($"Naam: {name}");
                            contactInfoBuilder.AppendLine($"Telefoonnummer: {inputPhoneNumber}");
                            contactInfoBuilder.AppendLine($"E-mail: {email}");
                            contactInfoBuilder.AppendLine($"Adres: {address}");
                            contactInfoBuilder.AppendLine($"Woonplaats: {city} - {inputPostalCode}");
                            
                            summaryLabel.Content = contactInfoBuilder.ToString();

                            orderBuilder.AppendLine($"U heeft de volgende pizza's besteld:");
                            orderBuilder.AppendLine($"------------------------------------");
                            orderBuilder.AppendLine($"{firstNumber} x Quattro Stagioni");
                            orderBuilder.AppendLine($"{secondNumber} x Capricciosa");
                            orderBuilder.AppendLine($"{thirdNumber} x Salami");
                            orderBuilder.AppendLine($"{fourthNumber} x Prosciutto");
                            orderBuilder.AppendLine($"{fifthNumber} x Quattro Fromaggi");
                            orderBuilder.AppendLine($"{sixthNumber} x Hawaï");
                            orderBuilder.AppendLine($"{seventhNumber} x Margherita");
                            orderBuilder.AppendLine($"Totaalbedrag = €{totalPrice}");

                            resultLabel.Content= orderBuilder.ToString();

                        }         
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            double newSliderValue;

            if (textBox == firstNumberTextBox)
            {
                if (double.TryParse(firstNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    firstSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(firstNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    firstNumberTextBox.Text = "0";
                    firstNumberTextBox.Focus();
                }
            }
            else if (textBox == secondNumberTextBox)
            {
                if (double.TryParse(secondNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    secondSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(secondNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    secondNumberTextBox.Text = "0";
                    secondNumberTextBox.Focus();
                }
            }
            else if (textBox == thirdNumberTextBox)
            {
                if (double.TryParse(thirdNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    thirdSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(thirdNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    thirdNumberTextBox.Text = "0";
                    thirdNumberTextBox.Focus();
                }
            }
            else if (textBox == fourthNumberTextBox)
            {
                if (double.TryParse(fourthNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    fourthSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(fourthNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    fourthNumberTextBox.Text = "0";
                    fourthNumberTextBox.Focus();
                }
            }
            else if (textBox == fifthNumberTextBox)
            {
                if (double.TryParse(fifthNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    fifthSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(fifthNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    fifthNumberTextBox.Text = "0";
                    fifthNumberTextBox.Focus();
                }
            }
            else if (textBox == sixthNumberTextBox)
            {
                if (double.TryParse(sixthNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    sixthSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(sixthNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    sixthNumberTextBox.Text = "0";
                    sixthNumberTextBox.Focus();
                }
            }
            else if (textBox == seventhNumberTextBox)
            {
                if (double.TryParse(seventhNumberTextBox.Text, out newSliderValue) && newSliderValue >= 0 && newSliderValue <= 10)
                {
                    seventhSlider.Value = newSliderValue;
                }
                else if (!double.TryParse(seventhNumberTextBox.Text, out newSliderValue) || newSliderValue < 0 || newSliderValue > 10)
                {
                    MessageBox.Show("Geef aantallen in tussen 1 en 10", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    seventhNumberTextBox.Text = "0";
                    seventhNumberTextBox.Focus();
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;

            if (slider == firstSlider)
            {
                firstNumberTextBox.Text = slider.Value.ToString();
                inputFirstNumber = slider.Value.ToString();
            }
            else if (slider == secondSlider)
            {
                secondNumberTextBox.Text = slider.Value.ToString();
                inputSecondNumber = slider.Value.ToString();
            }
            else if (slider == thirdSlider)
            {
                thirdNumberTextBox.Text = slider.Value.ToString();
                inputThirdNumber = slider.Value.ToString();
            }
            else if (slider == fourthSlider)
            {
                fourthNumberTextBox.Text = slider.Value.ToString();
                inputFourthNumber = slider.Value.ToString();
            }
            else if (slider == fifthSlider)
            {
                fifthNumberTextBox.Text = slider.Value.ToString();
                inputFifthNumber = slider.Value.ToString();
            }
            else if (slider == sixthSlider)
            {
                sixthNumberTextBox.Text = slider.Value.ToString();
                inputSixthNumber = slider.Value.ToString();
            }
            else if (slider == seventhSlider)
            { 
                seventhNumberTextBox.Text = slider.Value.ToString();
                inputSeventhNumber = slider.Value.ToString();
            }
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            Button minusButton = sender as Button;

            if (minusButton == firstMinusButton)
            {
                bool isInputFirstNumberValid = int.TryParse(inputFirstNumber, out firstNumber);
                firstNumber--;
                firstNumberTextBox.Text = firstNumber.ToString();
            }
            else if (minusButton == secondMinusButton)
            {
                bool isInputSecondNumberValid = int.TryParse(inputSecondNumber, out secondNumber);
                secondNumber--;
                secondNumberTextBox.Text = secondNumber.ToString();
            }
            else if (minusButton == thirdMinusButton)
            {
                bool isInputThirdNumberValid = int.TryParse(inputThirdNumber, out thirdNumber);
                thirdNumber--;
                thirdNumberTextBox.Text = thirdNumber.ToString();
            }
            else if (minusButton == fourthMinusButton)
            {
                bool isInputFourthNumberValid = int.TryParse(inputFourthNumber, out fourthNumber);
                fourthNumber--;
                fourthNumberTextBox.Text = fourthNumber.ToString();
            }
            else if (minusButton == fifthMinusButton)
            {
                bool isInputFifthNumberValid = int.TryParse(inputFifthNumber, out fifthNumber);
                fifthNumber--;
                fifthNumberTextBox.Text = fifthNumber.ToString();
            }
            else if (minusButton == sixthMinusButton)
            {
                bool isInputSixthNumberValid = int.TryParse(inputSixthNumber, out sixthNumber);
                sixthNumber--;
                sixthNumberTextBox.Text = sixthNumber.ToString();
            }
            else if (minusButton == seventhMinusButton)
            {
                bool isInputSeventhNumberValid = int.TryParse(inputSeventhNumber, out seventhNumber);
                seventhNumber--;
                seventhNumberTextBox.Text = seventhNumber.ToString();
            }
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            Button plusButton = sender as Button;

            if (plusButton == firstPlusButton)
            {
                bool isInputFirstNumberValid = int.TryParse(inputFirstNumber, out firstNumber);
                firstNumber++;
                firstNumberTextBox.Text = firstNumber.ToString();
            }
            else if (plusButton == secondPlusButton)
            {
                bool isInputSecondNumberValid = int.TryParse(inputSecondNumber, out secondNumber);
                secondNumber++;
                secondNumberTextBox.Text = secondNumber.ToString();
            }
            else if (plusButton == thirdPlusButton)
            {
                bool isInputThirdNumberValid = int.TryParse(inputThirdNumber, out thirdNumber);
                thirdNumber++;
                thirdNumberTextBox.Text = thirdNumber.ToString();
            }
            else if (plusButton == fourthPlusButton)
            {
                bool isInputFourthNumberValid = int.TryParse(inputFourthNumber, out fourthNumber);
                fourthNumber++;
                fourthNumberTextBox.Text = fourthNumber.ToString();
            }
            else if (plusButton == fifthPlusButton)
            {
                bool isInputFifthNumberValid = int.TryParse(inputFifthNumber, out fifthNumber);
                fifthNumber++;
                fifthNumberTextBox.Text = fifthNumber.ToString();
            }
            else if (plusButton == sixthPlusButton)
            {
                bool isInputSixthNumberValid = int.TryParse(inputSixthNumber, out sixthNumber);
                sixthNumber++;
                sixthNumberTextBox.Text = sixthNumber.ToString();
            }
            else if (plusButton == seventhPlusButton)
            {
                bool isInputSeventhNumberValid = int.TryParse(inputSeventhNumber, out seventhNumber);
                seventhNumber++;
                seventhNumberTextBox.Text = seventhNumber.ToString();
            }
        }

        private void checkBox_CheckedOrUnchcked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox == firstExtraCheckBox)
            {
                if (firstExtraCheckBox.IsChecked == true)
                {
                    firstExtra = 1;
                }
                else if (firstExtraCheckBox.IsChecked == false)
                {
                    firstExtra = 0;
                }
            }
            else if (checkBox == secondExtraCheckBox)
            {
                if (secondExtraCheckBox.IsChecked == true)
                {
                    secondExtra = 1;
                }
                else if (secondExtraCheckBox.IsChecked == false)
                {
                    secondExtra = 0;
                }
            }
            else if (checkBox == thirdExtraCheckBox)
            {
                if (thirdExtraCheckBox.IsChecked == true)
                {
                    thirdExtra = 1;
                }
                else if (thirdExtraCheckBox.IsChecked == false)
                {
                    thirdExtra = 0;
                }
            }
            else if (checkBox == fourthExtraCheckBox)
            {
                if (fourthExtraCheckBox.IsChecked == true)
                {
                    fourthExtra = 1;
                }
                else if (fourthExtraCheckBox.IsChecked == false)
                {
                    fourthExtra = 0;
                }
            }
        }
    }
}