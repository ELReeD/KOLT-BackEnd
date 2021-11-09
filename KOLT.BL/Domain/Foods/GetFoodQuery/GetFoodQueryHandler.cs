using KOLT.DAL.Context;
using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Foods.GetFoodQuery
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery,FoodDTO>
    {
        private readonly KoltDbContext dbContext;

        public GetFoodQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  Task<FoodDTO> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var food = dbContext.Foods.Where(x => x.Id == request.FoodId).FirstOrDefault();

            if (food == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            FoodDTO dto = new FoodDTO
            {
                Id = food.Id,
                CookingTime = food.CookingTime,
                Ingridients = food.Ingridients,
                Name = food.Name,
                Price = food.Price,
                Title = food.Title,
                ImageUrl = food.ImageUrl
            };

            return Task.FromResult(dto);
        }
    }
}
