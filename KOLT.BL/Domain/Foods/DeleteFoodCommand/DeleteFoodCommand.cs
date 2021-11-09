using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.DeleteFoodCommand
{
    public class DeleteFoodCommand : IRequest
    {
        [FromRoute]
        public string FoodId { get; set; }
    }
}
