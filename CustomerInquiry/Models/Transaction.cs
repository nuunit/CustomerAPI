using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public enum TransactionStatus
    {
        Success,
        Failed,
        Canceled
    }
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
      
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }
    }
}