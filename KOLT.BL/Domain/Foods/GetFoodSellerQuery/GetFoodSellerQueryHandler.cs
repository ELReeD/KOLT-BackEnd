using KOLT.DAL.Context;
using KOLT.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Foods.GetFoodSellerQuery
{
    public class GetFoodSellerQueryHandler : IRequestHandler<GetFoodSellerQuery, IEnumerable<FoodDTO>>
    {
        private readonly KoltDbContext dbContext;

        public GetFoodSellerQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<IEnumerable<FoodDTO>> Handle(GetFoodSellerQuery request, CancellationToken cancellationToken)
        {
            var sellersFood = dbContext.Sellers.Where(x => x.Id == request.SellerId).Include(f => f.Foods).FirstOrDefault();


            List<FoodDTO> foodDTOs = new List<FoodDTO>();

            if (sellersFood.Foods == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(msg);
            }

            foreach (var food in sellersFood.Foods)
            {
                var fDto = new FoodDTO
                {
                    Id = food.Id,
                    CookingTime = food.CookingTime,
                    Ingridients = food.Ingridients,
                    Name = food.Name,
                    Price = food.Price,
                    Title = food.Title,
                    SellerId = request.SellerId,
                    ImageUrl = food.ImageUrl
                };

                foodDTOs.Add(fDto);
            }

            return Task.FromResult(foodDTOs.AsEnumerable());

          
        }
    }
}
