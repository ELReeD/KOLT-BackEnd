using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.GetFoodQuery
{
    public class GetFoodQuery : IRequest<FoodDTO>
    {
        [FromRoute]
        public string FoodId { get; set; }
    }
}
