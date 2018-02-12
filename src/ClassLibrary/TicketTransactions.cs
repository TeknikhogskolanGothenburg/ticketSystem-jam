using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class TicketTransactions
    {
        int TransactionID { get; set; }
        string BuyerLastName { get; set; }
        string BuyerFirstName { get; set; }
        string BuyerAddress { get; set; }
        string BuyerCity { get; set; }
        string PaymentStatus { get; set; }
        string PaymentReferenceId { get; set; }
    }
}
