using KOLT.DAL.Context;
using KOLT.DTO.SellerSide;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.GetUserOrderQuery
{
    public class GetUserOrderQueryHandler : IRequestHandler<GetUserOrderQuery, IEnumerable<OrderDTO>>
    {
        private readonly KoltDbContext dbContext;

        public GetUserOrderQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<IEnumerable<OrderDTO>> Handle(GetUserOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = dbContext.Orders.Where(x => x.UserId == request.UserId)
                    .Include(x => x.OrderFood).AsEnumerable();

            List<OrderDTO> ordersDto = new List<OrderDTO>();

            foreach (var item in orders)
            {
                OrderDTO order = new OrderDTO();
                order.Id = item.Id;
                order.Time = item.Time;
                order.FinalCost = item.FinalCost;
                order.UserId = item.UserId;
                order.Send = item.Send;
                order.DateTime = item.Date;
                order.Delivery = item.Delivery;

                ordersDto.Add(order);
            }

            return Task.FromResult(ordersDto.AsEnumerable());
        }
    }
}