using System;
using System.ComponentModel.DataAnnotations;

namespace Xayah.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        public int AccountId { get; set; }
        public int BankId { get; set; }
        public string TransactionCurrency { get; set; }
        public string TransactionType { get; set; }
        public DateTime TranscationDateTime { get; set; }
        public int TransactionAmmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
