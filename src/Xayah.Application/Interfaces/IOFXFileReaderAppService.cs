using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Domain.Entities;

namespace Xayah.Application.Interfaces
{
    public interface IOFXFileReaderAppService
    {
        Task<IEnumerable<Transaction>> Convert(IEnumerable<Stream> fileStreams);
    }
}
