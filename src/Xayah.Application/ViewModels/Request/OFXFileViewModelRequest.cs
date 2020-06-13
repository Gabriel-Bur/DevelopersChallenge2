using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Xayah.Application.Validator;

namespace Xayah.Application.ViewModels.Request
{
    public class OFXFileViewModelRequest
    {
        [FileExtensionValidator(ExpectedExtension = ".ofx",
            ErrorMessage = "Invalid file, only .ofx are allowed")]
        public IList<IFormFile> Files { get; set; }
    }
}
