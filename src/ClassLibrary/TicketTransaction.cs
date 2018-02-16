using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary
{
    public class TicketTransaction
    {
        public int TransactionID { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerCity { get; set; }
        public string BuyerEmail { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentReferenceId { get; set; }
    }
}
