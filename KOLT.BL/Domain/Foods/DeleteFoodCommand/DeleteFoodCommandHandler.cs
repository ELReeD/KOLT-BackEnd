using KOLT.DAL.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Foods.DeleteFoodCommand
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
    {
        private readonly KoltDbContext dbContext;

        public DeleteFoodCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = dbContext.Foods.Where(x => x.Id == request.FoodId).FirstOrDefault();
            if (food == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            try
            {
                dbContext.Foods.Remove(food);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new HttpResponseException(msg);
            }

            return Unit.Value;
        }
    }
}
