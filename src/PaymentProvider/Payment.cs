﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProvider
{
    public class Payment
    {
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string Valuta { get; set; }
        public string PaymentReference { get; set; }
        public string OrderReference { get; set; }
    }
}
