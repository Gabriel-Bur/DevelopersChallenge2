using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Domain.Entities;

namespace Xayah.Application.Interfaces
{
    public interface IOFXFileReaderAppService
    {
        Task<IList<Transaction>> ConvertOFXFileAsync(IList<Stream> fileStreams);
    }
}
