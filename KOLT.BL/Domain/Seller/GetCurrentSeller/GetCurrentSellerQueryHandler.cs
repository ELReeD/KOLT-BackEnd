using KOLT.DAL.Context;
using KOLT.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Seller.GetCurrentSeller
{
    public class GetCurrentSellerQueryHandler : IRequestHandler<GetCurrentSellerQuery,SellerDTO>
    {
        private readonly KoltDbContext dbContext;

        public GetCurrentSellerQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<SellerDTO> Handle(GetCurrentSellerQuery request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.Where(x=>x.AppUserId == request.UserId).FirstOrDefault();

            if (seller == null)
            {
                return null;
            }

            var sellerDto = new SellerDTO
            {
                Id = seller.Id,
                Adress = seller.Adress,
                ImageUrl = seller.ImageUrl,
                Latitude = seller.Latitude,
                Longitude = seller.Longitude,
                Name = seller.Name,
                Number = seller.Number,
                Radius = seller.Radius,
                Rating = seller.Rating
            };

            return Task.FromResult(sellerDto);
        }

        public string UserID(string UserName)
        {
            return dbContext.Users.Where(x => x.UserName == UserName).FirstOrDefault().Id;
        }
    }
}
