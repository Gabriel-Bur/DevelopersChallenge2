using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Application.ViewModels.Request;
using Xayah.Application.ViewModels.Response;
using Xayah.Data.Interfaces;
using Xayah.Domain.Entities;

namespace Xayah.Application.Services
{
    public class TransactionAppService : IDisposable, ITransactionAppService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transaction;
        private readonly IOFXFileReaderAppService _ofxfilereader;
        public TransactionAppService(
            IMapper mapper,
            ITransactionRepository transaction,
            IOFXFileReaderAppService ofxfilereader)
        {
            _mapper = mapper;
            _transaction = transaction;
            _ofxfilereader = ofxfilereader;
        }

        public async Task<TransactionViewModelResponse> GetById(Guid Id)
        {
            var transaction = _mapper.Map<TransactionViewModelResponse>(
                await _transaction.GetById(Id));

            return transaction;
        }
        public async Task<IList<TransactionViewModelResponse>> GetAllTransactions()
        {
            var transactionList = _mapper.Map<IList<TransactionViewModelResponse>>(
                await _transaction.GetAll());

            return transactionList;
        }

        public async Task BeginConciliation(OFXFileViewModelRequest OfxFileViewModelRequest)
        {
            IList<Transaction> ListOfTransactions = await
                ReadAndConvert(OfxFileViewModelRequest);

            await SaveTransaction(ListOfTransactions);

        }

        private async Task<IList<Transaction>> ReadAndConvert(OFXFileViewModelRequest OfxFileViewModelRequest)
        {
            List<Stream> ListOfFilesAsStream = new List<Stream>();

            foreach (var file in OfxFileViewModelRequest.Files)
            {
                ListOfFilesAsStream.Add(file.OpenReadStream());
            }

            return await _ofxfilereader.ConvertOFXFileAsync(ListOfFilesAsStream);
        }
        private async Task SaveTransaction(IList<Transaction> transactionsToSave)
        {
            await _transaction.InsertRange(transactionsToSave);
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
