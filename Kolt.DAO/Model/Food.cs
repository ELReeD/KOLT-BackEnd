using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model
{
    public class Food
    {

        public string Id{ get; set; }
        public string ImageUrl{ get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Ingridients { get; set; }
        public string Price { get; set; }
        public int CookingTime { get; set; }

        public string SellerID { get; set; }


        public void ChangeFood(
            string title, 
            string name, 
            string ingridients,
            string price, 
            int cookingTime)
        {
            Title = title;
            Name = name;
            Ingridients = ingridients;
            Price = price;
            CookingTime = cookingTime;
        }

    }
}
