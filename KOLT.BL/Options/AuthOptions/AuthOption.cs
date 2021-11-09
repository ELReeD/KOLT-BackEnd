using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOLT.BL.Options.AuthOptions
{
    public class AuthOption
    {
        public const string ISSUER = "ELReeDCinemaAuth"; // издатель токена
        public const string AUDIENCE = "ELReedCinema"; // потребитель токена
        const string KEY = "fa887bb6-bc1f-41d8-9427-2d166f3f9886";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
