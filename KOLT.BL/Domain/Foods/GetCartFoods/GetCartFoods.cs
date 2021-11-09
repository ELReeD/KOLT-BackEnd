using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.GetCartFoods
{
    public class GetCartFoods : IRequest<List<FoodDTO>>
    {
        public string CartJSON { get; set; }
    }
}
