using System.Collections.Generic;
using Xayah.Application.Interfaces;
using Xayah.Domain.Entities;
using Xayah.Domain.Extensions;

namespace Xayah.Application.Services
{
    public class ConciliationAppService : IConciliationAppService
    {
        public IEnumerable<Transaction> BeginConciliation(
            IEnumerable<Transaction> transactionsFromFiles,
            IEnumerable<Transaction> transactionsFromDatabase)
        {
            //remove incoming duplicated transactions from file
            IEnumerable<Transaction> transactions = transactionsFromFiles.RemoveDuplicated();

            //remove duplicated if already exist in database
            return transactions.RemoveDuplicated(transactionsFromDatabase);
        }
    }
}
