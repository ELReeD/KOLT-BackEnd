using KOLT.DAL.Model;
using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.CreateFoodCommand
{
    public class CreateFoodCommand : FoodDTO,IRequest
    {
        public string  Login { get; set; }
    }
}
