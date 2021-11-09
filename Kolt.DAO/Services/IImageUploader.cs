using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KOLT.DAL.Services
{
    public interface IImageUploader
    {
        Task<string> Upload(IFormFile file);
    }
}
