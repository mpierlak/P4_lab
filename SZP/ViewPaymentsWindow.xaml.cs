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
    /// Logika interakcji dla klasy ViewPaymentsWindow.xaml
    /// </summary>
    public partial class ViewPaymentsWindow : Window
    {
        private List<Payment> _payments;

        public ViewPaymentsWindow(List<Payment> payments)
        {
            InitializeComponent();
            _payments = payments;

            // Wyświetl płatności w oknie
            foreach (var payment in _payments)
            {
                // Utwórz nowy kontroler ListBoxItem
                ListBoxItem item = new ListBoxItem();

                // Ustaw zawartość kontrolera ListBoxItem na szczegóły płatności
                item.Content = $"PaymentId: {payment.PaymentId}, Description: {payment.Description}, Amount: {payment.Amount}, Date: {payment.Date}, CustomerId: {payment.CustomerId}";

                // Dodaj kontroler ListBoxItem do listy
                PaymentListBox.Items.Add(item);
            }
        }
    }
}
