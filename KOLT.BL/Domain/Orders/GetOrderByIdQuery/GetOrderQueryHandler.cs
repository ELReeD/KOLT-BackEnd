using KOLT.DAL.Context;
using KOLT.DAL.Model;
using KOLT.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Orders.GetOrderByIdQuery
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly KoltDbContext dbContext;

        public GetOrderByIdQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = dbContext.Orders.Where(x => x.Id == request.OrderId).Include(of=>of.OrderFood).FirstOrDefault();

            if (order == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            return Task.FromResult(order);
        }
    }
}
