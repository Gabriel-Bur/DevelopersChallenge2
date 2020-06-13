using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Domain.Entities;

namespace Xayah.Application.Services
{
    public class OFXFileReaderAppService : IOFXFileReaderAppService
    {

        public Task<IEnumerable<Transaction>> Convert(IEnumerable<Stream> fileStreams)
        {
            foreach (var fileStream in fileStreams)
            {
                ReadFile(fileStream);
            }

            return null;
        }

        private void ReadFile(Stream streamFile)
        {
            using (StreamReader fileReader = new StreamReader(streamFile))
            {
                var fullText = fileReader.ReadToEnd();
            }
        }

    }
}
