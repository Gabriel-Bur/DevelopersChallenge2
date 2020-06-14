using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public async Task<IList<Transaction>> ConvertOFXFileAsync(IList<Stream> fileStreams)
        {
            List<Transaction> transaction = new List<Transaction>();

            foreach (var file in fileStreams)
            {
                transaction.AddRange(await ReadStreamFileAsync(file));
            }

            return transaction;
        }

        private async Task<IList<Transaction>> ReadStreamFileAsync(Stream streamFile)
        {
            List<Transaction> transaction = new List<Transaction>();

            var fullText = await new StreamReader(streamFile).ReadToEndAsync();

            long accountId = long.Parse(ReadTransactionTag(fullText, AccountPattern));
            long bankId = long.Parse(ReadTransactionTag(fullText, BankPattern));
            string currency = ReadTransactionTag(fullText, CurrencyPattern);

            foreach (Match item in Regex.Matches(fullText, TransactionPattern))
            {
                double ammout = double.Parse(ReadTransactionTag(item.Value, TransactionAmmoutPattern));
                string type = ReadTransactionTag(item.Value, TransactionTypePattern).Trim();
                string description = ReadTransactionTag(item.Value, TransactionDescriptionPattern);
                DateTime dateTime = FormatTransactionDateTime(ReadTransactionTag(item.Value, TransactionDatePattern));

                transaction.Add(new Transaction()
                {
                    AccountId = accountId,
                    BankId = bankId,
                    TransactionCurrency = currency,
                    TransactionAmmount = ammout,
                    TransactionType = type,
                    TransactionDescription = description,
                    TranscationDateTime = dateTime,
                });
            }

            return transaction;
        }

        private string ReadTransactionTag(string text, string pattern)
        {
            var match = Regex.Match(text, pattern);

            return match.Value.Trim();
        }

        private DateTime FormatTransactionDateTime(string text)
        {
            string format = "yyyyMMddHHmmss";

            return DateTime.ParseExact(text, format, CultureInfo.InvariantCulture);
        }
    }
}
