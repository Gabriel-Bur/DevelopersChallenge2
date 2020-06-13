using System;

namespace Xayah.Application.ViewModels.Response
{
    public class TransactionViewModelResponse
    {
        public Guid Id { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string Ammount { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

    }
}
