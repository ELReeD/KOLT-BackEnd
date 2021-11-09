using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DTO
{
    public class FoodDTO
    {

        public string Id{ get; set; }
        public string SellerId { get; set; }
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public string Ingridients { get; set; }
        public string Price { get; set; }
        public int CookingTime { get; set; }



    }
}
