using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Seller.GetCurrentSeller
{
    public class GetCurrentSellerQuery : IRequest<SellerDTO>
    {
        [FromRoute]
        public string UserId { get; set; }
    }
}
