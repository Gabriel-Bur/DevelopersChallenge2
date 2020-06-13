using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Application.ViewModels.Request;
using Xayah.Application.ViewModels.Response;
using Xayah.Data.Interfaces;

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
        public async Task<IEnumerable<TransactionViewModelResponse>> GetAllTransactions()
        {
            var transactionList = _mapper.Map<IEnumerable<TransactionViewModelResponse>>(
                await _transaction.GetAll());

            return transactionList;
        }

        public async Task SaveTransaction(OFXFileViewModelRequest OfxFileViewModelRequest)
        {
            List<Stream> ListOfFilesAsStream =
                new List<Stream>();

            foreach (var file in OfxFileViewModelRequest.Files)
            {
                ListOfFilesAsStream.Add(file.OpenReadStream());
            }

            await _ofxfilereader.Convert(ListOfFilesAsStream);


            //todo
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

    }
}
