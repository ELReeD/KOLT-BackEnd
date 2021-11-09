using KOLT.DAL.Model.AuthModel;
using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.User.UserGetProfileQuery
{
    public class UserGetProfileQuery : IRequest<UserDTO>
    {
        public string UserName { get; set; }
    }
}
