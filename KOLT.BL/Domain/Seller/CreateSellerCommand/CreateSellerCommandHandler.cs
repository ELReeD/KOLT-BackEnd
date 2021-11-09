using KOLT.DAL.Context;
using KOLT.DAL.Model.AuthModel;
using KOLT.DAL.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Seller.CreateSellerCommand
{
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand>
    {
        private readonly KoltDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IImageUploader imageService;

        public CreateSellerCommandHandler(KoltDbContext dbContext,UserManager<AppUser> userManager , IImageUploader imageService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.imageService = imageService;
        }

        public async Task<Unit> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == request.UserLogin);
            if (user == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }


            var seller = new DAL.Model.Seller
            {
                Adress = request.Adress,
                Name = request.Name,
                Number = request.Number,
                Latitude = "0",
                Longitude = "0",               
                Radius = request.Radius,
                Rating = 5,
                RegistrationDateTime = DateTime.Now,
                AppUser = user,
            };


            try
            {
                await dbContext.Sellers.AddAsync(seller);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }
          


            return Unit.Value;
        }
    }
}
