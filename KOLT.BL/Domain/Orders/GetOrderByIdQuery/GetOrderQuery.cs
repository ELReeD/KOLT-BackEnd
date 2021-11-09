using KOLT.DAL.Model;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.GetOrderByIdQuery
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        [FromRoute]
        public string OrderId { get; set; }
    }
}
