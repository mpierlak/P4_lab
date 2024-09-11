using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace SZP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentManager
    {
        private readonly PaymentContext _context;

        public PaymentManager(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _context = new PaymentContext(optionsBuilder.Options);
        }

        public List<Payment> GetPaymentsForCustomer(int customerId)
        {
            return _context.Payment.Where(p => p.CustomerId == customerId).ToList();
        }

        public void AddPayment(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();
        }

        public void EditPayment(int paymentId, decimal newAmount, DateTime newDate)
        {
            var payment = _context.Payment.Find(paymentId);
            if (payment != null)
            {
                payment.Amount = newAmount;
                payment.Date = newDate;
                _context.SaveChanges();
            }
        }

        public void DeletePayment(int paymentId)
        {
            var payment = _context.Payment.Find(paymentId);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
                _context.SaveChanges();
            }
        }
        public int AuthenticateUser(string username, string password)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Username == username && c.Password == password);
            App._customer = customer;
            return customer != null ? customer.CustomerId : -1;
        }

        public bool RegisterUser(string username, string password)
        {
            // Sprawdź, czy istnieje już użytkownik o podanej nazwie
            var existingUser = _context.Customer.FirstOrDefault(c => c.Username == username);
            if (existingUser != null)
            {
                return false; // Użytkownik już istnieje
            }

            // Dodaj nowego użytkownika
            _context.Customer.Add(new Customer { Username = username, Password = password });
            _context.SaveChanges();
            return true; // Rejestracja zakończona sukcesem
        }
    }
}