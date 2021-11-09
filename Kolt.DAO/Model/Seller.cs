using KOLT.DAL.Model.AuthModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model
{
    public class Seller
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public int Radius { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public float Rating { get; set; }

        public DateTime RegistrationDateTime { get; set; }
        public List<Food> Foods { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public void UpdateSeller(
          string Name,
          string Adress,
          string Number,
          int Radius,
          string Longitude,
          string Latitude)
        {
            this.Name = Name;
            this.Adress = Adress;
            this.Number = Number;
            this.Radius = Radius;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        public void UpdateImage(string ImageUrl)
        {
            this.ImageUrl = ImageUrl;
        }
    }
}
