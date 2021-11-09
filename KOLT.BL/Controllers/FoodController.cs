using KOLT.BL.Domain.Foods.ChangeFoodCommand;
using KOLT.BL.Domain.Foods.CreateFoodCommand;
using KOLT.BL.Domain.Foods.DeleteFoodCommand;
using KOLT.BL.Domain.Foods.GetCartFoods;
using KOLT.BL.Domain.Foods.GetFoodQuery;
using KOLT.BL.Domain.Foods.GetFoodSellerQuery;
using KOLT.BL.Domain.Foods.UploadFoodImage;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KOLT.BL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IMediator mediator;

        public FoodController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddFood(CreateFoodCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeFood(ChangeFoodCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }


        [HttpGet("{FoodId}")]
        public async Task<IActionResult> GetFoodById([FromRoute]GetFoodQuery query)
        {
            var food = await mediator.Send(query);
            return Ok(food);            
        }

        [HttpGet("SellersFood/{SellerId}")]
        public async Task<IActionResult> GetFoodBySellerId([FromRoute] GetFoodSellerQuery query)
        {
            var food = await mediator.Send(query);
            return Ok(food);
        }

        [HttpDelete("{FoodId}")]
        public async Task<IActionResult> DeleteFood([FromRoute]DeleteFoodCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] UploadFoodImage foodImage)
        {
            await mediator.Send(foodImage);
            return Ok();
        }
    }
}
