using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xayah.Domain.Entities;

namespace Xayah.Domain.Helpers
{
    public class TransactionComparator : IEqualityComparer<Transaction>
    {
        public bool Equals([AllowNull] Transaction x, [AllowNull] Transaction y)
        {
            //same object (Equals compares values, while == compares object references)
            if (x == y || x.Equals(y)) return true;

            //same transaction
            bool isEqual =
                x.AccountId.Equals(y.AccountId) &&
                x.TransactionType.Equals(y.TransactionType) &&
                x.TranscationDateTime.Equals(y.TranscationDateTime) &&
                x.TransactionAmmount.Equals(y.TransactionAmmount) &&
                x.TransactionDescription.Equals(y.TransactionDescription);

            return isEqual;
        }

        public int GetHashCode([DisallowNull] Transaction obj)
        {
            return obj.GetHashCode();
        }
    }
}
