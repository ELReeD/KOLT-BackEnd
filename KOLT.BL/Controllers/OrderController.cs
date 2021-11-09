using KOLT.BL.Domain.Orders.ConfirmDeleviryCommand;
using KOLT.BL.Domain.Orders.ConfirmDeliveryCommand;
using KOLT.BL.Domain.Orders.CreateOrderCommand;
using KOLT.BL.Domain.Orders.GetOrderByIdQuery;
using KOLT.BL.Domain.Orders.GetOrdersQuery;
using KOLT.BL.Domain.Orders.GetUserOrderQuery;
using KOLT.DAL.Context;
using KOLT.DTO.SellerSide;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly KoltDbContext dbContext;

        public OrderController(IMediator mediator, KoltDbContext dbContext)
        {
            this.mediator = mediator;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderCommand command)
        {
            command.UserName = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }


        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute]GetOrderByIdQuery query)
        {
             var order = await mediator.Send(query);
             return Ok(order);
        }

        [HttpGet("SellerOrders")]
        public async Task<IEnumerable<OrderDTO>> GetSellerOrders()
        {
            GetOrderQuery query = new GetOrderQuery { 
                UserName = User.Identity.Name
            };
            var test = await mediator.Send(query);
            return test;
        }

        [HttpGet("UserOrders/{UserId}")]
        public async Task<IEnumerable<OrderDTO>> GetUserOrders([FromRoute]GetUserOrderQuery query)
        {
            return await mediator.Send(query);
        }



        [HttpPost("ConfirmSend")]
        public async Task<IActionResult> ConfirmDeleviryAsync(ConfirmSendCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost("ConfirmDeliviry")]
        public async Task<IActionResult> ConfirmDeleviryAsync(ConfirmDeliveryCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }


}
