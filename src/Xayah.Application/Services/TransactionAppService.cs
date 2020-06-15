using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Application.ViewModels.Request;
using Xayah.Application.ViewModels.Response;
using Xayah.Data.Interfaces;
using Xayah.Domain.Entities;

namespace Xayah.Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IOFXFileReaderAppService _ofxfilereader;
        private readonly IConciliationAppService _conciliation;

        public TransactionAppService(
            IMapper mapper,
            ITransactionRepository transactionRepository,
            IOFXFileReaderAppService ofxfilereader,
            IConciliationAppService conciliation)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _conciliation = conciliation;
            _ofxfilereader = ofxfilereader;
        }

        public async Task<TransactionViewModelResponse> GetById(Guid Id)
        {
            return _mapper.Map<TransactionViewModelResponse>(
                await _transactionRepository.GetById(Id));
        }

        public async Task<IList<TransactionViewModelResponse>> GetAllTransactions()
        {
            return _mapper.Map<IList<TransactionViewModelResponse>>(
                await _transactionRepository.GetAll());
        }

        public async Task UploadOFXFiles(OFXUploadViewModelRequest OfxFileViewModelRequest)
        {
            //Read file(s) content and transform into a list of transactions
            IEnumerable<Transaction> transactionsToVerify = await _ofxfilereader
                .ReadOFXFileAsync(OfxFileViewModelRequest.Files);

            //retrieve all transactions save in database
            IEnumerable<Transaction> transactionsFromBase =
                await _transactionRepository.GetAll();

            //remove duplicated transactions inside the list + database
            IEnumerable<Transaction> transactionsToSave =
                _conciliation.BeginConciliation(transactionsToVerify, transactionsFromBase);

            await _transactionRepository.InsertRange(transactionsToSave);
        }

    }
}
