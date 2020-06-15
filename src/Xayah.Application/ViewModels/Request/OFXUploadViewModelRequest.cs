using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Xayah.Application.CustomAttribute;

namespace Xayah.Application.ViewModels.Request
{
    public class OFXUploadViewModelRequest
    {
        [FileExtensionValidationAttribute(ExpectedExtension = ".ofx",
            ErrorMessage = "Invalid file, only .ofx are allowed")]
        public IList<IFormFile> Files { get; set; }
    }
}
