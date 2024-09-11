using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Windows;

namespace SZP
{
    public partial class App : Application
    {

        public static Customer _customer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            

            var connectionString = @"Data Source=DESKTOP-8OUDE05\SQLEXPRESS;Initial Catalog=SZP;Integrated Security=True";
            var paymentManager = new PaymentManager(connectionString);

            var loginWindow = new LoginWindow(paymentManager);

            loginWindow.ShowDialog();

            

        }
        
    }
}
