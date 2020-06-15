using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xayah.Domain.Entities;

namespace Xayah.Domain.Helpers
{
    public class TransactionComparer : IEqualityComparer<Transaction>
    {
        public bool Equals([AllowNull] Transaction x, [AllowNull] Transaction y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //same transaction
            bool isEqual =
                x.TransactionType == y.TransactionType &&
                x.TranscationDateTime == y.TranscationDateTime &&
                x.TransactionAmmount == y.TransactionAmmount &&
                x.TransactionDescription == y.TransactionDescription;

            return isEqual;
        }

        public int GetHashCode([DisallowNull] Transaction obj)
        { 
            if(ReferenceEquals(obj, null)) return 0;

            int typehash = obj.TransactionType == null ? 0 : obj.TransactionType.GetHashCode();
            int descriptionhash = obj.TransactionDescription == null ? 0 : obj.TransactionType.GetHashCode();
            int datehash = obj.TranscationDateTime == null ? 0 : obj.TranscationDateTime.GetHashCode();
            int ammounthash = obj.TransactionAmmount.GetHashCode();

            return typehash ^ descriptionhash ^ datehash ^ ammounthash;
        }
    }
}
