using KOLT.DAL.Context;
using KOLT.DAL.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Seller.ChangeSellerCommand
{
    public class ChangeSellerCommandHandler : IRequestHandler<ChangeSellerCommand>
    {
        private readonly KoltDbContext dbContext;
        private readonly IImageUploader imageUploader;

        public ChangeSellerCommandHandler(KoltDbContext dbContext,IImageUploader imageUploader)
        {
            this.dbContext = dbContext;
            this.imageUploader = imageUploader;
        }
        public async Task<Unit> Handle(ChangeSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.FirstOrDefault(x => x.Id == request.Id);

            if(seller == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            seller.UpdateSeller(
                request.Name,
                request.Adress,
                request.Number,
                request.Radius,"0","0");


            try
            {
                dbContext.Sellers.Update(seller);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception )
            {
                   var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                   throw new HttpResponseException(msg);
            }

            return Unit.Value;
        }
    }
}


/*
 using KOLT.DAL.Context;
using KOLT.DAL.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Seller.ChangeSellerCommand
{
    public class ChangeSellerCommandHandler : IRequestHandler<ChangeSellerCommand>
    {
        private readonly KoltDbContext dbContext;

        public ChangeSellerCommandHandler(KoltDbContext dbContext,IImageUploader imageUploader)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(ChangeSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = dbContext.Sellers.FirstOrDefault(x => x.Id == request.Id);

            if(seller == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            seller.UpdateSeller(
                request.Name, 
                request.Adress, 
                request.Noomber,
                request.Radius,
                request.Latitude,
                request.Longitude);

            try
            {
                dbContext.Sellers.Update(seller);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            return Unit.Value;
        }
    }
}

 
 */