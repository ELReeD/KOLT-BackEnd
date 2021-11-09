using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using KOLT.DTO.SellerSide;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.GetOrdersQuery
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<OrderDTO>>
    {
        private readonly KoltDbContext dbContext;
        private readonly UserManager<AppUser> userManager;

        public GetOrderQueryHandler(
            KoltDbContext dbContext,
            UserManager<AppUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public Task<IEnumerable<OrderDTO>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var user = dbContext.Users.Where(x => x.UserName == request.UserName).FirstOrDefault();
            var orders = dbContext.Sellers.Where(x => x.AppUserId == user.Id).Include(o=>o.Orders).FirstOrDefault();
            //var orders = dbContext.Sellers.Where(x => x.Id == seller.Id).Include(x=>x.Orders).FirstOrDefault();


            List<OrderDTO> ordersDto = new List<OrderDTO>();

            foreach (var item in orders.Orders)
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