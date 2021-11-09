using KOLT.DAL.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Services
{
    public class ImageUploader : IImageUploader
    {
        public async Task<string> Upload(IFormFile file)
        {
             var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
             var path = $"wwwroot/Images/{fileName}";

             using (var fs = new FileStream(path, FileMode.CreateNew))
             {
                 await file.CopyToAsync(fs);
             }
             return fileName;
        }
    }
}
