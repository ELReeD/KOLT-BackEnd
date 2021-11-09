using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DTO.SellerSide
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public string Time { get; set; }
        public string FinalCost { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Send { get; set; }
        public bool Delivery { get; set; }
    }
}
