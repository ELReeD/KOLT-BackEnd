using KOLT.DAL.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Orders.CreateOrderCommand
{
    public class CreateOrderCommand :IRequest
    {
        public Dictionary<string,int> Foods { get; set; }   
        public string UserName { get; set; }
        public string SellerId { get; set; }
    }
}
