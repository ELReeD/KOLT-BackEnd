using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using KOLT.DAL.Services;
using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.User.AuthorizationQuery
{
    public class AuthorizationQueryHandler : IRequestHandler<AuthorizationQuery,UserTokens>
    {
        private readonly KoltDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenGenerator tokenGenerator;

        public AuthorizationQueryHandler(
            KoltDbContext dbContext,
            UserManager<AppUser> userManager,
            ITokenGenerator tokenGenerator)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<UserTokens> Handle(AuthorizationQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Login);
            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                throw new Exception("Wrong Password!");

            var token = tokenGenerator.CreateJwtToken(user.UserName, user.Id);
            //вынести в отдельный Сервис
            ///TODO
            var refreshToken = new RefreshToken
            {
                Token = tokenGenerator.CreateRefreshToken(),
                AppUser = user,
                ExpiresAt = DateTime.Now + TimeSpan.FromDays(30),
                AppUserId = user.Id
            };

            var list = dbContext.RefreshTokens.Where(x => x.AppUserId == user.Id).ToList();
            dbContext.RefreshTokens.RemoveRange(list);

            await dbContext.RefreshTokens.AddAsync(refreshToken);
            await dbContext.SaveChangesAsync();


            var userTokens = new UserTokens
            {
                AccessToken = token,
                RefreshToken = refreshToken.Token,
                UserId = user.Id,
                UserName = request.Login
            };


            return userTokens;
        }
    }
}
