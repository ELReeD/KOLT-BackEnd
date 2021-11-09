using System;
using System.Collections.Generic;
using System.Text;

namespace KOLT.DAL.Services
{
    public interface ITokenGenerator
    {
        public string CreateJwtToken(string userName, string id);
        public string CreateRefreshToken();

    }
}
