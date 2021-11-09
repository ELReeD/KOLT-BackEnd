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

namespace KOLT.BL.Domain.Seller.GetSellerQuery
{
    public class GetSellerQueryHandler : IRequestHandler<GetSellerQuery, SellerDTO>
    {
        private readonly KoltDbContext dbContext;

        public GetSellerQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<SellerDTO> Handle(GetSellerQuery request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.Where(x => x.Id == request.SellerId).FirstOrDefault();
            if(seller == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            var sellerDto = new SellerDTO 
            { 
                Id = seller.Id,
                Adress = seller.Adress,
                Latitude = seller.Latitude,
                Longitude = seller.Longitude,
                Name = seller.Name,
                Number = seller.Name,
                Radius = seller.Radius,
                Rating = seller.Rating
            };

            return Task.FromResult(sellerDto);
        }
    }
}
