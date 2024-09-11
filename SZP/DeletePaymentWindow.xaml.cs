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
    /// Logika interakcji dla klasy DeletePaymentWindow.xaml
    /// </summary>
    public partial class DeletePaymentWindow : Window
    {
        // Zdefiniuj właściwość przechowującą identyfikator zaznaczonej płatności
        public int SelectedPaymentId { get; private set; }

        // Zdefiniuj właściwość informującą, czy płatność została usunięta
        public bool PaymentDeleted { get; private set; }

        private PaymentManager _paymentManager;

        public DeletePaymentWindow(PaymentManager paymentManager)
        {
            InitializeComponent();
            _paymentManager = paymentManager;

            // Pobierz i wyświetl płatności w DataGrid
            RefreshPayments();
        }

        private void RefreshPayments()
        {
            PaymentDataGrid.ItemsSource = _paymentManager.GetPaymentsForCustomer(App._customer.CustomerId);
        }

        private void DeletePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz identyfikator zaznaczonej płatności
            int paymentId = GetSelectedPaymentId();

            // Usuń płatność
            _paymentManager.DeletePayment(paymentId);

            // Odśwież wyświetlanie płatności
            RefreshPayments();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Ustaw właściwość PaymentDeleted na true, aby oznaczyć, że płatność została usunięta
            PaymentDeleted = true;

            // Zamknij okno
            Close();
        }


        // Metoda do pobrania identyfikatora zaznaczonej płatności z kontrolki DataGrid
        private int GetSelectedPaymentId()
        {
            // Sprawdź, czy zaznaczono element
            if (PaymentDataGrid.SelectedItem != null)
            {
                // Pobierz zaznaczoną płatność z kontrolki DataGrid
                Payment selectedPayment = (Payment)PaymentDataGrid.SelectedItem;
                return selectedPayment.PaymentId;
            }
            else
            {
                MessageBox.Show("Wybierz płatność do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return -1; // Zwróć -1, jeśli nie ma zaznaczonej płatności
            }
        }
    }

}
