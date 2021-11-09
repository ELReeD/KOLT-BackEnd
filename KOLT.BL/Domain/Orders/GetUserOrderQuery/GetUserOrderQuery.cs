using KOLT.DTO.SellerSide;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.GetUserOrderQuery
{
    public class GetUserOrderQuery : IRequest<IEnumerable<OrderDTO>>
    {
        [FromRoute]
        public string UserId { get; set; }
    }
}
