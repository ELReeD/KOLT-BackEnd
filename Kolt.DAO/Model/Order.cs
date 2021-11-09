using KOLT.DAL.Model.AuthModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model
{
    public class Order
    {
        public string Id { get; set; }
        public string Time { get; set; }        
        public string FinalCost { get; set; }
        public string UserId { get; set; }
        public bool Send { get; set; } = false;
        public bool Delivery { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
        public List<OrderFood> OrderFood { get; set; } 

        public AppUser User{ get; set; }        

        public void ChangeSend()
        {
            if (!this.Send)
            {
                this.Send = true;
            }
        }

        
    }
}
