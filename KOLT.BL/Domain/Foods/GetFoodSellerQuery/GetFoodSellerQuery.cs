using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.GetFoodSellerQuery
{
    public class GetFoodSellerQuery : IRequest<IEnumerable<FoodDTO>>
    {
        public string SellerId{ get; set; }
    }
}
