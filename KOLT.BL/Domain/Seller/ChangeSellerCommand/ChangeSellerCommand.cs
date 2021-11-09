using KOLT.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOLT.BL.Domain.Seller.ChangeSellerCommand
{
    public class ChangeSellerCommand : SellerDTO,IRequest
    {
       
    }
}
