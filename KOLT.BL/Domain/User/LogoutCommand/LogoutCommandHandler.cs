using KOLT.DAL.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KOLT.BL.Domain.User.LogoutCommand
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly KoltDbContext dbContext;

        public LogoutCommandHandler(KoltDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = dbContext.RefreshTokens.Find(request.RefreshToken);
            if (token == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            
            try
            {
                dbContext.RefreshTokens.Remove(token);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(msg);
            }

            return Unit.Value;
        }
    }
}
