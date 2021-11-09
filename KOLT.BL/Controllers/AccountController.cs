using KOLT.BL.Domain.User.AuthorizationQuery;
using KOLT.BL.Domain.User.LogoutCommand;
using KOLT.BL.Domain.User.RefreshTokenJwt;
using KOLT.BL.Domain.User.UserGetProfileQuery;
using KOLT.BL.Domain.User.СreateProfileCommand;
using KOLT.DAL.Context;
using KOLT.DAL.Model;
using KOLT.DAL.Model.AuthModel;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KOLT.BL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Registartaion")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Registartion(CreateProfileCommand command)
        {
            
            try
            {
                await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Login(AuthorizationQuery query)
        {
            UserTokens tokens = new UserTokens();
            
            try
            {
                tokens = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

            return Ok(tokens);
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserTokens>> Refresh(RefreshTokenJwtQuery query)
        {
            UserTokens tokens = new UserTokens();
            try
            {
                tokens = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

            return Ok(tokens);
        }


        [Authorize]
        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfileAsync()
        {
            UserGetProfileQuery query = new UserGetProfileQuery();
            query.UserName = User.Identity.Name;   
            
            try
            {
                var user = await mediator.Send(query);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("logout/{RefreshToken}")]
        public IActionResult Logout([FromRoute]LogoutCommand command)
        {
            try
            {
                mediator.Send(command);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
