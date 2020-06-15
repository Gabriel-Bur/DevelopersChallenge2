using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Domain.Entities;

namespace Xayah.Application.Services
{
    public class OFXFileReaderAppService : IOFXFileReaderAppService
    {
        private const string AccountPattern = @"(?<=<ACCTID>)([\s\S]{10})";
        private const string BankPattern = @"(?<=<BANKID>)([\s\S]{04})";
        private const string CurrencyPattern = @"(?<=<CURDEF>)([A-Z]{3})";
        private const string TransactionPattern = @"<TRNTYPE>[\s\S]*?(?=\n.*?<\/STMTTRN>|$)";
        private const string TransactionTypePattern = @"(?<=<TRNTYPE>)([\s\S]{5,6})";
        private const string TransactionDatePattern = @"(?<=<DTPOSTED>)([\s\S]{14})";
        private const string TransactionAmmoutPattern = @"(?<=<TRNAMT>)(-?[.0-9]*\d+)";
        private const string TransactionDescriptionPattern = @"(?<=<MEMO>)([\d\w-\s\/.])+";


        public async Task<IList<Transaction>> ReadOFXFileAsync(IList<IFormFile> files)
        {
            var ListOfTransactions = new List<Transaction>();

            foreach (var file in files)
            {
                Stream streamFile = file.OpenReadStream();
                ListOfTransactions.AddRange(await ReadStreamFileAsync(streamFile));
            }

            return ListOfTransactions;
        }

        private async Task<IList<Transaction>> ReadStreamFileAsync(Stream streamFile)
        {
            var transaction = new List<Transaction>();

            using (var streamReader = new StreamReader(streamFile))
            {
                string text = await streamReader.ReadToEndAsync();

                long accountId = long.Parse(ReadTransactionTag(text, AccountPattern));
                long bankId = long.Parse(ReadTransactionTag(text, BankPattern));
                string currency = ReadTransactionTag(text, CurrencyPattern);

                foreach (Match item in Regex.Matches(text, TransactionPattern))
                {
                    decimal ammout = decimal.Parse(ReadTransactionTag(item.Value, TransactionAmmoutPattern), CultureInfo.InvariantCulture);
                    string type = ReadTransactionTag(item.Value, TransactionTypePattern).Trim();
                    string description = ReadTransactionTag(item.Value, TransactionDescriptionPattern);
                    DateTime dateTime = FormatTransactionDateTime(ReadTransactionTag(item.Value, TransactionDatePattern));

                    transaction.Add(
                        new Transaction(Guid.NewGuid(), accountId, bankId, currency, type, dateTime, ammout, description));
                }
            }

            return transaction;
        }

        private string ReadTransactionTag(string text, string pattern)
        {
            Match match = Regex.Match(text, pattern);

            return match.Value.Trim();
        }

        private DateTime FormatTransactionDateTime(string text)
        {
            var format = "yyyyMMddHHmmss";

            return DateTime.ParseExact(text, format, CultureInfo.InvariantCulture);
        }
    }
}
