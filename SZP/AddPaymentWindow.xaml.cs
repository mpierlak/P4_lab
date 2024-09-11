using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SZP
{
    /// <summary>
    /// Logika interakcji dla klasy AddPaymentWindow.xaml
    /// </summary>
    public partial class AddPaymentWindow : Window
    {
        private PaymentManager _paymentManager;

        public AddPaymentWindow(PaymentManager paymentManager)
        {
            InitializeComponent();
            _paymentManager = paymentManager;
            
        }

        private void AddPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz dane wprowadzone przez użytkownika
            decimal amount;
            if (!decimal.TryParse(AmountTextBox.Text, out amount))
            {
                MessageBox.Show("Nieprawidłowa kwota płatności.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime date = DatePicker.SelectedDate ?? DateTime.Now;


            // Utwórz obiekt Payment na podstawie wprowadzonych danych
            var payment = new Payment
            {
                Amount = amount,
                Date = date,
                CustomerId = App._customer.CustomerId
                 // Zastąp 'currentCustomerId' rzeczywistym identyfikatorem klienta
            };


            // Wywołaj metodę dodawania płatności z PaymentManager
            _paymentManager.AddPayment(payment);

            MessageBox.Show("Płatność została dodana pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            // Zamknij okno AddPaymentWindow po dodaniu płatności
            Close();
        }
    }

}
