using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Domain.Entities;

namespace Xayah.Application.Interfaces
{
    public interface IOFXFileReaderAppService
    {
        Task<IList<Transaction>> ReadOFXFileAsync(IList<IFormFile> files);
    }
}
