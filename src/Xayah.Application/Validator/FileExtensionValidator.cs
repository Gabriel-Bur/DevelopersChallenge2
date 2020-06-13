using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Xayah.Application.Validator
{
    public class FileExtensionValidator : ValidationAttribute
    {
        public string ExpectedExtension { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var listOfFile = (IList<IFormFile>)value;

            foreach (var file in listOfFile)
            {
                string fileExtesion = Path.GetExtension(file.FileName);

                if (!fileExtesion.Equals(ExpectedExtension)) return false;
            }

            return true;
        }
    }
}
