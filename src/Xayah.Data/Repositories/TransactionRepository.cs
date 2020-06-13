using System.Transactions;
using Xayah.Data.Interfaces;

namespace Xayah.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SqlServerContext context) : base(context)
        {
        }
    }
}
