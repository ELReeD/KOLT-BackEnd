using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.User.RefreshTokenJwt
{
    public class RefreshTokenJwtQuery : IRequest<UserTokens>
    {
        public string RefreshToken { get; set; }
    }
}
