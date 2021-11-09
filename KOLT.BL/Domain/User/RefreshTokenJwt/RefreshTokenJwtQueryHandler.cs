using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using KOLT.DAL.Services;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.User.RefreshTokenJwt
{
    public class RefreshTokenJwtQueryHandler : IRequestHandler<RefreshTokenJwtQuery, UserTokens>
    {
        private readonly KoltDbContext dbContext;
        private readonly ITokenGenerator tokenGenerator;

        public RefreshTokenJwtQueryHandler(
            KoltDbContext dbContext,
            ITokenGenerator tokenGenerator)
        {
            this.dbContext = dbContext;
            this.tokenGenerator = tokenGenerator;
        }
        public async Task<UserTokens> Handle(RefreshTokenJwtQuery request, CancellationToken cancellationToken)
        {
            var oldToken = dbContext.RefreshTokens.FirstOrDefault(x => x.Token == request.RefreshToken);
            var user = dbContext.Users.FirstOrDefault(x => x.Id == oldToken.AppUserId);

            if (oldToken == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(msg);
            }

            else if(oldToken!=null && oldToken.ExpiresAt < DateTime.Now)
            {
                dbContext.RefreshTokens.Remove(oldToken);
                await dbContext.SaveChangesAsync();

                var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(msg);
            }
            else
            {
                var newToken = new RefreshToken
                {
                    Token = tokenGenerator.CreateRefreshToken(),
                    AppUserId = oldToken.AppUserId,
                    ExpiresAt = DateTime.Now + TimeSpan.FromDays(30)
                };

                await dbContext.RefreshTokens.AddAsync(newToken);
                dbContext.RefreshTokens.Remove(oldToken);
                await dbContext.SaveChangesAsync();

                var userTokens = new UserTokens 
                { 
                    AccessToken = tokenGenerator.CreateJwtToken(user.Email, user.Id),
                    RefreshToken = newToken.Token,
                    UserId = user.Id,
                    UserName = user.Name
                };

                return userTokens;
            }

        }
    }
}
