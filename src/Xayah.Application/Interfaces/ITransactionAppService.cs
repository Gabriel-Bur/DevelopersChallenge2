using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Application.ViewModels.Request;
using Xayah.Application.ViewModels.Response;

namespace Xayah.Application.Interfaces
{
    public interface ITransactionAppService
    {
        Task<TransactionViewModelResponse> GetById(Guid Id);
        Task<IEnumerable<TransactionViewModelResponse>> GetAllTransactions();
        Task SaveTransaction(OFXFileViewModelRequest OfxFileViewModelRequest);
    }
}
