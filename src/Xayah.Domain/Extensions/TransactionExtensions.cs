using System.Collections.Generic;
using System.Linq;
using Xayah.Domain.Entities;
using Xayah.Domain.Helpers;

namespace Xayah.Domain.Extensions
{
    public static class TransactionExtensions
    {
        public static IEnumerable<Transaction> RemoveDuplicated(this IEnumerable<Transaction> transactionsA, IEnumerable<Transaction> transactionsB)
        {
            return transactionsA.Except(transactionsB, new TransactionComparer());
        }

        public static IEnumerable<Transaction> RemoveDuplicated(this IEnumerable<Transaction> transactions)
        {
            return transactions.Distinct(new TransactionComparer());
        }
    }
}
