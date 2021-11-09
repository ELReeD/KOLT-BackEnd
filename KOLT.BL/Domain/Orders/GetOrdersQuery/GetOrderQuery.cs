using KOLT.DTO.SellerSide;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.GetOrdersQuery
{
    public class GetOrderQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public string UserName { get; set; }
    }
}
