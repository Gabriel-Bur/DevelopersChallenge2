using System.Collections.Generic;
using Xayah.Domain.Entities;

namespace Xayah.Application.Interfaces
{
    public interface IConciliationAppService
    {
        IEnumerable<Transaction> BeginConciliation(
            IEnumerable<Transaction> transactionsFromFiles,
            IEnumerable<Transaction> transactionsFromDatabase);
    }
}
