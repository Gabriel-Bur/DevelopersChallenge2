using System;
using System.ComponentModel.DataAnnotations;

namespace Xayah.Application.ViewModels.Response
{
    public class TransactionViewModelResponse
    {
        public Guid Id { get; set; }
        public long BankId { get; set; }
        public long AccountId { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public double Ammount { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

    }
}
