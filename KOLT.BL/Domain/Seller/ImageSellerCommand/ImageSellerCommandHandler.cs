using KOLT.DAL.Context;
using KOLT.DAL.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Seller.ImageSellerCommand
{
    public class ImageSellerCommandHandler : IRequestHandler<ImageSellerCommand>
    {
        private readonly KoltDbContext dbContext;
        private readonly IImageUploader imageService;

        public ImageSellerCommandHandler(KoltDbContext dbContext, IImageUploader imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }
        public async Task<Unit> Handle(ImageSellerCommand request, CancellationToken cancellationToken)
        {
            var imagePath = await imageService.Upload(request.File);

            var seller = dbContext.Sellers.Where(x => x.Id == request.SellerId).FirstOrDefault();

            seller.ImageUrl = imagePath;

            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
