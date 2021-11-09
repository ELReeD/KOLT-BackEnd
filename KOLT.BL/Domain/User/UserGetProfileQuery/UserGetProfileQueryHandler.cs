using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using KOLT.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.User.UserGetProfileQuery
{
    public class UserGetProfileQueryHandler : IRequestHandler<UserGetProfileQuery, UserDTO>
    {
        private readonly KoltDbContext dbContext;

        public UserGetProfileQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<UserDTO> Handle(UserGetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = dbContext.Users.Where(x => x.UserName == request.UserName).FirstOrDefault();
            if (user == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            var userDto = new UserDTO { 
                UserName = user.UserName,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Telephone = user.Telephone
            };

            return Task.FromResult(userDto);

        }
    }
}
