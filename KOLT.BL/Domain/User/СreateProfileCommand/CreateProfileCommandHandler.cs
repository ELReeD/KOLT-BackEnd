using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.User.СreateProfileCommand
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly KoltDbContext dbContext;

        public CreateProfileCommandHandler(
            UserManager<AppUser> userManager,
            KoltDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {

            var user = new AppUser { 
                Name = request.Name ,
                Surname = request.Surname,
                Telephone = request.Telephone,
                UserName = request.Email,
                Email = request.Email,
                RegistrationDateTime = DateTime.Now
            };

            var result = await userManager.CreateAsync(user,request.Password);

            if(!result.Succeeded)
                throw new Exception("Invalid Registration!");

            dbContext.Users.Add(user);

            return Unit.Value;
        }
    }
}
