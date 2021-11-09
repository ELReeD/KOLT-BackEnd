using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.User.LogoutCommand
{
    public class LogoutCommand : IRequest
    {
        [FromRoute]
        public string RefreshToken { get; set; }
    }
}
