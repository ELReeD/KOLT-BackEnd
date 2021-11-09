using KOLT.DAL.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.ConfirmDeliveryCommand
{
    public class ConfirmDeliveryCommandHandler : IRequestHandler<ConfirmDeliveryCommand>
    {
        private readonly KoltDbContext dbContext;

        public ConfirmDeliveryCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Unit> Handle(ConfirmDeliveryCommand request, CancellationToken cancellationToken)
        {
            var order = dbContext.Orders.Where(x => x.Id == request.OrderId).FirstOrDefault();
            order.Delivery = true;
            dbContext.Orders.Update(order);
            dbContext.SaveChanges();
            return Unit.Task;
        }
    }
}
