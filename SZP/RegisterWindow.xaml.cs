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
    public partial class RegisterWindow : Window
    {
        private PaymentManager _paymentManager;

        public RegisterWindow(PaymentManager paymentManager)
        {
            InitializeComponent();
            _paymentManager = paymentManager;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            bool success = _paymentManager.RegisterUser(username, password);

            if (success)
            {
                MessageBox.Show("Konto zostało pomyślnie utworzone.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(); // Zamknij okno rejestracji po udanej rejestracji
            }
            else
            {
                MessageBox.Show("Nie udało się utworzyć konta. Spróbuj ponownie.", "Błąd rejestracji", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

