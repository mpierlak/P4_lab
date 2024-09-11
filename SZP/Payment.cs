using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZP
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }


        public string DisplayText
        {
            get
            {
                return $"PaymentId: {PaymentId}, Description: {Description}, Amount: {Amount}, Date: {Date}, CustomerId: {CustomerId}";
            }
        }
    }

}
