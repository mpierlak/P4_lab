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
    /// Logika interakcji dla klasy EditPaymentWindow.xaml
    /// </summary>
    public partial class EditPaymentWindow : Window
    {
        private int _paymentId;
        private PaymentManager _paymentManager;
        internal Action<object, EventArgs> PaymentEdited;

        public EditPaymentWindow(int paymentId, PaymentManager paymentManager)
        {
            InitializeComponent();
            _paymentId = paymentId;
            _paymentManager = paymentManager;

            // Pobierz i ustaw listę płatności w ComboBox
            List<Payment> payments = _paymentManager.GetPaymentsForCustomer(App._customer.CustomerId);
            PaymentComboBox.ItemsSource = payments;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz wybraną płatność z ComboBox (pomiń pierwszą pozycję, bo to jest opcja pusta)
            Payment selectedPayment = PaymentComboBox.SelectedIndex > 0 ? PaymentComboBox.SelectedItem as Payment : null;

            // Sprawdź, czy płatność została wybrana
            if (selectedPayment == null)
            {
                MessageBox.Show("Proszę wybrać płatność do edycji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Pobierz dane wprowadzone przez użytkownika
            decimal newAmount;
            if (!decimal.TryParse(NewAmountTextBox.Text, out newAmount))
            {
                MessageBox.Show("Nieprawidłowa kwota płatności.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime newDate = NewDatePicker.SelectedDate ?? DateTime.Now;

            // Wywołaj metodę edycji płatności z PaymentManager
            _paymentManager.EditPayment(selectedPayment.PaymentId, newAmount, newDate);

            MessageBox.Show("Płatność została zaktualizowana pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            // Zamknij okno po zakończeniu edycji
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Zamknięcie okna po kliknięciu przycisku Anuluj
        }
    }
}
