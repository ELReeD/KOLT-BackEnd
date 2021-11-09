using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Seller.GetSellerQuery
{
    public class GetSellerQuery : IRequest<SellerDTO>
    {
        [FromRoute]
        public string SellerId { get; set; }
    }
}
