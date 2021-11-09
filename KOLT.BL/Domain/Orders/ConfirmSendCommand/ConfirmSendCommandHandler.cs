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

namespace KOLT.BL.Domain.Orders.ConfirmDeleviryCommand
{
    public class ConfirmSendCommandHandler : IRequestHandler<ConfirmSendCommand>
    {
        private readonly KoltDbContext dbContext;

        public ConfirmSendCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(ConfirmSendCommand request, CancellationToken cancellationToken)
        {
            var order = dbContext.Orders.Where(x => x.Id == request.OrderId).FirstOrDefault();
            if(order == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            order.Send = true;

            try
            {
                dbContext.Orders.Update(order);
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
