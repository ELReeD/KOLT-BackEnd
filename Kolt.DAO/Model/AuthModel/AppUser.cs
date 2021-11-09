using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Model.AuthModel
{
    public class AppUser : IdentityUser
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public float Rating { get; set; }
        public DateTime RegistrationDateTime{ get; set; }
    }
}
