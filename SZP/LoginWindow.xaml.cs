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
    public partial class LoginWindow : Window
    {
        private PaymentManager _paymentManager;

        public LoginWindow(PaymentManager paymentManager)
        {
            InitializeComponent();
            _paymentManager = paymentManager;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            int customerId = _paymentManager.AuthenticateUser(username, password);

            if (customerId != -1)
            {
                MainWindow mainWindow = new MainWindow(_paymentManager);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(_paymentManager);
            registerWindow.Show();
            // Usunięcie zamknięcia okna po otwarciu okna rejestracji
            // Close();
        }
    }
}