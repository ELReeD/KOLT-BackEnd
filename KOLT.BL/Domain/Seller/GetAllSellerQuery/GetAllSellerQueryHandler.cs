using KOLT.DAL.Context;
using KOLT.DTO;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Seller.GetAllSellerQuery
{
    public class GetAllSellerQueryHandler : IRequestHandler<GetAllSellerQuery, IEnumerable<SellerDTO>>
    {
        private readonly KoltDbContext dbContext;

        public GetAllSellerQueryHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<SellerDTO>> Handle(GetAllSellerQuery request, CancellationToken cancellationToken)
        {
            var sellers = dbContext.Sellers.ToList();
            List<SellerDTO> sellersDTO = new List<SellerDTO>();

            foreach (var item in sellers)
            {
                sellersDTO.Add(new SellerDTO { 
                    Adress =item.Adress,
                    Id = item.Id,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Name =item.Name,
                    Number = item.Number,
                    Radius =item.Radius,
                    Rating = item.Rating,
                    ImageUrl = item.ImageUrl
                });
            }
            return Task.FromResult(sellersDTO.AsEnumerable());
        }
    }
}
