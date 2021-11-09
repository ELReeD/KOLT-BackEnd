using KOLT.DAL.Context;
using KOLT.DAL.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Foods.UploadFoodImage
{
    public class UploadFoodImageHandler : IRequestHandler<UploadFoodImage>
    {
        private readonly KoltDbContext dbContext;
        private readonly IImageUploader imageService;

        public UploadFoodImageHandler(KoltDbContext dbContext,IImageUploader imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }
        public async Task<Unit> Handle(UploadFoodImage request, CancellationToken cancellationToken)
        {
            var imagePath = await imageService.Upload(request.File);
            var food = dbContext.Foods.Where(x => x.Id == request.FoodId).FirstOrDefault();
            food.ImageUrl = imagePath;
            await dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
