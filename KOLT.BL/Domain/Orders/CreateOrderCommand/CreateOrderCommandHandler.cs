using KOLT.DAL.Context;
using KOLT.DAL.Model;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly KoltDbContext dbContext;

        public CreateOrderCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.Where(x => x.Id == request.SellerId).FirstOrDefault();
            var user = dbContext.Users.Where(x => x.UserName == request.UserName).FirstOrDefault();


            
            decimal finalCost = 0;  
            int foodTime = 0;

            List<OrderFood> orderFoods = new List<OrderFood>();

            foreach(var food in request.Foods)
            {
                var foodDb = dbContext.Foods.Where(x => x.Id == food.Key).FirstOrDefault();
                finalCost += Decimal.Parse(foodDb.Price);
                if(foodDb.CookingTime > foodTime)
                {
                    foodTime = foodDb.CookingTime;
                }
                var Orderfood = new OrderFood
                {
                    Food = foodDb,
                    FoodId = foodDb.Id,
                    Count = food.Value
                };
                orderFoods.Add(Orderfood);
                await dbContext.OrderFoods.AddAsync(Orderfood);
            }


            var order = new Order
            {         
                FinalCost = finalCost.ToString(),
                OrderFood = orderFoods,
                Send = false,
                Time = foodTime.ToString(),
                User = user,
                UserId = user.Id               
            };
            seller.Orders.Add(order);

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
