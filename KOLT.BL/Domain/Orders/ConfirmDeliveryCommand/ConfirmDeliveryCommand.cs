using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.ConfirmDeliveryCommand
{
    public class ConfirmDeliveryCommand : IRequest
    {

        public string OrderId { get; set; }
    }
}
