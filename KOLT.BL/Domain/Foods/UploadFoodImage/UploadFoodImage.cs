using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.UploadFoodImage
{
    public class UploadFoodImage : IRequest
    {
        public IFormFile File { get; set; }
        public string FoodId { get; set; }
    }
}
