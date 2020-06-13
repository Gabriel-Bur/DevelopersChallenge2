using Xayah.Data.Interfaces;
using Xayah.Domain.Entities;

namespace Xayah.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SqlServerContext context) : base(context)
        {
        }
    }
}
