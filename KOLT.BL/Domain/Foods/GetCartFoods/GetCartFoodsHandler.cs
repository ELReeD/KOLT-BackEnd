using KOLT.DAL.Context;
using KOLT.DTO;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.GetCartFoods
{
    public class GetCartFoodsHandler : IRequestHandler<GetCartFoods, List<FoodDTO>>
    {
        private readonly KoltDbContext dbContext;

        public GetCartFoodsHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<FoodDTO>> Handle(GetCartFoods request, CancellationToken cancellationToken)
        {
            var cart = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.CartJSON);
            IEnumerable<FoodDTO> foods = 
                (IEnumerable<FoodDTO>)dbContext.Foods.Where(x => cart.ContainsKey(x.Id)).ToList();
            return (Task<List<FoodDTO>>)foods;
        }

    }
}
