using KOLT.BL.Domain.Foods.CreateFoodCommand;
using KOLT.BL.Domain.Foods.GetFoodSellerQuery;
using KOLT.BL.Domain.Seller.ChangeSellerCommand;
using KOLT.BL.Domain.Seller.CreateSellerCommand;
using KOLT.BL.Domain.Seller.GetAllSellerQuery;
using KOLT.BL.Domain.Seller.GetCurrentSeller;
using KOLT.BL.Domain.Seller.GetSellerQuery;
using KOLT.BL.Domain.Seller.ImageSellerCommand;
using KOLT.DAL.Context;
using KOLT.DAL.Services;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class SellerController : ControllerBase
    {
        private readonly IMediator mediator;

        public SellerController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Registration(CreateSellerCommand command)
        {
            command.UserLogin = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Change(ChangeSellerCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }       

        [HttpGet("GetAllSeller")]
        public async Task<IEnumerable<SellerDTO>> GetAllSeller()
        {
            return await mediator.Send(new GetAllSellerQuery());            
        }

        [HttpGet("{SellerId}")]
        public async Task<IActionResult> Information ([FromRoute]GetSellerQuery query)
        {
            var seller = await mediator.Send(query);
            return Ok(seller);
        }



        //SellerSide

        [HttpGet("SellersFood/{SellerId}")]
        public async Task<IActionResult> GetFoodBySellerId([FromRoute] GetFoodSellerQuery query)
        {
            var food = await mediator.Send(query);
            return Ok(food);
        }

        [HttpGet("SellerSide/{UserId}")]
        [Authorize]
        public async Task<IActionResult> GetCurrentSeller([FromRoute]GetCurrentSellerQuery query)
        {
            var seller = await mediator.Send(query);
            return Ok(seller);
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm]ImageSellerCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }

}
