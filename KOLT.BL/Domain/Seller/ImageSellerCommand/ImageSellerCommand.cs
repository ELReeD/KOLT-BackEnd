using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Seller.ImageSellerCommand
{
    public class ImageSellerCommand : IRequest
    {
        public IFormFile File { get; set; }
        public string SellerId { get; set; }
    }
}
