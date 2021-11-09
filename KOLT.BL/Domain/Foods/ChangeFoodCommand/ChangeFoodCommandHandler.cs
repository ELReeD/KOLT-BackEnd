using KOLT.DAL.Context;
using KOLT.DAL.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.Foods.ChangeFoodCommand
{
    public class ChangeFoodCommandHandler : IRequestHandler<ChangeFoodCommand>
    {
        private readonly KoltDbContext dbContext;

        public ChangeFoodCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(ChangeFoodCommand request, CancellationToken cancellationToken)
        {
            var food = dbContext.Foods.Where(x => x.Id == request.Id).FirstOrDefault();
            if(food==null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            food.ChangeFood(
                request.Title, 
                request.Name,
                request.Ingridients,
                request.Price,
                request.CookingTime);

            try
            {
                dbContext.Foods.Update(food);
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
