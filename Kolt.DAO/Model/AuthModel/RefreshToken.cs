using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.AuthModel
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public string AppUserId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public AppUser AppUser { get; set; }
    }
}
