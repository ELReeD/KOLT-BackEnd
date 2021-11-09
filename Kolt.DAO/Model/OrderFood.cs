using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model
{
    public class OrderFood
    {
        public string Id { get; set; }
        public string FoodId { get; set; }
        public Food Food { get; set; }
        public int Count { get; set; }
    }
}
