using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SZP
{
    public partial class MainWindow : Window
    {
        private PaymentManager _paymentManager;

        // Konstruktor bezparametrowy
        public MainWindow()
        {
            InitializeComponent();
            // Tutaj możesz zainicjować _paymentManager, jeśli to konieczne
        }

        // Konstruktor z przekazaniem PaymentManager
        public MainWindow(PaymentManager paymentManager) : this()
        {
            _paymentManager = paymentManager;
            RefreshLoggedInUser(); // Aktualizuj nazwę zalogowanego użytkownika
        }

        private void AddPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentWindow addPaymentWindow = new AddPaymentWindow(_paymentManager);
            addPaymentWindow.ShowDialog();
        }


        private void EditPaymentWindow_PaymentEdited(object sender, EventArgs e)
        {
            // Odśwież listę płatności po edycji
            RefreshPayments();
        }

        private void EditPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz identyfikator zaznaczonej płatności
            int selectedPaymentId = GetSelectedPaymentId();

            if (selectedPaymentId == -1)
            {
                MessageBox.Show("Proszę wybrać płatność do edycji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Utwórz nowe okno edycji płatności i przekaż identyfikator oraz PaymentManager
            EditPaymentWindow editPaymentWindow = new EditPaymentWindow(selectedPaymentId, _paymentManager);

            // Obsłuż zdarzenie po zakończeniu edycji płatności
            editPaymentWindow.PaymentEdited += EditPaymentWindow_PaymentEdited;

            // Wyświetl okno edycji płatności
            editPaymentWindow.ShowDialog();
        }

        private void RefreshPayments()
        {
            // Tutaj dodaj kod do odświeżania tabeli płatności
            // Ta metoda będzie wywoływana, gdy chcesz odświeżyć widok płatności w interfejsie użytkownika
        }

        private int GetSelectedPaymentId()
        {
            // Tutaj dodaj kod do pobrania identyfikatora zaznaczonej płatności z tabeli lub innego kontrolki interfejsu użytkownika
            // Ta metoda będzie używana do pobrania identyfikatora zaznaczonej płatności, na przykład z tabeli
            return 0; // Tutaj zwróć domyślną wartość, gdy metoda nie jest jeszcze zaimplementowana
        }


        private void DeletePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno DeletePaymentWindow
            DeletePaymentWindow deletePaymentWindow = new DeletePaymentWindow(_paymentManager);
            deletePaymentWindow.ShowDialog();

            // Sprawdź, czy płatność została usunięta w oknie DeletePaymentWindow
            if (deletePaymentWindow.PaymentDeleted)
            {
                // Pobierz identyfikator zaznaczonej płatności z okna DeletePaymentWindow
                int paymentIdToDelete = deletePaymentWindow.SelectedPaymentId;

                // Usuń płatność za pomocą PaymentManager
                _paymentManager.DeletePayment(paymentIdToDelete);

                // Aktualizuj wyświetlanie płatności w MainWindow
                // Tutaj możesz dodać kod do odświeżenia danych w tabeli lub innej kontrolce
            }
        }


        private void ShowPaymentsWindow(List<Payment> payments)
        {
            // Utwórz nowe okno z wyświetleniem szczegółów płatności
            ViewPaymentsWindow viewPaymentsWindow = new ViewPaymentsWindow(payments);
            viewPaymentsWindow.ShowDialog();
        }

        private void ViewPaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz wszystkie płatności dla bieżącego klienta
            List<Payment> payments = _paymentManager.GetPaymentsForCustomer(App._customer.CustomerId);

            // Wywołaj funkcję wyświetlającą okno płatności, przekazując listę płatności
            ShowPaymentsWindow(payments);
        }
        private void RefreshLoggedInUser()
        {

        }
    }
}