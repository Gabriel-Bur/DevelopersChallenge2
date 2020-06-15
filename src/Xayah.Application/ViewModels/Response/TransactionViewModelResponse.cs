using System;
using System.ComponentModel.DataAnnotations;

namespace Xayah.Application.ViewModels.Response
{
    public class TransactionViewModelResponse
    {
        public Guid Id { get; set; }

        [Display(Name = "Bank Code")]
        public long BankId { get; set; }

        [Display(Name = "Account Code")]
        public long AccountId { get; set; }

        public string Currency { get; set; }

        [Display(Name = "Operation")]
        public string Type { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
    }
}
