using System;
using System.ComponentModel.DataAnnotations;

namespace Xayah.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public long AccountId { get; set; }
        public long BankId { get; set; }
        public string TransactionCurrency { get; set; }
        public string TransactionType { get; set; }
        public DateTime TranscationDateTime { get; set; }
        public double TransactionAmmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
