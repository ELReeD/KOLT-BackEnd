using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.ConfirmDeleviryCommand
{
    public class ConfirmSendCommand : IRequest
    {
        public string OrderId { get; set; }
    }
}
