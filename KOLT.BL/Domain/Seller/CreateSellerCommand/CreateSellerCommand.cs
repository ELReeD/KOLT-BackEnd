using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KOLT.DAL.Model;
using KOLT.DTO;
using Microsoft.AspNetCore.Http;

namespace KOLT.BL.Domain.Seller.CreateSellerCommand
{
    public class CreateSellerCommand : SellerDTO, IRequest
    {
        public string UserLogin { get; set; }

    }
}
