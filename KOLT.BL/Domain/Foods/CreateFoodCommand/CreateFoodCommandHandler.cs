using KOLT.DAL.Context;
using KOLT.DAL.Model;
using KOLT.DAL.Model.AuthModel;
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

namespace KOLT.BL.Domain.Foods.CreateFoodCommand
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand>
    {
        private readonly KoltDbContext dbContext;
        private readonly UserManager<AppUser> userManager;

        public CreateFoodCommandHandler(KoltDbContext dbContext,UserManager<AppUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.Where(x => x.Id == request.SellerId).FirstOrDefault();
            if (seller == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }


            Food food = new Food
            {
                Name = request.Name,
                CookingTime = request.CookingTime,
                ImageUrl = request.ImageUrl,
                Title = request.Title,
                Ingridients = request.Ingridients,
                Price = request.Price,
                SellerID = seller.Id
            };


            try
            {
                await dbContext.Foods.AddAsync(food);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            return Unit.Value;
        }
    }
}
