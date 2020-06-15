using System;
using System.ComponentModel.DataAnnotations;

namespace Xayah.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; private set; }
        public long AccountId { get; private set; }
        public long BankId { get; private set; }
        public string TransactionCurrency { get; private set; }
        public string TransactionType { get; private set; }
        public DateTime TranscationDateTime { get; private set; }
        public decimal TransactionAmmount { get; private set; }
        public string TransactionDescription { get; private set; }

        public Transaction(Guid id, long accountId, long bankId,
            string currency, string type, DateTime dateTime,
            decimal ammout, string description)
        {
            this.Id = id;
            this.AccountId = accountId;
            this.BankId = bankId;
            this.TransactionCurrency = currency;
            this.TransactionType = type;
            this.TranscationDateTime = dateTime;
            this.TransactionAmmount = ammout;
            this.TransactionDescription = description;
        }

        protected Transaction() { }

    }
}
